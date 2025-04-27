using Tenaris.Library.DbClient;

namespace Host.Database
{
    [DbStoredProc("dbo.InsPiece")]
    internal class InsPiece
    {
        [DbParam]
        public int @colorid { get; set; }
        [DbParam]
        public int @materialid { get; set; }
        [DbParam]
        public int @stateid { get; set; }
        [DbParam]
        public int @typeid { get; set; }
        [DbParam]
        public float @width { get; set; }
        [DbParam]
        public float @length { get; set; }
        [DbParam]
        public float @thickness { get; set; }
        [DbParam]
        public int @pieceorderid { get; set; }
    }
}
