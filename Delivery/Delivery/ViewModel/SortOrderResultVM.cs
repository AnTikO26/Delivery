using Delivery.Core;
using Delivery.Model;
using Delivery.View;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Delivery.ViewModel;

internal class SortOrderResultVM : INotifyPropertyChanged
{
    private Order selectedOrder = new Order();
    public Order SelectedOrder { get => selectedOrder; set => OnPropertyChanged(ref selectedOrder, value, nameof(Order)); }

    private ObservableCollection<Order> orders;
    public ObservableCollection<Order> Orders { get => orders; set => OnPropertyChanged(ref orders, value, nameof(Orders)); }

    private NavigateService navigatedService;
    private CommandController command;
    private DatabaseController databaseController;

    public SortOrderResultVM(NavigateService navigateService, CommandController command, DatabaseController databaseController)
    {
        this.navigatedService = navigateService;
        this.command = command;
        this.databaseController = databaseController;

        command.Subscribe<OrderFilter>(CommandController.Command.sort_patient, this, SortOrders);
    }

    private async void SortOrders(OrderFilter filter)
    {
        Orders = new ObservableCollection<Order>(await databaseController.SearchPatients(filter));
    }

    private RelayCommand back;
    public RelayCommand Back => back
           ??= new RelayCommand(() =>
           {
               navigatedService.ChangePage(new SortOrder());
           });

    #region INotifyPropertyChanged

    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged<T>(ref T propertyFiled, T newValue, string propertyName = null)
    {
        if (!object.Equals(propertyFiled, newValue))
        {
            propertyFiled = newValue;
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    #endregion
}
