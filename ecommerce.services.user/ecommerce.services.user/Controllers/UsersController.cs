using Azure.Messaging.ServiceBus;
using ecommerce.services.user.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ecommerce.services.user.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public UsersController()
        { }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        { 
            string str = string.Empty;
            return Ok(str); 
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            string str = string.Empty;
            return Ok(str);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(User user)
        {
            var connectionString = ""; 
            var client = new ServiceBusClient(connectionString);
            var sender = client.CreateSender("mytopic");
            var body = JsonSerializer.Serialize(user);
            var sbMessage = new ServiceBusMessage(body);

            await sender.SendMessageAsync(sbMessage);

            return CreatedAtAction("GetAsync", new { id = 1 });
        }
    }
}
