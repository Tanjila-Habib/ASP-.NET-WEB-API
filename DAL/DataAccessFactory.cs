using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using DAL.Repos;

namespace DAL
{
    public class DataAccessFactory
    {
        ApplicationDbContext db;
        public DataAccessFactory(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IRepository<Appointment> AppointmentData()
        {
            return new AppointmentRepo(db);
        }
        public IRepository<User>UserData()
        {
            return new UserRepo(db); 
        }
        public IRepository<Professional>ProfessionalData()
        {  return new ProfessionalRepo(db);
        }
        public IAppointmentFeature AppointmentFeature()
        {
            return new AppointmentRepo(db);
        }
        public IAppointmentReport AppointmentReport()
        {
            return new AppointmentRepo(db);
        }
        public IAppointmentWorkFlow AppointmentWorkFlow()
        {
            return new AppointmentRepo(db); 
        }
        public IUserFeature UserFeature()
        {
            return new UserRepo(db);
        }
        public IUserReport UserReport()
        {
            return new UserRepo(db);
        }
        public IProfessionalFeature ProfessionalFeature()
        {
            return new ProfessionalRepo(db);
        }
        public IProfessionalStatus ProfessionalStatus()
        {
            return new ProfessionalRepo(db);
        }
        public IProfessionalReport ProfessionalReport()
        {
            return new ProfessionalRepo(db);
        }


    }

}

