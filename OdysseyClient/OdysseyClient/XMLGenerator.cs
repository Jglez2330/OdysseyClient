using System;
using System.Xml;
using System.Xml.Linq;
namespace OdysseyClient
{
	public class XMLGenerator
	{
		private XMLGenerator()
		{
		}


		public static XDocument Generate(string style, string name,string artistName , string album, int year, string lyrics, int operationCode, byte[] cancion)
		{
			string s = Convert.ToBase64String(cancion);
			Console.Write(s.Length);
			XDocument xmlCancion = new XDocument(new XElement("Data",
			                                                  new XElement("opCode", operationCode),
			                                                  new XElement("style", style),
			                                                  new XElement("song",s),
			                                                  new XElement("songName",name),
			                                                  new XElement("albumName",album),
			                                                  new XElement("artistName",artistName),
			                                                  new XElement("year",year),
			                                                  new XElement("lyrics",lyrics)));
			xmlCancion.Save("Cancion.xml");
			return xmlCancion;


            



		}

        internal static XDocument RequestSongs(int pageNumber)
        {
            XDocument document = new XDocument(new XElement("Data",
                new XElement("opCode", 2),
                new XElement("Index", pageNumber)));

            SocketClient.GetSocketClient().send(document);
            document = SocketClient.GetSocketClient().Listen();

            return document;
        }

        internal static XDocument Generate(string user, string passwordString, string style, string fullName, string age, string friends,int operationCode)
        {
			XDocument xml = new XDocument(new XElement("Data",
                                                              new XElement("opCode", operationCode),
			                                                  new XElement("User", user),
			                                                  new XElement("Password", passwordString),
			                                                  new XElement("Style",style),
			                                           new XElement("Name",fullName),
			                                           new XElement("Age",age),
			                                           new XElement("Friends",friends)));
			return xml;
        }
		public static XDocument RequestUsers()
		{
			XDocument xml = new XDocument(new XElement("Data",
														new XElement("opCode", 22)));
			return xml;
		}
		public static XDocument RequestSort(string sort)
		{
			XDocument xml = new XDocument(new XElement("Data",
													   new XElement("opCode", 23),
													   new XElement("Sort", sort)));
			return xml;
		}
   	}
}