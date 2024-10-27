using System;

namespace Delivery.Model;

public class Order
{
    public int Id { get; set; }
    public string? NumberOrder { get; set; }
    public float Kg {  get; set; }
    public string? District { get; set; }
    public DateTime DateOrder { get; set; }
}
