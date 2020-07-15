using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CRUDPersonas.Modelo;

namespace CRUDPersonas
{
    public partial class frmAñadir : Form
    {
        CRUDPersonaEntities db = new CRUDPersonaEntities();
        public frmAñadir()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAñadir_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = string.Empty;
            mtxtCedula.Text = string.Empty;
            mtxtNumero.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            dateTimePicker1.Value = DateTime.Today;
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

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            Personas persona = new Personas();
            if (txtCorreo.Text == string.Empty || txtCorreo.Text == string.Empty)
            {
                MessageBox.Show("Campos Requeridos Sin Completar");
            }
            else
            {
                try
                {
                    persona.nombre = txtNombre.Text;
                    persona.cedula = Reemplazar(mtxtCedula.Text);
                    persona.fecha = dateTimePicker1.Value;
                    persona.telefono = Reemplazar(mtxtNumero.Text);
                    persona.correo = txtCorreo.Text;

                    db.Personas.Add(persona);
                    db.SaveChanges();
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Añadir Persona", 
                        MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                CargarDatos();
            }

        }

        private int Reemplazar(string dato)
        {
            dato = dato.Replace("-", "");
            return Convert.ToInt32(dato);
        }

        private void lblFecha_Click(object sender, EventArgs e)
        {

        }
    }
}
