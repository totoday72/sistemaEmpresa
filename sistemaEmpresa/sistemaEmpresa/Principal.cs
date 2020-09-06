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
    }
}
