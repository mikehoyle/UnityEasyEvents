# UnityEasyEvents
A simple, strongly typed Event manager and dispatcher for Unity projects.

Each event manages its own listeners and lifecycle.

Advantages over other Unity event systems:
 - Doesn't use string event names, which can easily lead to typos and hard-to-find bugs.
 - Doesn't key events on ScriptableObjects as suggested in [this](https://www.youtube.com/watch?v=raQ3iHhE_Kk)
   popular talk, which is great for a company with non-developers, but overly-cumbersome for a solo developer.

Example usage:

```
public class MyDispatch : Dispatch {
    [EasyEvent] public GameEvent<string, int> OnThingHappening { get; private set; }
    [EasyEvent] public GameEvent<CustomPayload> OnOtherThingHappening { get; private set; }
}

-----------------------------------------------------------

public class ExampleMonoBehavior : MonoBehaviour {
    private void Awake() {
        // Use AddScopedListener to ensure we only get a callback when this component is active and enabled.
        EasyEvents.Get<MyDispatch>().OnThingHappening.AddScopedListener(HandleThingHappening, this);
    }
    
    private void HandleThingHappening(string thingName, int thingAmount) {
        // Handle event however you like here.
    }
    
    private void Update() {
        if (/* something */) {
            EasyEvents.Get<MyDispatch>().OnOtherThingHappening.Raise(new CustomPayload("hello"));
        }
    }
}
```