namespace winproySerialPort
{
    partial class frmBienvenido
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblInicio = new System.Windows.Forms.Label();
            this.btniniciarCOM = new System.Windows.Forms.Button();
            this.boxVelocidad = new System.Windows.Forms.ComboBox();
            this.boxPuerto = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblInicio
            // 
            this.lblInicio.AutoSize = true;
            this.lblInicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInicio.ForeColor = System.Drawing.Color.White;
            this.lblInicio.Location = new System.Drawing.Point(53, 39);
            this.lblInicio.Name = "lblInicio";
            this.lblInicio.Size = new System.Drawing.Size(183, 37);
            this.lblInicio.TabIndex = 0;
            this.lblInicio.Text = "Bienvenido";
            // 
            // btniniciarCOM
            // 
            this.btniniciarCOM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(26)))), ((int)(((byte)(54)))));
            this.btniniciarCOM.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btniniciarCOM.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btniniciarCOM.ForeColor = System.Drawing.Color.White;
            this.btniniciarCOM.Location = new System.Drawing.Point(99, 194);
            this.btniniciarCOM.Name = "btniniciarCOM";
            this.btniniciarCOM.Size = new System.Drawing.Size(90, 55);
            this.btniniciarCOM.TabIndex = 1;
            this.btniniciarCOM.Text = "Iniciar";
            this.btniniciarCOM.UseVisualStyleBackColor = false;
            this.btniniciarCOM.Click += new System.EventHandler(this.btniniciarCOM_Click);
            // 
            // boxVelocidad
            // 
            this.boxVelocidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(26)))), ((int)(((byte)(54)))));
            this.boxVelocidad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.boxVelocidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.boxVelocidad.ForeColor = System.Drawing.Color.White;
            this.boxVelocidad.FormattingEnabled = true;
            this.boxVelocidad.Location = new System.Drawing.Point(60, 103);
            this.boxVelocidad.Name = "boxVelocidad";
            this.boxVelocidad.Size = new System.Drawing.Size(176, 21);
            this.boxVelocidad.TabIndex = 2;
            // 
            // boxPuerto
            // 
            this.boxPuerto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(26)))), ((int)(((byte)(54)))));
            this.boxPuerto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.boxPuerto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.boxPuerto.ForeColor = System.Drawing.Color.White;
            this.boxPuerto.FormattingEnabled = true;
            this.boxPuerto.Location = new System.Drawing.Point(60, 145);
            this.boxPuerto.Name = "boxPuerto";
            this.boxPuerto.Size = new System.Drawing.Size(176, 21);
            this.boxPuerto.TabIndex = 3;
            // 
            // frmBienvenido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(1)))), ((int)(((byte)(31)))));
            this.ClientSize = new System.Drawing.Size(284, 287);
            this.Controls.Add(this.boxPuerto);
            this.Controls.Add(this.boxVelocidad);
            this.Controls.Add(this.btniniciarCOM);
            this.Controls.Add(this.lblInicio);
            this.Name = "frmBienvenido";
            this.Text = "frmBienvenido";
            this.Load += new System.EventHandler(this.frmBienvenido_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInicio;
        private System.Windows.Forms.Button btniniciarCOM;
        public System.Windows.Forms.ComboBox boxVelocidad;
        public System.Windows.Forms.ComboBox boxPuerto;
    }
}