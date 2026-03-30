using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class AppointmentDTO
    {
        public int AppointmentId { get; set; }

        public int UserId { get; set; }
        public int ProfessionalId { get; set; }

        public DateTime AppointmentDate { get; set; }
        public TimeSpan AppointmentTime { get; set; }

        public string ? Status { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
