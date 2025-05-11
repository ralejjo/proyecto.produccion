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
    internal class PieceType : MarshalByRefObject, IPieceType
    {
        private readonly DbClient db;

        private int _pieceTypeId { get; }
        private string _description { get; }
        private bool _isActive { get; }
        private DateTime _startedAt { get; }
        private DateTime _updatedAt { get; }

        public int pieceTypeId { get { return _pieceTypeId; } }
        public string description { get { return _description; } }
        public bool isActive { get { return _isActive; } }
        public DateTime startedAt { get { return _startedAt; } }
        public DateTime updatedAt { get { return _updatedAt; } }

        public PieceType()
        {
            db = Context.Instance.Db;
        }

        public PieceTypeDto[] GetAll()
        {
            var result = db.Execute
            (
                new GetPieceType { }
            );

            return result.rows.ToArray();
        }
    }
}