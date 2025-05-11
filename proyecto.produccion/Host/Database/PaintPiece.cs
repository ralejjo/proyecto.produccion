using Tenaris.Library.DbClient;

namespace Host.Database
{
    [DbStoredProc("dbo.PaintPiece")]
    internal class PaintPiece
    {
        [DbParam]
        public int @colorId { get; set; }
        [DbParam]
        public int @pieceId { get; set; }
        [DbField]
        public int @identity { get; set; }
    }
}