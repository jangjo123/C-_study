using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerCore
{
    class Program
    {
        static Listener _listener = new Listener();

        static void OnAcceptHandler (Socket clientSocket)
        {
            try
            {
                // 손님이 말한 것을 저장하는 곳
                byte[] reveBuff = new byte[1024];

                // 손님이 말한 것을 받는다 (몇 바이트 받는지는 따로 저장)
                int recvBytes = clientSocket.Receive(reveBuff);
                string recvData = Encoding.UTF8.GetString(reveBuff, 0, recvBytes);
                Console.WriteLine($"[From Client] {recvData}");

                // 보낸다
                byte[] sendBuff = Encoding.UTF8.GetBytes("Welcome to Server !");
                clientSocket.Send(sendBuff);

                // 쫒아낸다.
                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            
        }

        static void Main(string[] args)
        {
            // DNS (Domain Name System) // www.naver.com -> 123.123.123.12
            string host = Dns.GetHostName();
            IPHostEntry ipHost = Dns.GetHostEntry(host);
            IPAddress ipAddr = ipHost.AddressList[0];
            IPEndPoint endPoint = new IPEndPoint(ipAddr, 7777);


            
            _listener.init(endPoint, OnAcceptHandler);
            Console.WriteLine("Listening....");

            while (true)
               {
                    
               }

            
        }
    }
}
