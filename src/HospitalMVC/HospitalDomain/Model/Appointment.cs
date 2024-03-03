using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospitalDomain.Model;

public partial class Appointment : Entity
{
    public int Id { get; set; }

    public int? PatientId { get; set; }

    public int? DoctorId { get; set; }

    public int? HospitalId { get; set; }

    [Display(Name ="Номер кабінету")]
    public int? Cabinet { get; set; }

    [Display(Name = "Дата")]
    public DateTime? Date { get; set; }

    [Display(Name = "Лікар")]
    public virtual Doctor? Doctor { get; set; }

    [Display(Name = "Лікарня")]
    public virtual Hospital? Hospital { get; set; }

    [Display(Name = "Пацієнт")]
    public virtual Patient? Patient { get; set; }
}
