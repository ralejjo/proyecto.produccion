using Tenaris.Library.DbClient;

namespace Host.Database
{
    [DbStoredProc("dbo.PutPieceOnExit")]
    internal class PutPieceOnExit
    {
        [DbParam]
        public int @stationid { get; set; }
        [DbParam]
        public int @pieceid { get; set; }
    }
}
