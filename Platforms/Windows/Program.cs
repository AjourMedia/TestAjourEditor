using Microsoft.UI.Dispatching;

namespace TestAjourEditor.WinUI
{
	static class Program
	{
		[STAThread]
		static void Main()
		{
			WinRT.ComWrappersSupport.InitializeComWrappers();

			Microsoft.UI.Xaml.Application.Start((p) =>
			{
				DispatcherQueue dispatcherQueue = DispatcherQueue.GetForCurrentThread();
				var context = new DispatcherQueueSynchronizationContext(dispatcherQueue);
				SynchronizationContext.SetSynchronizationContext(context);
				_ = new App();
			});
		}
	}
}
