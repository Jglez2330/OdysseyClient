using System.Net;
using System;
using System.Text;
using System.Net.Sockets;

namespace OdysseyClient
{
    public class SocketClient
    {
        private Socket socket;
		private static SocketClient SocketClientInstance;
        private string ip = "192.168.0.102";

		private SocketClient()
        {
            try{

				IPHostEntry ipHostInfo = Dns.GetHostEntry(ip);//Dns.GetHostName());  
                IPAddress ipAddress = ipHostInfo.AddressList[0];
                IPEndPoint ipEndpoint = new IPEndPoint(ipAddress, 3000);
                socket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                socket.Connect(ipEndpoint);
                Console.WriteLine("Socket created to {0}", socket.RemoteEndPoint.ToString());

            }catch(Exception e){
                Console.WriteLine(e.ToString()); 
                
            }
        }
		public static SocketClient GetSocketClient(){
			if (SocketClientInstance == null){
				SocketClientInstance = new SocketClient();
			}
			return SocketClientInstance;
		}
		public void send(){
			byte[] bytes = Encoding.ASCII.GetBytes("Hola\n");

			this.socket.Send(bytes);
		}
    }
}
