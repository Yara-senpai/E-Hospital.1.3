using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospitalDomain.Model;

public partial class Doctor : Entity
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Поле повинне бути заповненим")]
    [Display(Name = "ПІБ")]
    public string? Name { get; set; }

    [Display(Name = "Років стажу")]
    public int? Experience { get; set; }

    [Display(Name = "Спеціалізація")]
    public int? SpecializationId { get; set; }

    [Display(Name = "Місце роботи")]
    public int? HospitalId { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    [Display(Name = "Місце роботи")]
    public virtual Hospital? Hospital { get; set; }

    public virtual ICollection<Receipt> Receipts { get; set; } = new List<Receipt>();

    [Display(Name = "Спеціалізація")]
    public virtual Specialization? Specialization { get; set; }
}
