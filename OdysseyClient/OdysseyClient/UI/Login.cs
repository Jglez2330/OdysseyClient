using System;
namespace OdysseyClient
{
    public partial class Login : Gtk.Window
    {
        public Login() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
			ShowAll();
        }

		protected void Access(object sender, EventArgs e)
		{
		}

		protected void GetPassword(object o, Gtk.TextInsertedArgs args)
		{
		}

		protected void GetUserName(object o, Gtk.TextInsertedArgs args)
		{
		}
	}
}
