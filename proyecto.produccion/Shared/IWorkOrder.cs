using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public interface IWorkOrder
    {
        int workOrderId { get; }
        DateTime date { get; }
        int lote {  get; }
        int colada { get; }
        int clientId { get; }
        int pieceId { get; }
        int quantity { get; }
        int processTypeId { get; }
        bool isActive { get; }
        DateTime startedAt { get; }
        DateTime updatedAt { get; }

        int CreateWorkOrder(CreateWorkOrderDto workOrder);
    }
}
