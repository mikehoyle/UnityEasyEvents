using UnityEasyEvents;
using UnityEasyEvents.Events;

namespace UnityEasyEventsTest.Helpers {
  public class TestEventDispatch : EventDispatch<TestEventDispatch> {
    [EasyEvent] public readonly GameEvent<string> EventOne;
  }
}