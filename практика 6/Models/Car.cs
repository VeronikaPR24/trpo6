using System;
using System.Collections.Generic;

namespace практика_6.Models;

public partial class Car
{
    public int Id { get; set; }

    public string Brand { get; set; } = null!;

    public string Model { get; set; } = null!;

    public int ReleaseYear { get; set; }

    public decimal Price { get; set; }

    public bool IsAvailable { get; set; }
}
