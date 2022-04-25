using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using Lila.Desktop.ViewModels;
using ReactiveUI;

namespace Lila.Desktop.Views
{
    public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
    {
        public MainWindow()
        {
            this.WhenActivated(disposables => { });
            AvaloniaXamlLoader.Load(this);
        }
    }
}