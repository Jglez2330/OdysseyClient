using System;
using Gtk;
namespace OdysseyClient
{
    public partial class AddSongUI : Gtk.Window
    {
		private Window window;
		public AddSongUI(Window window) :
                base(Gtk.WindowType.Toplevel)
        {
            this.Build();
        }

		protected void AddSong(object sender, EventArgs e)
		{
			FileChooserDialog fileChooser = new FileChooserDialog("Hola", window, FileChooserAction.Open, "Cancel", ResponseType.Cancel,
                                                                  "Open", ResponseType.Accept);

        FileFilter file = new FileFilter();
        file.AddPattern("*.mp3");
                 
        fileChooser.AddFilter(file);
        //fileChooser.Show();
        if (fileChooser.Run() == (int)ResponseType.Accept)
        {
				int yearInt = 0;
            byte[] cancionBytes = System.IO.File.ReadAllBytes(fileChooser.Filename);
				if(nameSong.Text == "")
				{
					nameSong.Text = "Unknown";
				}if(album.Text == "")
				{
					album.Text = "Unknown";
				}if (style.Text == "")
				{
					style.Text = "Unknown";
				}if (artist.Text == "")
				{
					artist.Text = "Unknown";
				}if (lyrics.Text == "")
				{
					lyrics.Text = "Unknown";
				}try
				{
					yearInt = Int32.Parse(year.Text);
				}catch(Exception)
				{
					yearInt = -1;	
				}
                
                      
				SocketClient.GetSocketClient().send(XMLGenerator.Generate(style.Text,nameSong.Text,artist.Text,album.Text, yearInt,lyrics.Text,0, cancionBytes));
                       

                
        }
			Destroy();
        fileChooser.Destroy();
			
		}
	}
}
