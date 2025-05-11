using System;
using System.Collections.Generic;
using Tenaris.Library.DbClient;
using Shared.DTO;

namespace Host.Database
{
    [DbStoredProc("dbo.GetStationByIdAle")]
    internal class GetStationById
    {
        [DbParam]
        public int @id { get; set; }
        [DbRecordset(0)]
        public List<StationDto> rows { get; set; }
    }
}
