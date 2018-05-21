using System;
using System.Xml.Linq;
 
namespace OdysseyClient
{
    public class XMLGetter
    {
        public XMLGetter()
        {
        }
		public static void GetPlaylist()
		{
			XDocument xmlPlaylist;
			string[][] songArray;
			XDocument document = SocketClient.GetSocketClient().Listen();
            
            
            
			return ;
			
		}
    }
}
