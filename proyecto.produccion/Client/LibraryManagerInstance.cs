using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;

namespace Client
{
    public static class LibraryManagerInstance
    {
        private static ILibraryManager _Instance;

        public static ILibraryManager Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = (ILibraryManager)Activator.GetObject(typeof(ILibraryManager), "tcp://127.0.0.1:1234/LibraryManager");
                }

                return _Instance;
            }
        }
    }
}
