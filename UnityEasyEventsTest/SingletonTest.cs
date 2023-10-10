using NUnit.Framework;
using UnityEasyEventsTest.Helpers;

namespace UnityEasyEventsTest {
  /// <summary>
  /// Static singletons are notoriously hard to test (one reason why they have such a bad reputation), so
  /// we just include a single test for our simple singleton to avoid any persistent state issues.
  /// </summary>
  [TestFixture]
  public class SingletonTest {
    [Test]
    public void UseSingletonInterface() {
      var listener = new TestListener<string>();
      listener.RegisterForEvent(TestEventDispatch.Get().EventOne);
      TestEventDispatch.Get().EventOne.Raise("hello");
      
      Assert.AreEqual(listener.ReceivedEvents.Count, 1);
      Assert.AreEqual(listener.ReceivedEvents[0], "hello");
    }
  }
}