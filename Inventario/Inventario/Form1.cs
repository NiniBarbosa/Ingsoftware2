using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventario
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(System.Object sender, System.EventArgs e)
        {
            string usuario = null;
            string contrasena = null;
            string usu = null;
            string contra = null;
            string usua = null;
            string contrase = null;

            usu = TextBox1.Text;
            contra = TextBox2.Text;
            usuario = "administrador";
            contrasena = "admin";
            usua = "usuario";
            contrase = "usuario";


            if (usu == usuario & contra == contrasena)
            {
                MessageBox.Show("Usted es Administrador");
                Form2.Show();
                this.Finalize();
            }
            else
            {
                if (usu == usua & contra == contrase)
                {
                    MessageBox.Show("Usted es Usuario");
                    Form2.Show();
                    Form2.MercanciaToolStripMenuItem.Enabled = false;
                    //Form3.Button4.Enabled = False
                    //Form3.Button2.Enabled = False
                    //Form5.Button4.Enabled = False
                    this.Finalize();
                }
                else
                {
                    if (usu != usuario | usu != usua | contra != contrasena | contra != contrase)
                    {
                        MessageBox.Show("Usted ha ingresado un Usuario o una Contraseña erroneos");
                        MessageBox.Show("Vuelva a intentarlo");
                    }
                }

            }
        }
    }
}
