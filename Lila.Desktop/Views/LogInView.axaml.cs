using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using Lila.Desktop.ViewModels;
using ReactiveUI;

namespace Lila.Desktop.Views;

public partial class LogInView : ReactiveUserControl<LogInViewModel>
{
    public LogInView()
    {
        this.WhenActivated(disposables => { });
        AvaloniaXamlLoader.Load(this);
    }
}