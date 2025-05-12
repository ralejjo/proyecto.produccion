using System;
using System.Collections.Generic;
using Tenaris.Library.DbClient;
using Shared.DTO;

namespace Host.Database
{
    [DbStoredProc("dbo.PieceOrderLastState")]
    internal class PieceOrderLastState
    {
        [DbParam]
        public int @workOrderId { get; set; }
        [DbRecordset(0)]
        public List<PieceOrderLastStateDto> rows { get; set; }
    }
}
