﻿using System;
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
    private static Mp3FileReader mp3FileReader;

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

    public void UpdateSongs(XDocument xml)
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
        Pagina.Text += (page / 4 + 1);

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
        XDocument document = XMLGenerator.RequestSongs(page);
        UpdateSongs(document);

    }

	protected void GetSongs(object sender, EventArgs e)
	{
        

	}
    private void Backward(object sender, EventArgs e)
    {
        mp3FileReader.Skip(-10);
    }

    private void Forward(object sender, EventArgs e)
    {
        mp3FileReader.Skip(10);
    }

    protected void SendSort(object sender, EventArgs e)
	{
		SocketClient.GetSocketClient().send(XMLGenerator.RequestSort(combobox1.ActiveText));
        XDocument document = XMLGenerator.RequestSongs(page);
        UpdateSongs(document);
		//image1.Pixbuf;
        
	}

	protected void Play(object sender, EventArgs e)
	{
        try
        {


            player.Play();
        }catch(Exception)
        {

        }
	}

    private void Edit(object sender, EventArgs e)
    {
        try
        {
            Button button = (Button)sender;
            string name = "";
            string artist = "";
            char separator = " ".ToCharArray()[0];
            string buttonLabel = "";

            if (button.Name == "1")
            {
                buttonLabel = button21.Label;
                name = buttonLabel.Split(separator)[0];
                artist = buttonLabel.Split(separator)[2];

            }
            else if (button.Name == "2")
            {
                buttonLabel = button22.Label;
                name = buttonLabel.Split(separator)[0];
                artist = buttonLabel.Split(separator)[2];
            }
            else if (button.Name == "3")
            {
                buttonLabel = button23.Label;
                name = buttonLabel.Split(separator)[0];
                artist = buttonLabel.Split(separator)[2];
            }
            else if (button.Name == "4")
            {
                buttonLabel = button24.Label;
                name = buttonLabel.Split(separator)[0];
                artist = buttonLabel.Split(separator)[2];
            }
            XDocument document = new XDocument(new XElement("Data",
                new XElement("opCode", 25),
                new XElement("SongName", name),
                new XElement("Artist", artist)));
            SocketClient.GetSocketClient().send(document);
            
            EditSong editSong = new EditSong(name,artist, page);
            document = XMLGenerator.RequestSongs(page);
            UpdateSongs(document);
        }
        catch (Exception)
        {
            AlertWindow alertWindow = new AlertWindow("Error: No se pudo eliminar el elemento o este no existe, por favor reintentar");
        }
    }

    protected void Stop(object sender, EventArgs e)
	{
        try
        {
            Console.Write(mp3FileReader.Length);
            Console.Write(mp3FileReader.Position);

            player.Pause();
        }catch(Exception)
        {

        }
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
                mp3FileReader = new Mp3FileReader(memoryStream);
                //player.PlaybackStopped =
                
                //mp3FileReader.
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
                //NAudio.Gui.WaveViewer waveViewer = new NAudio.Gui.WaveViewer();
            }
           


        }catch(Exception)
        {

        }
        //button.Name;

	}

    private void ResquestMoreSong(object sender, EventArgs e)
    {
        
            XDocument document = new XDocument(new XElement("Data",
                new XElement("opCode", 3)));
            SocketClient.GetSocketClient().send(document);
            document = SocketClient.GetSocketClient().Listen();

            byte[] song = Convert.FromBase64String(document.Root.Element("Reply").Value);
            MemoryStream memoryStream = new MemoryStream(song);
            //mp3FileReader.
            mp3FileReader = new Mp3FileReader(memoryStream);
        player.Init(mp3FileReader);



        
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
        Pagina.Text = "" + (page + 1); 
       
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
        Pagina.Text = "" + (page + 1);

    }
    private void Delete(object sender, EventArgs e)
    {
        try
        {
            Button button = (Button)sender;
            string name = "";
            string artist = "";
            char separator = " ".ToCharArray()[0];
            string buttonLabel = "";

            if (button.Name == "1")
            {
                buttonLabel = button21.Label;
                name = buttonLabel.Split(separator)[0];
                artist = buttonLabel.Split(separator)[2];

            }
            else if (button.Name == "2")
            {
                buttonLabel = button22.Label;
                name = buttonLabel.Split(separator)[0];
                artist = buttonLabel.Split(separator)[2];
            }
            else if (button.Name == "3")
            {
                buttonLabel = button23.Label;
                name = buttonLabel.Split(separator)[0];
                artist = buttonLabel.Split(separator)[2];
            }
            else if (button.Name == "4")
            {
                buttonLabel = button24.Label;
                name = buttonLabel.Split(separator)[0];
                artist = buttonLabel.Split(separator)[2];
            }
            XDocument document = new XDocument(new XElement("Data",
                new XElement("opCode", 24),
                new XElement("SongName", name),
                new XElement("Artist", artist)));
            SocketClient.GetSocketClient().send(document);
            document = XMLGenerator.RequestSongs(page);
            UpdateSongs(document);
        }catch(Exception)
        {
            AlertWindow alertWindow = new AlertWindow("Error: No se pudo eliminar el elemento o este no existe, por favor reintentar");
        }
    }
    private void ShowLyrics(object sender, EventArgs e)
    {
        try
        {
            Button button = (Button)sender;
            string name = "";
            string artist = "";
            char separator = " ".ToCharArray()[0];
            string buttonLabel = "";

            if (button.Name == "1")
            {
                buttonLabel = button21.Label;
                name = buttonLabel.Split(separator)[0];
                artist = buttonLabel.Split(separator)[2];

            }
            else if (button.Name == "2")
            {
                buttonLabel = button22.Label;
                name = buttonLabel.Split(separator)[0];
                artist = buttonLabel.Split(separator)[2];
            }
            else if (button.Name == "3")
            {
                buttonLabel = button23.Label;
                name = buttonLabel.Split(separator)[0];
                artist = buttonLabel.Split(separator)[2];
            }
            else if (button.Name == "4")
            {
                buttonLabel = button24.Label;
                name = buttonLabel.Split(separator)[0];
                artist = buttonLabel.Split(separator)[2];
            }
            XDocument document = new XDocument(new XElement("Data",
                new XElement("opCode", 40),
                new XElement("SongName", name),
                new XElement("Artist", artist)));
            SocketClient.GetSocketClient().send(document);

            document = SocketClient.GetSocketClient().Listen();
            string lyrics = document.Root.Element("Reply").Value;
            Lyrics lyricsWindow = new Lyrics(lyrics);
            lyricsWindow.Show();

        }
        catch (Exception)
        {
            AlertWindow alertWindow = new AlertWindow("Error: No se pudo eliminar el elemento o este no existe, por favor reintentar");
        }
    }
}
