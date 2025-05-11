using System;
using System.Collections.Generic;
using Tenaris.Library.DbClient;
using Shared.DTO;

namespace Host.Database
{
    [DbStoredProc("dbo.GetState")]
    internal class GetState
    {
        [DbRecordset(0)]
        public List<StateDto> rows { get; set; }
    }
}
