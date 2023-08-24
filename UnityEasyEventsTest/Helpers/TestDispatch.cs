using UnityEasyEvents;
using UnityEasyEvents.Events;

namespace UnityEasyEventsTest.Helpers {
  public class TestDispatch : Dispatch {
    [EasyEvent] public GameEvent<string> EventOne { get; private set; }
  }
}