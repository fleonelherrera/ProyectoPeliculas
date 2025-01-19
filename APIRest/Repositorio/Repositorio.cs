using System.Linq.Expressions;
using APIRest.Data;
using APIRest.Repositorio.IRepositorio;
using Microsoft.EntityFrameworkCore;

namespace APIRest.Repositorio
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet { get; set; }

        // CONSTRUCTOR
        public Repositorio(ApplicationDbContext db)
        {
            _db = db;
            dbSet = _db.Set<T>();
        }

        public async Task Crear(T entidad)
        {
            await dbSet.AddAsync(entidad);
            await Guardar();
        }

        public async Task Guardar()
        {
            await _db.SaveChangesAsync();
        }

        public async Task<T> Obtener(Expression<Func<T, bool>> filtro = null, bool tracked = true)
        {
            IQueryable<T> query = dbSet;

            if (!tracked)
            {
                query = query.AsNoTracking();
            }

            if (filtro != null)
            {
                query = query.Where(filtro);
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<T>> ObtenerTodos(Expression<Func<T, bool>>? filtro = null)
        {
            IQueryable<T> query = dbSet;

            if (filtro != null)
            {
                query = query.Where(filtro);
            }

            return await query.ToListAsync();
        }

        public async Task Remover(T entidad)
        {
            dbSet.Remove(entidad);
            await Guardar();
        }
    }
}
