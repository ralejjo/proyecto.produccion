using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;
using Tenaris.Library.DbClient;
using Host.Database;
using Shared.DTO;

namespace Host
{
    internal class State : MarshalByRefObject, IState
    {
        private readonly DbClient db;

        private int _stateId { get; }
        private string _description { get; }
        private bool _isActive { get; }
        private DateTime _startedAt { get; }
        private DateTime _updatedAt { get; }

        public int stateId { get { return _stateId; } }
        public string description { get { return _description; } }
        public bool isActive { get { return _isActive; } }
        public DateTime startedAt { get { return _startedAt; } }
        public DateTime updatedAt { get { return _updatedAt; } }

        public State()
        {
            db = Context.Instance.Db;
        }

        public StateDto[] GetAll()
        {
            var result = db.Execute
            (
                new GetState { }
            );

            return result.rows.ToArray();
        }
    }
}
