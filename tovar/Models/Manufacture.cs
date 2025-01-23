using System;
using System.Collections.Generic;

namespace tovar.Models;

public partial class Manufacture
{
    public int ManufactureId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
