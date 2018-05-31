using System;
namespace OdysseyClient
{
    public partial class EditSong : Gtk.Window
    {
        public EditSong() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
        }

		protected void ChangeData(object sender, EventArgs e)
		{
		}
	}
}
