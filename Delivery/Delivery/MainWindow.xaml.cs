using Delivery.ViewModel;
using System.Windows;

namespace Delivery;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        var val = DataContext as MainViewModel;
    }
}
