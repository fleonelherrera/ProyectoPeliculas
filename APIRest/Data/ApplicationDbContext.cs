using APIRest.Model;
using Microsoft.EntityFrameworkCore;

namespace APIRest.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // CREO LA TABLA DE Peliculas
        public DbSet<Pelicula> Peliculas { get; set; }


        // ALIMENTO LA TABLA CON UN PAR DE DATOS
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pelicula>().HasData(
                new Pelicula()
                {
                    IdPelicula = 1,
                    Titulo = "Los Vengadores",
                    Director = "Joss Whedon",
                    Sinopsis = "bla bla",
                    FechaEstreno = DateTime.Now,
                    UrlPortada = "https://www.futuro.cl/wp-content/uploads/2019/03/avengers-endgame-poster.jpg"
                },
                new Pelicula()
                {
                    IdPelicula = 2,
                    Titulo = "Harry Potter y el caliz de fuego",
                    Director = "Mike Newell",
                    Sinopsis = "bla bla bla",
                    FechaEstreno = DateTime.Now,
                    UrlPortada = "https://www.mubis.es/media/movies/1456/170565/harry-potter-y-el-caliz-de-fuego-l_cover.jpg"
                });
        }
    }
}
