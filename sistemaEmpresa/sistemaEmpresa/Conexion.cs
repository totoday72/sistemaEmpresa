using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sistemaEmpresa
{
    public class Conexion
    {
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
                MessageBox.Show("Hubo un error inesperado: " + error);
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
                MessageBox.Show("Ha habido un error en su conexión, intentelo más tarde "+error.Message);
            }

        }


        public void AgregarCategoria(String nombre, String descripcion)
        {
            DataTable tabla = new DataTable();
            try
            {
                conexionstring.Open();
                OleDbDataAdapter adaptador = new OleDbDataAdapter("Insert into CATEGORIAS (nombre, descripcion) values ('" + nombre + "', '" + descripcion + "');", conexionstring);
                adaptador.Fill(tabla);
                conexionstring.Close();
                MessageBox.Show("Categoria Creada con exito");
            }
            catch (System.Exception error)
            {
                MessageBox.Show("Ha habido un error en su conexión, intentelo más tarde "+error.Message);
            }

        }


        public void AgregarEmpleado(String dpi, String nombre, String apellido, String direccion, String fecha_nacimiento, String telefono, String email, String fecha_contratacion, String profesion, String puesto_trabajo, String Salario)
        {
            DataTable tabla = new DataTable();
            try
            {
                conexionstring.Open();
                OleDbDataAdapter adaptador = new OleDbDataAdapter("Insert into EMPLEADOS (dpi,nombre,apellido,direccion, fecha_de_nacimiento, telefono, email, fecha_de_contratacion, Profesión, puesto_de_trabajo, salario) values ('" + dpi + "','" + nombre + "', '" + apellido + "', '" + direccion + "', '" + fecha_nacimiento + "', '" + telefono + "', '" + email + "','" + fecha_contratacion + "', '" + profesion + "','" + puesto_trabajo + "'," + Salario + ");", conexionstring);
                adaptador.Fill(tabla);
                conexionstring.Close();
                MessageBox.Show("Empleado Creado con exito");
            }
            catch (System.Exception error)
            {
                MessageBox.Show("Ha habido un error en su conexión, intentelo más tarde" + error.Message);
            }

        }

        public void leerProductos(ListView obj)
        {
            ListView.ListViewItemCollection d = new ListView.ListViewItemCollection(obj);
            try
            {

                conexionstring.Open();
                OleDbCommand comando = new OleDbCommand("SELECT * FROM Productos", conexionstring);
                OleDbDataReader lector;
                lector = comando.ExecuteReader();
                lector.Read();
                if (lector.HasRows)
                {
                    Boolean color = true;
                    string textocolor = "";
                    do
                    {
                        if (color)
                        {
                            textocolor = "ActiveCaption";
                        }
                        else
                        {
                            textocolor = "Window";
                        }
                        int index = lector.GetInt32(0);
                        string nombre = lector.GetString(1);
                        int costo = int.Parse(lector.GetValue(2).ToString());
                        int stock = lector.GetInt32(3);
                        int precioVenta = int.Parse(lector.GetValue(4).ToString());
                        string descripcion = lector.GetString(5);
                        ListViewItem x = new ListViewItem();
                        x.Text = index + "";
                        x.BackColor = Color.FromName(textocolor);
                        ListViewItem.ListViewSubItem nombre1 = new ListViewItem.ListViewSubItem();
                        nombre1.Text = nombre;
                        ListViewItem.ListViewSubItem costo1 = new ListViewItem.ListViewSubItem();
                        costo1.Text = costo + "";
                        ListViewItem.ListViewSubItem stock1 = new ListViewItem.ListViewSubItem();
                        stock1.Text = stock + "";
                        ListViewItem.ListViewSubItem precioVenta1 = new ListViewItem.ListViewSubItem();
                        precioVenta1.Text = precioVenta + "";
                        ListViewItem.ListViewSubItem descripcion1 = new ListViewItem.ListViewSubItem();
                        descripcion1.Text = descripcion;

                        x.SubItems.Add(nombre1);
                        x.SubItems.Add(costo1);
                        x.SubItems.Add(stock1);
                        x.SubItems.Add(precioVenta1);
                        x.SubItems.Add(descripcion1);
                        d.Insert(index - 1, x);
                        color = !color;
                        //MessageBox.Show("Se inserto el valor: "+lector.GetValue(1).ToString());
                    } while (lector.Read());
                }
                lector.Close();
                conexionstring.Close();

            }
            catch (System.Exception error)
            {
                MessageBox.Show("Ha habido un error en su conexión, intentelo más tarde" + error.Message);
            }
            finally
            {
                conexionstring.Close();
            }
        }



        public cliente leerInfoCliente(string nit)
        {
            cliente c = new cliente();
            try
            {
                conexionstring.Open();
                OleDbCommand comando = new OleDbCommand("SELECT * FROM Clientes where NIT='"+nit+"'", conexionstring);
                OleDbDataReader lector;
                lector = comando.ExecuteReader();
                lector.Read();
                if (lector.HasRows)
                {
                    do
                    {
                        int id = lector.GetInt32(0);
                        string nombre = lector.GetString(1);
                        string apellido = lector.GetString(2);
                        string direccion = lector.GetString(3);
                        string nit1 = lector.GetString(4);
                        string telefono = lector.GetString(5);
                        c.id = id;
                        c.nombre = nombre;
                        c.apellido = apellido;
                        c.direccion = direccion;
                        c.nit = nit1;
                        c.telefono = telefono;
                        //MessageBox.Show("Se inserto el valor: "+lector.GetValue(1).ToString());
                    } while (lector.Read());
                }
                lector.Close();
                conexionstring.Close();
                return c;

            }
            catch (System.Exception error)
            {
                MessageBox.Show("Ha habido un error en su conexión, intentelo más tarde" + error.Message);
                return null;
            }
            finally
            {
                conexionstring.Close();
            }

        }

        public void AgregarCotizacion(String fecha, String total, String idcliente)
        {
            DataTable tabla = new DataTable();
            try
            {
                conexionstring.Open();
                OleDbDataAdapter adaptador = new OleDbDataAdapter("Insert into Cotizaciones (Fecha_Cotizacion, Total,fk_id_Cliente) values ('" + fecha + "', " + total + ", " + idcliente + ");", conexionstring);
                adaptador.Fill(tabla);
                conexionstring.Close();
                MessageBox.Show("Cotización guardada con éxito");
            }
            catch (System.Exception error)
            {
                MessageBox.Show("Ha habido un error en su conexión, intentelo más tarde "+error.Message);
            }
            finally
            {
                conexionstring.Close();
            }

        }


        public int darUltimoIndiceCotizacion()
        {
            int id = -1;
            try
            {
                conexionstring.Open();
                OleDbCommand comando = new OleDbCommand("SELECT TOP 1 id FROM Cotizaciones ORDER BY id DESC", conexionstring);
                OleDbDataReader lector;
                lector = comando.ExecuteReader();
                lector.Read();
                if (lector.HasRows)
                {
                    do
                    {
                        id = lector.GetInt32(0);
                        
                        //MessageBox.Show("Se inserto el valor: "+lector.GetValue(1).ToString());
                    } while (lector.Read());
                }
                lector.Close();
                conexionstring.Close();
                return id;

            }
            catch (System.Exception error)
            {
                MessageBox.Show("Ha habido un error en su conexión, intentelo más tarde" + error.Message);
                return -1;
            }
            finally
            {
                conexionstring.Close();
            }

        }

        public void agregarDetalleCotizacion(String cantidad, String idproducto, String idcotizacion)
        {
            DataTable tabla = new DataTable();
            try
            {
                conexionstring.Open();
                OleDbDataAdapter adaptador = new OleDbDataAdapter("Insert into Detalle_Cotizaciones (cantidad, fk_id_Producto,fk_id_Cotizacion) values (" + cantidad + ", " + idproducto + ", " + idcotizacion + ");", conexionstring);
                adaptador.Fill(tabla);
                conexionstring.Close();
                MessageBox.Show("Detalle Cotización guardada con éxito");
            }
            catch (System.Exception error)
            {
                MessageBox.Show("Ha habido un error en su conexión, intentelo más tarde " + error.Message);
            }
            finally
            {
                conexionstring.Close();
            }

        }

    }
}
    //prueba
