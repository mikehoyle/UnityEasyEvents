using System.Collections;
using UnityEngine;

// Similar to typical GameEvents, but utilizes Coroutines to ensure event listeners finish running their handler
// before another handler is called.
namespace UnityEasyEvents.Events {
  public class SynchronousGameEvent : BaseGameEvent<SynchronousGameEvent.OnEventRaised> {
    public delegate IEnumerator OnEventRaised();

    public void Raise(MonoBehaviour runner) {
      runner.StartCoroutine(ForEachListenerSync(listener => listener.Invoke()));
    }
  }

  public class SynchronousGameEvent<T1> : BaseGameEvent<SynchronousGameEvent<T1>.OnEventRaised> {
    public delegate IEnumerator OnEventRaised(T1 param);

    public void Raise(MonoBehaviour runner, T1 param) {
      runner.StartCoroutine(ForEachListenerSync(listener => listener.Invoke(param)));
    }
  }

  public class SynchronousGameEvent<T1, T2> : BaseGameEvent<SynchronousGameEvent<T1, T2>.OnEventRaised> {
    public delegate IEnumerator OnEventRaised(T1 param1, T2 param2);

    public void Raise(MonoBehaviour runner, T1 param1, T2 param2) {
      runner.StartCoroutine(ForEachListenerSync(listener => listener.Invoke(param1, param2)));
    }
  }

  public class SynchronousGameEvent<T1, T2, T3> : BaseGameEvent<SynchronousGameEvent<T1, T2, T3>.OnEventRaised> {
    public delegate IEnumerator OnEventRaised(T1 param1, T2 param2, T3 param3);

    public void Raise(MonoBehaviour runner, T1 param1, T2 param2, T3 param3) {
      runner.StartCoroutine(ForEachListenerSync(listener => listener.Invoke(param1, param2, param3)));
    }
  }
}