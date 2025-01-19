using System.Linq.Expressions;

namespace APIRest.Repositorio.IRepositorio
{
    public interface IRepositorio<T> where T : class
    {
        Task Crear(T entidad);

        // DEVUELVE UNA LISTA DE T, DONDE T ES CUALQUIER CLASE
        Task<List<T>> ObtenerTodos(Expression<Func<T, bool>>? filtro = null);

        // OBTIENE LA T QUE CUMPLE EL FILTRO
        Task<T> Obtener(Expression<Func<T, bool>> filtro = null, bool tracked = true);

        Task Remover(T entidad);

        Task Guardar();
    }
}
