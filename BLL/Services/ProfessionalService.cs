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
    public class ProfessionalService
    {
        DataAccessFactory factory;
        INotification notification;
        public ProfessionalService(DataAccessFactory factory, INotification notification)
        {
            this.factory = factory;
            this.notification = notification;   
        }
        public List<ProfessionalDTO>All()
        {
            var data = factory.ProfessionalData().Get();
            var ret=MapperConfig.GetMapper().Map<List<ProfessionalDTO>>(data);
            return ret;
        }
        public ProfessionalDTO Get(int id)  
        {   Professional data=factory.ProfessionalData().Get(id);
            ProfessionalDTO ret = MapperConfig.GetMapper().Map<ProfessionalDTO>(data);
            return ret;
        }
        public string Create(ProfessionalCreateDTO dto)
        {
            var prof = MapperConfig.GetMapper().Map<Professional>(dto);
           var result= factory.ProfessionalData().Create(prof);
            if(result)
            {
                notification.Notify($"Professional Created:{prof.Name}");
                return "Professional is created successfully";
            }
            return "Failed to create professional";
        }
        public bool Update(ProfessionalDTO dto)
        {
            var data = MapperConfig.GetMapper().Map<Professional>(dto);
            return factory.ProfessionalData().Update(data);
        }
        public bool Delete(int id)
        {
            return factory.ProfessionalData().Delete(id);
        }
        public List<ProfessionalDTO>GetBySpecialization(string specialization)
        {
            var data = factory.ProfessionalFeature().GetBySpecialization(specialization);
            return MapperConfig.GetMapper().Map<List<ProfessionalDTO>>(data);
        }
        public List<ProfessionalDTO>GetActive()
        {
            var data = factory.ProfessionalStatus().GetActive();
            return MapperConfig.GetMapper().Map<List<ProfessionalDTO>>(data);

        }
        public int TotalProfessionals()
        {
            var data = factory.ProfessionalReport().TotalProfessionals();
            return data;
        }
    }
}
