using System;
using System.Collections.Generic;

namespace kurs.DateBase;

public partial class User
{
    public int Id { get; set; }

    public string Fname { get; set; } = null!;

    public string Sname { get; set; } = null!;

    public string? Mname { get; set; }

    public int GruppaId { get; set; }

    public DateTime DateBirth { get; set; }

    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int GenderId { get; set; }

    public virtual Gender Gender { get; set; } = null!;

    public virtual Gruppa Gruppa { get; set; } = null!;

    public virtual ICollection<PassingTest> PassingTests { get; set; } = new List<PassingTest>();

    public virtual ICollection<Test> Tests { get; set; } = new List<Test>();
}
