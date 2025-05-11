using Tenaris.Library.DbClient;

namespace Host.Database
{
    [DbStoredProc("dbo.PutPieceOnEntry")]
    internal class PutPieceOnEntry
    {
        [DbParam]
        public int @stationid { get; set; }
        [DbParam]
        public int @pieceid { get; set; }
    }
}