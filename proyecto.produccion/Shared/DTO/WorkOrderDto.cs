using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO
{
    [Serializable]
    public class WorkOrderDto
    {
        public int workOrderId { get; set; }
        public DateTime date { get; set; }
        public int lote { get; set; }
        public int colada { get; set; }
        public int clientId { get; set; }
        public int pieceId { get; set; }
        public int quantity { get; set; }
        public int processTypeId { get; set; }
        public bool isActive { get; set; }
        public DateTime startedAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
}
