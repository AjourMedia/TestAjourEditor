using Ajour.EditorLib.ViewModels;

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
			Window? window = null;
			/* optional
			if (DeviceInfo.Current.Idiom == DeviceIdiom.Desktop)
			{
				if (DeviceInfo.Current.Platform == DevicePlatform.WinUI)
				{
					window = services?.GetService<AppTitleWinUI>()!;
					window.Page = new AppShell();
				}
				else if (DeviceInfo.Current.Platform == DevicePlatform.MacCatalyst)
				{
					window = Microsoft.Maui.Controls.Application.Current?.Handler.GetService<AppTitleCatalyst>()!;
					window.Page = new AppShell();
				}
			}
			else
			*/
			{
				window = new Window(new AppShell());
			}
			
			window.Created += (sender, args) =>
			{
				if (DeviceInfo.Current.Platform == DevicePlatform.WinUI ||
					DeviceInfo.Current.Platform == DevicePlatform.MacCatalyst)
				{
					Window? win = sender as Window;
					if (win != null)
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
								win.X = bounds.Left;
								win.Y = bounds.Top;
								win.Width = bounds.Width;
								win.Height = bounds.Height;
							}
						}
					}
				}

				AjourEditorViewModel viewModel = Microsoft.Maui.Controls.Application.Current.Handler.GetService<AjourEditorViewModel>();
				viewModel.m_email_to = "post@ajourpanorama.com";
				viewModel.m_subject_to = "A message to Ajour Media/Morten Ellingsen";
			};
			
			window.Destroying += (sender, args) =>
			{
				if (DeviceInfo.Current.Platform == DevicePlatform.WinUI ||
					DeviceInfo.Current.Platform == DevicePlatform.MacCatalyst)
				{
					Window? win = sender as Window;
					if (win != null)
					{
						string position = String.Format("{0};{1};{2};{3}",
							Convert.ToInt32(win.X),
							Convert.ToInt32(win.Y),
							Convert.ToInt32(win.Width),
							Convert.ToInt32(win.Height));
						Microsoft.Maui.Storage.Preferences.Set("Position", position);
					}
				}
			};
			
			return window;
		}
	}
}