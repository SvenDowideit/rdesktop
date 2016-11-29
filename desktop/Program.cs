using System;
using Gtk;
using Gdk;

namespace desktop
{
	class MainClass : Gtk.Window
	{
		public static void Main(string[] args)
		{
			Application.Init();
			MainClass win = new MainClass();
			//MainWindow win = new MainWindow();
			//win.Show();
			Application.Run();
		}

		// from https://huseyincakir.wordpress.com/2015/02/19/mono-gtksharp-application-at-taskbar/
		// docs at http://www.mono-project.com/docs/gui/gtksharp/widgets/notification-icon/
		private static StatusIcon trayIcon;

		public MainClass() : base("monoGTK_Test")
		{
			trayIcon = new StatusIcon(Gdk.Pixbuf.LoadFromResource("desktop.rancher.ico"));
			trayIcon.Visible = true;
			trayIcon.PopupMenu += OnTrayIconPopup;
			trayIcon.Tooltip = "Rancher Desktop";

			this.SetSizeRequest(300, 300);
			//this.ShowAll();
		}
		static void OnTrayIconPopup(object o, EventArgs args)
		{
			Menu popupMenu = new Menu();

			ImageMenuItem menuItemQuit = new ImageMenuItem("QUIT");
			Gtk.Image imgmenuItemQuit = new Gtk.Image(Stock.Quit, IconSize.Menu);
			menuItemQuit.Image = imgmenuItemQuit;

			ImageMenuItem menuItemTIME = new ImageMenuItem("CHK NOW!");
			Gtk.Image imgmenuItemTIME = new Gtk.Image(Stock.Stop, IconSize.Menu);
			menuItemTIME.Image = imgmenuItemTIME;

			popupMenu.Add(menuItemQuit);

			popupMenu.Add(menuItemTIME);
			menuItemQuit.Activated += delegate { Application.Quit(); };

			menuItemTIME.Activated += new EventHandler(menuItemTIME_Activated);
			popupMenu.ShowAll();
			popupMenu.Popup();
		}
		static void menuItemTIME_Activated(object sender, EventArgs e)
		{
			Console.WriteLine("menuItemTIME_Activated");
		}
	}
}