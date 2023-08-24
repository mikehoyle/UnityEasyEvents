using System;
using System.Collections;
using System.Collections.Generic;
using UnityEasyEvents.Listeners;
using UnityEngine;

namespace UnityEasyEvents.Events {
  /// <summary>
  /// The base event class from which all raise-able events inherit. Events can be registered with listeners, and
  /// dispatch custom data payloads.
  ///
  /// Each event is instantiated and manages its own listeners. To be easily called, events should likely be made
  /// available somewhere globally, such as a singleton event manager.
  ///
  /// TODO: proactively clear null objects on scene load via SceneManager.sceneLoaded?
  /// </summary>
  public abstract class BaseGameEvent<T> where T : Delegate {
    private readonly List<EventListener<T>> _listeners = new();

    /// <summary>
    /// Adds a listener. NOTE: This listener is persistent until removed, even across scenes. If not
    /// manually removed, it could cause strange behavior, calling methods for objects that are destroyed.
    /// </summary>
    public void AddListener(T listener) {
      _listeners.Add(new EventListener<T>(listener));
    }

    /// <summary>
    /// Remove a previously-added listener (including ScopedListeners).
    /// </summary>
    public void RemoveListener(T listener) {
      _listeners.Remove(new EventListener<T>(listener));
    }

    /// <summary>
    /// Adds a listener that is scoped to a Unity Behaviour. This means the listener will only be called when the
    /// underlying GameObject is active (and optionally only when the Behaviour is enabled),
    /// and will automatically be removed when the Behaviour is destroyed.
    /// </summary>
    public void AddScopedListener(T listener, Behaviour scope, bool onlyWhenEnabled = true) {
      _listeners.Add(new ScopedEventListener<T>(listener, scope, onlyWhenEnabled));
    }

    protected void ForEachListener(Action<T> listenerAction) {
      for (int i = _listeners.Count - 1; i >= 0; i--) {
        if (_listeners[i].IsDestroyed()) {
          _listeners.RemoveAt(i);
          continue;
        }
        if (_listeners[i].IsCurrentlyListening()) {
          listenerAction(_listeners[i].Callback);
        }
      }
    }

    protected IEnumerator ForEachListenerSync(Func<T, IEnumerator> listenerAction) {
      for (int i = _listeners.Count - 1; i >= 0; i--) {
        if (_listeners[i].IsDestroyed()) {
          _listeners.RemoveAt(i);
          continue;
        }
        if (_listeners[i].IsCurrentlyListening()) {
          yield return listenerAction(_listeners[i].Callback);
        }
      }
    }
  }
}