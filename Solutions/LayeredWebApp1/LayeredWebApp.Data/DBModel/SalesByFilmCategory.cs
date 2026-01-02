using System;
using System.Collections.Generic;

namespace LayeredWebApp.Data.DBModel;

public partial class SalesByFilmCategory
{
    public string? Category { get; set; }

    public decimal? TotalSales { get; set; }
}
