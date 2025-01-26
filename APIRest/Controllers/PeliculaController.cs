using System.Net;
using APIRest.Model;
using APIRest.Model.Dto;
using APIRest.Models;
using APIRest.Repositorio.IRepositorio;
using AutoMapper;
using Azure;
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
        private readonly IMapper _mapper;
        protected APIResponse _respuesta;


        // CONSTRUCTOR
        public PeliculaController(ILogger<PeliculaController> logger, IMapper mapper, IPeliculaRepositorio peliculaRepo)
        {
            _logger = logger;
            _mapper = mapper;
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
                _respuesta.Resultado = _mapper.Map<IEnumerable<PeliculaDto>>(peliculas);

                return Ok(_respuesta);
            }
            catch (Exception ex)
            {
                _respuesta.EsExitoso = false;
                _respuesta.MensajesDeError = new List<string>() { ex.ToString() };
            }
            return _respuesta;
        }

        
        // OBTENER UNA PELICULA
        [HttpGet("id:int", Name = "ObtenerPelicula")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> ObtenerPelicula(int id)
        {
            try
            {
                // VALIDO QUE EL ID NO SEA CERO
                if (id == 0)
                {
                    _logger.LogError("Error. El id no puede ser cero");

                    _respuesta.CodigoHttp = HttpStatusCode.BadRequest;
                    _respuesta.EsExitoso = false;

                    return BadRequest(_respuesta);
                }

                var pelicula = await _peliculaRepo.Obtener(p => p.IdPelicula == id);

                // VALIDO QUE LA PELICULA EXISTA
                if (pelicula == null)
                {
                    _logger.LogError("Error al obtener la pelicula con id: " + id);

                    _respuesta.CodigoHttp = HttpStatusCode.NotFound;
                    _respuesta.EsExitoso = false;
                    _respuesta.MensajesDeError = new List<string>() { "Pelicula no encontrada" };

                    return NotFound(_respuesta);
                }

                _respuesta.CodigoHttp = HttpStatusCode.OK;
                _respuesta.Resultado = _mapper.Map<PeliculaDto>(pelicula);

                return Ok(_respuesta);
            }
            catch (Exception ex)
            {
                _respuesta.EsExitoso = false;
                _respuesta.MensajesDeError = new List<string>() { ex.ToString() };
            }
            return _respuesta;
        }

        
        // CREAR UNA PELICULA
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> CrearPelicula([FromBody] PeliculaCreacionDto peliculaCreacionDto)
        {
            try
            {
                // VALIDACIONES DEL MODELO
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                // VALIDO QUE NO EXISTE UNA PELICULA CON EL NOMBRE DADO
                if (await _peliculaRepo.Obtener(p=> p.Titulo == peliculaCreacionDto.Titulo) != null)
                {
                    ModelState.AddModelError("NombreExistente", "Ya existe una pelicula con el nombre dado");

                    return BadRequest(ModelState);
                }

                // VALIDO QUE SE PASE LA MODIFICACION
                if (peliculaCreacionDto == null)
                {
                    return BadRequest(peliculaCreacionDto);
                }

                Pelicula nuevaPelicula = _mapper.Map<Pelicula>(peliculaCreacionDto);

                await _peliculaRepo.Crear(nuevaPelicula);

                _respuesta.CodigoHttp = HttpStatusCode.Created;
                _respuesta.Resultado = nuevaPelicula;

                return CreatedAtRoute("ObtenerPelicula", new { id = nuevaPelicula.IdPelicula }, _respuesta);

            }
            catch (Exception ex)
            {
                _respuesta.EsExitoso = false;
                _respuesta.MensajesDeError = new List<string>() { ex.ToString() };
            }
            return _respuesta;
        }

        
        // ELIMINAR UNA PELICULA
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> EliminarPelicula(int id)
        {
            try
            {
                if (id == 0)
                {
                    _logger.LogError("Error. El id no puede ser cero");

                    _respuesta.CodigoHttp = HttpStatusCode.BadRequest;
                    _respuesta.EsExitoso = false;

                    return BadRequest(_respuesta);
                }

                var peliculaAEliminar = await _peliculaRepo.Obtener(p => p.IdPelicula == id);

                if (peliculaAEliminar == null)
                {
                    _logger.LogError("Error al obtener la pelicula con id: " + id);

                    _respuesta.CodigoHttp = HttpStatusCode.NotFound;
                    _respuesta.EsExitoso = false;
                    _respuesta.MensajesDeError = new List<string>() { "Pelicula no encontrada" };

                    return NotFound(_respuesta);
                }

                await _peliculaRepo.Remover(peliculaAEliminar);

                _respuesta.CodigoHttp = HttpStatusCode.NoContent;

                return Ok(_respuesta);
            }
            catch (Exception ex)
            {
                _respuesta.EsExitoso = false;
                _respuesta.MensajesDeError = new List<string>() { ex.ToString() };
            }
            return BadRequest(_respuesta); // NO PUEDO RETORNAR LA RESPUESTA SOLA
        }

        
        // MODIFICAR UNA PELICULA
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ModificarPelicula(int id, [FromBody] PeliculaModificacionDto peliculaModifDto)
        {
            if (peliculaModifDto == null || id != peliculaModifDto.IdPelicula)
            {
                _respuesta.EsExitoso = false;
                _respuesta.CodigoHttp = HttpStatusCode.BadRequest;
                return BadRequest(_respuesta);
            }

            Pelicula peliculaModificada = _mapper.Map<Pelicula>(peliculaModifDto);

            await _peliculaRepo.Actualizar(peliculaModificada);

            _respuesta.CodigoHttp = HttpStatusCode.NoContent;

            return Ok(_respuesta);
        }

        /*
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
