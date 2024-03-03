using System;
using System.Collections.Generic;

namespace HospitalDomain.Model;

public partial class Doctor : Entity
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Experience { get; set; }

    public int? SpecializationId { get; set; }

    public int? HospitalId { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual Hospital? Hospital { get; set; }

    public virtual ICollection<Receipt> Receipts { get; set; } = new List<Receipt>();

    public virtual Specialization? Specialization { get; set; }
}
