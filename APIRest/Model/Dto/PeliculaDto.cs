namespace APIRest.Model.Dto
{
    public class PeliculaDto
    {
        public int IdPelicula { get; set; }
        public string Titulo { get; set; }
        public string Director { get; set; }
        public string Sinopsis { get; set; }
        public DateTime FechaEstreno { get; set; }
    }
}
