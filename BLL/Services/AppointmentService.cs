using AutoMapper;
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
    public class AppointmentService
    {
        DataAccessFactory factory;
        INotification notification;
       
        public AppointmentService(DataAccessFactory factory, INotification notification)
        {
            this.factory = factory;
           this.notification = notification;
        }   
        public List<AppointmentDTO> All()
        {
            var data = factory.AppointmentData().Get();
            var ret = MapperConfig.GetMapper().Map<List<AppointmentDTO>>(data);

            return ret;
        } 
        public AppointmentDTO Get(int id)
        {
            Appointment data=factory.AppointmentData().Get(id);
            AppointmentDTO ret = MapperConfig.GetMapper().Map<AppointmentDTO>(data);
            return ret;
        }
        public string Create(AppointmentCreateDTO dto)
        {
            var appointment = MapperConfig.GetMapper().Map<Appointment>(dto);

            var result = factory.AppointmentData().Create(appointment);

            if (result)
            {
                notification.Notify("Appointment created successfully");
                return "Appointment created successfully";
            }
            return "Failed to create appointment";
        }


        public bool Update(AppointmentDTO dto)
        {
            var data = MapperConfig.GetMapper().Map<Appointment>(dto);
            return factory.AppointmentData().Update(data);
        }
        public bool Delete(int id)
        {
            return factory.AppointmentData().Delete(id);
        }
        public List<AppointmentDTO>FilterByStatus(string status)
        {
            var data = factory.AppointmentFeature().FilterByStatus(status);
            return MapperConfig.GetMapper().Map<List<AppointmentDTO>>(data);
        }
        public List<AppointmentDTO>FilterByDate(DateTime date)
        {
            var data = factory.AppointmentFeature().FilterByDate(date);
            return MapperConfig.GetMapper().Map<List<AppointmentDTO>>(data);
        }
        public List<AppointmentDTO>FilterByUser(int userId)
        {
            var data = factory.AppointmentFeature().FilterByUser(userId);
            return MapperConfig.GetMapper().Map<List<AppointmentDTO>>(data);
         }
        public List<AppointmentDTO>FilterByProfessional(int professionalId)
        {
            var data = factory.AppointmentFeature().FilterByProfessional(professionalId);
            return MapperConfig.GetMapper().Map<List<AppointmentDTO>>(data);
        }
        public int TotalAppointments()
        {
            var data=factory.AppointmentReport().TotalAppointments();
            return data;
        }
        public List<object>AppointmentCountByStatus()
        {
            var data = factory.AppointmentReport().AppointmentCountByStatus();
            return data;
        }
        public List<object>AppointmentCountByProfessional()
        {
            var data = factory.AppointmentReport().AppointmentCountByProfessional();
            return data;
        }
        public int AutoUpdateStatus()
        {
            var updated = factory.AppointmentWorkFlow().AutoUpdateStatus();
            if(updated>0)
            {
                notification.Notify($"{updated} appointments auto-updated");
               
            }
            return updated;
        }
    }
}
