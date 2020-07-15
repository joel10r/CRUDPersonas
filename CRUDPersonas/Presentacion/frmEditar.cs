using CRUDPersonas.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDPersonas
{
    public partial class frmEditar : Form
    {
        CRUDPersonaEntities db = new CRUDPersonaEntities();
        private Personas persona = null;

        public frmEditar()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmEditar_Load(object sender, EventArgs e)
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

        private string ObtenerCedula()
        {
            try
            {
                return dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();

            }
            catch
            {
                return null;
            }
        }
        private int Reemplazar(string dato)
        {
            dato = dato.Replace("-", "");
            return Convert.ToInt32(dato);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int? cedula = Reemplazar(ObtenerCedula());


            if (cedula != null)
            {
                persona = db.Personas.FirstOrDefault(p => p.cedula == cedula);
                txtNombre.Text = persona.nombre;
                mtxtCedula.Text = persona.cedula.ToString();
                dateTimePicker1.Value = persona.fecha;
                mtxtNumero.Text = persona.telefono.ToString();
                txtCorreo.Text = persona.correo;
            }
        }

        

        private void btnEditar_Click(object sender, EventArgs e)
        {
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
                    db.Entry(persona).State = EntityState.Modified;
                    db.SaveChanges();
                    CargarDatos();
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Editar Persona",
                         MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}
