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
		//SocketClient.GetSocketClient().Close();
        Application.Quit();
        a.RetVal = true;
    }

	protected void OnAgregarCancion(object sender, EventArgs e)
	{
		//AddSongUI addSong = new AddSongUI();
		//addSong.ShowAll();
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
            /* Mp3FileReader mp = new Mp3FileReader(fileChooser.Filename);
             Mp3FileReader fileReader;// = new Mp3FileReader(memoryStream);
             MemoryStream memoryBuffer;
             byte[] arrayCancion = new byte[cancionBytes.Length / 200];

             for (int i = 0;i < cancionBytes.Length/200; i++ )
             {
                 arrayCancion[i] = cancionBytes[i];
             }
             MemoryStream memoryStream = new MemoryStream(arrayCancion);

             var wave = new WaveOut();

                 fileReader = new Mp3FileReader(memoryStream);
                 wave.Init(fileReader);
                 wave.Play();*/
            // MemoryStream memoryStream = new MemoryStream(cancionBytes);
            byte[] array = new byte[cancionBytes.Length];
            MemoryStream memory = new MemoryStream(cancionBytes);
            var wave = new WaveOut();


            Mp3FileReader fileReader = new Mp3FileReader(memory);
            //
           wave.Init(fileReader);
            wave.Play();


            Console.Write(memory.Position);
            
            
           
                


            
           

                 
        

            //	SocketClient.GetSocketClient().send(XMLGenerator.Generate("rock","NightMoves","BobSeger","Unknown", 0, "Hola", 0, cancionBytes));
            //MediaPlayer mediaPlayer = new MediaPlayer();

           // MediaPlayer.MediaPlayerClass = new MediaPlayer.MediaPlayerClass();
           

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
        Console.Write(xml.Root.Element("SongData").Element("SongString").Value);//.Element("SongString")



        byte[] song = System.Text.Encoding.UTF8.GetBytes(xml.Root.Element("SongData").Element("SongString").Value + "\n");
       
        
       
        Console.Write(System.Text.Encoding.UTF8.GetString(song));



        //MemoryStream memory = new MemoryStream(song);
        
        File.Create("Cancion.mp3").Close();
        File.WriteAllBytes("Cancion.mp3", song);
        byte[] shong = File.ReadAllBytes("Cancion.mp3");
       // MemoryStream stream = new MemoryStream(shong);
        //stream.ReadTimeout = 1000000;
        //stream.WriteTimeout = 1000000;
        //byte[] songs = ; 
        
        WaveOut waveOut = new WaveOut();
       /* Mp3FileReader mp3FileReader = new Mp3FileReader(stream);
        waveOut.Init(mp3FileReader);
        waveOut.Play();*/


	}

	protected void SendSort(object sender, EventArgs e)
	{
		SocketClient.GetSocketClient().send(XMLGenerator.RequestSort(combobox1.ActiveText));
		XDocument xmlRespond = SocketClient.GetSocketClient().Listen();
		//image1.Pixbuf;
        
	}
}
