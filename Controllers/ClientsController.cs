using API.Models;
using backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public ClientsController (ApplicationDbContext context)
        {
            this.context = context;
        }


        [HttpGet]
        public List<Client> GetClients()
        {
            return context.Clients.OrderByDescending(c => c.Id).ToList();
        }

        // GET: api/Client/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClient(int id)
        {
            var client = await context.Clients.FindAsync(id);

            if (client == null)
            {
                return NotFound();
            }

            return client;
        }

        [HttpPost]
        public IActionResult CreateClient(ClientDto clientDto)
        {
            // submitted data is valid

            var otherClient = context.Clients.FirstOrDefault(c => c.Email == clientDto.Email);
            if (otherClient != null)
            {
                ModelState.AddModelError("Email", "The Email Address is already used");
                var validation = new ValidationProblemDetails(ModelState);
                return BadRequest(validation);
            }
            //create valid data
            var client = new Client
            {
                FirstName = clientDto.FirstName,
                LastName = clientDto.LastName,
                Email = clientDto.Email,
                Phone = clientDto.Phone ?? "",
                Address = clientDto.Address ?? "",
                Status = clientDto.Status,
                CreatedAt = DateTime.Now,
            };
            // save data on database's table
            context.Clients.Add(client);
            context.SaveChanges();

            return Ok(client);


            
        }
        [HttpPut("{id}")]
        public IActionResult EditClient(int id, ClientDto clientDto)
        {
            // submitted data is valid

            var otherClient = context.Clients.FirstOrDefault(c => c.Id != id && c.Email == clientDto.Email);
            if (otherClient != null)
            {
                ModelState.AddModelError("Email", "The Email Address is already used");
                var validation = new ValidationProblemDetails(ModelState);
                return BadRequest(validation);
            }

            var client = context.Clients.Find(id);
            if (client == null)
            {
                return NotFound();
            }

            client.FirstName = clientDto.FirstName;
            client.LastName = clientDto.LastName;
            client.Email = clientDto.Email;
            client.Phone = clientDto.Phone ?? "";
            client.Address = clientDto.Address ?? "";
            client.Status = clientDto.Status;

            context.SaveChanges();

            return Ok(client);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteClient(int id)
        {
            var client = context.Clients.Find(id);
            if (client == null)
            {
                return NotFound();
            }

            context.Clients.Remove(client);
            context.SaveChanges();

            return Ok();
        }



    }


   
}
