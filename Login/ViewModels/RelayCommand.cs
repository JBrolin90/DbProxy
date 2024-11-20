using System;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Login.ViewModels;

public class RelayCommand(Action<object?> execute, Func<object?, bool>? canExecute = null) : ICommand
{
    public event EventHandler? CanExecuteChanged;
    private readonly Action<object?> execute = execute;
    private readonly Func<object?, bool>? canExecute = canExecute;

    public void OnCanExecuteChanged()
    {
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }

    public bool CanExecute(object? parameter)
    {
        return canExecute == null ? true : canExecute(parameter);
    }

    public void Execute(object? parameter)
    {
        execute?.Invoke(parameter);
    }
    public async void ExecuteAsync(object? parameter)
    {
        await Task.Run(() => execute(parameter));
    }
}
