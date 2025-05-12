using Tenaris.Library.DbClient;

namespace Host.Database
{
    [DbStoredProc("dbo.ApprovePiece")]
    internal class ApprovePiece
    {
        [DbParam]
        public int @colorId { get; set; }
        [DbParam]
        public int @materialId { get; set; }
        [DbParam]
        public int @typeId { get; set; }
        [DbParam]
        public int @width { get; set; }
        [DbParam]
        public int @length { get; set; }
        [DbParam]
        public int @thickness { get; set; }
        [DbParam]
        public int @pieceId { get; set; }
        [DbField]
        public int @identity { get; set; }
    }
}
