using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO
{
    [Serializable]
    public class PieceOrderLastStateDto
    {
        public int stateId { get; set; }
        public int workOrderId { get; set; }
    }
}