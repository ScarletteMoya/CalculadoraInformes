using System;
using System.Windows.Forms;
using CapaNegocio;

namespace CapaPresentacion
{
    public partial class FormGuardarCalculo : Form
    {
        public FormGuardarCalculo()
        {
            InitializeComponent();
        }
        public FormGuardarCalculo(string resultadoCalculadora)
        {
            InitializeComponent();
            txtResultadoFinal.Text = resultadoCalculadora;

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtNombre.Text.Trim();
                string descripcion = txtDescripcion.Text.Trim();
                string categoria = cmbCategoria.SelectedItem?.ToString() ?? "";
                string carpeta = cmbCarpeta.SelectedItem?.ToString() ?? "";
                string resultado = txtResultadoFinal.Text.Trim();

                CalculoBL logica = new CalculoBL();
                bool guardado = logica.GuardarCalculo(nombre, descripcion, resultado, categoria, carpeta);

                if (guardado)
                {
                    MessageBox.Show("Cálculo guardado correctamente");
                }
                else
                {
                    MessageBox.Show("Error al guardar el cálculo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error técnico: " + ex.Message);
            }
        }

        private void FormGuardarCalculo_Load(object sender, EventArgs e)
        {
            try
            {
                CategoriaBL categoriaBL = new CategoriaBL();
                CarpetaBL carpetaBL = new CarpetaBL();

                cmbCategoria.Items.AddRange(categoriaBL.ObtenerNombresCategorias().ToArray());
                cmbCarpeta.Items.AddRange(carpetaBL.ObtenerNombresCarpetas().ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Parent.Controls.Remove(this);
            this.Dispose();
        }
    }
}
