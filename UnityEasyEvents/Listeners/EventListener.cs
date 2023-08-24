using System;

namespace UnityEasyEvents.Listeners {
  /// <summary>
  /// Encapsulates a listener to an event.
  /// </summary>
  public class EventListener<T> where T : Delegate {
    public T Callback { get; }
    
    public EventListener(T callback) {
      Callback = callback;
    }

    public virtual bool IsCurrentlyListening() => true;

    public virtual bool IsDestroyed() => false;
    
    
    public override bool Equals(object obj) {
      return obj != null && obj.GetType() == GetType() && Callback.Equals(((EventListener<T>)obj).Callback);
    }

    public override int GetHashCode() {
      return Callback.GetHashCode();
    }
  }
}