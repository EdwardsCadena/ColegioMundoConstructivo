using System;
using System.Collections.Generic;

namespace MundoConstructivo.Core.Entities;

public class Course
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? TeacherId { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Grade> Grades { get; } = new List<Grade>();

    public virtual Teacher? Teacher { get; set; }
}
