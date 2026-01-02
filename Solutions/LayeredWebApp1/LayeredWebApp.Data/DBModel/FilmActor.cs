using System;
using System.Collections.Generic;

namespace LayeredWebApp.Data.DBModel;

public partial class FilmActor
{
    public short ActorId { get; set; }

    public short FilmId { get; set; }

    public DateTime LastUpdate { get; set; }
}
