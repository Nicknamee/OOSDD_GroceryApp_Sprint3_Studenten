using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Grocery.App.Views;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;

namespace Grocery.App.ViewModels;

public partial class LoginViewModel : BaseViewModel
{
    private readonly IAuthService _authService;
    private readonly GlobalViewModel _global;

    [ObservableProperty]
    private string email = string.Empty;

    [ObservableProperty]
    private string password = string.Empty;

    [ObservableProperty]
    private string loginMessage = string.Empty;

    public LoginViewModel(IAuthService authService, GlobalViewModel global)
    {
        _authService = authService;
        _global = global;
    }

    [RelayCommand]
    private void Login()
    {
        if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
        {
            LoginMessage = "Vul zowel e-mail als wachtwoord in.";
            return;
        }

        Client? authenticatedClient = _authService.Login(Email, Password);
        if (authenticatedClient != null)
        {
            LoginMessage = $"Welkom {authenticatedClient.Name}!";
            _global.Client = authenticatedClient;
            Application.Current.MainPage = new AppShell(); // Navigeer naar hoofdscherm
        }
        else
        {
            LoginMessage = "Ongeldige inloggegevens.";
        }
    }

    [RelayCommand]
    private void Register()
    {
        if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password))
        {
            LoginMessage = "Vul e-mail en wachtwoord in om te registreren.";
            return;
        }

        bool success = _authService.Register(Email, Password);
        if (success)
        {
            LoginMessage = "Registratie gelukt! Je kunt nu inloggen.";
        }
        else
        {
            LoginMessage = "Registratie mislukt. Gebruiker bestaat al?";
        }
    }

    [RelayCommand]
    private void Logout()
    {
        _authService.Logout();
        _global.Client = null;
        LoginMessage = "Je bent uitgelogd.";
        Application.Current.MainPage = new LoginView(); // Terug naar loginpagina
    }
}
