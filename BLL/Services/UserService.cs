using BLL.DTOs;
using DAL;
using DAL.EF.Models;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService
    {
        DataAccessFactory factory;
        INotification notification;
        public UserService(DataAccessFactory factory, INotification notification)
        {
            this.factory = factory;
            this.notification = notification;
        }
        public List<UserDTO>All()
        {

            var data = factory.UserData().Get();
            var ret=MapperConfig.GetMapper().Map<List<UserDTO>>(data);
            return ret;
        }
        public UserDTO Get(int id)
        {
            User Data=factory.UserData().Get(id);
            UserDTO ret=MapperConfig.GetMapper().Map<UserDTO>(Data);
            return ret;

        }
        public string Create(UserCreateDTO dto)
        {
            var user = MapperConfig.GetMapper().Map<User>(dto);

            var result = factory.UserData().Create(user);

            if (result)
            {
                notification.Notify($"New user created: {user.FullName}");
                return "User is created";
            }
            return "Failed to create user ";
        }
        public bool Update(UserDTO dto)
        {
            var data=MapperConfig.GetMapper().Map<User>(dto);
            return factory.UserData().Update(data);
        }
        public bool Delete(int id)
        {  return factory.UserData().Delete(id); 
        }
        public UserDTO GetByEMail(string email)
        {
            var data = factory.UserFeature().GetByEmail(email);
            return MapperConfig.GetMapper().Map<UserDTO>(data);
        }
        public int TotalUsers()
        {
            var data = factory.UserReport().TotalUser();
                return data;
        }
        public int UserCreatedToday()
        {
            var data=factory.UserReport().UserCreatedToday();
            return data;
        }
            
    }
}
