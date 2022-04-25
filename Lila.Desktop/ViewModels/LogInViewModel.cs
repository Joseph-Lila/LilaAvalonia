using ReactiveUI;

namespace Lila.Desktop.ViewModels;

public class LogInViewModel : ReactiveObject, IRoutableViewModel
{
    public IScreen HostScreen { get; }
    public string UrlPathSegment => "/logIn";
    public LogInViewModel(IScreen screen) => HostScreen = screen;
}