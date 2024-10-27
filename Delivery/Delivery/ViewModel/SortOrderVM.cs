using Delivery.Core;
using Delivery.Model;
using Delivery.View;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace Delivery.ViewModel;

public class SortOrderVM : INotifyPropertyChanged
{
    private OrderFilter orderFilter = new OrderFilter();
    public OrderFilter OrderFilter { get => orderFilter; set => OnPropertyChanged(ref orderFilter, value, nameof(OrderFilter)); }
    


    private NavigateService navigatedService;
    private CommandController command;
    private LogWriter logWriter;

    public SortOrderVM(NavigateService navigateService, CommandController command, LogWriter logWriter)
    {
        this.navigatedService = navigateService;
        this.command = command;
        this.logWriter = logWriter;
    }

    private RelayCommand sort;
    public RelayCommand Sort => sort
           ??= new RelayCommand(() =>
           {
               if (!orderFilter.Validate())
               {
                   MessageBox.Show("Вы не заполнили критерии сортировки или неправильно ввели дату");
                   return;
               }

               logWriter.WriteLog($"Сортировка заказов по данным параметрам: Район - {orderFilter.District}, Время доставки - {orderFilter.DateOrder}");
               command.Publish(CommandController.Command.sort_patient, orderFilter);
               navigatedService.ChangePage(new SortOrderResult());
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
