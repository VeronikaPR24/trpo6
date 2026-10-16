using System;
using System.Collections.Generic;

namespace практика_6.Models;

public partial class Training
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Trainer { get; set; } = null!;

    public int DurationMinutes { get; set; }

    public decimal Price { get; set; }

    public bool IsActive { get; set; }
}
