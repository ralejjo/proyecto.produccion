using Tenaris.Library.DbClient;

namespace Host.Database
{
    [DbStoredProc("dbo.putPieceOnExit")]
    internal class PutPieceOnExit
    {
        [DbParam]
        public int @stationid { get; set; }
        [DbParam]
        public int @pieceid { get; set; }
    }
}
