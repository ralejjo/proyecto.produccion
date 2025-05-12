using System;
using System.Collections.Generic;
using Tenaris.Library.DbClient;
using Shared.DTO;

namespace Host.Database
{
    [DbStoredProc("dbo.GetPieceOrderByWorkOrder")]
    internal class GetPieceOrderByWorkOrder
    {
        [DbParam]
        public int @workOrderId { get; set; }
        [DbRecordset(0)]
        public List<PieceOrderDto> rows { get; set; }
    }
}