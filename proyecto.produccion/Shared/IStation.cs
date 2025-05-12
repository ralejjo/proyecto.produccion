using Shared.DTO;
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
        int ProcessPiece(PieceDto processPiece);
        void PutPieceOnEntry(StationDto stationId, PieceDto pieceId);
        void PutPieceOnProcess(StationDto stationId, PieceDto pieceId);
        void PutPieceOnExit(StationDto stationId, PieceDto pieceId);
        StationDto[] GetStationById(int stationId);
        void InitializeStation(StationDto station);
    }
}
