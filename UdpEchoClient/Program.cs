using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace UdpEchoClient
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Send data over UDP packet 
                // source ip address and source port
                int sourceListenPort = 9999;
                UdpClient udpClient = new UdpClient("127.0.0.1", sourceListenPort);

                // IPEndPoint --> connect to server : you need to
                // Destination IP address
                // Destination Port
                IPAddress destinationIpAddress = IPAddress.Loopback;
                int DestinationListenPort = 9999;
                IPEndPoint remoteIpEndPoint = new IPEndPoint(destinationIpAddress, DestinationListenPort);
                //udpClient.Connect(remoteIpEndPoint);
                // we need to convert data into bytes
                Console.WriteLine("Write your Message here ");
                string msg = Console.ReadLine();
                int n = 0;
                for (int i = 0; i < 1000; i++)
                {
                    Byte[] sendBytes = Encoding.ASCII.GetBytes($"{msg}-number :{n}");
                    // UDP ready to send byte data to host at the specified remote endpoint 
                    udpClient.Send(sendBytes, sendBytes.Length);

                    // Client received  bytes from Server 
                    Byte[] receivedBytes = udpClient.Receive(ref remoteIpEndPoint);

                    string receivedMsg = Encoding.ASCII.GetString(receivedBytes);
                    Console.WriteLine($" Message from Server:{receivedMsg}");
                    
                    n++;
                }

                Console.WriteLine("Now loop is finished");
                Console.ReadKey();
            
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.ReadLine();
            }

        }
    }
}
