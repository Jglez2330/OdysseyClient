using System;
namespace OdysseyClient
{
    public partial class Lyrics : Gtk.Window
    {
        public Lyrics(String Lyrics) :
                base(Gtk.WindowType.Toplevel)
        {
            
            this.Build();
            label1.Text = Lyrics;
        }
        private void Exit(object sender, EventArgs e)
        {
            Destroy();
        }
    }
}

