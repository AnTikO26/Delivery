using Delivery.Core;
using Delivery.View;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Delivery.ViewModel;

internal class MainViewModel : INotifyPropertyChanged
{
    private UserControl pg;
    public UserControl PageSource { get => pg; set => OnPropertyChanged(ref pg, value, nameof(PageSource)); }

    private NavigateService navigateService;

    public MainViewModel(NavigateService navigateService)
    {
        this.navigateService = navigateService;
        navigateService.OnPageChanged += (page) => PageSource = page;
        navigateService.ChangePage(new SortOrder());
    }

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
    