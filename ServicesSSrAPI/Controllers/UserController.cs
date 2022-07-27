using DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicesSSrAPI.Request;
using ServicesSSrAPI.Models.Response;

namespace ServicesSSrAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private ServiceSSRContext _context;

        public UserController(ServiceSSRContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            Response r1 = new Response();
            try
            {
                var lst =  _context.users.ToList();
                r1.Exito = 1;
                r1.Data = lst;
            }
            catch (Exception ex)
            {
                r1.Mensaje = ex.Message;

            }

            return Ok(r1);
        }

        [HttpPost]
        public async Task<IActionResult> Add(UserRequest model)
        {
            Response r1 = new Response();
            try
            {
                User u1 = new User();
                u1.Name = model.Name;
                u1.Password = model.Password;
                _context.Add(u1);
                await _context.SaveChangesAsync();
                r1.Exito = 1;
                r1.Data = u1;
            }
            catch (Exception ex)
            {

                r1.Mensaje = ex.Message;
            }
            return Ok(r1);
        }

        [HttpPut]
        public async Task<IActionResult> Edit(UserRequest model)
        {
            Response r1 = new Response();
            try
            {
                User u1 = await _context.users.FindAsync(model.UserId);
                u1.Name = model.Name;
                u1.Password = model.Password;
                _context.Entry(u1).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChangesAsync();

                r1.Exito = 1;
                r1.Data = u1;
            }
            catch (Exception ex)
            {
                r1.Mensaje = ex.Message;
            }
            return Ok(r1);
        }

        [HttpDelete("{UserId}")]
        public async Task<IActionResult> Delete(int UserId)
        {
            Response r1 = new Response();
            try
            {
                User u1 = await _context.users.FindAsync(UserId);
                _context.Remove<User>(u1);
                _context.SaveChangesAsync();
                r1.Exito = 1;
                r1.Data=u1;
            }
            catch (Exception ex)
            {
                r1.Mensaje = ex.Message;
            }
            return Ok(r1);
        }

    }
}
 