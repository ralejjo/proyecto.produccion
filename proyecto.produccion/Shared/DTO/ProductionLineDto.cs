using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO
{
    [Serializable]
    public class ProductionLineDto
    {
        public int ProductionLineId { get; }
        public string description { get; set; }
        public bool isActive { get; set; }
        public DateTime startedAt { get; }
        public DateTime updatedAt { get; set; }
    }
}
