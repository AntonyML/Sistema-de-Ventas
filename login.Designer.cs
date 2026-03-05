namespace sistema_de_ventas
{
    partial class login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(login));
            this.label2Contraseña = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtContraseña = new System.Windows.Forms.TextBox();
            this.button2Salir = new System.Windows.Forms.Button();
            this.button1Entrar = new System.Windows.Forms.Button();
            this.label1Usuario = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // label2Contraseña
            // 
            this.label2Contraseña.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2Contraseña.AutoSize = true;
            this.label2Contraseña.BackColor = System.Drawing.Color.Transparent;
            this.label2Contraseña.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2Contraseña.ForeColor = System.Drawing.Color.White;
            this.label2Contraseña.Location = new System.Drawing.Point(320, 217);
            this.label2Contraseña.Name = "label2Contraseña";
            this.label2Contraseña.Size = new System.Drawing.Size(146, 29);
            this.label2Contraseña.TabIndex = 1;
            this.label2Contraseña.Text = "Contraseña";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtUsuario.Location = new System.Drawing.Point(320, 155);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(160, 20);
            this.txtUsuario.TabIndex = 2;
            this.txtUsuario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUsuario_KeyDown);
            this.txtUsuario.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtUsuario_MouseDown);
            // 
            // txtContraseña
            // 
            this.txtContraseña.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtContraseña.Location = new System.Drawing.Point(320, 249);
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.PasswordChar = '*';
            this.txtContraseña.Size = new System.Drawing.Size(160, 20);
            this.txtContraseña.TabIndex = 2;
            // 
            // button2Salir
            // 
            this.button2Salir.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button2Salir.BackColor = System.Drawing.Color.Crimson;
            this.button2Salir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2Salir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2Salir.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2Salir.ForeColor = System.Drawing.Color.LavenderBlush;
            this.button2Salir.Location = new System.Drawing.Point(237, 306);
            this.button2Salir.Name = "button2Salir";
            this.button2Salir.Size = new System.Drawing.Size(120, 43);
            this.button2Salir.TabIndex = 3;
            this.button2Salir.Text = "Salir";
            this.button2Salir.UseVisualStyleBackColor = false;
            this.button2Salir.Click += new System.EventHandler(this.button2Salir_Click);
            // 
            // button1Entrar
            // 
            this.button1Entrar.BackColor = System.Drawing.Color.DarkGreen;
            this.button1Entrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1Entrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1Entrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1Entrar.ForeColor = System.Drawing.Color.White;
            this.button1Entrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1Entrar.Location = new System.Drawing.Point(418, 306);
            this.button1Entrar.Name = "button1Entrar";
            this.button1Entrar.Size = new System.Drawing.Size(120, 43);
            this.button1Entrar.TabIndex = 4;
            this.button1Entrar.Text = "Entrar";
            this.button1Entrar.UseVisualStyleBackColor = false;
            this.button1Entrar.Click += new System.EventHandler(this.button1Entrar_Click);
            // 
            // label1Usuario
            // 
            this.label1Usuario.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1Usuario.AutoSize = true;
            this.label1Usuario.BackColor = System.Drawing.Color.Transparent;
            this.label1Usuario.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1Usuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1Usuario.ForeColor = System.Drawing.Color.White;
            this.label1Usuario.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label1Usuario.Location = new System.Drawing.Point(339, 123);
            this.label1Usuario.Name = "label1Usuario";
            this.label1Usuario.Size = new System.Drawing.Size(103, 29);
            this.label1Usuario.TabIndex = 0;
            this.label1Usuario.Text = "Usuario";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::sistema_de_ventas.Properties.Resources.contrasena;
            this.pictureBox2.Location = new System.Drawing.Point(263, 217);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(51, 51);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::sistema_de_ventas.Properties.Resources.perfil;
            this.pictureBox1.Location = new System.Drawing.Point(263, 123);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(51, 52);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.label1Usuario);
            this.panel1.Controls.Add(this.button2Salir);
            this.panel1.Controls.Add(this.txtUsuario);
            this.panel1.Controls.Add(this.button1Entrar);
            this.panel1.Controls.Add(this.label2Contraseña);
            this.panel1.Controls.Add(this.txtContraseña);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Location = new System.Drawing.Point(0, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(769, 451);
            this.panel1.TabIndex = 7;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(0, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(769, 451);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(768, 450);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1Usuario;
        private System.Windows.Forms.Label label2Contraseña;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.Button button2Salir;
        private System.Windows.Forms.Button button1Entrar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}

