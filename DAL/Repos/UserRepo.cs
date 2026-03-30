using DAL.EF;
using DAL.EF.Models;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class UserRepo : IRepository<User>, IUserFeature, IUserReport
    {
        ApplicationDbContext db;
        public UserRepo(ApplicationDbContext db)
        {
            this.db= db;
        }
        public bool Create(User obj)
        {
            db.Users.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var exob = Get(id);
            db.Users.Remove(exob);
            return db.SaveChanges() > 0;
        }

        public User Get(int id)
        {
            return db.Users.Find(id);
        }

        public List<User> Get()
        {
            return db.Users.ToList();
        }

       

        public bool Update(User obj)
        {
            var exob = Get(obj.UserId);
            db.Entry(exob).CurrentValues.SetValues(obj);
            return db.SaveChanges() > 0;
        }
        public User GetByEmail(string email)
        {
            return db.Users.FirstOrDefault(u => u.Email == email);
            
        }

        public int TotalUser()
        {
            return db.Users.Count();
        }

        public int UserCreatedToday()
        {
            var today = DateTime.Today;
            var data = db.Users.Count(u => u.CreatedAt.Date == today);
            return data;
        }
    }
}
