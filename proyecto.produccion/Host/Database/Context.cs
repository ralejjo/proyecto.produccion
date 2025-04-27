using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tenaris.Library.DbClient;

namespace Host.Database
{
    public class Context
    {
        private static readonly Context _Instance = new Context();
        public DbClient Db { get; private set; }
        private Context()
        {
            Db = new DbClient("production");
        }
        public static Context Instance
        {
            get
            {
                return _Instance;
            }
        }
    }
}
