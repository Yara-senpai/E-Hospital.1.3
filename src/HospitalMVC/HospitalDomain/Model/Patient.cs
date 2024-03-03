using System;
using System.Collections.Generic;

namespace HospitalDomain.Model;

public partial class Patient : Entity
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Age { get; set; }

    public DateOnly? BirthdayDate { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual ICollection<Receipt> Receipts { get; set; } = new List<Receipt>();
}
