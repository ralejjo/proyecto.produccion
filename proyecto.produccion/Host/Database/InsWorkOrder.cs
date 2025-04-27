using System;
using Tenaris.Library.DbClient;

namespace Host.Database
{
    [DbStoredProc("dbo.InsWorkOrder")]
    internal class InsWorkOrder
    {
        [DbParam]
        public DateTime @date { get; set; }
        [DbParam]
        public int @lote { get; set; }
        [DbParam]
        public int @colada { get; set; }
        [DbParam]
        public int @clientid { get; set; }
        [DbParam]
        public int @pieceid { get; set; }
        [DbParam]
        public int @quantity { get; set; }
        [DbParam]
        public int @processtypeid { get; set; }
    }
}
