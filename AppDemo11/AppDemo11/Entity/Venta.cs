using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDemo11.Entity
{
    public class Venta
    {


        public Venta()
        {
            this.ID = 0;
            this.Nombre = string.Empty;
            this.Cliente = string.Empty;
            this.Precio = 0;
            this.Cantidad = 0;
            this.Monto = 0;
        }
        //propiedades
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Cliente { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }

        public decimal Monto { get; set; }
    }
}
