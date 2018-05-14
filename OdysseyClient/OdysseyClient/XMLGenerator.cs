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
	}
}