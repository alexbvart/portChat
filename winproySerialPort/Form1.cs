using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace winproySerialPort
{
    public partial class Form1 : Form
    {
       classTransRecep  objTxRx;
       delegate void MostrarOtroProceso(string mensaje);
       MostrarOtroProceso delegadoMostrar;

       
        public Form1()
        {
            InitializeComponent();
           
        }

        public Form1(string puerto, string velocidad)
        {
            InitializeComponent();
            lblInicio.Text = $"Puerto {puerto}";
            lblConexcionMsg.Text = "rateBaudios: " + velocidad;

            //-------------
            //string prtName = cmbPuerto.Text;
            //int vld = Convert.ToInt32(cmbvelocidad.Text);
            int baudioRate = Convert.ToInt32(velocidad);

            //lblInicio.Text = $"Puerto {prtName}";
            //lblConexcionMsg.Text = "rateBaudios: " + vld;


            objTxRx = new classTransRecep();
            objTxRx.Inicializa(puerto, baudioRate);
            objTxRx.LlegoMensaje += new classTransRecep.HandlerTxRx(objTxRx_LlegoMensaje);
            delegadoMostrar = new MostrarOtroProceso(MostrandoMensaje);
            MostrandoMensaje(this.rchMensajes.Text); //envio mi mensajito

        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            int envio = rchMensajes.Text.Length;
            if (envio > 0)
            {
                //string seenvia = "Recibido:\n" + rchMensajes.Text.Trim();
                objTxRx.Enviar("\nRecibido:\n" + rchMensajes.Text.Trim());//recibo mi mensajito
                //rchMensajes = HorizontalAlignment.Left;
                //rchConversacion.ForeColor = Color.Blue;

                MostrandoMensaje("\nEnviado:\n" + this.rchMensajes.Text); //envio mi mensajito
                rchMensajes.Text = ""; //limpa para enviar nuevo mensaje  
            }
            else
            {   MessageBox.Show("escribe algo primero"); }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            int[] velocidades = {110, 300, 600, 1200, 2400, 4800, 9600, 14400, 19200, 38400, 57600, 115200, 128000 , 256000};
            foreach (var velocidad in velocidades)
            {cmbvelocidad.Items.Add(velocidad);}

            Control.CheckForIllegalCrossThreadCalls = false;
            foreach (string puerto in SerialPort.GetPortNames())
            {cmbPuerto.Items.Add(puerto);}
        }
        private void objTxRx_LlegoMensaje(object o, string mm)
        {
            //MessageBox.Show("se disparó: " + mm);
            Invoke(delegadoMostrar, mm);
        }


        //muestra el menaje en el rich -- addMessageToChat
        private void MostrandoMensaje(string textMens /*,string user*/)
        {
             rchConversacion.Text += "\n"+ textMens;
        }

        // Nos conectamos del puerto
        private void btnConectar_Click(object sender, EventArgs e)
        {
            //frmBienvenido frmbien = new frmBienvenido();
            //string txtport = frmbien.txtpuerto.Text ;

            string prtName = cmbPuerto.Text;
            int vld = Convert.ToInt32(cmbvelocidad.Text);

            lblInicio.Text = $"Puerto {prtName}";
            lblConexcionMsg.Text = "rateBaudios: " + vld;


            objTxRx = new classTransRecep();
            objTxRx.Inicializa(prtName, vld);
            objTxRx.LlegoMensaje += new classTransRecep.HandlerTxRx(objTxRx_LlegoMensaje);
            delegadoMostrar = new MostrarOtroProceso(MostrandoMensaje);
            MostrandoMensaje(this.rchMensajes.Text); //envio mi mensajito
        }

        // Nos desconectamos del puerto
        private void button1_Click(object sender, EventArgs e)
        {
            objTxRx.Finaliza();
            lblConexcionMsg.Text = "Sin Conexion";
            //this.Close();
        }

        //sacroll del rich
        private void rchConversacion_TextChanged(object sender, EventArgs e)
        {
            // this.addMessageToChat(message, "Receive");
            rchConversacion.SelectionStart = rchConversacion.TextLength;
            rchConversacion.ScrollToCaret();
        }

        private void cmbPuerto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void cmbvelocidad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEnviaArchivo_Click(object sender, EventArgs e)
        {
            
            try
            {
                string rutaArchivo = string.Empty;
                OpenFileDialog openFileDialog = new OpenFileDialog();

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //File name devuelve el nombre.. la ruta del archivo
                    rutaArchivo = openFileDialog.FileName;
                }
                objTxRx.IniciaEnvioArchivo(rutaArchivo);
                //objTxRx.IniciaEnvioArchivo("C:\\Users\\BRIONES\\Downloads\\Rectangle 25.png");

            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void btnRecibirArchivo_Click(object sender, EventArgs e)
        {
            objTxRx.InicioConstruirArchivo("ccopia.png", 0, 1);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.objTxRx != null) this.objTxRx.closeConnection();


        }
        //sin comentarios
        //Form config = new frmConfig();
        // config.Show();
    }
}
