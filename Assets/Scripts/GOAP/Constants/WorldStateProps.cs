public static class WorldStateProps {
    public const string AvailableBeds = "freeBeds";
    public const string AvailableSeats = "freeSeats";
    public const string AvailableArenaSlotsA = "freeArenaSlotsA";
    public const string AvailableArenaSlotsB = "freeArenaSlotsB";

    // Indicates there's at least one warrior KOed in arena
    public const string DefeatedWarriorsInArena = "defeatedWarriorsInArena";

    // Indicates there's at least one warrior waiting to be healed
    public const string WarriorsAwaitingTreatment = "warriorsAwaitingTreatment";
}
