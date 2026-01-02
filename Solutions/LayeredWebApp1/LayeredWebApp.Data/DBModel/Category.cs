using System;
using System.Collections.Generic;

namespace LayeredWebApp.Data.DBModel;

public partial class Category
{
    public int CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime LastUpdate { get; set; }
}
