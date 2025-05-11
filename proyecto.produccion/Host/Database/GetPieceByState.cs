using System;
using System.Collections.Generic;
using Tenaris.Library.DbClient;
using Shared.DTO;

namespace Host.Database
{
    [DbStoredProc("dbo.GetPieceByState")]
    internal class GetPieceByState
    {
        [DbParam]
        public int @stateId { get; set; }
        [DbRecordset(0)]
        public List<PieceDto> rows { get; set; }
    }
}