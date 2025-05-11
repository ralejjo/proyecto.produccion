using Tenaris.Library.DbClient;

namespace Host.Database
{
    [DbStoredProc("dbo.CortarPieza")]
    internal class CortarPieza
    {
        [DbParam]
        public float @length { get; set; }
        [DbParam]
        public float @width { get; set; }
        [DbParam]
        public float @thickness { get; set; }
        [DbParam]
        public int @pieceId { get; set; }
        [DbField]
        public int @identity { get; set; }
    }
}
