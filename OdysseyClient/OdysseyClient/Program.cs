using System;
using Gtk;

namespace OdysseyClient
{
    class MainClass
    {
        public static void Main(string[] args)
        {
			//SocketClient client = SocketClient.GetSocketClient();
			//XMLGenerator.Generate("", "", "", -1, "", 0);
			//ViewManager viewManager = new ViewManager();
			Application.Init();
			Login login = new Login();
			Login.originalLogin = login;
			login.Show();
			Application.Run();
			//login.ShowAll();
        }
    }
}
