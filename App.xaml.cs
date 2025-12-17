namespace TestAjourEditor
{
    public partial class App : Application
    {
		private readonly IServiceProvider? services;

		public App(IServiceProvider services)
        {
            InitializeComponent();
			this.services = services.GetService<IServiceProvider>();
		}

		protected override Window CreateWindow(IActivationState? activationState)
		{
			if (DeviceInfo.Current.Platform == DevicePlatform.WinUI ||
				DeviceInfo.Current.Platform == DevicePlatform.MacCatalyst)
			{
				Window? window = null;
				if (DeviceInfo.Current.Platform == DevicePlatform.WinUI)
				{
					window = services?.GetService<AppTitleWinUI>()!;
					window.Page = new StartupWinUI();
				}
				else
				{
					window = services?.GetService<AppTitleCatalyst>()!;
					window.Page = new StartupCatalyst();
				}
				window.Created += (sender, args) =>
				{
					Window? window = sender as Window;
					if (window != null)
					{
						string? position = Microsoft.Maui.Storage.Preferences.Get("Position", null);
						if (position != null)
						{
							string[] array = position.Split(";".ToCharArray());
							var bounds = new Rect(
								new Point(Convert.ToDouble(array[0]), Convert.ToDouble(array[1])),
								new Size(Convert.ToDouble(array[2]), Convert.ToDouble(array[3])));
							if (bounds.Width > 0 && bounds.Height > 0)
							{
								window.X = bounds.Left;
								window.Y = bounds.Top;
								window.Width = bounds.Width;
								window.Height = bounds.Height;
							}
						}
					}
				};
				window.Destroying += (sender, args) =>
				{
					Window? window = sender as Window;
					if (window != null)
					{
						string position = String.Format("{0};{1};{2};{3}",
							Convert.ToInt32(window.X),
							Convert.ToInt32(window.Y),
							Convert.ToInt32(window.Width),
							Convert.ToInt32(window.Height));
						Microsoft.Maui.Storage.Preferences.Set("Position", position);
					}
				};
				return window;
			}
			else
			{
				return new Window(new StartupMobile());
			}
		}


		/// <summary>
		/// App-to-App Deep Link support. Imports registered file types: 
		/// - from operating system to the app.
		/// - from other apps to the app.
		/// - from other instances within the same app.
		/// </summary>
		protected override async void OnAppLinkRequestReceived(Uri uri)
		{
			base.OnAppLinkRequestReceived(uri);

			await Dispatcher.DispatchAsync(async () =>
			{
				try
				{
					// Application.Current.SendOnAppLinkRequestReceived(Uri uri) method.
					// The Application.Current.SendOnAppLinkRequestReceived method is part
					// of the Microsoft.Maui.Controls namespace and is used to send an
					// app link request to this application.

					if (uri.IsFile)
					{
						var ajourEditorViewModel = Microsoft.Maui.Controls.Application.Current.Handler.GetService<Ajour.EditorLib.ViewModels.AjourEditorViewModel>();
						ajourEditorViewModel.ExecuteDeepLinkingCommand.Execute(uri.LocalPath);
					}
				}
				catch { }
			});
		}
	}
}