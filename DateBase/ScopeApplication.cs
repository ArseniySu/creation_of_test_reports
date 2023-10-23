using System;
using System.Collections.Generic;

namespace kurs.DateBase;

public partial class ScopeApplication
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public virtual ICollection<Test> Tests { get; set; } = new List<Test>();
}
