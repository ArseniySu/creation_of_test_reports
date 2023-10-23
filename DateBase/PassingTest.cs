using System;
using System.Collections.Generic;

namespace kurs.DateBase;

public partial class PassingTest
{
    public int UsersId { get; set; }

    public int TestsId { get; set; }

    public string UserResponse { get; set; } = null!;

    public DateTime DatePasses { get; set; }

    public virtual Test Tests { get; set; } = null!;

    public virtual User Users { get; set; } = null!;
}
