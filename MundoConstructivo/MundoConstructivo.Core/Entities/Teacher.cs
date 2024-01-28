using System;
using System.Collections.Generic;

namespace MundoConstructivo.Core.Entities;

public class Teacher
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string IdentityDocument { get; set; } = null!;

    public string? CellPhone { get; set; }

    public string? Email { get; set; }

    public DateTime? BirthDate { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Course> Courses { get; } = new List<Course>();
}
