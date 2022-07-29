using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneyDescription.Tests.Integration_Testing.Models
{
    public class BoardingPass
    {
        public string? TransporationId { get; init; }
        public string TransporationType { get; init; } = default!;
        public string StartingPoint { get; init; } = default!;
        public string DestinationPoint { get; init; } = default!;
        public string? SeatNumber { get; init; }
        public string? BagageInfo { get; init; }
        public string? GateNumber { get; init; }
    }
}
