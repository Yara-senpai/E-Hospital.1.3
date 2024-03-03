using System;
using System.Collections.Generic;

namespace HospitalDomain.Model;

public partial class Hospital : Entity
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Adress { get; set; }

    public int? NumberOfDoctors { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
}
