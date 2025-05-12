using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public interface IPiece
    {
        int pieceId { get; }
        int colorId { get; }
        int materialId { get; }
        int stateId { get; }
        int typeId { get; }
        float width { get; }
        float length { get; }
        float thickness { get; }
        int pieceOrderId { get; }
        bool isActive { get; }
        DateTime startedAt { get; }
        DateTime UpdatedAt { get; }
        PieceDto[] GetAllByState(int stateId);
        PieceDto[] GetById(int pieceId);
    }
}
