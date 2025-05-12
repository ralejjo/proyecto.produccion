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
    internal class PieceOrder : MarshalByRefObject, IPieceOrder
    {
        private readonly DbClient db;

        private int _pieceOrderId { get; }
        private int _workOrderId { get; }
        private int _pieceId { get; }
        private bool _isActive { get; }
        private DateTime _startedAt { get; }
        private DateTime _updatedAt { get; }

        public int pieceOrderId { get { return _pieceOrderId; } }
        public int workOrderId { get { return _workOrderId; } }
        public int pieceId { get { return _pieceId; } }
        public bool isActive { get { return _isActive; } }
        public DateTime startedAt { get { return _startedAt; } }
        public DateTime updatedAt { get { return _updatedAt; } }

        public PieceOrder()
        {
            db = Context.Instance.Db;
        }

        public PieceOrderDto[] GetByPieceId(int pieceId)
        {
            var result = db.Execute
            (
                new GetPieceOrderByPieceId
                {
                    pieceid = pieceId
                }
            );

            return result.rows.ToArray();
        }
    }
}