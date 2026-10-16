using System;
using System.Collections.Generic;

namespace практика_6.Models;

public partial class Furniture
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Material { get; set; } = null!;

    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public bool IsAvailable { get; set; }
}
