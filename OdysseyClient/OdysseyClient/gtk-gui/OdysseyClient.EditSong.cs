﻿
namespace OdysseyClient
{
	public partial class EditSong
	{
        private global::Gtk.Entry nameSong;
        private global::Gtk.Entry artist;
        private global::Gtk.Entry album;
        private global::Gtk.Entry style;
        private global::Gtk.Entry lyrics;
        private global::Gtk.Entry year;
        private global::Gtk.Button button3;
        private global::Gtk.Fixed fixed1;

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
            
            

            // Container child fixed1.Gtk.Fixed+FixedChild
            this.nameSong = new global::Gtk.Entry();
            this.nameSong.CanFocus = true;
            this.nameSong.Name = "nameSong";
            this.nameSong.Text = global::Mono.Unix.Catalog.GetString("Nombre Cancion");
            this.nameSong.IsEditable = true;
            this.nameSong.InvisibleChar = '●';
            this.fixed1.Add(this.nameSong);
            global::Gtk.Fixed.FixedChild w2 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.nameSong]));
            w2.X = 70;
            w2.Y = 25;
            // Container child fixed1.Gtk.Fixed+FixedChild
            this.artist = new global::Gtk.Entry();
            this.artist.CanFocus = true;
            this.artist.Name = "nameSong";
            this.artist.Text = global::Mono.Unix.Catalog.GetString("Artista");
            this.artist.IsEditable = true;
            this.artist.InvisibleChar = '●';
            this.fixed1.Add(this.artist);
            global::Gtk.Fixed.FixedChild w3 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.artist]));
            w3.X = 70;
            w3.Y = 75;
            // Container child fixed1.Gtk.Fixed+FixedChild
            this.album = new global::Gtk.Entry();
            this.album.CanFocus = true;
            this.album.Name = "nameSong";
            this.album.Text = global::Mono.Unix.Catalog.GetString("Album");
            this.album.IsEditable = true;
            this.album.InvisibleChar = '●';
            this.fixed1.Add(this.album);
            global::Gtk.Fixed.FixedChild w4 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.album]));
            w4.X = 70;
            w4.Y = 125;
            // Container child fixed1.Gtk.Fixed+FixedChild
            this.style = new global::Gtk.Entry();
            this.style.CanFocus = true;
            this.style.Name = "nameSong";
            this.style.Text = global::Mono.Unix.Catalog.GetString("Genero");
            this.style.IsEditable = true;
            this.style.InvisibleChar = '●';
            this.fixed1.Add(this.style);
            global::Gtk.Fixed.FixedChild w5 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.style]));
            w5.X = 70;
            w5.Y = 175;
            // Container child fixed1.Gtk.Fixed+FixedChild
            this.lyrics = new global::Gtk.Entry();
            this.lyrics.CanFocus = true;
            this.lyrics.Name = "nameSong";
            this.lyrics.Text = global::Mono.Unix.Catalog.GetString("Letra");
            this.lyrics.IsEditable = true;
            this.lyrics.InvisibleChar = '●';
            this.fixed1.Add(this.lyrics);
            global::Gtk.Fixed.FixedChild w6 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.lyrics]));
            w6.X = 70;
            w6.Y = 225;
            // Container child fixed1.Gtk.Fixed+FixedChild
            this.year = new global::Gtk.Entry();
            this.year.CanFocus = true;
            this.year.Name = "nameSong";
            this.year.Text = global::Mono.Unix.Catalog.GetString("Año");
            this.year.IsEditable = true;
            this.year.InvisibleChar = '●';
            this.fixed1.Add(this.year);
            global::Gtk.Fixed.FixedChild w7 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.year]));
            w7.X = 70;
            w7.Y = 275;

            this.button3 = new global::Gtk.Button();
            this.button3.CanFocus = true;
            this.button3.Name = "button3";
            this.button3.UseStock = true;
            this.button3.UseUnderline = true;
            this.button3.Label = "Cambiar Informacion";
            this.fixed1.Add(this.button3);
            global::Gtk.Fixed.FixedChild w14 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.button3]));
            w14.X = 400;
            w14.Y = 400;


            this.Add(this.fixed1);
            if ((this.Child != null))
            {
                this.Child.ShowAll();
            }
            this.DefaultWidth = 500;
            this.DefaultHeight = 500;
            this.button3.Clicked += new global::System.EventHandler(this.ChangeData);

            this.Show();
        }
    }
}


