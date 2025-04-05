using System;

namespace CapaDatos
{
    public class CalculoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Resultado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Categoria { get; set; }
        public string Carpeta { get; set; }
    }
}
