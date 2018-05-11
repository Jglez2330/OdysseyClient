using System.Net;
using System.Xml.Linq;
using System.Text;
using System;
using System.Net.Sockets;

namespace OdysseyClient
{
    public class SocketClient
    {
        private Socket socket;
		private static SocketClient SocketClientInstance;
		private string ip = "192.168.0.103";

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
		public void send(XDocument xmlCancion){
			string s = xmlCancion.ToString();
			byte[] message = Encoding.UTF8.GetBytes(s + "\n");

			this.socket.Send(message);
		}
    }
}
