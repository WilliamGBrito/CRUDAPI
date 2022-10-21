using CRUDAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace CRUDAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {

        private static List<Usuario> Usuarios()
        {
            return new List<Usuario>{
            new Usuario{Nome="Lucas", Id=1}
         };
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Usuarios());
        }
    }
}