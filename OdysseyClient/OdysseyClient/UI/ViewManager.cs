using System;
using Gtk;

namespace OdysseyClient
{
    public class ViewManager
    {
		public MainWindow window;
		private Window ventana;
        public ViewManager()
        {
            /*Application.Init();
			this.ventana = new Window("Odyssey");
			this.ventana.SetSizeRequest(600, 600);
			this.ventana.DeleteEvent += OnDeleteEvent;
			this.ventana.Opacity = 0.92;
			Fixed @fix = new Fixed();
			Button button = new Button("Hola");
			button.WidthRequest = 30;
			button.HeightRequest = 30;
			button.Clicked += new EventHandler(ShowFileChooser);
			fix.Put(button, 30, 30);
			this.ventana.Add(fix);
			this.ventana.ShowAll();

			Application.Run();*/
            Application.Init();
            this.window = MainWindow.GetMainWindow();
            this.window.ShowAll();
            Application.Run();
            
            

          /*  Application.Init();
			this.window = new MainWindow();
			this.window.Show();
			FileChooserDialog fileChooser = new FileChooserDialog("Hola", this.window, FileChooserAction.Open, "Cancel", ResponseType.Cancel,
																  "Open", ResponseType.Accept);
			
			Button button = new Button();
			Button button2 = new Button();
            
           
			button.Label = "Button";
			Layout layout = new Layout();
			//button.
			button.SetAlignment(30, 30);
			button.SetAlignment(100, 30);
			button.SetSizeRequest(1, 1);
			button.SetSizeRequest(10, 10);
			button.Clicked += new EventHandler(ShowFileChooser);
			//button.set
			this.window.Add(button);
			this.window.Add(button2);


			this.window.ShowAll();
			Application.Run();*/
            
        }
		public void Send(object obj,EventArgs args){
			//SocketClient.GetSocketClient().send();
		}
		public void ShowFileChooser(object obj, EventArgs args)
        {
			FileChooserDialog fileChooser = new FileChooserDialog("Hola", this.ventana, FileChooserAction.Open, "Cancel", ResponseType.Cancel,
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
				Console.Write(cancionBytes[cancionBytes.Length-1]);



                

            }

			fileChooser.Destroy();
            
        }
        /**
         * 
         */
		protected void OnDeleteEvent(object sender, DeleteEventArgs a)
        {
            Application.Quit();
            a.RetVal = true;
        }


    }
}
