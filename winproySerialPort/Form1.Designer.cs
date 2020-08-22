namespace winproySerialPort
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnEnviar = new System.Windows.Forms.Button();
            this.rchMensajes = new System.Windows.Forms.RichTextBox();
            this.rchConversacion = new System.Windows.Forms.RichTextBox();
            this.cmbPuerto = new System.Windows.Forms.ComboBox();
            this.cmbvelocidad = new System.Windows.Forms.ComboBox();
            this.btnConectar = new System.Windows.Forms.Button();
            this.lblConexcionMsg = new System.Windows.Forms.Label();
            this.btnDesconet = new System.Windows.Forms.Button();
            this.lblInicio = new System.Windows.Forms.Label();
            this.btnEnviaArchivo = new System.Windows.Forms.Button();
            this.btnRecibirArchivo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEnviar
            // 
            this.btnEnviar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(26)))), ((int)(((byte)(54)))));
            this.btnEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEnviar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnEnviar.Location = new System.Drawing.Point(198, 263);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(60, 40);
            this.btnEnviar.TabIndex = 0;
            this.btnEnviar.Text = "ENVIAR ";
            this.btnEnviar.UseVisualStyleBackColor = false;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // rchMensajes
            // 
            this.rchMensajes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(26)))), ((int)(((byte)(54)))));
            this.rchMensajes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rchMensajes.ForeColor = System.Drawing.SystemColors.Window;
            this.rchMensajes.Location = new System.Drawing.Point(12, 263);
            this.rchMensajes.Name = "rchMensajes";
            this.rchMensajes.Size = new System.Drawing.Size(183, 38);
            this.rchMensajes.TabIndex = 1;
            this.rchMensajes.Text = "";
            this.rchMensajes.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // rchConversacion
            // 
            this.rchConversacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(26)))), ((int)(((byte)(54)))));
            this.rchConversacion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rchConversacion.ForeColor = System.Drawing.SystemColors.Window;
            this.rchConversacion.Location = new System.Drawing.Point(12, 91);
            this.rchConversacion.Name = "rchConversacion";
            this.rchConversacion.Size = new System.Drawing.Size(287, 165);
            this.rchConversacion.TabIndex = 2;
            this.rchConversacion.Text = "";
            this.rchConversacion.TextChanged += new System.EventHandler(this.rchConversacion_TextChanged);
            // 
            // cmbPuerto
            // 
            this.cmbPuerto.FormattingEnabled = true;
            this.cmbPuerto.Location = new System.Drawing.Point(103, 394);
            this.cmbPuerto.Name = "cmbPuerto";
            this.cmbPuerto.Size = new System.Drawing.Size(98, 21);
            this.cmbPuerto.TabIndex = 3;
            this.cmbPuerto.SelectedIndexChanged += new System.EventHandler(this.cmbPuerto_SelectedIndexChanged);
            // 
            // cmbvelocidad
            // 
            this.cmbvelocidad.FormattingEnabled = true;
            this.cmbvelocidad.Location = new System.Drawing.Point(12, 394);
            this.cmbvelocidad.Name = "cmbvelocidad";
            this.cmbvelocidad.Size = new System.Drawing.Size(85, 21);
            this.cmbvelocidad.TabIndex = 4;
            this.cmbvelocidad.SelectedIndexChanged += new System.EventHandler(this.cmbvelocidad_SelectedIndexChanged);
            // 
            // btnConectar
            // 
            this.btnConectar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(26)))), ((int)(((byte)(54)))));
            this.btnConectar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnConectar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConectar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnConectar.ForeColor = System.Drawing.Color.White;
            this.btnConectar.Location = new System.Drawing.Point(207, 392);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(89, 23);
            this.btnConectar.TabIndex = 5;
            this.btnConectar.Text = "CONECTAR";
            this.btnConectar.UseMnemonic = false;
            this.btnConectar.UseVisualStyleBackColor = false;
            this.btnConectar.Click += new System.EventHandler(this.btnConectar_Click);
            // 
            // lblConexcionMsg
            // 
            this.lblConexcionMsg.AutoSize = true;
            this.lblConexcionMsg.BackColor = System.Drawing.Color.Transparent;
            this.lblConexcionMsg.ForeColor = System.Drawing.Color.White;
            this.lblConexcionMsg.Location = new System.Drawing.Point(12, 374);
            this.lblConexcionMsg.Name = "lblConexcionMsg";
            this.lblConexcionMsg.Size = new System.Drawing.Size(13, 13);
            this.lblConexcionMsg.TabIndex = 6;
            this.lblConexcionMsg.Text = ">";
            // 
            // btnDesconet
            // 
            this.btnDesconet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(26)))), ((int)(((byte)(54)))));
            this.btnDesconet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDesconet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDesconet.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDesconet.ForeColor = System.Drawing.Color.White;
            this.btnDesconet.Location = new System.Drawing.Point(198, 421);
            this.btnDesconet.Name = "btnDesconet";
            this.btnDesconet.Size = new System.Drawing.Size(98, 23);
            this.btnDesconet.TabIndex = 7;
            this.btnDesconet.Text = "DESCONECTAR";
            this.btnDesconet.UseMnemonic = false;
            this.btnDesconet.UseVisualStyleBackColor = false;
            this.btnDesconet.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblInicio
            // 
            this.lblInicio.AutoSize = true;
            this.lblInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInicio.ForeColor = System.Drawing.Color.White;
            this.lblInicio.Location = new System.Drawing.Point(12, 38);
            this.lblInicio.Name = "lblInicio";
            this.lblInicio.Size = new System.Drawing.Size(183, 37);
            this.lblInicio.TabIndex = 8;
            this.lblInicio.Text = "Bienvenido";
            // 
            // btnEnviaArchivo
            // 
            this.btnEnviaArchivo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(26)))), ((int)(((byte)(54)))));
            this.btnEnviaArchivo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEnviaArchivo.ForeColor = System.Drawing.Color.White;
            this.btnEnviaArchivo.Location = new System.Drawing.Point(259, 263);
            this.btnEnviaArchivo.Name = "btnEnviaArchivo";
            this.btnEnviaArchivo.Size = new System.Drawing.Size(40, 40);
            this.btnEnviaArchivo.TabIndex = 9;
            this.btnEnviaArchivo.Text = "A";
            this.btnEnviaArchivo.UseVisualStyleBackColor = false;
            this.btnEnviaArchivo.Click += new System.EventHandler(this.btnEnviaArchivo_Click);
            // 
            // btnRecibirArchivo
            // 
            this.btnRecibirArchivo.Location = new System.Drawing.Point(207, 334);
            this.btnRecibirArchivo.Name = "btnRecibirArchivo";
            this.btnRecibirArchivo.Size = new System.Drawing.Size(75, 23);
            this.btnRecibirArchivo.TabIndex = 10;
            this.btnRecibirArchivo.Text = "Recibir";
            this.btnRecibirArchivo.UseVisualStyleBackColor = true;
            this.btnRecibirArchivo.Click += new System.EventHandler(this.btnRecibirArchivo_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(1)))), ((int)(((byte)(31)))));
            this.ClientSize = new System.Drawing.Size(313, 483);
            this.Controls.Add(this.btnRecibirArchivo);
            this.Controls.Add(this.btnEnviaArchivo);
            this.Controls.Add(this.lblInicio);
            this.Controls.Add(this.btnDesconet);
            this.Controls.Add(this.lblConexcionMsg);
            this.Controls.Add(this.btnConectar);
            this.Controls.Add(this.cmbvelocidad);
            this.Controls.Add(this.cmbPuerto);
            this.Controls.Add(this.rchConversacion);
            this.Controls.Add(this.rchMensajes);
            this.Controls.Add(this.btnEnviar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BRIONES VENTURA";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.RichTextBox rchMensajes;
        private System.Windows.Forms.RichTextBox rchConversacion;
        private System.Windows.Forms.ComboBox cmbPuerto;
        private System.Windows.Forms.ComboBox cmbvelocidad;
        private System.Windows.Forms.Button btnConectar;
        private System.Windows.Forms.Label lblConexcionMsg;
        private System.Windows.Forms.Button btnDesconet;
        public System.Windows.Forms.Label lblInicio;
        private System.Windows.Forms.Button btnEnviaArchivo;
        private System.Windows.Forms.Button btnRecibirArchivo;
    }
}

