using System;

namespace InfiniteRemotingServer
{
    public class InfiniteServer : MarshalByRefObject
    {
        public string Greetings()
        {
            return "Hello Folks !! Welcome to CSharp Remoting...";

        }
    }
    //service class
        public class InfinteServices : MarshalByRefObject
    {
        public int WriteData(int n1, int n2)
        {
            int maxval = (Math.Max(n1, n2));
            Console.WriteLine("call Executed...");
            return maxval;
        }
    }
}
