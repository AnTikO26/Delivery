using System;
using System.ComponentModel;
using System.Windows.Controls;

namespace Delivery.Core;

public class NavigateService
{
    public event Action<UserControl> OnPageChanged;

    public void ChangePage(UserControl page)
    {
        OnPageChanged?.Invoke(page);
    }
}
