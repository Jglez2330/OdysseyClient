
// This file has been generated by the GUI designer. Do not modify.
namespace OdysseyClient
{
	public partial class RegisterWindow
	{
		private global::Gtk.Fixed fixed1;

		private global::Gtk.Entry entry1;

		private global::Gtk.Entry entry3;

		private global::Gtk.ComboBoxEntry comboboxentry1;

		private global::Gtk.Button button5;

		private global::Gtk.ComboBoxEntry comboboxentry2;


		private global::Gtk.Button button6;

		private global::Gtk.Label label2;

		private global::Gtk.Entry entry4;

		private global::Gtk.Entry entry2;

		protected virtual void Build()
		{
			global::Stetic.Gui.Initialize(this);
			// Widget OdysseyClient.RegisterWindow
			this.Name = "OdysseyClient.RegisterWindow";
			this.Title = global::Mono.Unix.Catalog.GetString("RegisterWindow");
			this.WindowPosition = ((global::Gtk.WindowPosition)(4));
			// Container child OdysseyClient.RegisterWindow.Gtk.Container+ContainerChild
			this.fixed1 = new global::Gtk.Fixed();
			this.fixed1.Name = "fixed1";
			this.fixed1.HasWindow = false;
			// Container child fixed1.Gtk.Fixed+FixedChild
			this.entry1 = new global::Gtk.Entry();
			this.entry1.CanFocus = true;
			this.entry1.Name = "nameSong";
			this.entry1.Text = global::Mono.Unix.Catalog.GetString("Usuario");
			this.entry1.IsEditable = true;
			this.entry1.InvisibleChar = '●';
			this.fixed1.Add(this.entry1);
			global::Gtk.Fixed.FixedChild w1 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.entry1]));
			w1.X = 60;
			w1.Y = 50;
			// Container child fixed1.Gtk.Fixed+FixedChild
			this.entry3 = new global::Gtk.Entry();
			this.entry3.CanFocus = true;
			this.entry3.Name = "entry3";
			this.entry3.Text = global::Mono.Unix.Catalog.GetString("Edad");
			this.entry3.IsEditable = true;
			this.entry3.InvisibleChar = '●';
			this.fixed1.Add(this.entry3);
			global::Gtk.Fixed.FixedChild w2 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.entry3]));
			w2.X = 60;
			w2.Y = 200;
			// Container child fixed1.Gtk.Fixed+FixedChild
			this.comboboxentry1 = global::Gtk.ComboBoxEntry.NewText();
			this.comboboxentry1.AppendText(global::Mono.Unix.Catalog.GetString("Rock"));
			this.comboboxentry1.AppendText(global::Mono.Unix.Catalog.GetString("Pop"));
			this.comboboxentry1.AppendText(global::Mono.Unix.Catalog.GetString("Electronica"));
			this.comboboxentry1.AppendText(global::Mono.Unix.Catalog.GetString("Alternativa"));
			this.comboboxentry1.AppendText(global::Mono.Unix.Catalog.GetString("Un Buen Cumbion"));
			this.comboboxentry1.Name = "comboboxentry1";
			this.comboboxentry1.Active = 0;
			this.fixed1.Add(this.comboboxentry1);
			global::Gtk.Fixed.FixedChild w3 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.comboboxentry1]));
			w3.X = 60;
			w3.Y = 290;
			// Container child fixed1.Gtk.Fixed+FixedChild
			this.button5 = new global::Gtk.Button();
			this.button5.CanFocus = true;
			this.button5.Name = "button5";
			this.button5.UseUnderline = true;
			this.button5.Label = global::Mono.Unix.Catalog.GetString("Registrarse");
			this.fixed1.Add(this.button5);
			global::Gtk.Fixed.FixedChild w4 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.button5]));
			w4.X = 670;
			w4.Y = 500;
			// Container child fixed1.Gtk.Fixed+FixedChild
			this.comboboxentry2 = global::Gtk.ComboBoxEntry.NewText();
			this.comboboxentry2.Name = "comboboxentry2";
            this.comboboxentry2.Active= 0; 
			this.fixed1.Add(this.comboboxentry2);
			global::Gtk.Fixed.FixedChild w5 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.comboboxentry2]));
			w5.X = 410;
			w5.Y = 60;
			
			// Container child fixed1.Gtk.Fixed+FixedChild
			this.button6 = new global::Gtk.Button();
			this.button6.CanFocus = true;
			this.button6.Name = "button6";
			this.button6.UseUnderline = true;
			this.button6.Label = global::Mono.Unix.Catalog.GetString("Agregar Amigo");
			this.fixed1.Add(this.button6);
			global::Gtk.Fixed.FixedChild w7 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.button6]));
			w7.X = 660;
			w7.Y = 50;
			// Container child fixed1.Gtk.Fixed+FixedChild
			this.label2 = new global::Gtk.Label();
			this.label2.Name = "label2";
			this.label2.LabelProp = global::Mono.Unix.Catalog.GetString("Amigos: ");
			this.fixed1.Add(this.label2);
			global::Gtk.Fixed.FixedChild w8 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.label2]));
			w8.X = 440;
			w8.Y = 120;
			// Container child fixed1.Gtk.Fixed+FixedChild
			this.entry4 = new global::Gtk.Entry();
			this.entry4.CanFocus = true;
			this.entry4.Name = "entry4";
			this.entry4.Text = global::Mono.Unix.Catalog.GetString("Contraseña");
			this.entry4.IsEditable = true;
			this.entry4.Visibility = false;
			this.entry4.InvisibleChar = '●';
			this.fixed1.Add(this.entry4);
			global::Gtk.Fixed.FixedChild w9 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.entry4]));
			w9.X = 60;
			w9.Y = 100;
			// Container child fixed1.Gtk.Fixed+FixedChild
			this.entry2 = new global::Gtk.Entry();
			this.entry2.CanFocus = true;
			this.entry2.Name = "entry2";
			this.entry2.Text = global::Mono.Unix.Catalog.GetString("Nombre Completo");
			this.entry2.IsEditable = true;
			this.entry2.InvisibleChar = '●';
			this.fixed1.Add(this.entry2);
			global::Gtk.Fixed.FixedChild w10 = ((global::Gtk.Fixed.FixedChild)(this.fixed1[this.entry2]));
			w10.X = 60;
			w10.Y = 150;
			this.Add(this.fixed1);
			if ((this.Child != null))
			{
				this.Child.ShowAll();
			}
			this.DefaultWidth = 808;
			this.DefaultHeight = 542;
			this.Show();
			this.button5.Clicked += new global::System.EventHandler(this.Register);
			this.button6.Clicked += new global::System.EventHandler(this.AddFriend);
		}
	}
}
