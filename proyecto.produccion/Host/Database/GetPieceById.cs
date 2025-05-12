using System;
using System.Collections.Generic;
using Tenaris.Library.DbClient;
using Shared.DTO;

namespace Host.Database
{
    [DbStoredProc("dbo.GetPieceByIdAle")]
    internal class GetPieceById
    {
        [DbParam]
        public int @id { get; set; }
        [DbRecordset(0)]
        public List<PieceDto> rows { get; set; }
    }
}
