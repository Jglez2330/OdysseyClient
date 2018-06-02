using System;
using System.Xml.Linq;
using Gtk;
namespace OdysseyClient
{
    public partial class EditSong : Gtk.Window
    {
        private string originalName;
        private string originalArtist;
        private int page;

        public EditSong( string originalName,string originalArtist, int page) :
                base(Gtk.WindowType.Toplevel)

        {
            this.originalArtist = originalArtist;
            this.originalName = originalName;
            this.page = page;

            this.Build();
            XDocument document = SocketClient.GetSocketClient().Listen();
            //Entry[] infoSong = { nameSong, artist, album, style, year, lyrics };
            foreach(XElement x in document.Root.Element("Reply").Elements())
            {
                if (x.Name == "Name")
                {
                    nameSong.Text = x.Value;
                }
                else if (x.Name == "Artist")
                {
                    artist.Text = x.Value;
                }
                else if (x.Name == "Album")
                {
                    album.Text = x.Value;
                }
                else if (x.Name == "Style")
                {
                    style.Text = x.Value;
                }
                else if (x.Name == "Year")
                {
                    year.Text = x.Value;
                }
                else if (x.Name == "Lyrics")
                {
                    lyrics.Text = x.Value;
                }
            }
                

            

        }

		protected void ChangeData(object sender, EventArgs e)
		{
            int yearInt = 0;
            if (nameSong.Text == "")
            {
                nameSong.Text = "Unknown";
            }
            if (album.Text == "")
            {
                album.Text = "Unknown";
            }
            if (style.Text == "")
            {
                style.Text = "Unknown";
            }
            if (artist.Text == "")
            {
                artist.Text = "Unknown";
            }
            if (lyrics.Text == "")
            {
                lyrics.Text = "Unknown";
            }
            try
            {
                yearInt = Int32.Parse(year.Text);
            }
            catch (Exception)
            {
                yearInt = -1;
            }
            nameSong.Text = nameSong.Text.Replace(" ", "");
            album.Text = album.Text.Replace(" ", "");
            style.Text = style.Text.Replace(" ", "");
            artist.Text = artist.Text.Replace(" ", "");
            XDocument document = new XDocument(new XElement("Data",
                new XElement("opCode", 26),
                new XElement("OriginalName",this.originalName),
                new XElement("OriginalArtist",this.originalArtist),
                new XElement("Name",nameSong.Text),
                new XElement("Artist",artist.Text),
                new XElement("Album",album.Text),
                new XElement("Style",style.Text),
                new XElement("Year",year.Text),
                new XElement("Lyrics",lyrics.Text)));
            SocketClient.GetSocketClient().send(document);
            

            Destroy();
            MainWindow.GetMainWindow().UpdateSongs(XMLGenerator.RequestSongs(page));
            
            return;
		}
        
	}
}
