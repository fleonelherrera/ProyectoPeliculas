using System.Net;
using APIRest.Model;
using APIRest.Model.Dto;
using APIRest.Models;
using APIRest.Repositorio.IRepositorio;
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
        private readonly IPeliculaRepositorio _peliculaRepo;
        protected APIResponse _respuesta;


        // CONSTRUCTOR
        public PeliculaController(ILogger<PeliculaController> logger, IPeliculaRepositorio peliculaRepo)
        {
            _logger = logger;
            _respuesta = new();
            _peliculaRepo = peliculaRepo;
        }
        
        // OBTENER TODAS LAS PELICULAS
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<APIResponse>> ObtenerPeliculas()
        {
            try
            {
                _logger.LogInformation("Obtener todas las peliculas");

                IEnumerable<Pelicula> peliculas = await _peliculaRepo.ObtenerTodos();

                _respuesta.CodigoHttp = HttpStatusCode.OK;
                _respuesta.Resultado = peliculas;

                return Ok(_respuesta);
            }
            catch (Exception ex)
            {
                _respuesta.EsExitoso = false;
                _respuesta.MensajesDeError = new List<string> { ex.Message.ToString() };
            }
            return _respuesta;
        }

        /*
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
