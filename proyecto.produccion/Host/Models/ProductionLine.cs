using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;
using Tenaris.Library.DbClient;
using Host.Database;

namespace Host
{
    internal class ProductionLine : MarshalByRefObject, IProductionLine
    {
        private readonly DbClient db;

        private int _productionLineId;
        private string _description;
        private bool _isActvive;
        private DateTime _startedAt;
        private DateTime _updatedAt;
        public int productionLineId { get { return _productionLineId; } }

        public string description { get { return _description; } }

        public bool isActive { get { return _isActvive; } }

        public DateTime startedAt { get { return _startedAt; } }

        public DateTime updatedAt { get { return _updatedAt; } }

        public ProductionLine() //Constructor
        {
            db = Context.Instance.Db;
        }
    }
}
