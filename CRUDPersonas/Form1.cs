using CRUDPersonas.Presentacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDPersonas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            diseño();
        }

        private Form formActivo = null; 

        private void formHijo(Form formHijo)
        {
            if (formActivo != null)
            {
                formActivo.Close();
            }

            formActivo = formHijo;
            formHijo.TopLevel = false;
            formHijo.FormBorderStyle = FormBorderStyle.None;
            formHijo.Dock = DockStyle.Fill;
            pnlCentral.Controls.Add(formHijo);
            pnlCentral.Tag = formHijo;
            formHijo.BringToFront();
            formHijo.Show();
        }

        private void diseño()
        {
            pnlSubMenu.Visible = false;
        }

        private void mostrarMenu()
        {
            if (pnlSubMenu.Visible == false)
            {
                pnlSubMenu.Visible = true;
            }
            else
            {
                pnlSubMenu.Visible = false;
            }
        }
      

        private void btnAcciones_Click(object sender, EventArgs e)
        {
            mostrarMenu();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            formHijo(new frmEditar());
            mostrarMenu();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            mostrarMenu();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            formHijo(new frmEliminar());
            mostrarMenu();
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            formHijo(new frmAñadir());
            mostrarMenu();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            formHijo(new frmBuscar());
            mostrarMenu();
        }

        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void ocultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
