using System;
using System.Collections.Generic;

namespace WebApp.model;

public partial class Producer
{
    public int Id { get; set; }

    public string Fuldenavn { get; set; } = null!;

    public virtual ICollection<Film> Films { get; set; } = new List<Film>();
}
