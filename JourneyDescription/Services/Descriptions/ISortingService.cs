using JourneyDescription.Models;
using JourneyDescription.Models.Base;

namespace JourneyDescription.Services.Descriptions
{
    public interface ISortingService<T> where T : BoardingPass
    {
           T[] Sort(T[] boardingCards);
    }
}
