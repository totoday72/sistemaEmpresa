using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sistemaEmpresa
{
    public partial class Principal : Form
    {
        Form1 f;
        Conexion con = new Conexion();
       
        public Principal(Form1 f)
        {
            InitializeComponent();
            this.f = f;

          



        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void Principal_FormClosed(object sender, FormClosedEventArgs e)
        {
            f.Visible=true;
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.AgregarProveedor(text_nombre.Text, text_razonSocial.Text, textdireccion.Text, text_telefono.Text, text_nit.Text, text_correo.Text);
            this.Vaciado();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            con.AgregarCategoria(text_NomCategoria.Text, text_DescCategoria.Text);
            this.Vaciado();
        }


        public void Vaciado(){
            text_nombre.Clear();
            text_razonSocial.Clear();
            textdireccion.Clear();
            text_telefono.Clear();
            text_nit.Clear();
            text_correo.Clear();
            text_NomCategoria.Clear();
            text_DescCategoria.Clear();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            con.AgregarEmpleado(text_dpi.Text, emp_nombre.Text, emp_apellido.Text, empDireccion.Text, empEdad.Text, emp_Telefono.Text,empEmail.Text ,empContratacion.Text, emp_profesion.Text, empPuestoLaboral.Text, empSalario.Text);
        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            list1Productos.Items.Clear();
            con.leerProductos(list1Productos);
        }

        private void list1Productos_MouseClick(object sender, MouseEventArgs e)
        {
            

        }

        private void buscarcliente_Click(object sender, EventArgs e)
        {
            if (txtnitcotizacion.Text.Length > 0)
            {
                cliente temp = con.leerInfoCliente(txtnitcotizacion.Text);
                if(temp != null)
                {
                    txtidclientecotizacion.Text = temp.id+"";
                    txtnombrecotizacion.Text = temp.nombre;
                    txtapellidocotizacion.Text = temp.apellido;
                    txtdireccioncotizacion.Text = temp.direccion;
                    txttelefonocotizacion.Text = temp.telefono;
                }
            }else
            {
                MessageBox.Show("Por favor ingrese el nit del cliente.");
                txtnitcotizacion.Select();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void list1Productos_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (list1Productos.SelectedItems.Count > 0)
            { 
                ListViewItem temp = new ListViewItem();
                temp = (ListViewItem)list1Productos.SelectedItems[0].Clone();
                string cantidad = Microsoft.VisualBasic.Interaction.InputBox("Ingrese la cantidad de este producto", "Cantidad del Producto: "+temp.Text, "1");
                try
                {
                    double cant = double.Parse(cantidad);
                    temp.SubItems.Add(cantidad);
                    list1productosSeleccionados.Items.Add(temp);
                    lbltotal.Text = double.Parse(lbltotal.Text) + double.Parse(temp.SubItems[4].Text)*cant+ "";
                }catch(Exception error)
                {
                    MessageBox.Show("Ingrese un Numero en la cantidad. "+error.Message);
                }
            }
        }

        private void list1productosSeleccionados_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (list1productosSeleccionados.SelectedItems.Count > 0)
            {
                lbltotal.Text = double.Parse(lbltotal.Text) - double.Parse(list1productosSeleccionados.SelectedItems[0].SubItems[4].Text) * double.Parse(list1productosSeleccionados.SelectedItems[0].SubItems[6].Text) + "";
                list1productosSeleccionados.Items.Remove(list1productosSeleccionados.SelectedItems[0]);
                
            }else
            {
                MessageBox.Show("Por favor seleccione un producto de la lista para continuar.");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            list1productosSeleccionados.Items.Clear();
            lbltotal.Text = "0.00";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            
            if (list1productosSeleccionados.Items.Count > 0)
            {
                if (txtidclientecotizacion.Text.Length > 0 && txtidclientecotizacion.Text != "0")
                {
                    string fechaactual = fecha.Value.Day + "/" + fecha.Value.Month + "/" + fecha.Value.Year;
                    con.AgregarCotizacion(fechaactual, lbltotal.Text, txtidclientecotizacion.Text);
                    string idcotizacion = con.darUltimoIndiceCotizacion()+"";
                    for (int i =0; i< list1productosSeleccionados.Items.Count; i++){
                        con.agregarDetalleCotizacion(list1productosSeleccionados.Items[i].SubItems[6].Text, list1productosSeleccionados.Items[i].Text, idcotizacion);
                    }
                }
                else
                {
                    MessageBox.Show("Por favor busque a un cliente, ingrese el nit del cliente y haga clic en el boton buscar cliente.");
                }
            }else
            {
                MessageBox.Show("NO HAY PRODUCTOS AGREGADOS, Por favor seleccione un producto para la cotizacion.");
            }
        }
    }
}
