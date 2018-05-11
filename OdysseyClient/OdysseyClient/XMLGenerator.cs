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


		public static XDocument Generate(string style, string name, string album, int year, string lyrics, int operationCode, byte[] cancion)
		{
			string s = Convert.ToBase64String(cancion);
			XDocument xmlCancion = new XDocument(new XElement("Data",
			                                                  new XElement("opCode", operationCode),
			                                                  new XElement("style", style),
			                                                  new XElement("Song",s)));
			xmlCancion.Save("Cancion.xml");
			return xmlCancion;






		}
	}
}