namespace JourneyDescription.Models.Base
{
    public class GenericBoardingPass
    {
        public string? TransporationId { get; init; }
        public string TransporationType { get; init; } = default!;
        public string StartingPoint { get; init; } = default!;
        public string DestinationPoint { get; init; } = default!;
        public string? SeatNumber { get; init; }


    }
}
