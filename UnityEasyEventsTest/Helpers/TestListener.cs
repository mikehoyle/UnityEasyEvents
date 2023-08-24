using System.Collections.Generic;
using UnityEasyEvents.Events;

namespace UnityEasyEventsTest.Helpers {
  public class TestListener<T> {
    public List<T> ReceivedEvents { get; } = new();

    private void ReceiveEvent(T payload) {
      ReceivedEvents.Add(payload);
    }

    public void RegisterForEvent(GameEvent<T> gameEvent) {
      gameEvent.AddListener(ReceiveEvent);
    }
    
    public void UnregisterForEvent(GameEvent<T> gameEvent) {
      gameEvent.RemoveListener(ReceiveEvent);
    }
  }
}