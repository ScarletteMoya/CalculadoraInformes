using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void AbrirFormulario(Form formularioHijo)
        {
            panelContenedor.Controls.Clear(); 
            formularioHijo.TopLevel = false;
            formularioHijo.Dock = DockStyle.Fill; 
            panelContenedor.Controls.Add(formularioHijo); 
            formularioHijo.Show(); 
        }

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        private void panelTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0xA1, 0x2, 0);
        }

        private void BtnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BtnMaximizarRestaurar_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FormCalculadora());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Historial formHistorial = new Historial();
            formHistorial.TopLevel = false;
            formHistorial.FormBorderStyle = FormBorderStyle.None;
            formHistorial.Dock = DockStyle.Fill;

            panelContenedor.Controls.Clear();
            panelContenedor.Controls.Add(formHistorial);
            formHistorial.Show();
        }
    }
}
