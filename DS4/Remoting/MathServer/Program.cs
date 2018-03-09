using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;


namespace MathServer
{
    class ServerMain
    {
        static void Main(string[] args)
        {
            //// Create a channel specifying the port
            //HttpServerChannel channel = new HttpServerChannel(10000);
            //// Register the channel with the runtime remoting services
            //ChannelServices.RegisterChannel(channel);
            // Read remoting info from config file.
            RemotingConfiguration.Configure("MathServer.exe.config");
            // Register the Customer class as a client-activated type.
            //RemotingConfiguration.RegisterActivatedServiceType(typeof(MathLibrary.Customer));
            // Keep the server alive until Enter is pressed.
            Console.WriteLine("Server started. Press Enter to end ...");
            Console.ReadLine();
        }
    }
}
