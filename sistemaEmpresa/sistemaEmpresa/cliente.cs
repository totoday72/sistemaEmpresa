using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistemaEmpresa
{
    public class cliente
    {
        public int id { get; set; }
        public String nombre { get; set; }
        public String apellido { get; set; }
        public String direccion { get; set; }
        public String nit { get; set; }
        public String telefono { get; set; }
        public String tipo_cliente { get; set; }
        public cliente() { }
        public cliente(int id,String nombre,String apellido, String direccion, String nit, String telefono) {
            this.id = id;
            this.nombre = nombre;
            this.apellido = apellido;
            this.direccion = direccion;
            this.nit = nit;
            this.telefono = telefono;
        }
    }
}
