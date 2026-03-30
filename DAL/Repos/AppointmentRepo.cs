using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class AppointmentRepo : IRepository<Appointment>, IAppointmentFeature, IAppointmentReport, IAppointmentWorkFlow
    {
        ApplicationDbContext db;
        public AppointmentRepo(ApplicationDbContext db)
        {
            this.db = db;
        }

        public bool Create(Appointment obj)
        {
            db.Appointments.Add(obj);
            return db.SaveChanges()>0;
        }

        public bool Delete(int id)
        {
            var exob=Get(id);
            db.Appointments.Remove(exob);
            return db.SaveChanges()>0;
        }

        public Appointment Get(int id)
        {
            return db.Appointments.Find(id);
        }

        public List<Appointment> Get()
        {
            return db.Appointments.ToList();
        }

        public bool Update(Appointment obj)
        {
            var exob = Get(obj.AppointmentId);
            db.Entry(exob).CurrentValues.SetValues(obj);
            return db.SaveChanges()>0;
        }
        public List<Appointment> FilterByStatus(string status)
        {
            return db.Appointments
                     .Where(a => a.Status == status)
                     .ToList();
        }
        public List<Appointment> FilterByDate(DateTime date)
        {
            return db.Appointments
                     .Where(a => a.AppointmentDate.Date == date.Date)
                     .ToList();
        }
        public List<Appointment> FilterByUser(int userId)
        {
            return db.Appointments
                     .Where(a => a.UserId == userId)
                     .ToList();
        }
        public List<Appointment> FilterByProfessional(int professionalId)
        {
            return db.Appointments
                     .Where(a => a.ProfessionalId == professionalId)
                     .ToList();
        }
        public int TotalAppointments()
        {
            return db.Appointments.Count();
        }

        public List<object> AppointmentCountByStatus()
        {
            var res = db.Appointments.GroupBy(a => a.Status).Select(g => new
            {
                Status = g.Key,
                Total = g.Count()
            }).ToList<object>();
            return res;
        }

        public List<object> AppointmentCountByProfessional()
        {
            var res = db.Appointments.GroupBy(a => a.ProfessionalId).Select(g => new
            {
               ProfessionalId = g.Key,
                Total = g.Count()
            }).ToList<object>();
            return res;
        }

        public int AutoUpdateStatus()
        {
            var today = DateTime.Today;
            var appointments = db.Appointments.ToList();

            foreach(var a in appointments)
            {
                if (a.AppointmentDate.Date < today)
                    a.Status = "Completed";
                else if (a.AppointmentDate.Date > today)
                    a.Status = "Upcoming";
            }
            return db.SaveChanges();
        }
    }
}