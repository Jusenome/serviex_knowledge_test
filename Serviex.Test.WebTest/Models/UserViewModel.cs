using System;
using System.ComponentModel.DataAnnotations;

namespace Serviex.Test.WebTest.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Fecha de nacimiento")]
        public DateTime Date_of_birth { get; set; }

        [Required]
        [StringLength(1)]
        [Display(Name = "Género")]
        public string Gender { get; set; }
    }
}