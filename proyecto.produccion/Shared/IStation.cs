using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public interface IStation
    {
        int stationId { get; }
        string name { get; }
        int pieceIdOnEntry { get; }
        int pieceIdOnProcess { get; }
        int pieceIdOnExit { get; }
        int stationTypeId { get; }
        int productionLineId { get; }
        bool isActive { get; }
        DateTime startedAt { get; }
        DateTime updatedAt { get; }
    }
}
