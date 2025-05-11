using Shared.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public interface IPieceType
    {
        int pieceTypeId { get; }
        string description { get; }
        bool isActive { get; }
        DateTime startedAt { get; }
        DateTime updatedAt { get; }
        PieceTypeDto[] GetAll();
    }
}
