using System;
namespace OdysseyClient
{
    public partial class Lyrics : Gtk.Window
    {
        public Lyrics() :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
        }
    }
}
