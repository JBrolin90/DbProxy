using Avalonia.Controls;
using Login.ViewModels;

namespace Login;

public partial class LoginWindow : Window
{
    LoginViewModel viewModel = new();
    public LoginWindow()
    {
        DataContext = viewModel;
        InitializeComponent();
    }
}