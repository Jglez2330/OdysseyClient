using System.Net;
using System.Xml.Linq;
using System.Text;
using System;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Threading;

namespace OdysseyClient
{
	public class SocketClient
	{
		private Socket socket;
		private static SocketClient SocketClientInstance;
		private string ip = "192.168.0.103";

		private SocketClient()
		{
			try
			{

				IPHostEntry ipHostInfo = Dns.GetHostEntry(ip);//Dns.GetHostName());  
				IPAddress ipAddress = ipHostInfo.AddressList[0];
				IPEndPoint ipEndpoint = new IPEndPoint(ipAddress, 3000);
				socket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
				socket.Connect(ipEndpoint);
				Console.WriteLine("Socket created to {0}", socket.RemoteEndPoint.ToString());
				//Listen();

			}
			catch (Exception e)
			{
				Console.WriteLine(e.ToString());

			}
		}
		public static SocketClient GetSocketClient()
		{
			if (SocketClientInstance == null)
			{
				SocketClientInstance = new SocketClient();
			}
			return SocketClientInstance;
		}
		public void send(XDocument xmlCancion)
		{
			string s = xmlCancion.ToString();
			byte[] message = Encoding.UTF8.GetBytes(s + "\n");
			byte[] close = Encoding.UTF8.GetBytes("Close\n");

			this.socket.Send(message);
			this.socket.Send(close);

		}
		public void Close()
		{
			this.socket.Close();
		}

		public XDocument Listen()
		{
			XDocument xml;

			byte[] buffer = new byte[socket.ReceiveBufferSize];
			socket.Receive(buffer);
			//byte[] realBuffer = new byte[socket.]
			//for (int i = 0; i < buffer.Length; i++)
			//{
			//	if (buffer[i] == 0x00)
			//	{
			//		buffer[i] = Encoding.UTF8.GetBytes()
			//	}
			//}
			//socket.Receive(buffer,buffer.Length,SocketFlags.None);
			//var buffer = new List<byte>();
			//while (true)
			//{
			//	var currByte = new Byte[1];
			//	var byteCounter = socket.Receive(currByte, currByte.Length, SocketFlags.None);

			//	if (byteCounter.Equals(1))
			//	{
			//		buffer.Add(currByte[0]);
            
			//	
			//System.Text.StringBuilder sb = new System.Text.StringBuilder();
			//for (int i = 0; i < buffer.Length; i++)
			//         {
			//	sb.Append(buffer[i].ToString("X2"));
			//         }
			//Console.Write(sb);
            
			string sb = Encoding.UTF8.GetString(buffer);

			sb = sb.Replace("\u0000", System.String.Empty);
            
			xml = XDocument.Parse(sb);
            
           
            
			//}
			return xml;
             

		}
	}
}
