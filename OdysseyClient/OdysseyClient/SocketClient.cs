using System.Net;
using System.Xml.Linq;
using System.Text;
using System;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Threading;
//using Zirpl.Spotify.MetadataApi;

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
            //this.socket.Close();
        }

        public XDocument Listen()
        {
            XDocument xml;
            //socket.ReceiveBufferSize = 
            //byte[] buffer = new byte[socket.ReceiveBufferSize];
            //Console.Write(socket.ReceiveBufferSize);



            //socket.Receive(buffer);
            //byte[] buffer2 = new byte[socket.ReceiveBufferSize];
            //Console.Write(socket.ReceiveBufferSize);

            ////byte[] realBuffer = new byte[socket.]
            ////for (int i = 0; i < buffer.Length; i++)
            ////{
            ////    if (buffer[i] == 0x00)
            ////    {
            ////        buffer[i] = Encoding.UTF8.GetBytes()
            ////    }
            ////}
            ////socket.Receive(buffer,buffer.Length,SocketFlags.None);
            byte[] trash = new byte[1];
            var buffer = new List<byte>();
            var currByte = new Byte[1];
            while (true)
			{
				
				var byteCounter = socket.Receive(currByte, currByte.Length, SocketFlags.None);

				
					if (currByte[0] == 1)
					{
						break;


					}
					else
					{


						buffer.Add(currByte[0]);

					}
				
			}
            while (socket.Available != 0)
            {

                socket.Receive(trash);
                
            }
            //trash = new byte[trash.Length];
            //socket.Receive(trash); 
            
            ////Console.Write(sb);

            string sb = System.Text.Encoding.UTF8.GetString(buffer.ToArray());
            //string sb2 = Encoding.UTF8.GetString(buffer2);
            //Console.Write(sb);


            sb = sb.Replace("\u0000", System.String.Empty);
			//sb = sb.Replace("\u0020", System.String.Empty);
			//sb2 = sb2.Replace("\u0000", System.String.Empty);
			//Console.Write("\n" +sb2 + "\n" );

			//xml = XDocument.Parse(sb);
			//Console.Write(sb);

			xml = XDocument.Parse(sb);
            
            ////}
            return xml;
             

        }
    }
}
