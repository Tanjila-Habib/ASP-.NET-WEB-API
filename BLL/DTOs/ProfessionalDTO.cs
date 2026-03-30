using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class ProfessionalDTO
    {
        public int ProfessionalId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Specialization { get; set; } = string.Empty;
        public TimeSpan AvailableFrom { get; set; }
        public TimeSpan AvailableTo { get; set; }

        public bool IsActive { get; set; } = true;

    }
}
