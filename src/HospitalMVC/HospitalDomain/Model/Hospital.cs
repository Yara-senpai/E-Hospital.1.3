using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HospitalDomain.Model;

public partial class Hospital : Entity
{
    public int Id { get; set; }

    [Required(ErrorMessage ="Поле повинне бути заповненим")]
    [Display(Name = "Назва лікарні")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Поле повинне бути заповненим")]
    [Display(Name = "Адреса")]
    public string? Adress { get; set; }

    [Display(Name = "Кількість лікарів")]
    public int? NumberOfDoctors { get; set; }

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
}
