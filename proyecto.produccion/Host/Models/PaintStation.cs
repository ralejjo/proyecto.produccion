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
    internal class PaintStation : Station
    {
        private readonly DbClient db;

        public PaintStation()
        {
            db = Context.Instance.Db;
        }

        public override int ProcessPiece(PieceDto processPiece)
        {
            var result = db.Execute
                (
                    new PaintPiece
                    {
                        colorId = processPiece.colorId,
                        pieceId = pieceIdOnEntry
                    }
                );
            return result.identity;
        }
    }
}
