using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows.Forms;

namespace winproySerialPort
{
    public partial class frmBienvenido : Form
    {
        public frmBienvenido()
        {
            InitializeComponent();
        }

        private void frmBienvenido_Load(object sender, EventArgs e)
        {
            int[] velocidades = { 110, 300, 600, 1200, 2400, 4800, 9600, 14400, 19200, 38400, 57600, 115200, 128000, 256000 };
            foreach (var velocidad in velocidades)
            { boxVelocidad.Items.Add(velocidad); }

            Control.CheckForIllegalCrossThreadCalls = false;
            foreach (string puerto in SerialPort.GetPortNames())
            { boxPuerto.Items.Add(puerto); }
        }

        private void btniniciarCOM_Click(object sender, EventArgs e)
        {
           

            string puerto = boxPuerto.Text;
            string velocidad = boxVelocidad.Text;
            Form inicioCOM = new Form1(puerto,velocidad);
            //Form inicioCOM = new Form1();

            inicioCOM.Show();


        }


    }
}
