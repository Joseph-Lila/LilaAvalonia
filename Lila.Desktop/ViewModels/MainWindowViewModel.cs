using System;
using System.Reactive;
using System.Windows.Input;
using Avalonia.Interactivity;
using Lila.Desktop.ViewModels;
using ReactiveUI;

namespace Lila.Desktop.ViewModels
{
    public class MainWindowViewModel : ReactiveObject, IScreen
    {
        public RoutingState Router { get; } = new RoutingState();
        public ReactiveCommand<Unit, IRoutableViewModel> GoLogIn { get; }
        public MainWindowViewModel()
        {
            GoLogIn = ReactiveCommand.CreateFromObservable(
                () =>
                {
                    Router.NavigationStack.Clear();
                    return Router.Navigate.Execute(new LogInViewModel(this));
                });
        }
    }
}