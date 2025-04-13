global using OrderCLI.Models;
global using OrderCLI.Services;
using CommunityToolkit.Mvvm.ComponentModel;

namespace OrderGUI.ViewModels;

public partial class MainWindowViewModel : ViewModelBase, IViewChange
{
    [ObservableProperty] 
    private ViewModelBase _current;

    public MainWindowViewModel()
    {
        Current = new UserSelectViewModel(this);
    }

    public void ChangeView(ViewModelBase view)
    {
        Current = view;
    }
}