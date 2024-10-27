using System;

namespace Delivery.Model;

public class OrderFilter
{
    public string? District { get; set; }
    public DateTime DateOrder { get; set; }

    public bool Validate()
    {
        if (!string.IsNullOrEmpty(District) && DateOrder != new DateTime(01, 01, 0001, 00, 00, 00)) return true;

        return false;
    }
}
