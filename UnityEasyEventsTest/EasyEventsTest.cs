using NUnit.Framework;
using UnityEasyEvents;
using UnityEasyEventsTest.Helpers;

namespace UnityEasyEventsTest {
  /// <summary>
  /// Static singletons are notoriously hard to test (one reason why they have such a bad reputation), so
  /// we just include a single test for our simple singleton to avoid any persistent state issues.
  /// </summary>
  [TestFixture]
  public class EasyEventsTest {
    [Test]
    public void UseEasyEventsInterface() {
      var listener = new TestListener<string>();
      listener.RegisterForEvent(EasyEvents.Get<TestDispatch>().EventOne);
      EasyEvents.Get<TestDispatch>().EventOne.Raise("hello");
      
      Assert.AreEqual(listener.ReceivedEvents.Count, 1);
      Assert.AreEqual(listener.ReceivedEvents[0], "hello");
    }
  }
}