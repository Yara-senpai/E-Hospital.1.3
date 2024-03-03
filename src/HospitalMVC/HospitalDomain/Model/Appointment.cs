using System;
using System.Collections.Generic;

namespace HospitalDomain.Model;

public partial class Appointment : Entity
{
    public int Id { get; set; }

    public int? PatientId { get; set; }

    public int? DoctorId { get; set; }

    public int? HospitalId { get; set; }

    public int? Cabinet { get; set; }

    public DateTime? Date { get; set; }

    public virtual Doctor? Doctor { get; set; }

    public virtual Hospital? Hospital { get; set; }

    public virtual Patient? Patient { get; set; }
}
