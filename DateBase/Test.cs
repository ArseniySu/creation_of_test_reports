using System;
using System.Collections.Generic;

namespace kurs.DateBase;

public partial class Test
{
    public int Id { get; set; }

    public string Question { get; set; } = null!;

    public string RightAnswer { get; set; } = null!;

    public int UserCreateId { get; set; }

    public int ScopeApplicationId { get; set; }

    public virtual ICollection<PassingTest> PassingTests { get; set; } = new List<PassingTest>();

    public virtual ScopeApplication ScopeApplication { get; set; } = null!;

    public virtual User UserCreate { get; set; } = null!;
}
