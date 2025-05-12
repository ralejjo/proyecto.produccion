using System;
using Tenaris.Library.DbClient;

namespace Host.Database
{
    [DbStoredProc("dbo.InsPieceOrder")]
    internal class InsPieceOrder
    {
        [DbParam]
        public int @workOrderId { get; set; }
        [DbParam]
        public int @pieceId { get; set; }
        [DbField]
        public int @identity { get; set; }
    }
}