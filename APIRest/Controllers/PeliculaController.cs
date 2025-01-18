using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculaController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetPeliculas()
        {

        }
    }
}
