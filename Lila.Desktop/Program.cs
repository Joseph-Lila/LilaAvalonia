using Avalonia;
using Avalonia.ReactiveUI;
using Lila.Desktop.ViewModels;
using Lila.Desktop.Views;
using ReactiveUI;
using Splat;


namespace Lila.Desktop
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            string logPath = projectDirectory + "/Lila.UI/DataSources/logs.txt";
            string sqliteDb = $"Data source={projectDirectory}/Lila.UI/DataSources/SqLite/sqlite.db";
            string csvBeginPath = projectDirectory + "/Lila.UI/DataSources/CSV/";
            BuildAvaloniaApp().Start<MainWindow>(
                () => new MainWindowViewModel()
                );
        }
        public static AppBuilder BuildAvaloniaApp()
        {
            Locator.CurrentMutable.Register(() => new LogInView(), typeof(IViewFor<LogInViewModel>));

            return AppBuilder
                .Configure<App>()
                .UseReactiveUI()
                .UsePlatformDetect()
                .LogToTrace();
        }
    }
}