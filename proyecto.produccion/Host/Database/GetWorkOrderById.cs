using System;
using System.Collections.Generic;
using Tenaris.Library.DbClient;
using Shared.DTO;

namespace Host.Database
{
    [DbStoredProc("dbo.GetWorkOrderByIdAle")]
    internal class GetWorkOrderById
    {
        [DbParam]
        public int @workorderid { get; set; }
        [DbRecordset(0)]
        public List<WorkOrderDto> rows { get; set; }
    }
}
