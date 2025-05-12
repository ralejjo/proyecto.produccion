using Tenaris.Library.DbClient;

namespace Host.Database
{
    [DbStoredProc("dbo.PutPieceOnProcess")]
    internal class PutPieceOnProcess
    {
        [DbParam]
        public int @stationid { get; set; }
        [DbParam]
        public int @pieceid { get; set; }
    }
}
