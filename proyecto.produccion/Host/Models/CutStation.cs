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
    internal class CutStation : Station
    {
        private readonly DbClient db;

        public CutStation()
        {
            db = Context.Instance.Db;
        }

        public override int ProcessPiece(PieceDto processPiece)
        {
            var result = db.Execute
                (
                    new CortarPieza
                    {
                        length = processPiece.length,
                        width = processPiece.width,
                        thickness = processPiece.thickness,
                        pieceId = pieceIdOnProcess
                    }
                );
            return result.identity;
        }
    }
}
