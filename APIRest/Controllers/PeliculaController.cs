using APIRest.Model.Dto;
using APIRest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace APIRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculaController : ControllerBase
    {
        private readonly ILogger<PeliculaController> _logger;
        protected APIResponse _respuesta;


        // CONSTRUCTOR
        public PeliculaController(ILogger<PeliculaController> logger)
        {
            _logger = logger;
            _respuesta = new();
        }
        /*
        // OBTENER TODAS LAS PELICULAS
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> ObtenerPeliculas()
        {

        }


        // OBTENER UNA PELICULA
        [HttpGet("id:int", Name = "ObtenerPelicula")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> ObtenerPelicula(int id)
        {

        }


        // CREAR UNA PELICULA
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> CrearPelicula([FromBody] PeliculaCreacionDto peliculaCreacionDto)
        {

        }


        // ELIMINAR UNA PELICULA
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EliminarPelicula(int id)
        {

        }


        // MODIFICAR UNA PELICULA
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ModificarPelicula(int id, [FromBody] PeliculaModificacionDto peliculaModifDto)
        {

        }


        // MODIFICAR PARCIALMENTE UNA PELICULA
        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ModificarPeliculaParcial(int id, JsonPatchDocument<PeliculaModificacionDto> patchPelicula)
        {

        }
        */
    }
}
