using System;
using Gtk;
using OdysseyClient;

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
        Application.Quit();
        a.RetVal = true;
    }

	protected void OnAgregarCancion(object sender, EventArgs e)
	{
		FileChooserDialog fileChooser = new FileChooserDialog("Hola", mainWindow, FileChooserAction.Open, "Cancel", ResponseType.Cancel,
                                                                  "Open", ResponseType.Accept);

        FileFilter file = new FileFilter();
        file.AddPattern("*.mp3");
        file.AddPattern("*.mp4");
        file.AddPattern("*.aac");

        fileChooser.AddFilter(file);
        fileChooser.Show();
        if (fileChooser.Run() == (int)ResponseType.Accept)
        {
            byte[] cancionBytes = System.IO.File.ReadAllBytes(fileChooser.Filename);

			SocketClient.GetSocketClient().send(XMLGenerator.Generate("", "", "", -1, "", 0, cancionBytes));





        }

        fileChooser.Destroy();

    }

}
