using System;
using System.Collections.Generic;
using Tenaris.Library.DbClient;
using Shared.DTO;

namespace Host.Database
{
    [DbStoredProc("dbo.GetClient")]
    internal class GetClient
    {
        [DbRecordset(0)]
        public List<ClientDto> rows { get; set; }
    }
}