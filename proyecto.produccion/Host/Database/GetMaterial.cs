using System;
using System.Collections.Generic;
using Tenaris.Library.DbClient;
using Shared.DTO;

namespace Host.Database
{
    [DbStoredProc("dbo.GetMaterial")]
    internal class GetMaterial
    {
        [DbRecordset(0)]
        public List<MaterialDto> rows { get; set; }
    }
}