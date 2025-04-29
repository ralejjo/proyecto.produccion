using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;

namespace Host
{
    internal class LibraryManager : MarshalByRefObject, ILibraryManager
    {
        private ProductionLine _ProductionLine;
        private WorkOrder _WorkOrder;

        public IProductionLine productionLine { get { return _ProductionLine; } }

        public IWorkOrder workOrder { get { return _WorkOrder; } }

        public LibraryManager()
        {
            _ProductionLine = new ProductionLine();
            _WorkOrder = new WorkOrder();
        }
    }
}
