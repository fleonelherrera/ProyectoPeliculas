using APIRest.Data;
using APIRest.Model;
using APIRest.Repositorio.IRepositorio;

namespace APIRest.Repositorio
{
    public class PeliculaRepositorio : Repositorio<Pelicula>, IPeliculaRepositorio
    {
        private readonly ApplicationDbContext _db;

        public PeliculaRepositorio(ApplicationDbContext db) :base(db)
        {
            _db = db;
        }

        public async Task<Pelicula> Actualizar(Pelicula entidad)
        {
            _db.Peliculas.Update(entidad);

            await _db.SaveChangesAsync();

            return entidad;
        }
    }
}
