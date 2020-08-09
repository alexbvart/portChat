using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows.Forms;
using System.Threading;
namespace winproySerialPort
{
    class classTransRecep
    {
        public delegate void HandlerTxRx(object oo, string mensRec);
        public event HandlerTxRx LlegoMensaje;

        Thread procesoEnvio;
        Thread procesoVerificaSalida;
        Thread procesoRecibirMensaje;



        private SerialPort puerto;
        private string mensajeEnviar;
        private string mensRecibido;

        private Boolean BufferSalidaVacio;

        byte[] TramaEnvio;
        byte[] TramCabeceraEnvio;
        byte[] tramaRelleno;
        byte[] TramaRecibida;


        public classTransRecep()
        {
            TramaEnvio = new byte[1024];
            TramCabeceraEnvio = new byte[5];
            tramaRelleno = new byte[1024];
            TramaRecibida = new byte[1024];


            for (int i = 0; i <= 1023; i++)
            {
                tramaRelleno[i] = 64;
            }
        }

        public void Inicializa(string NombrePuerto, int velocidad)
        {
            try
            {
                puerto = new SerialPort(NombrePuerto, velocidad, Parity.Even, 8, StopBits.Two);
                puerto.ReceivedBytesThreshold = 1024;
                puerto.DataReceived += new SerialDataReceivedEventHandler(puerto_DataReceived);
                //puerto.Open();

                //BufferSalidaVacio = true;

                //procesoVerificaSalida = new Thread(verificandoSalida);
                //procesoVerificaSalida.Start();
            }
            catch(Exception er)
            {
                // throw new Exception("Invalid port");
                MessageBox.Show(er.Message);
            }
            try
            {
                puerto.Open();

                BufferSalidaVacio = true;

                procesoVerificaSalida = new Thread(verificandoSalida);
                procesoVerificaSalida.Start();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }

            //MessageBox.Show("apertura del puerto " + puerto.PortName);
        }
        public void Finaliza()
        {

            try
            {
                procesoVerificaSalida.Abort();
                puerto.Dispose();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void puerto_DataReceived(object o, SerialDataReceivedEventArgs sd)
        {
            //MessageBox.Show("se disparo el evento de recepcion");
            //mensRecibido = puerto.ReadExisting();
            if (puerto.BytesToRead>=1024) //nos indica la cantidad de bytes que va leyendo
            {
                puerto.Read(TramaRecibida, 0, 1024); // leer los 1023 bytes que llegues al puerto

                string TAREA = ASCIIEncoding.UTF8.GetString(TramaRecibida, 0, 1);

                switch (TAREA) {
                    case "M":
                        procesoRecibirMensaje = new Thread(RecibiendoMensaje);
                        procesoRecibirMensaje.Start();
                        break;
                    case "A":
                        break;
                    case "I":
                        break;
                    default:
                        MessageBox.Show("Trama no reconocida");
                        break;

                }
                //string CabRec = ASCIIEncoding.UTF8.GetString(TramaRecibida,0,5);
                //int LongMensRec = Convert.ToInt16(CabRec); 
                //-- decodificar variable (mensaje) recibida                          (999)
                //mensRecibido = ASCIIEncoding.UTF8.GetString(TramaRecibida, 5, LongMensRec);
                //OnLlegoMensaje();

            }

            //MessageBox.Show(mensRecibido);
        }

        private void RecibiendoMensaje()
        {
            string CabRec = ASCIIEncoding.UTF8.GetString(TramaRecibida, 1, 4);
            int LongMensRec = Convert.ToInt16(CabRec);//                       (999)
            mensRecibido = ASCIIEncoding.UTF8.GetString(TramaRecibida, 5, LongMensRec);
            OnLlegoMensaje();
        }
        protected virtual void OnLlegoMensaje()
        {
            if (LlegoMensaje != null)
                LlegoMensaje(this, mensRecibido);
        }

        public void Enviar(string mens)
        {
            mensajeEnviar = mens;
            string lreal = mensajeEnviar.Length.ToString();
            string longMenString = "";
            TramaEnvio = ASCIIEncoding.UTF8.GetBytes(mensajeEnviar);
            //TramCabeceraEnvio contener la longitud del mensaje

            if (lreal.ToString().Length == 1)
                longMenString = "M000" + mensajeEnviar.Length.ToString();
            if (lreal.ToString().Length == 2)
                longMenString = "M00" + mensajeEnviar.Length.ToString();
            if (lreal.ToString().Length == 3)
                longMenString = "M0" + mensajeEnviar.Length.ToString();

            TramCabeceraEnvio = ASCIIEncoding.UTF8.GetBytes(longMenString);
            procesoEnvio = new Thread(Enviando);
            procesoEnvio.Start();
        }

        private void Enviando()
        {
            puerto.Write(TramCabeceraEnvio, 0, 5);
            puerto.Write(TramaEnvio, 0, TramaEnvio.Length);
            puerto.Write(tramaRelleno, 0, 1019 - TramaEnvio.Length);
            //MessageBox.Show("mensaje terminado de enviar");
        }

        public void Recibir()
        {
            mensRecibido = puerto.ReadExisting();
            MessageBox.Show(mensRecibido);
        }

        private void verificandoSalida()//indica si buffer esta vacio
        {
            while(true){
                if (puerto.BytesToWrite>0)
	            {
		             //Buffer de salida no vacio
                    BufferSalidaVacio=false;
	            }
                else
	            {
                    BufferSalidaVacio=true;
	            }
            }
        }

        public int BytesPorSalir(){
            int cantBytes= 0; //cantidadBytesPorSalir
            if (BufferSalidaVacio==false)
	        {
		        cantBytes = puerto.BytesToWrite;
	        }return cantBytes;
        }
    }
}