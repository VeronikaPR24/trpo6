using System;
using System.Collections.Generic;

namespace практика_6.Models;

public partial class Device
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Manufacturer { get; set; } = null!;

    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public bool IsActive { get; set; }
}
