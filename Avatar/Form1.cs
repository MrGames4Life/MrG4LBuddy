using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Web;
using System.Net;
using System.Diagnostics;
using System.IO;
using System.Media;

namespace Avatar
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer timer;
        private Random random;
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;

            // Crear el temporizador
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 2000; // 2 segundos
            timer.Tick += Timer_Tick;

            // Crear el generador de números aleatorios
            random = new Random();

            // Iniciar el temporizador
            timer.Start();
            
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Cerrar la ventana
            this.Hide();

            // Generar coordenadas aleatorias dentro de los límites de la pantalla
            int x = random.Next(Screen.PrimaryScreen.Bounds.Width - this.Width);
            int y = random.Next(Screen.PrimaryScreen.Bounds.Height - this.Height);

            // Establecer la nueva ubicación de la ventana
            this.Location = new Point(x, y);

            // Abrir la ventana nuevamente después de 2 segundos
            timer.Stop(); // Detener el temporizador para evitar que se abra la ventana repetidamente
            timer.Interval = 2000; // 2 segundos
            timer.Start(); // Iniciar el temporizador nuevamente

            this.Show(); // Abrir la ventana
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("¡Buenos días!", "Mr G4L");

            // Mostrar el cuadro de diálogo de solicitud de permiso
            DialogResult result = MessageBox.Show("¿Quieres escuchar música?", "Mr G4L", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);

            // Si se concede el permiso, reproducir el archivo de audio
            if (result == DialogResult.Yes)
            {
                string url = "https://drive.google.com/uc?export=download&id=1JEPUXC2tmPKKy1A-iWVWr0Qe5PN-KllC";
                Process.Start(url);
                MessageBox.Show("Descargué el archivo de música. ¡Ya está listo para ser escuchado!", "Mr G4L", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                string downloadsPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
                Process.Start(downloadsPath);
                MessageBox.Show("¡Aquí está!", "Mr G4L", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }


        }
    }
}

