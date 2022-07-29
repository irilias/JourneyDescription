using JourneyDescription.Models;
using JourneyDescription.Models.Base;
using JourneyDescription.Services.Descriptions;

namespace JourneyDescription.Services
{
    public class SortingService<T> : ISortingService<T>
        where T : BoardingPass
    {
        private readonly ILogger<SortingService<T>> logger;
        public SortingService(ILogger<SortingService<T>> logger)
        {
            this.logger = logger;   
        }
        public T[] Sort(T[] boardingCards)
        {
          
            var startingPoint = GetStartingPoint(boardingCards);
            if(string.IsNullOrEmpty(startingPoint))
            {
                //TODO : Throw a custom Exception instead of the generic Exception: "Cannot have two or more boarding pass cards with the same departure location."
            }
            return Sort(boardingCards, startingPoint);
        }

        private T[] Sort(T[] boardingCards, string startingPoint)
        {
            var location = startingPoint;
            var sortedResult = new T[boardingCards.Length];
            int index = boardingCards.Length - 1, sortedResultIndex = 0;
            T? boardingCardLocation;
            while (index >= 0)
            {
                boardingCardLocation = boardingCards.FirstOrDefault(b => b.StartingPoint == location);
                if (boardingCardLocation == null)
                {
                    logger.LogError($"Missing a boarding pass for a complete journey. Departure Point {location}.");
                    //TODO : Throw a custom Exception instead of the generic Exception : "Missing a boarding pass for a complete journey."
                    throw new Exception($"Missing a boarding pass for a complete journey. Departure Point {location}.");
                }
                sortedResult[sortedResultIndex++] = boardingCardLocation!;
                location = boardingCardLocation.DestinationPoint;
                index--;
            }

            return sortedResult;
        }

        private string GetStartingPoint(T[] boardingCards)
        {
            var locationsCount = 0;
            var startingLocations = new Dictionary<string, int>();
            var destinationLocations = new Dictionary<string, int>();
            foreach (var boardingCard in boardingCards)
            {
                startingLocations[boardingCard.StartingPoint] = locationsCount;
                destinationLocations[boardingCard.DestinationPoint] = locationsCount++;
            }
            var startingPoint = startingLocations.Keys.Except(destinationLocations.Keys);
            return startingPoint.FirstOrDefault() ?? String.Empty;
        }
    }
}
