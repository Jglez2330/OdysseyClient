
using System.Collections.Generic;
using System.Xml.Linq;
namespace OdysseyClient
{
    public partial class RegisterWindow : Gtk.Window
    {
        public RegisterWindow() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
			SocketClient.GetSocketClient().send(XMLGenerator.RequestUsers());
			XDocument xmlUsers = SocketClient.GetSocketClient().Listen();
			IEnumerable<XElement> inumerable = xmlUsers.Root.Elements();
			//XElement xElement = new XElement("");

			foreach (XElement x in inumerable){
				comboboxentry2.AppendText(x.Value);
			}
			ShowAll();


            
        }

		protected void AddFriend(object sender, System.EventArgs e)
		{
			//comboboxentry2.


		}
	}
}
