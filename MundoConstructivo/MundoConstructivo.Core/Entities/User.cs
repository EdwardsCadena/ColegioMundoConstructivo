using System;
using System.Collections.Generic;

namespace MundoConstructivo.Core.Entities;

public partial class User
{
    public int Id { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public DateTime? DateCreation { get; set; }
}
