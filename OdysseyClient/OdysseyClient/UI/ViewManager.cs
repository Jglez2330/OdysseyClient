using System;
using Gtk;

namespace OdysseyClient
{
    public class ViewManager
    {
		private MainWindow window;
        public ViewManager()
        {
            Application.Init();
			this.window = new MainWindow();
			this.window.Show();
			FileChooserDialog fileChooser = new FileChooserDialog("Hola", this.window, FileChooserAction.Open, "Cancel", ResponseType.Cancel,
																  "Open", ResponseType.Accept);
			
			Button button = new Button();
			button.Label = "Button";
			//button.
			button.SetAlignment(30, 30);
			button.SetSizeRequest(1, 1);
			button.Clicked += new EventHandler(ShowFileChooser);
			//button.set
			this.window.Add(button);


			this.window.ShowAll();
			Application.Run();
            
        }
		public void Send(object obj,EventArgs args){
			SocketClient.GetSocketClient().send();
		}
		public void ShowFileChooser(object obj, EventArgs args)
        {
            FileChooserDialog fileChooser = new FileChooserDialog("Hola", this.window, FileChooserAction.Open, "Cancel", ResponseType.Cancel,
                                                                  "Open", ResponseType.Accept);

			FileFilter file = new FileFilter();
			file.AddPattern("*.mp3");
            
			fileChooser.AddFilter(file);
            fileChooser.Show();
        }


    }
}
