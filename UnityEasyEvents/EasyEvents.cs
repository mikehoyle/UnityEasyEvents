namespace UnityEasyEvents {
  public static class EasyEvents {
    private static class DispatchRegister<T> where T : Dispatch, new() {
      public static T Instance = new T();
    }
    
    public static T Get<T>() where T : Dispatch, new() {
      return DispatchRegister<T>.Instance;
    }
 
    public static void Reset<T>() where T : Dispatch, new() {
      DispatchRegister<T>.Instance = null;
    }
  }
}