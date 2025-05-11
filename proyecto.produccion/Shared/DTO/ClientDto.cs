using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO
{
    [Serializable]
    public class ClientDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string mobilePhone { get; set; }
        public int cuit { get; set; }
        public bool isActive { get; set; }
        public DateTime startedAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
}
