using System.ComponentModel.DataAnnotations;

namespace appweb001.Models
{
    public class Contactos
    {
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string correoE { get; set; }
        public DateTime fechaNacimiento { get; set; }

    }
}
