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
    internal class QualityStation : Station
    {
        private readonly DbClient db;

        public QualityStation()
        {
            db = Context.Instance.Db;
        }

        public override int ProcessPiece(PieceDto processPiece)
        {
            var result = db.Execute
                (
                    new ApprovePiece
                    {
                        colorId = processPiece.colorId,
                        materialId = processPiece.materialId,
                        typeId = processPiece.typeId,
                        width = (int)processPiece.width,
                        length = (int)processPiece.length,
                        thickness = (int)processPiece.thickness,
                        pieceId = pieceIdOnProcess
                    }
                );
            return result.identity;
        }
    }
}
