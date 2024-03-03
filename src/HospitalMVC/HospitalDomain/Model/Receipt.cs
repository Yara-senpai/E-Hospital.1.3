using System;
using System.Collections.Generic;

namespace HospitalDomain.Model;

public partial class Receipt : Entity
{
    public int Id { get; set; }

    public string? Information { get; set; }

    public DateTime? Date { get; set; }

    public int? DoctorId { get; set; }

    public int? PatientId { get; set; }

    public virtual Doctor? Doctor { get; set; }

    public virtual Patient? Patient { get; set; }
}
