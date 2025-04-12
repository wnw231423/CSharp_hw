using System.Collections.Generic;

namespace OrderGUI.ViewModels;

public class UserSelectViewModel: ViewModelBase
{
    private IViewChange parent;
    public User SelectedUser { get; set; }
    public List<User> Users { get; set; }
    
    public UserSelectViewModel(IViewChange parent)
    {
        this.parent = parent;
        Users = new OrderService().GetUsers();
    }

    public void HandleButtonClick()
    {
        var home = new HomeViewModel(parent, SelectedUser, new OrderService());
        parent.ChangeView(home);
    }
}