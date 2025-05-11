using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO
{
    [Serializable]
    public class StationDto
    {
        public int stationId { get; set; }
        public string name { get; set; }
        public int pieceIdOnEntry { get; set; }
        public int pieceIdOnProcess { get; set; }
        public int pieceIdOnExit { get; set; }
        public int stationTypeId { get; set; }
        public int productionLineId { get; set; }
        public bool isActive { get; set; }
        public DateTime startedAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
}
