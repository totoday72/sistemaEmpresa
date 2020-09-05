using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
    
}
