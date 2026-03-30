using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IAppointmentFeature
    {
        List<Appointment> FilterByStatus(string status);
        List<Appointment> FilterByDate(DateTime date);
        List<Appointment> FilterByUser(int userId);
        List<Appointment> FilterByProfessional(int professionalId);
    }
}
