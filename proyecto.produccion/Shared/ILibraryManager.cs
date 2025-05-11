using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public interface ILibraryManager
    {
        IClient client { get; }
        IColor color { get; }
        IMaterial material { get; }
        IPiece piece { get; }
        IPieceType pieceType { get; }
        IProcessType processType { get; }
        IProductionLine productionLine { get; }
        IState state { get; }
        IStation cutStation { get; }
        IStation paintStation { get; }
        //IStationType stationType { get; }
        IWorkOrder workOrder { get; }
    }
}
