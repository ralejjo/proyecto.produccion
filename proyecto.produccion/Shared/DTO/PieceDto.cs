using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO
{
    [Serializable]
    public class PieceDto
    {
        public int pieceId { get; }
        public int colorId { get; set; }
        public int materialId { get; set; }
        public int stateId { get; set; }
        public int typeId { get; set; }
        public float width { get; set; }
        public float length { get; set; }
        public float thickness { get; set; }
        public int pieceOrderId { get; set; }
        public bool isActive { get; set; }
        public DateTime startedAt { get; }
        public DateTime UpdatedAt { get; set; }
    }
}
