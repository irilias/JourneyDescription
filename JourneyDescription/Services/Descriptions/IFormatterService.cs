using JourneyDescription.Models;
using JourneyDescription.Models.Base;

namespace JourneyDescription.Services.Descriptions
{
    public interface IFormatterService
    {
        string[] Format(BoardingPass[] boardingCards);
    }
}
