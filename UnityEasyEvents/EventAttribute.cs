using System;

namespace UnityEasyEvents {
  /// <summary>
  /// An attribute that tags event fields and allows for easy and automatic instantiation.
  /// </summary>
  [AttributeUsage(AttributeTargets.Property)]
  public class EasyEventAttribute : Attribute { }
}