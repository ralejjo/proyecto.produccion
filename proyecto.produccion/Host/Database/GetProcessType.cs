using System;
using System.Collections.Generic;
using Tenaris.Library.DbClient;
using Shared.DTO;

namespace Host.Database
{
    [DbStoredProc("dbo.GetProcessType")]
    internal class GetProcessType
    {
        [DbRecordset(0)]
        public List<ProcessTypeDto> rows { get; set; }
    }
}
