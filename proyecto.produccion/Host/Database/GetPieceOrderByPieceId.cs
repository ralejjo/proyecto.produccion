using System;
using System.Collections.Generic;
using Tenaris.Library.DbClient;
using Shared.DTO;

namespace Host.Database
{
    [DbStoredProc("dbo.GetPieceOrderByPieceId")]
    internal class GetPieceOrderByPieceId
    {
        [DbParam]
        public int @pieceid { get; set; }
        [DbRecordset(0)]
        public List<PieceOrderDto> rows { get; set; }
    }
}
