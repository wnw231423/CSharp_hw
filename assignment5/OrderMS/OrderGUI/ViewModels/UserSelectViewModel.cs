using System.Collections.Generic;
using OrderCLI.entity;

namespace OrderGUI.ViewModels;

public class UserSelectViewModel: ViewModelBase
{
    // navigation
    private INavigation Navigation { get; }

    //set => SetProperty(ref _navigation, value);
    // combo box
    private List<User> _users;
    private User _selectedUser;
    public List<User> Users
    {
        get => _users;
        set => SetProperty(ref _users, value);
    }
    public User SelectedUser
    {
        get => _selectedUser;
        set => SetProperty(ref _selectedUser, value);
    }
    
    // button
    public void HandleButtonClick()
    {
        Navigation.NavigateTo(View.Main, SelectedUser);
    }
    

    // constructor
    public UserSelectViewModel(INavigation w)
    {
        Navigation = w;
        _users = User.Users;
        _selectedUser = _users[0];
    }
}