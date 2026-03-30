using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.EF.Models
{
    public class Professional
    {
        [Key]
        public int ProfessionalId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Specialization { get; set; } = string.Empty;

        public TimeSpan AvailableFrom { get; set; }
        public TimeSpan AvailableTo { get; set; }

        public bool IsActive { get; set; } = true;

        // Navigation Property (optional but recommended)
        public ICollection<Appointment>? Appointments { get; set; }
    }
}
