using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class ProfessionalRepo : IRepository<Professional>, IProfessionalFeature, IProfessionalStatus, IProfessionalReport
    {
        ApplicationDbContext db;
        public ProfessionalRepo(ApplicationDbContext db)
        {
            this.db = db;
        }

        public bool Create(Professional obj)
        {
            db.Professionals.Add(obj);
            return db.SaveChanges() >0;        
        }

        public bool Delete(int id)
        {
            var exob = Get(id);
            db.Professionals.Remove(exob);
            return db.SaveChanges() > 0;
        }

        public Professional Get(int id)
        {
            return db.Professionals.Find(id);
        }

        public List<Professional> Get()
        {
            return db.Professionals.ToList();
        }

        public bool Update(Professional obj)
        {
            var exob = Get(obj.ProfessionalId);
            db.Entry(exob).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
        public List<Professional> GetBySpecialization(string specialization)
        {
            var res = db.Professionals
                 .Where(p => p.Specialization == specialization)
                 .ToList();
            return res;
        }

        public List<Professional> GetActive()
        {
            var res=db.Professionals
                .Where(p => p.IsActive)
                .ToList();
            return res;
        }
        public int TotalProfessionals()
        {
            return db.Professionals.Count();
        }
    }
}
