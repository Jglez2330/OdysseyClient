using System;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace OdysseyClient
{
    public partial class Login : Gtk.Window
    {
		public static Login originalLogin;
        public Login() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
			ShowAll();
            
        }

		protected void Access(object sender, EventArgs e)
		{
			MD5 encryptor = MD5.Create();
			byte[] password = System.Text.Encoding.UTF8.GetBytes(entry5.Text);
			password = encryptor.ComputeHash(password);
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
            for (int i = 0; i < password.Length; i++)
            {
                sb.Append(password[i].ToString("X2"));
            }
			XDocument xml = XMLGenerator.Generate(entry4.Text, sb.ToString(),20);
			SocketClient socketClient = SocketClient.GetSocketClient();
			socketClient.send(xml);
			XDocument reply = socketClient.Listen();
			Console.Write(reply);
			if(reply.Root.Element("Reply").Value == "Granted")
			{
				Destroy();
				ViewManager viewmanager = new ViewManager();
			}
			else
			{
				AlertWindow alertWindow = new AlertWindow("Error: Usuario o Contraseña incorrectos, Por favor reintentar");
				alertWindow.Show();
                
			    	
			}
			//Console.Write(reply);
            



            
		}

		protected void GetPassword(object o, Gtk.TextInsertedArgs args)
		{
		}

		protected void GetUserName(object o, Gtk.TextInsertedArgs args)
		{
		}

		protected void Register(object sender, EventArgs e)
		{
			MD5 encryptor = MD5.Create();
            byte[] password = System.Text.Encoding.UTF8.GetBytes(entry5.Text);
            password = encryptor.ComputeHash(password);
			System.Text.StringBuilder sb = new System.Text.StringBuilder();
			for (int i = 0; i < password.Length; i++)
            {
				sb.Append(password[i].ToString("X2"));
            }
			XDocument xml = XMLGenerator.Generate(entry4.Text,sb.ToString(), 21);
			Destroy();
			SocketClient.GetSocketClient().send(xml);
             
			ViewManager viewManager = new ViewManager();
				

			//Console.Write(System.Text.Encoding.UTF8.GetBytes("Close").Length);
			         
           

		}
	}
}
