using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public class Libro
    {
        public Guid IDLibro { get; set; }
        public string ISBN { get; set; }
        public string ISBN_10 { get; set; }
        public string Titulo { get; set; }
        public string SubTitulo { get; set; }
        public DateTime? FechaPublicacion { get; set; }
        public int Paginas { get; set; }
        public string DatosEnvio { get; set; }

        public virtual Editorial Editorial { get; set; }


        public Libro()
        {
            IDLibro = Guid.NewGuid();
        }
     }


}
