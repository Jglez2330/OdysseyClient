
using System.Collections.Generic;
using System.Security.Cryptography;
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
			label2.Text += comboboxentry2.ActiveText + ",";

		}

		protected void Register(object sender, System.EventArgs e)
		{
            MD5 encryptor = MD5.Create();
                     byte[] password = System.Text.Encoding.UTF8.GetBytes(entry4.Text);
                     password = encryptor.ComputeHash(password);
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < password.Length; i++)
            {
                sb.Append(password[i].ToString("X2"));
            }
            SocketClient.GetSocketClient().send(XMLGenerator.Generate(entry1.Text, sb.ToString(), comboboxentry1.ActiveText, entry2.Text, entry3.Text, label2.Text.Substring(0,label2.Text.Length-1), 21));
			XDocument xml = SocketClient.GetSocketClient().Listen();
			if (xml.Root.Element("Reply").Value == "Granted")
            {
                Destroy();
                ViewManager viewmanager = new ViewManager();
            }
            else
            {
                AlertWindow alertWindow = new AlertWindow("Error: Nombre de Usuario ya se encunetra en uso, Por favor reintentar");
                alertWindow.Show();


            }


		}
	}
}
