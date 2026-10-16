using System;
using System.Collections.Generic;

namespace практика_6.Models;

public partial class Game
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Genre { get; set; } = null!;

    public decimal Price { get; set; }

    public int AgeRating { get; set; }

    public bool IsAvailable { get; set; }
}
