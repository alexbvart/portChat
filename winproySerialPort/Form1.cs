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

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            int envio = rchMensajes.Text.Length;
            if (envio > 0)
            {
                objTxRx.Enviar(rchMensajes.Text.Trim());
                //rchMensajes = HorizontalAlignment.Left;
                //rchConversacion.ForeColor = Color.Blue;

                MostrandoMensaje("Saliente:\n" + this.rchMensajes.Text); //envio mi mensajito
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
            //InsertarMensaje(this.txtMessage.Text, "Me");
            rchConversacion.Text += "\n\n" + textMens;
        }
        private void InsertarMensaje(string textMens ,string user)
        {

            if (textMens != "")
            {
                if (rchConversacion.Text == "")
                {
                    rchConversacion.Text = "[" + user + "]\n" + textMens;
                }
                else
                {
                    rchConversacion.Text += "\n\n" + user + "\n" + textMens;
                }
            }

        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        
        private void rchConversacion_TextChanged(object sender, EventArgs e)
        {
            // this.addMessageToChat(message, "Receive");
            rchConversacion.SelectionStart = rchConversacion.TextLength;
            rchConversacion.ScrollToCaret();
        }

        
        private void btnConectar_Click(object sender, EventArgs e)
        {
            string prtName = cmbPuerto.Text;
            int vld = Convert.ToInt32(cmbvelocidad.Text);
            lblConexcionMsg.Text = "Conectado al puerto: " + prtName + " rateBaudios: " + vld;


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
        }

        //Form config = new frmConfig();
        // config.Show();
        private void cmbPuerto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbvelocidad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
