namespace OrderGUI.ViewModels;

// this interface is for navigation between different views in a window
// any window who needs to change view should implement this interface
// and pass itself to views so that these views can access and call
// window's change view method
public interface INavigation
{
    void NavigateTo(View v, object? parameter = null);
}