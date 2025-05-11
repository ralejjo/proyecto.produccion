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
    internal class Client : MarshalByRefObject, IClient
    {
        private readonly DbClient db;

        private int _clientId { get; }
        private string _name { get; }
        private string _address { get; }
        private string _mobilePhone { get; }
        private int _cuit { get; }
        private bool _isActive { get; }
        private DateTime _startedAt { get; }
        private DateTime _updatedAt { get; }

        public int clientId { get { return _clientId; } }
        public string name { get { return _name; } }
        public string address { get { return _address; } }
        public string mobilePhone { get { return _mobilePhone; } }
        public int cuit { get { return _cuit; } }
        public bool isActive { get { return _isActive; } }
        public DateTime startedAt { get { return _startedAt; } }
        public DateTime updatedAt { get { return _updatedAt; } }

        public Client()
        {
            db = Context.Instance.Db;
        }

        public ClientDto[] GetAll()
        {
            var result = db.Execute
            (
                new GetClient { }
            );

            return result.rows.ToArray();
        }
    }
}
