using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sistemaEmpresa
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Conexion cn = new Conexion();
            switch (cn.IniciarSesion(txtuser.Text, txtpass.Text)) {
                case 0:
                    MessageBox.Show("Error, la comunicación con la base de datos no pudo ser establecida");
                    break;
                case 1:
                    MessageBox.Show("Error, No se encontro ningun usuario con el nombre: "+ txtuser.Text);
                    break;
                case 2:
                    MessageBox.Show("Error, la contraseña no es correcta vuelva a intentar.");
                    break;
                case 3:
                    
                    this.Visible = false;
                    MessageBox.Show("BIENVENIDO " + txtuser.Text + " EN UN MOMENTO SE ABRIRA EL PROGRAMA.");
                    Principal p = new Principal(this);
                    p.Show();
                    p.Visible = true;
                    break;
            }
        }
    }
}
