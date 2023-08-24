// A collection of GameEvents that take generics to represent the payloads a dispatched event contains.
namespace UnityEasyEvents.Events {
  public class GameEvent : BaseGameEvent<GameEvent.OnEventRaised> {
    public delegate void OnEventRaised();

    public void Raise() {
      ForEachListener(listener => listener.Invoke());
    }
  }

  public class GameEvent<T1> : BaseGameEvent<GameEvent<T1>.OnEventRaised> {
    public delegate void OnEventRaised(T1 param);

    public void Raise(T1 param) {
      ForEachListener(listener => listener.Invoke(param));
    }
  }
  
  public class GameEvent<T1, T2> : BaseGameEvent<GameEvent<T1, T2>.OnEventRaised> {
    public delegate void OnEventRaised(T1 param1, T2 param2);

    public void Raise(T1 param1, T2 param2) {
      ForEachListener(listener => listener.Invoke(param1, param2));
    }
  }
  
  public class GameEvent<T1, T2, T3> : BaseGameEvent<GameEvent<T1, T2, T3>.OnEventRaised> {
    public delegate void OnEventRaised(T1 param1, T2 param2, T3 param3);

    public void Raise(T1 param1, T2 param2, T3 param3) {
      ForEachListener(listener => listener.Invoke(param1, param2, param3));
    }
  }
  
  public class GameEvent<T1, T2, T3, T4> : BaseGameEvent<GameEvent<T1, T2, T3, T4>.OnEventRaised> {
    public delegate void OnEventRaised(T1 param1, T2 param2, T3 param3, T4 param4);

    public void Raise(T1 param1, T2 param2, T3 param3, T4 param4) {
      ForEachListener(listener => listener.Invoke(param1, param2, param3, param4));
    }
  }
}