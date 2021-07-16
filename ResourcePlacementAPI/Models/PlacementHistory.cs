using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResourcePlacementAPI.Models
{
    public class PlacementHistory
    {
        public int PlacementHistoryId { get; set; }
        public int ProjectId { get; set; }
        public int ParticipantId { get; set; }
    }
}
