using System;
using System.Collections.Generic;
using Tenaris.Library.DbClient;
using Shared.DTO;

namespace Host.Database
{
    [DbStoredProc("dbo.GetPieceType")]
    internal class GetPieceType
    {
        [DbRecordset(0)]
        public List<PieceTypeDto> rows { get; set; }
    }
}
