using System;
using System.Collections.Generic;
using Tenaris.Library.DbClient;
using Shared.DTO;

namespace Host.Database
{
    [DbStoredProc("dbo.GetWorkOrderByPieceIdAle")]
    internal class GetWorkOrderByPieceId
    {
        [DbParam]
        public int @pieceid { get; set; }
        [DbRecordset(0)]
        public List<WorkOrderDto> rows { get; set; }
    }
}
