using JourneyDescription.Models.Base;

namespace JourneyDescription.Models
{
    public class FlightBoardingPass : GenericBoardingPass 
    {
        public string? BagageInfo { get; init; }
        public string? GateNumber { get; init; }

    }
}
