using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppLayerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessionalController : ControllerBase
    {
        ProfessionalService service;
        public ProfessionalController(ProfessionalService service)
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
        public IActionResult Create(ProfessionalCreateDTO p)

        {
            var message = service.Create(p);
            return Ok(new {message});
        }
        [HttpPut("update")]
        public IActionResult Update(ProfessionalDTO p)
        {
            var updated = service.Update(p);
            return Ok(updated);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {

            var data = service.Delete(id);
            return Ok(data);
        }
        [HttpGet("by-specialization/{specialization}")]
        public IActionResult GetBySpecialization(string specialization)
        {
            var data=service.GetBySpecialization(specialization);
            return Ok(data);
        }
        [HttpGet("active")]
        public IActionResult GetActive()
        {
            var data=service.GetActive();
            return Ok(data);
        }
        [HttpGet("report/total")]
        public IActionResult TotalProfessionals()
        {
            var data = service.TotalProfessionals();
            return Ok(data);
        }
    }
}
