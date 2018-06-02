
using System;
using Gtk;

namespace OdysseyClient
{
    public partial class Lyrics
    {
        private global::Gtk.Fixed fixed1;
        private global::Gtk.Label label1;
        private global::Gtk.Button ok;



        private void Build()
        {
            global::Stetic.Gui.Initialize(this);
            // Widget OdysseyClient.AddSongUI
            this.Name = "OdysseyClient.AddSongUI";
            this.Title = global::Mono.Unix.Catalog.GetString("AddSongUI");
            this.WindowPosition = ((global::Gtk.WindowPosition)(4));
           

            // Container child OdysseyClient.AddSongUI.Gtk.Container+ContainerChild
            this.fixed1 = new global::Gtk.Fixed();
            this.fixed1.Name = "fixed1";
            this.fixed1.HasWindow = false;
            this.fixed1.SetSizeRequest(1000, 1000);
            // Container child fixed1.Gtk.Fixed+FixedChild
            this.label1 = new global::Gtk.Label();
            this.label1.Name = "label1";
            this.label1.LabelProp = global::Mono.Unix.Catalog.GetString("Amigos: ");
            this.fixed1.Add(this.label1);
            
            global::Gtk.Fixed.FixedChild w6 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.label1]));
            w6.X = 50;
            w6.Y = 50;
            // Container child fixed1.Gtk.Fixed+FixedChild
            this.ok = new global::Gtk.Button();
            this.ok.CanFocus = true;
            this.ok.Name = "button5";
            this.ok.UseUnderline = true;
            this.ok.Label = global::Mono.Unix.Catalog.GetString("Ok");
            this.fixed1.Add(this.ok);
            global::Gtk.Fixed.FixedChild w4 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.ok]));
            w4.X = 475;
            w4.Y = 475;

            this.ok.Clicked += new global::System.EventHandler(this.Exit);
            Show();

        }

    }
}
