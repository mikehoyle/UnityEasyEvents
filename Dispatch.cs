using System;

/// <summary>
/// Holds all static event objects for easy global access.
/// </summary>
public static class Dispatch<T> {
  private static readonly Lazy<EncounterEvents> EncounterEvents = new(() => new EncounterEvents());
  public static EncounterEvents Encounters => EncounterEvents.Value;
  
  private static readonly Lazy<ShipBuilderEvents> ShipBuilderEvents = new(() => new ShipBuilderEvents());
  public static ShipBuilderEvents ShipBuilder => ShipBuilderEvents.Value;
  
  private static readonly Lazy<CommonEvents> CommonEvents = new(() => new CommonEvents());
  public static CommonEvents Common => CommonEvents.Value;
}