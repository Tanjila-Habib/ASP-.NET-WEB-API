using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace AppLayerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        AppointmentService service;

        public AppointmentController(AppointmentService service)
        {
            this.service = service;
        }
        [HttpGet("all")]
        public IActionResult All()
        {
            var data = service.All();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var data = service.Get(id);
            return Ok(data);
        }
        [HttpPost("create")]
        
        public IActionResult Create(AppointmentCreateDTO a)
        {
            var message = service.Create(a);
            return Ok(new {message } );
        }

        [HttpPut("update")]
        public IActionResult Update(AppointmentDTO a)
        {
            var updated = service.Update(a);
            return Ok(updated);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {
            var data = service.Delete(id);
            return Ok(data);
        }
        //Filtering
        [HttpGet("filter-by-status/{status}")]
        public IActionResult FilterByStatus(string status)
        {
            var data=service.FilterByStatus(status);
            return Ok(data);
        }
        [HttpGet("filter-by-date/{date}")]
        public IActionResult FilterByDate(DateTime date)
        {
            var data=service.FilterByDate(date);    
            return Ok(data);
        }
        [HttpGet("filter-by-user/{userId}")]
        public IActionResult FilterByUser(int userId)
        {
            var data=service.FilterByUser(userId);
            return Ok(data);
        }
        [HttpGet("filter-by-professional/{professionalId}")]
        public IActionResult FilterByProfessional(int professionalId)
        {
            var data=service.FilterByProfessional(professionalId);
            return Ok(data);
        }
        //Reports
        [HttpGet("report/total")]
        public IActionResult TotalAppointments()
        {
            var data = service.TotalAppointments();
            return Ok(data);
        }
        [HttpGet("report/by-status")]
        public IActionResult AppointmentsCountByStautus()
        {
            var data = service.AppointmentCountByStatus();
            return Ok(data);    
        }
        [HttpGet("report/by-professional")]
        public IActionResult AppointmentCountByProfessional()
        {
            var data = service.AppointmentCountByProfessional();
            return Ok(data);
        }
        [HttpPut("workflow/auto-status")]
        public IActionResult AutoUpdateStatus()
        {
            var update=service.AutoUpdateStatus();
            return Ok(new
            {
                UpdatedCount = update,
                Message = update > 0
            ? $"{update} appointments auto-updated"
            : "No updates"
            });
        }
    }
}
