using System;
using System.Collections.Generic;

namespace LayeredWebApp.Data.DBModel;

public partial class FilmCategory
{
    public short FilmId { get; set; }

    public short CategoryId { get; set; }

    public DateTime LastUpdate { get; set; }
}
