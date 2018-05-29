using System;
using Gtk;

namespace OdysseyClient
{
    class MainClass
    {
        public static void Main(string[] args)
        {
			byte[] array = System.Text.Encoding.UTF8.GetBytes("\u0001");
			Console.Write(array[0]);
			Application.Init();
			//ViewManager viewManager = new ViewManager();
			Login login = new Login();
            

            Login.originalLogin = login;
			login.Show();
			Application.Run();
			//login.ShowAll();
        }
    }
}
