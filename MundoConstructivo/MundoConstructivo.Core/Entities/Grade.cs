using System;
using System.Collections.Generic;

namespace MundoConstructivo.Core.Entities;

public class Grade
{
    public int Id { get; set; }

    public int Score { get; set; }

    public int? StudentId { get; set; }

    public int? CourseId { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? UpdatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual Course? Course { get; set; }

    public virtual Student? Student { get; set; }
}
