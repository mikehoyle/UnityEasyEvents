using NUnit.Framework;
using UnityEasyEventsTest.Helpers;

namespace UnityEasyEventsTest {
  [TestFixture]
  public class DispatchTest {
    [Test]
    public void NoEvent() {
      var listener = new TestListener<string>();
      var dispatch = new TestEventDispatch();
      listener.RegisterForEvent(dispatch.EventOne);

      Assert.AreEqual(listener.ReceivedEvents.Count, 0);
    }
    
    
    [Test]
    public void MultipleEvents() {
      var listener = new TestListener<string>();
      var dispatch = new TestEventDispatch();
      listener.RegisterForEvent(dispatch.EventOne);
      
      dispatch.EventOne.Raise("hello");

      Assert.AreEqual(listener.ReceivedEvents.Count, 1);
      Assert.AreEqual(listener.ReceivedEvents[0], "hello");
      
      dispatch.EventOne.Raise("abc");
      dispatch.EventOne.Raise("def");
      
      Assert.AreEqual(listener.ReceivedEvents.Count, 3);
      Assert.AreEqual(listener.ReceivedEvents[0], "hello");
      Assert.AreEqual(listener.ReceivedEvents[1], "abc");
      Assert.AreEqual(listener.ReceivedEvents[2], "def");
    }
    
    [Test]
    public void Unsubscribe() {
      var listener = new TestListener<string>();
      var dispatch = new TestEventDispatch();
      listener.RegisterForEvent(dispatch.EventOne);
      
      dispatch.EventOne.Raise("hello");

      listener.UnregisterForEvent(dispatch.EventOne);
      
      dispatch.EventOne.Raise("abc");
      dispatch.EventOne.Raise("def");
      
      Assert.AreEqual(listener.ReceivedEvents.Count, 1);
      Assert.AreEqual(listener.ReceivedEvents[0], "hello");
    }
    
    [Test]
    public void MultipleListeners() {
      var listener1 = new TestListener<string>();
      var listener2 = new TestListener<string>();
      var listener3 = new TestListener<string>();
      var dispatch = new TestEventDispatch();
      listener1.RegisterForEvent(dispatch.EventOne);
      listener2.RegisterForEvent(dispatch.EventOne);
      listener3.RegisterForEvent(dispatch.EventOne);
      
      dispatch.EventOne.Raise("hello");
      
      listener1.UnregisterForEvent(dispatch.EventOne);
      listener3.UnregisterForEvent(dispatch.EventOne);
      
      dispatch.EventOne.Raise("abc");
      dispatch.EventOne.Raise("def");
      
      

      Assert.AreEqual(listener1.ReceivedEvents.Count, 1);
      Assert.AreEqual(listener1.ReceivedEvents[0], "hello");
      
      Assert.AreEqual(listener2.ReceivedEvents.Count, 3);
      Assert.AreEqual(listener2.ReceivedEvents[0], "hello");
      Assert.AreEqual(listener2.ReceivedEvents[1], "abc");
      Assert.AreEqual(listener2.ReceivedEvents[2], "def");
        
      Assert.AreEqual(listener3.ReceivedEvents.Count, 1);
      Assert.AreEqual(listener3.ReceivedEvents[0], "hello");
    }
  }
}