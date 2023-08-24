using UnityEasyEvents;
using UnityEasyEvents.Events;

namespace UnityEasyEventsTest.Helpers {
  public class TestDispatch : Dispatch {
    [EasyEvent] public readonly GameEvent<string> EventOne;
  }
}