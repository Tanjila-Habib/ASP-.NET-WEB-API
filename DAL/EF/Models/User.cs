using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.EF.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [MaxLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        public string PhoneNumber { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

       
        public ICollection<Appointment>? Appointments { get; set; }
    }
}
