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
    public partial class Principal : Form
    {
        Form1 f;
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
    }
}
