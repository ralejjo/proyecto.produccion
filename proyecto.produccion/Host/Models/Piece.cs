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
    internal class Piece : MarshalByRefObject, IPiece
    {
        private readonly DbClient db;

        private int _pieceId { get; }
        private int _colorId { get; }
        private int _materialId { get; }
        private int _stateId { get; }
        private int _typeId { get; }
        private float _width { get; }
        private float _length { get; }
        private float _thickness { get; }
        private int _pieceOrderId { get; }
        private bool _isActive { get; }
        private DateTime _startedAt { get; }
        private DateTime _UpdatedAt { get; }

        public int pieceId { get { return _pieceId; } }
        public int colorId { get { return _colorId; } }
        public int materialId { get { return _materialId; } }
        public int stateId { get { return _stateId; } }
        public int typeId { get { return _typeId; } }
        public float width { get { return _width; } }
        public float length { get { return _length; } }
        public float thickness { get { return _thickness; } }
        public int pieceOrderId { get { return _pieceOrderId; } }
        public bool isActive { get { return _isActive; } }
        public DateTime startedAt { get { return _startedAt; } }
        public DateTime UpdatedAt { get { return _UpdatedAt; } }

        public Piece()
        {
            db = Context.Instance.Db;
        }

        public PieceDto[] GetAllByState(int stateId)
        {
            var result = db.Execute
            (
                new GetPieceByState
                {
                    stateId = stateId
                }
            );

            return result.rows.ToArray();
        }
    }
}