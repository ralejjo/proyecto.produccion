using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Threading.Tasks;

namespace Host
{
    internal class InterfaceConnection
    {
        [STAThread]
        static void Main(string[] args)
        {
            IDictionary properties = new Hashtable();
            properties["port"] = 1234;
            properties["bindTo"] = "127.0.0.1";

            TcpServerChannel serverChannel = new TcpServerChannel(properties, null, null);
            ChannelServices.RegisterChannel(serverChannel, false);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(LibraryManager),
                "LibraryManager", WellKnownObjectMode.Singleton); //SingleCall si quiero que todos usen la misma instancia de ProductionLine

            Console.WriteLine("Listening on {0}", serverChannel.GetChannelUri());
            Console.WriteLine("Press the enter key to exit...");
            Console.ReadLine();
        }
    }
}
