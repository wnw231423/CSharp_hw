using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace OrderGUI.ViewModels;

public partial class HomeViewModel: ViewModelBase
{
    IViewChange Parent { get; set; }
    User CurrentUser { get; set; }
    OrderService Service { get; set; }
    
    [ObservableProperty]
    private ObservableCollection<Order> _orders;

    [ObservableProperty] 
    private Order _selectedOrder;

    // for query
    public string SelectedCondition { get; set; }
    public string Condition { get; set; }
    
    public HomeViewModel(IViewChange parent, User currentUser, OrderService sercice)
    {
        Parent = parent;
        CurrentUser = currentUser;
        Service = sercice;
        if (!CurrentUser.IsAdmin)
        {
          Orders = new ObservableCollection<Order>(Service.SelectOrderByUserName(currentUser.Name));
        }
        else
        {
          Orders = new ObservableCollection<Order>(Service.GetOrders());
        }
    }
}