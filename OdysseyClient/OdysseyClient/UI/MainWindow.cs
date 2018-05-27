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
public partial class MainWindow : Gtk.Window
{
	private static MainWindow mainWindow;

	public static MainWindow GetMainWindow(){
		if (mainWindow == null){
			mainWindow = new MainWindow();
		}
		return mainWindow;
        
        
	}


	private MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
		SocketClient.GetSocketClient().Close();
        Application.Quit();
        a.RetVal = true;
    }

	protected void OnAgregarCancion(object sender, EventArgs e)
	{
		AddSongUI addSong = new AddSongUI();
		addSong.ShowAll();
		FileChooserDialog fileChooser = new FileChooserDialog("Hola", mainWindow, FileChooserAction.Open, "Cancel", ResponseType.Cancel,
                                                                  "Open", ResponseType.Accept);

        FileFilter file = new FileFilter();
        file.AddPattern("*.mp3");
        //file.AddPattern("*.mp4");
        file.AddPattern("*.wav");

        fileChooser.AddFilter(file);
        //fileChooser.Show();
        if (fileChooser.Run() == (int)ResponseType.Accept)
        {
            byte[] cancionBytes = System.IO.File.ReadAllBytes(fileChooser.Filename);

			//	SocketClient.GetSocketClient().send(XMLGenerator.Generate("rock","NightMoves","BobSeger","Unknown", 0, "Hola", 0, cancionBytes));
			//MediaPlayer mediaPlayer = new MediaPlayer();

			//Audio audio = new Audio();
			//audio.Play(cancionBytes, Microsoft.VisualBasic.AudioPlayMode.WaitToComplete);





        }
		//SocketClient.GetSocketClient().Close();

        fileChooser.Destroy();

    }

	protected void GetSongs(object sender, EventArgs e)
	{
		SocketClient.GetSocketClient().send(XMLGenerator.Generate("None", "None", 2));
		XDocument xml = SocketClient.GetSocketClient().Listen();
		Console.Write(xml);
        
		//byte[] song = System.Text.Encoding.UTF8.GetBytes(xml.Root.Element("SongData").Element("SongString").Value);


	}

	protected void SendSort(object sender, EventArgs e)
	{
		SocketClient.GetSocketClient().send(XMLGenerator.RequestSort(combobox1.ActiveText));
		XDocument xmlRespond = SocketClient.GetSocketClient().Listen();
		//image1.Pixbuf;
        
	}
}
