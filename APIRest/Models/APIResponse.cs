using System.Net;

namespace APIRest.Models
{
    public class APIResponse
    {
        public HttpStatusCode CodigoHttp { get; set; }
        public bool EsExitoso { get; set; } = true;
        public List<string> MensajesDeError { get; set; }
        public object Resultado { get; set; }
    }
}
