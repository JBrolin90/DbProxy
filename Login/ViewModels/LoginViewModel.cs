using System;
using Avalonia.Markup.Xaml.MarkupExtensions;
using Login.Models;

namespace Login.ViewModels;

public class LoginViewModel : ObservableObject
{
    private DatabaseModel databaseModel = new();
    private string _server = string.Empty;
    private string _database = string.Empty;
    private string _username = string.Empty;
    private string _password = string.Empty;
    private string _message = "I wish you a good login experience!";
    public RelayCommand LoginCommand { get; }

    public LoginViewModel()
    {
        LoginCommand = new RelayCommand(Login, CanLogin);
    }

    public void OnTextChanged()
    {
        LoginCommand.OnCanExecuteChanged();
    }

    public bool CanLogin(object? parameter)
    {
        return !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password);
    }

    public void Login(object? parameter)
    {
        databaseModel.Login(new CredentialsModel()
        {
            Server = Server,
            Database = Database,
            Username = Username,
            Password = Password
        });
        if (Username == "admin" && Password == "admin")
        {
            Message = "Login successful!";
        }
        else
        {
            Message = "Login failed!";
        }
    }

    public string Server
    {
        get => _server;
        set
        {
            if (_server != value)
            {
                OnPropertyChanging(nameof(Server));
                _server = value;
                OnPropertyChanged(nameof(Server));
                OnTextChanged();
            }
        }
    }
    public string Database
    {
        get => _database;
        set
        {
            if (_database != value)
            {
                OnPropertyChanging(nameof(Database));
                _database = value;
                OnPropertyChanged(nameof(Database));
                OnTextChanged();
            }
        }
    }
    public string Username
    {
        get => _username;
        set
        {
            if (_username != value)
            {
                OnPropertyChanging(nameof(Username));
                _username = value;
                OnPropertyChanged(nameof(Username));
                OnTextChanged();
            }
        }
    }
    public string Password
    {
        get => _password;
        set
        {
            if (_password != value)
            {
                OnPropertyChanging(nameof(Password));
                _password = value;
                OnPropertyChanged(nameof(Password));
                OnTextChanged();
            }
        }
    }
    public string Message
    {
        get => _message;
        set
        {
            if (_message != value)
            {
                OnPropertyChanging(nameof(Message));
                _message = value;
                OnPropertyChanged(nameof(Message));
            }
        }
    }



}
