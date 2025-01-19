using APIRest.Model;

namespace APIRest.Repositorio.IRepositorio
{
    public interface IPeliculaRepositorio : IRepositorio<Pelicula>
    {
        Task<Pelicula> Actualizar(Pelicula entidad);
    }
}
