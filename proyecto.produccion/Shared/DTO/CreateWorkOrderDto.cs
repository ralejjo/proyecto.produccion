using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO
{
    [Serializable]
    public class CreateWorkOrderDto
    {
        public DateTime Date { get; set; }
        public int Lote { get; set; }
        public int Colada {  get; set; }
        public int ClientId { get; set; }
        public int ColorId { get; set; }
        public int MaterialId {  get; set; }
        public int StateId { get; set; }
        public int TypeId { get; set; }
        public float Width { get; set; }
        public float Length { get; set; }
        public float Thickness { get; set; }
        public int Quantity { get; set; }
        public int ProcessTypeId { get; set; }
    }
}
