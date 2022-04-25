using System;
using System.ComponentModel.DataAnnotations;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using ReactiveUI;
using ReactiveCommand = Reactive.Bindings.ReactiveCommand;

namespace Lila.Desktop.ViewModels;

public class LogInViewModel : ReactiveObject, IRoutableViewModel
{
    public IScreen HostScreen { get; }
    public string UrlPathSegment => "/logIn";
    public ReactiveProperty<string> TxtBoxLogIn { get; }
    public ReactiveProperty<string> TxtBoxPassword { get; }
    public ReactiveCommand BtnSignUp { get; }

    public LogInViewModel(IScreen screen)
    {
        HostScreen = screen;
        TxtBoxLogIn = new ReactiveProperty<string>()
            .SetValidateNotifyError(x => string.IsNullOrEmpty(x) ? "Invalid value" : null);
        TxtBoxPassword = new ReactiveProperty<string>()
            .SetValidateNotifyError(x => string.IsNullOrEmpty(x) ? "Invalid value" : null);
        BtnSignUp = new[]
            {
                TxtBoxLogIn.ObserveHasErrors,
                TxtBoxPassword.ObserveHasErrors,
            }
            .CombineLatestValuesAreAllFalse()
            .ToReactiveCommand()
            .WithSubscribe(() => { Console.WriteLine("poki"); });
    }

    public void BtnLogIn()
    {
        Console.WriteLine("Wow");
        // choose role functionality
    }

    public void BtnGetPassword()
    {
        // go to get password screen
    }
}