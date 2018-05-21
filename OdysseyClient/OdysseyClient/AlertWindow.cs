using System;
namespace OdysseyClient
{
    public partial class AlertWindow : Gtk.Dialog
    {
		public AlertWindow(string alertType)
        {
            this.Build();
			label1.Text = alertType;
        }

		protected void Delete(object sender, EventArgs e)
		{
			Login.originalLogin.Destroy();
			Destroy();
		}

		protected void Retry(object sender, EventArgs e)
		{
			Destroy();
		}
	}
}
