using System;
using System.Reflection;

namespace UnityEasyEvents {
  /// <summary>
  /// A base class for an event dispatcher that contains some minor convenience reflection for instantiating fields.
  /// Realistically this isn't any easier than just instantiating the fields yourself, but the attributes provide some
  /// inherent documentation anyways, and enforce some consistency among dispatchers.
  /// </summary>
  public abstract class Dispatch {
    protected Dispatch() {
      foreach (var fieldInfo in GetType().GetFields(BindingFlags.Instance | BindingFlags.Public)) {
        if (Attribute.GetCustomAttribute(fieldInfo, typeof(EasyEventAttribute)) != null) {
          var ctor = fieldInfo.FieldType.GetConstructor(Type.EmptyTypes);
          if (ctor != null) {
            fieldInfo.SetValue(this, ctor.Invoke(Array.Empty<object>()));
          }
        }
      }
    }
  }
}