using System;
using System.Collections.Generic;
using Tenaris.Library.DbClient;
using Shared.DTO;

namespace Host.Database
{
    [DbStoredProc("dbo.GetAllColor")]
    internal class GetAllColor
    {
        [DbRecordset(0)]
        public List<ColorDto> rows { get; set; }
    }
}
