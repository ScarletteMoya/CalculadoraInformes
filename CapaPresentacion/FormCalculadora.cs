using System;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FormCalculadora : Form
    {
        double valor1 = 0;
        string operacion = "";
        bool operacionEnCurso = false;
        public FormCalculadora()
        {
            InitializeComponent();
        }
        private void btnNumero_Click(object sender, EventArgs e)
        {
            if (txtResultado.Text == "0" || operacionEnCurso)
                txtResultado.Text = "";

            operacionEnCurso = false;

            Button btn = (Button)sender;
            txtResultado.Text += btn.Text;
        }
        private void btnOperacion_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            valor1 = double.Parse(txtResultado.Text);
            operacion = btn.Text;
            operacionEnCurso = true;
        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            double valor2 = double.Parse(txtResultado.Text);
            double resultado = 0;

            switch (operacion)
            {
                case "+":
                    resultado = valor1 + valor2;
                    break;
                case "-":
                    resultado = valor1 - valor2;
                    break;
                case "*":
                    resultado = valor1 * valor2;
                    break;
                case "/":
                    if (valor2 != 0)
                        resultado = valor1 / valor2;
                    else
                        MessageBox.Show("No se puede dividir entre cero");
                    break;
            }

            txtResultado.Text = resultado.ToString();
        }

        private void btnRaiz_Click(object sender, EventArgs e)
        {
            double valor = double.Parse(txtResultado.Text);
            txtResultado.Text = Math.Sqrt(valor).ToString();
        }

        private void btnPorcentaje_Click(object sender, EventArgs e)
        {
            double valor = double.Parse(txtResultado.Text);
            txtResultado.Text = (valor / 100).ToString();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtResultado.Text = "0";
            valor1 = 0;
            operacion = "";
            operacionEnCurso = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string resultadoActual = txtResultado.Text; 

            FormGuardarCalculo formGuardar = new FormGuardarCalculo(resultadoActual);

            formGuardar.TopLevel = false;
            formGuardar.FormBorderStyle = FormBorderStyle.None;
            formGuardar.Dock = DockStyle.Fill;

            panelContenedor1.Controls.Clear();
            panelContenedor1.Controls.Add(formGuardar);
            formGuardar.Show();
        }
    }
}
