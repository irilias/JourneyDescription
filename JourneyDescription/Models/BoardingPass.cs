namespace JourneyDescription.Models
{
    /// <summary>
    /// Used to encapsulate all properties needed to be bind to a boarding pass in the Sort endpoint.
    /// Considering that FlightBoardingPass conatains all properties of both Bus and Train Boarding Pass cards.
    /// </summary>
    public class BoardingPass : FlightBoardingPass
    {
    }
}
