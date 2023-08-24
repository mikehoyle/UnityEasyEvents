using System;
using UnityEngine;

namespace UnityEasyEvents.Listeners {
  public class ScopedEventListener<T> : EventListener<T> where T: Delegate {
    private readonly Behaviour _scope;
    private readonly bool _onlyWhenEnabled;

    public ScopedEventListener(T callback, Behaviour scope, bool onlyWhenEnabled) : base(callback) {
      _scope = scope;
      _onlyWhenEnabled = onlyWhenEnabled;
    }

    public override bool IsCurrentlyListening() {
      if (_onlyWhenEnabled) {
        return _scope.isActiveAndEnabled;
      }
      return _scope.gameObject.activeSelf;
    }

    public override bool IsDestroyed() {
      // Unity overrides null checks by checking the existence of the underlying engine
      // object
      return _scope == null;
    }
  }
}