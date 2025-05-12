using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;
using Tenaris.Library.DbClient;
using Host.Database;
using Shared.DTO;

namespace Host
{
    abstract class Station : MarshalByRefObject, IStation
    {
        private readonly DbClient db;

        private int _stationId;
        private string _name;
        private int _pieceIdOnEntry;
        private int _pieceIdOnProcess;
        private int _pieceIdOnExit;
        private int _stationTypeId;
        private int _productionLineId;
        private bool _isActive;
        private DateTime _startedAt;
        private DateTime _updatedAt;
        private bool _isInitialized = false;

        public int stationId { get { return _stationId; } }
        public string name { get { return _name; } }
        public int pieceIdOnEntry { get { return _pieceIdOnEntry; } }
        public int pieceIdOnProcess { get { return _pieceIdOnProcess; } }
        public int pieceIdOnExit { get { return _pieceIdOnExit; } }
        public int stationTypeId { get { return _stationTypeId; } }
        public int productionLineId { get { return _productionLineId; } }
        public bool isActive { get { return _isActive; } }
        public DateTime startedAt { get { return _startedAt; } }
        public DateTime updatedAt { get { return _updatedAt; } }

        public Station()
        {
            db = Context.Instance.Db;
        }

        public abstract int ProcessPiece(PieceDto processPiece);

        public void PutPieceOnEntry(StationDto stationId, PieceDto pieceId)
        {
            db.Execute
            (
                new PutPieceOnEntry
                {
                    stationid = stationId.stationId,
                    pieceid = pieceId.pieceId
                }
            );
            _pieceIdOnEntry = pieceId.pieceId;
        }

        public void PutPieceOnProcess(StationDto stationId, PieceDto pieceId)
        {
            db.Execute
            (
                new PutPieceOnProcess
                {
                    stationid = stationId.stationId,
                    pieceid = pieceId.pieceId
                }
            );
            _pieceIdOnEntry = 0;
            _pieceIdOnProcess = pieceId.pieceId;
        }

        public void PutPieceOnExit(StationDto stationId, PieceDto pieceId)
        {
            db.Execute
            (
                new PutPieceOnExit
                {
                    stationid = stationId.stationId,
                    pieceid = pieceId.pieceId
                }
            );
            _pieceIdOnProcess = 0;
            _pieceIdOnExit = pieceId.pieceId;
        }

        public StationDto[] GetStationById(int stationId)
        {
            var result = db.Execute
            (
                new GetStationById
                {
                    id = stationId
                }
            );

            return result.rows.ToArray();
        }

        public void InitializeStation(StationDto station)
        {
            _stationId = station.stationId;
            _name = station.name;
            _pieceIdOnEntry = station.pieceIdOnEntry;
            _pieceIdOnExit = station.pieceIdOnExit;
            _pieceIdOnProcess = station.pieceIdOnProcess;
            _stationTypeId = station.stationTypeId;
            _productionLineId = station.productionLineId;

            _isInitialized = true;
        }
    }
}