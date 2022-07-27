using DB;
using Microsoft.AspNetCore.Mvc;
using ServicesSSrAPI.Models.Response;
using ServicesSSrAPI.Request;
using ServicesSSrAPI.Models.Request;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ServicesSSrAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private ServiceSSRContext _context;

        public ExerciseController(ServiceSSRContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            Response r1 = new Response();
            try
            {
                var lst = _context.Exercises.ToList();
                r1.Exito = 1;
                r1.Data = lst;
            }
            catch (Exception ex)
            {
                r1.Mensaje = ex.Message;

            }

            return Ok(r1);
        }

        /*[HttpPost]
        public async Task<IActionResult> Add(ExerciseRequest model, int userId)
        {
            Response r1 = new Response();
            try
            {
                Exercise u1 = new Exercise();
                u1.Name = model.Name;
                u1.Description = model.Description;
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
        }*/
    }
}
