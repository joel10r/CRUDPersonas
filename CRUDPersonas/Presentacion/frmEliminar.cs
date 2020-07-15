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

namespace CRUDPersonas
{
    public partial class frmEliminar : Form
    {
        CRUDPersonaEntities db = new CRUDPersonaEntities();
        private int cedula;
        
        private int Reemplazar(string dato)
        {
            dato = dato.Replace("-", "");
            return Convert.ToInt32(dato);
        }
        private void LimpiarCampos()
        {
            mtxtCedula.Text = string.Empty;
        }
        private void CargarDatos()
        {
            var lista = from p in db.Personas
                        select new
                        {
                            p.nombre,
                            p.cedula,
                            p.fecha,
                            p.telefono,
                            p.correo
                        };

            dataGridView1.DataSource = lista.ToList();

        }
        public frmEliminar()
        {
            InitializeComponent();
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void frmEliminar_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarPersona();
        }
    
        private void BuscarPersona()
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
                LimpiarCampos();
              
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Eliminar Persona",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Personas eliminarPersona = db.Personas.FirstOrDefault(p => p.cedula == cedula);
                db.Personas.Remove(eliminarPersona);
                db.SaveChanges();
                BuscarPersona();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Eliminar Persona",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
