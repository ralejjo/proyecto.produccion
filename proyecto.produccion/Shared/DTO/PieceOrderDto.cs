using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO
{
    [Serializable]
    public class PieceOrderDto
    {
        public int id { get; set; }
        public int workOrderId { get; set; }
        public int pieceId { get; set; }
        public bool isActive { get; set; }
        public DateTime startedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}