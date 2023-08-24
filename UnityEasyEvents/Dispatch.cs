using System;

namespace UnityEasyEvents {
  /// <summary>
  /// A base class for an event dispatcher that contains some minor convenience reflection for instantiating fields.
  /// Realistically this isn't any easier than just instantiating the fields yourself, but the attributes provide some
  /// inherent documentation anyways, and enforce some consistency among dispatchers.
  /// </summary>
  public abstract class Dispatch {
    protected Dispatch() {
      foreach (var propertyInfo in GetType().GetProperties()) {
        if (Attribute.GetCustomAttribute(propertyInfo, typeof(EasyEventAttribute)) != null) {
          var ctor = propertyInfo.PropertyType.GetConstructor(Type.EmptyTypes);
          if (ctor != null && propertyInfo.CanWrite) {
            propertyInfo.SetValue(this, ctor.Invoke(Array.Empty<object>()));
          }
        }
      }
    }
  }
}