using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sistemaEmpresa
{
    public class Conexion {
        private OleDbConnection conexionstring;
        public Conexion()
        {
            conexionstring = new OleDbConnection(@"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = |DataDirectory|\db.accdb");
        }
        public byte IniciarSesion(String usuario, String contrasena)
        {
            DataTable tabla = new DataTable();
            try
            {

                conexionstring.Open();
                OleDbDataAdapter adaptador = new OleDbDataAdapter("SELECT usuario, password FROM Usuario WHERE Usuario ='" + usuario + "'", conexionstring);
                adaptador.Fill(tabla);
                conexionstring.Close();

                foreach (DataRow fila in tabla.Rows)
                {
                    if (fila.ItemArray[0].ToString().Equals(usuario))
                    {

                        if (fila.ItemArray[1].ToString().Equals(contrasena))
                        {
                            return 3;
                        }
                        return 2;
                    }

                }

                return 1;
            }
            catch (System.Exception error)
            {
                return 0;
            }

        }


        public void AgregarProveedor(String nombre, String razon_social, String direccion, String telefono, String nit, String correo)
        {
            DataTable tabla = new DataTable();
            try
            {
                conexionstring.Open();
                OleDbDataAdapter adaptador = new OleDbDataAdapter("Insert into PROVEEDORES (nombre, razon_social,direccion, telefono, nit, email) values ('" + nombre + "', '" + razon_social + "', '" + direccion + "', '" + telefono + "', '" + nit + "', '" + correo + "');", conexionstring);
                adaptador.Fill(tabla);
                conexionstring.Close();
                MessageBox.Show("Proveedor Creado con exito");
            }
            catch (System.Exception error)
            {
                MessageBox.Show("Ha habido un error en su conexión, intentelo más tarde");
            }

        }


        public void AgregarCategoria(String nombre, String descripcion)
        {
            DataTable tabla = new DataTable();
            try
            {
                conexionstring.Open();
                OleDbDataAdapter adaptador = new OleDbDataAdapter("Insert into CATEGORIAS (nombre, descripcion) values ('" + nombre + "', '" + descripcion +  "');", conexionstring);
                adaptador.Fill(tabla);
                conexionstring.Close();
                MessageBox.Show("Categoria Creada con exito");
            }
            catch (System.Exception error)
            {
                MessageBox.Show("Ha habido un error en su conexión, intentelo más tarde");
            }

        }


        public void AgregarEmpleado(String dpi, String nombre, String apellido, String direccion, String fecha_nacimiento, String telefono, String email, String fecha_contratacion, String profesion, String puesto_trabajo, String Salario)
        {
            DataTable tabla = new DataTable();
            try
            {
                conexionstring.Open();
                OleDbDataAdapter adaptador = new OleDbDataAdapter("Insert into EMPLEADOS (dpi,nombre,apellido,direccion, fecha_de_nacimiento, telefono, email, fecha_de_contratacion, profesion, puesto_de_trabajo, salario) ('" + dpi + "','" + nombre + "', '" + apellido + "', '" + direccion + "', '" + fecha_nacimiento + "', '" + telefono + "', '" + email + "','" + fecha_contratacion + "', '" + profesion +"','"+puesto_trabajo +"','"+ Salario +"');", conexionstring);
                adaptador.Fill(tabla);
                conexionstring.Close();
                MessageBox.Show("Empleado Creado con exito");
            }
            catch (System.Exception error)
            {
                MessageBox.Show("Ha habido un error en su conexión, intentelo más tarde");
            }

        }



    }
    //prueba
}
