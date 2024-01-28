using System;
using System.Collections.Generic;

namespace MundoConstructivo.Core.Dtos;

public partial class StudentDTOs
{

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string IdentityDocument { get; set; } = null!;

    public string? CellPhone { get; set; }

    public string? Email { get; set; }

    public DateTime? BirthDate { get; set; }


}
