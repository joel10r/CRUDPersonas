using CRUDPersonas.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDPersonas.Presentacion
{
    public partial class frmBuscar : Form
    {
        CRUDPersonaEntities db = new CRUDPersonaEntities();
        private int cedula;
        public frmBuscar()
        {
            InitializeComponent();
        }

        private int Reemplazar(string dato)
        {
            dato = dato.Replace("-", "");
            return Convert.ToInt32(dato);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                cedula = Reemplazar(mtxtCedula.Text);

                var persona = from p in db.Personas
                              where p.cedula == cedula
                              select new
                              {
                                  p.nombre,
                                  p.cedula,
                                  p.fecha,
                                  p.telefono,
                                  p.correo
                              };

                dataGridView1.DataSource = persona.ToList();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Buscar Persona",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

            mtxtCedula.Text = string.Empty;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
