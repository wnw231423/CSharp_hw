using OrderCLI.entity;

namespace OrderGUI.ViewModels;

public class MainWindowViewModel : ViewModelBase, INavigation
{
    // display view
    private ViewModelBase _selectedViewModel;
    public ViewModelBase SelectedViewModel
    {
        get => _selectedViewModel;
        set => SetProperty(ref _selectedViewModel, value);
    }

    private void ChangeView(ViewModelBase viewModel)
    {
        SelectedViewModel = viewModel;
    }


    // constructor
    public MainWindowViewModel()
    {
        // add some user for test
        User t = new User(1, "Tester", true);
        User b = new User(2, "Bob", false);
        User.Users.Add(t);
        User.Users.Add(b);
        
        SelectedViewModel = new UserSelectViewModel(this);
    }
    
    // implement INavigation
    public void NavigateTo(View v, object? parameter = null)
    {
        switch (v)
        {
            case View.UserSelect:
                ChangeView(new UserSelectViewModel(this));
                break;
            case View.Main:
                var user = parameter as User;
                if (user != null)
                {
                    ChangeView(new MainViewModel(this, user));
                }
                break;
        }
    }
}