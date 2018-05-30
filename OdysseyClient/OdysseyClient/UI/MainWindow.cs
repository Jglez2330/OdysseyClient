using System;
using Gtk;
using OdysseyClient;
using System.Xml.Linq;
using System.Media;
using System.IO;
using Microsoft.VisualBasic.Devices;
using NAudio.Wave;
using CSCore.Codecs.MP3;
using Vlc.DotNet.Core;
using System.Windows;
using System.Windows.Media;
using NAudio;
using System.Collections.Generic;
public partial class
    MainWindow : Gtk.Window
   {
    public WaveOut player;
    public bool playing = false;
    public int page = 0;
	private static MainWindow mainWindow;

	public static MainWindow GetMainWindow(){
		if (mainWindow == null){
			mainWindow = new MainWindow();
            
		}
		return mainWindow;
        
        
	}


	private MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        this.player = new WaveOut();
        Build();

        XDocument xml = XMLGenerator.RequestSongs(0);
        UpdateSongs(xml);
        
    }

    protected void UpdateSongs(XDocument xml)
    {
        try
        {
            int i = 0;
            Button[] arrayButtons = { button21, button22, button23, button24 };
            button21.Label = " ";
            button22.Label = " ";
            button23.Label = " ";
            button24.Label = " ";
            

            foreach (XElement x in xml.Root.Elements())
            {
                //button21.Label = x.Element("SongName").Value;
                foreach (XElement y in x.Elements())
                {
                    if (y.Name == "SongName")
                    {
                        arrayButtons[i].Label = y.Value;

                    }
                    else if (y.Name == "ArtistName")
                    {
                        arrayButtons[i].Label += " by " + y.Value;
                    }
                }
                i++;


            }
           

        }
        catch(Exception)
        {

        }
        Pagina.Text = "";
        Pagina.Text += page / 4;

    }


 
    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
		//SocketClient.GetSocketClient().Close();
        Application.Quit();
        a.RetVal = true;
    }

	protected void OnAgregarCancion(object sender, EventArgs e)
	{
        AddSongUI addSongUI = new AddSongUI(mainWindow);

    }

	protected void GetSongs(object sender, EventArgs e)
	{
		SocketClient.GetSocketClient().send(XMLGenerator.Generate("None", "None"," "," "," "," ",2));
		XDocument xml = SocketClient.GetSocketClient().Listen();
        Console.Write(xml.Root.Element("SongData").Element("SongString").Value.ToString());//.Element("SongString")
        string sb = xml.Root.Element("SongData").Element("SongString").Value;



        byte[] song = Convert.FromBase64String(sb);
       
        
       
        //Console.Write(System.Text.Encoding.UTF8.GetString(song));



        //MemoryStream memory = new MemoryStream(song);
        
        //File.Create("Cancion.mp3").Close();
        //File.WriteAllBytes("Cancion.mp3", song);
        //byte[] shong = File.ReadAllBytes("Cancion.mp3");
       MemoryStream stream = new MemoryStream(song);
        //stream.ReadTimeout = 1000000;
        //stream.WriteTimeout = 1000000;
        //byte[] songs = ; 
        
        Mp3FileReader mp3FileReader = new Mp3FileReader(stream);
        player.Init(mp3FileReader);
        player.Play();


	}

	protected void SendSort(object sender, EventArgs e)
	{
		SocketClient.GetSocketClient().send(XMLGenerator.RequestSort(combobox1.ActiveText));
		XDocument xmlRespond = SocketClient.GetSocketClient().Listen();
		//image1.Pixbuf;
        
	}

	protected void Play(object sender, EventArgs e)
	{
        player.Play();
        
	}

	protected void Stop(object sender, EventArgs e)
	{
        player.Pause();
        Console.Write("Pausa");
	}

	

    protected void PlaySeletedSong(object sender, EventArgs e)
    {
        try
        {
            Gtk.Button button = (Button)sender;
            if (button.Label != " ")
            {
                string songRequested = "";
                string songByArtist = "";
                char separator = " ".ToCharArray()[0];
                songRequested = button.Label.Split(separator)[0];
                songByArtist = button.Label.Split(separator)[2];

                XDocument xml = new XDocument(new XElement("Data",
                    new XElement("opCode", 30),
                    new XElement("Song", songRequested),
                    new XElement("Artist", songByArtist)));
                SocketClient.GetSocketClient().send(xml);
                xml = SocketClient.GetSocketClient().Listen();
                
                byte[] song = Convert.FromBase64String(xml.Root.Element("Reply").Value);
                MemoryStream memoryStream = new MemoryStream(song);
                Mp3FileReader mp3FileReader = new Mp3FileReader(memoryStream);
                try
                {
                    player.Dispose();
                    player = new WaveOut();
                }
                catch (Exception)
                {

                }
                player.Init(mp3FileReader);
                player.Play();
            }


        }catch(Exception)
        {

        }
        //button.Name;

	}

	protected void PreviousPage(object sender, EventArgs e)
	{
        --page;
        if (page < 0)
        {
            page = 0;
        }
        XDocument xml = XMLGenerator.RequestSongs(page);
        UpdateSongs(xml);
       
    }

	protected void NextPage(object sender, EventArgs e)
	{
        
       if(button24.Label == " ")
        {

        }
        else
        {
            page++;
        }
        XDocument xml = XMLGenerator.RequestSongs(page);
        UpdateSongs(xml);
        
    }
}
