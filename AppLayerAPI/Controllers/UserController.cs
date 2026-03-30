using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;

namespace AppLayerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserService service;
        public UserController(UserService service)
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
        public IActionResult Create(UserCreateDTO u)

        {
            var message = service.Create(u);
            return Ok(message);
        }
        [HttpPut("update")]
        public IActionResult Update(UserDTO u)
        {
            var updated = service.Update(u);
            return Ok(updated);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(int id)
        {

            var data = service.Delete(id);
            return Ok(data);
        }
        [HttpGet("by-email/{email}")]
        public IActionResult GetByEmail(string email)
        {
            var data = service.GetByEMail(email);
            return Ok(data);
        }
        [HttpGet("report/total")]
        public IActionResult TotalUser()
        {
            var data = service.TotalUsers();
            return Ok(data);
        }
        [HttpGet("report/today-created")]
        public IActionResult UserCreatedToday()
        {
            var data = service.UserCreatedToday();
            return Ok(data);
        }
    }
}
