﻿namespace TestAjourEditor
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
	}
}