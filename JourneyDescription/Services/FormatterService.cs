using JourneyDescription.Models;
using JourneyDescription.Models.Base;
using JourneyDescription.Services.Descriptions;

namespace JourneyDescription.Services
{
    public class FormatterService : IFormatterService
    {
        public string[] Format(BoardingPass[] boardingCards)
        {
            string[] result = new string[boardingCards.Length + 1];
            int resultIndex = 0;
            foreach (var boardingCard in boardingCards)
            {
                if (string.Equals(boardingCard.TransporationType, TransporationType.Flight))
                {
                    result[resultIndex++] = $"From {boardingCard.StartingPoint}, " +
                        $"take {boardingCard.TransporationType} " +
                        $" {boardingCard.TransporationId}" +
                        $"to {boardingCard.DestinationPoint}. Gate {boardingCard.GateNumber}, " +
                        $"seat {boardingCard.SeatNumber}. {boardingCard.BagageInfo}.";
                }
                else if(string.Equals(boardingCard.TransporationType, TransporationType.Train))
                {
                    result[resultIndex++] = $"Take {boardingCard.TransporationType} " +
                    $"{boardingCard.TransporationId} from {boardingCard.StartingPoint} to " +
                    $"{boardingCard.DestinationPoint}. Sit in seat {boardingCard.SeatNumber}.";
                }
                else
                {
                    result[resultIndex++] = $"Take the {boardingCard.TransporationType}" +
                  $" from {boardingCard.StartingPoint} to {boardingCard.DestinationPoint}." +
                  $"No seat assignment.";
                }
             
            }
            result[resultIndex] = "You have arrived at your final destination.";

            return result;
        }
    }
}
