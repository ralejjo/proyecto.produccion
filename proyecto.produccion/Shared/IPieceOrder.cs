using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public interface IPieceOrder
    {
        int pieceOrderId { get; }
        int workOrderId { get; }
        int pieceId { get; }
        bool isActive { get; }
        DateTime startedAt { get; }
        DateTime updatedAt { get; }
        PieceOrderDto[] GetByPieceId(int pieceId);
    }
}
