using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace winproySerialPort
{
    class classTransRecep
    {
        public delegate void HandlerTxRx(object oo, string mensRec);
        public event HandlerTxRx LlegoMensaje;

        private SerialPort puerto;

        //------Streams enviar/recibir archivo
        private classArchivoEnviando archivoaEnviar;
        private FileStream FlujoArchivoEnviar;
        private BinaryReader LeyendoArchivo;

        private classArchivoEnviando archivoaRecibir;
        private FileStream FlujoArchivoRecibir;
        private BinaryWriter EscribiendoArchivo;


        //---- Hilos
        Thread procesoEnvio;
        Thread procesoVerificaSalida;
        Thread procesoRecibirMensaje;

        Thread procedoEnvioArchivo; // hilo de envio de archivos
        Thread procesoConstruyeArchivo; // hilo de construye de archivos




        private string mensajeEnviar;
        private string mensRecibido;

        private Boolean BufferSalidaVacio;
        private bool hiloBuffer;

        //-----Tramas de envio
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
            hiloBuffer = true;


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
            }
            catch(Exception er)
            {
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

            try
            {
                archivoaEnviar = new classArchivoEnviando();
                archivoaRecibir = new classArchivoEnviando();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);

            }
            //MessageBox.Show("apertura del puerto " + puerto.PortName);
        }
        public void closeConnection() {
            this.hiloBuffer = false;
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
                    case "M": //                ::      MEnsaje
                        procesoRecibirMensaje = new Thread(RecibiendoMensaje);
                        procesoRecibirMensaje.Start();
                        break;
                    //case "AC":
                    //    break;
                    case "A"://                ::      Archivo
                        //procesoConstruyeArchivo = new Thread(ContruirArchivo);
                        //procesoConstruyeArchivo.Start();
                        ContruirArchivo();
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
            puerto.Write(TramaEnvio, 0, TramaEnvio.Length); //mensaje como tal
            puerto.Write(tramaRelleno, 0, 1019 - TramaEnvio.Length); //rellena los espacios vacios del 1024
            //MessageBox.Show("mensaje terminado de enviar");
        }

        public void Recibir()
        {
            mensRecibido = puerto.ReadExisting();
            MessageBox.Show(mensRecibido);
        }

        private void verificandoSalida()//indica si buffer esta vacio
        {
            while(hiloBuffer){              	                              
                BufferSalidaVacio = puerto.BytesToWrite == 0;
                Thread.Sleep(10);
            }
        }

        public int BytesPorSalir(){
            int cantBytes= 0; //cantidadBytesPorSalir
            if (BufferSalidaVacio)
	        {
		        cantBytes = puerto.BytesToWrite;
	        }
            return cantBytes;
        }


        public void IniciaEnvioArchivo(string nombreArchivo)
        {
            try
            {
                //abrir y manejar trycath
                FlujoArchivoEnviar = new FileStream(nombreArchivo, FileMode.Open, FileAccess.Read);
                //flujodeArchivo = new FileStream($"{ruta}", FileMode.Open, FileAccess.Read);
                LeyendoArchivo = new BinaryReader(FlujoArchivoEnviar);

                //propiedades del archivo desde la clase creada
                archivoaEnviar.nombre = nombreArchivo;
                archivoaEnviar.tamaño = FlujoArchivoEnviar.Length;
                archivoaEnviar.avance = 0;
                archivoaEnviar.numero = 1;
                //archivoaEnviar.

                //leerlo en strem
                //iniciar hilo de envio
                procedoEnvioArchivo = new Thread(EnviandoArchivo);
                procedoEnvioArchivo.Start();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void EnviandoArchivo()
        {
            byte[] TramaEnvioArchivo        = new byte[1019];
            byte[] TramaCabeceraEnvioArchivo = new byte[5];


            //TramaCabeceraEnvioArchivo = ASCIIEncoding.UTF8.GetBytes("AC001"); //cabecera     :: enviar la primera treama con el nombre del archivo
            TramaCabeceraEnvioArchivo = ASCIIEncoding.UTF8.GetBytes("AI001"); //informacion  :: enviar las tramas de información


            while (archivoaEnviar.avance <= archivoaEnviar.tamaño - 1019)
            {   //hacemos la lectura del archivo
                LeyendoArchivo.Read(TramaEnvioArchivo, 0, 1019);    //                :: envio de ina trama entera de 1019
                archivoaEnviar.avance = archivoaEnviar.avance + 1019;
                
                while (!BufferSalidaVacio)
                {   //no hacemos nada hasta que este vacio
                }
                puerto.Write(TramaCabeceraEnvioArchivo, 0, 5);
                puerto.Write(TramaEnvioArchivo, 0, TramaEnvioArchivo.Length); 
            }


            //------ enviamos la colita
            int colita = Convert.ToInt16((archivoaEnviar.tamaño - archivoaEnviar.avance));
            LeyendoArchivo.Read(TramaEnvioArchivo, 0, colita);     //                :: envio de ina trama colita
            while (!BufferSalidaVacio)
            {   //no hacemos nada hasta que este vacio
            }
            puerto.Write(TramaCabeceraEnvioArchivo, 0, 5);
            puerto.Write(TramaEnvioArchivo, 0, colita);             //                :: mensaje como tal
            puerto.Write(tramaRelleno, 0, 1019 - colita);           //                :: rellena los espacios vacios 
            //MessageBox.Show($"avance: {archivoaEnviar.avance}+{colita}=" + (archivoaEnviar.avance + colita));

            LeyendoArchivo.Close();
            FlujoArchivoEnviar.Close();
        }
        // dee ser provate, y llamarse en un huiloo al recibir la primera trama FILE
        //(tamaño, nombre, numero ...)
        public void InicioConstruirArchivo(string nombreArchivo, long tamaño, int id)
        {
            FlujoArchivoRecibir = new FileStream(nombreArchivo, FileMode.CreateNew, FileAccess.Write);
            EscribiendoArchivo = new BinaryWriter(FlujoArchivoRecibir);

            archivoaRecibir.nombre = nombreArchivo;
            archivoaRecibir.numero = 1;
            archivoaRecibir.tamaño = 31831;
            //tamaño;//31831; //FlujoArchivoRecibir.Length;
            //archivoaRecibir.avance = 0;
        }

        private void ContruirArchivo()
        {   //implementar una lista de archivos oooooooooooooooooooooooooooooo
            if (archivoaRecibir.avance <= archivoaRecibir.tamaño-1019)
            {
                EscribiendoArchivo.Write(TramaRecibida, 5, 1019);
                archivoaRecibir.avance = archivoaRecibir.avance + 1019;
               // MessageBox.Show($"avance-CONSTRUCCION: {archivoaRecibir.avance} de {archivoaRecibir.tamaño}");
            }
            else
            {
                int colita = Convert.ToInt16((archivoaRecibir.tamaño - archivoaRecibir.avance));
                EscribiendoArchivo.Write(TramaRecibida, 5, colita);
                EscribiendoArchivo.Close();
                FlujoArchivoRecibir.Close();
                //MessageBox.Show($"CONSTRUIDO: {archivoaRecibir.avance}+{colita}=" + (archivoaRecibir.avance + colita));
            }
        }
    }
}