using System;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class Historial : Form
    {
        public Historial()
        {
            InitializeComponent();
            DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn();
            btnEditar.HeaderText = "Editar";
            btnEditar.Text = "Editar";
            btnEditar.UseColumnTextForButtonValue = true;
            dgvHistorial.Columns.Add(btnEditar);

            DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
            btnEliminar.HeaderText = "Eliminar";
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseColumnTextForButtonValue = true;
            dgvHistorial.Columns.Add(btnEliminar);
        }

        private void Historial_Load(object sender, EventArgs e)
        {
            CargarHistorial();
            CalculoBL logica = new CalculoBL();
            var lista = logica.ObtenerCalculos();
            dgvHistorial.DataSource = lista;
        }
        private void CargarHistorial()
        {
            CalculoBL logica = new CalculoBL();
            var lista = logica.ObtenerCalculos(); 

            dgvHistorial.DataSource = null;
            dgvHistorial.DataSource = lista;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarHistorial();
        }
    }
}
