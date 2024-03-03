using System;
using System.Collections.Generic;

namespace HospitalDomain.Model;

public partial class Specialization : Entity
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
}
