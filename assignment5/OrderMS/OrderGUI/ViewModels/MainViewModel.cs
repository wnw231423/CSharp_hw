using OrderCLI;
using OrderCLI.entity;

namespace OrderGUI.ViewModels;

public class MainViewModel: ViewModelBase
{
    // navigation
    private INavigation _navigation;
    public INavigation Navigation
    {
        get => _navigation;
        set => SetProperty(ref _navigation, value);
    }
    
    // service
    private OrderService _service;
    public OrderService Service
    {
        get => _service;
        set => SetProperty(ref _service, value);
    }
    
    // constructor
    public MainViewModel(INavigation w, User user)
    {
        Navigation = w;
        Service = new OrderService(user);
    }
}