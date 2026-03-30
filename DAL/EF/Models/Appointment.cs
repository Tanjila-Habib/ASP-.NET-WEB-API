using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.EF.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int ProfessionalId { get; set; }

        [Required]
        public DateTime AppointmentDate { get; set; }

        [Required]
        public TimeSpan AppointmentTime { get; set; }

        [Required]
        [MaxLength(20)]
        public string Status { get; set; } = "Pending";

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // 🔹 Navigation Properties
        [ForeignKey("UserId")]
        public User ? User { get; set; }

        [ForeignKey("ProfessionalId")]
        public Professional ? Professional { get; set; }
    }
}
