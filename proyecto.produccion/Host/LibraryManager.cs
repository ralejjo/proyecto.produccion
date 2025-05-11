using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Host;
using Shared;
using Tenaris.Library.Framework;

namespace Host
{
    internal class LibraryManager : MarshalByRefObject, ILibraryManager
    {
        private ProductionLine _ProductionLine;
        private WorkOrder _WorkOrder;
        private CutStation _CutStation;
        private Color _Color;
        private Client _Client;
        private ProcessType _ProcessType;
        private Material _Material;
        private PieceType _PieceType;
        private State _State;
        private Piece _Piece;
        private PaintStation _PaintStation;

        public IProductionLine productionLine { get { return _ProductionLine; } }
        public IWorkOrder workOrder { get { return _WorkOrder; } }
        public IStation cutStation { get { return _CutStation; } }
        public IColor color { get { return _Color; } }
        public IClient client { get { return _Client; } }
        public IProcessType processType { get { return _ProcessType; } }
        public IMaterial material { get { return _Material; } }
        public IPieceType pieceType { get { return _PieceType; } }
        public IState state { get { return _State; } }
        public IPiece piece { get { return _Piece; } }
        public IStation paintStation { get { return _PaintStation; } }


        public LibraryManager()
        {
            _ProductionLine = new ProductionLine();
            _WorkOrder = new WorkOrder();
            _CutStation = new CutStation();
            _Color = new Color();
            _Client = new Client();
            _ProcessType = new ProcessType();
            _Material = new Material();
            _PieceType = new PieceType();
            _State = new State();
            _PaintStation = new PaintStation();
            _Piece = new Piece();
        }
    }
}
