using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using InfiniteRemotingServer;
namespace RemoteClient
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpChannel c1 = new TcpChannel(8003);
            ChannelServices.RegisterChannel(c1);

            //create a service class object
            InfinteServices services = (InfinteServices)Activator.GetObject(typeof(InfinteServices), "http://localhost:83/OurRemoteService");

            //start making calls to the remote object
            Console.WriteLine(services.WriteData(12, 20));
            Console.Read();

        }
    }
}
