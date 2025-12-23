using System;
using System.Collections.Generic;

namespace lb_shoe_store.Models;

public partial class Measure
{
    public int Id { get; set; }

    public string MeasureName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
