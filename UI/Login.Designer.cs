
namespace UI
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.pbpass = new System.Windows.Forms.PictureBox();
            this.pbClose = new System.Windows.Forms.PictureBox();
            this.tbClave = new UI.componentes.RJTextBox();
            this.tbUsuario = new UI.componentes.RJTextBox();
            this.ellipseComponentes1 = new UI.componentes.EllipseComponentes();
            this.btnIngresat = new ePOSOne.btnProduct.Button_WOC();
            this.llblRecuperarClave = new System.Windows.Forms.LinkLabel();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbpass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pbpass
            // 
            this.pbpass.BackColor = System.Drawing.Color.Transparent;
            this.pbpass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbpass.Image = ((System.Drawing.Image)(resources.GetObject("pbpass.Image")));
            this.pbpass.Location = new System.Drawing.Point(286, 261);
            this.pbpass.Name = "pbpass";
            this.pbpass.Size = new System.Drawing.Size(34, 25);
            this.pbpass.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbpass.TabIndex = 3;
            this.pbpass.TabStop = false;
            this.pbpass.Click += new System.EventHandler(this.pbpass_Click);
            // 
            // pbClose
            // 
            this.pbClose.BackColor = System.Drawing.Color.Transparent;
            this.pbClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbClose.Image = ((System.Drawing.Image)(resources.GetObject("pbClose.Image")));
            this.pbClose.Location = new System.Drawing.Point(344, 12);
            this.pbClose.Name = "pbClose";
            this.pbClose.Size = new System.Drawing.Size(34, 29);
            this.pbClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbClose.TabIndex = 4;
            this.pbClose.TabStop = false;
            this.pbClose.Click += new System.EventHandler(this.pbClose_Click);
            // 
            // tbClave
            // 
            this.tbClave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.tbClave.BorderColor = System.Drawing.Color.LightGray;
            this.tbClave.BorderFocusColor = System.Drawing.SystemColors.ActiveBorder;
            this.tbClave.BorderRadius = 5;
            this.tbClave.BorderSize = 2;
            this.tbClave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbClave.ForeColor = System.Drawing.Color.White;
            this.tbClave.Location = new System.Drawing.Point(73, 255);
            this.tbClave.Margin = new System.Windows.Forms.Padding(4);
            this.tbClave.Multiline = false;
            this.tbClave.Name = "tbClave";
            this.tbClave.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tbClave.PasswordChar = true;
            this.tbClave.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.tbClave.PlaceholderText = "Contraseña";
            this.tbClave.Size = new System.Drawing.Size(250, 35);
            this.tbClave.TabIndex = 2;
            this.tbClave.Texts = "";
            this.tbClave.UnderlinedStyle = false;
            // 
            // tbUsuario
            // 
            this.tbUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.tbUsuario.BorderColor = System.Drawing.Color.LightGray;
            this.tbUsuario.BorderFocusColor = System.Drawing.SystemColors.ActiveBorder;
            this.tbUsuario.BorderRadius = 5;
            this.tbUsuario.BorderSize = 2;
            this.tbUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUsuario.ForeColor = System.Drawing.Color.White;
            this.tbUsuario.Location = new System.Drawing.Point(73, 193);
            this.tbUsuario.Margin = new System.Windows.Forms.Padding(4);
            this.tbUsuario.Multiline = false;
            this.tbUsuario.Name = "tbUsuario";
            this.tbUsuario.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.tbUsuario.PasswordChar = false;
            this.tbUsuario.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.tbUsuario.PlaceholderText = "Usuario";
            this.tbUsuario.Size = new System.Drawing.Size(250, 35);
            this.tbUsuario.TabIndex = 1;
            this.tbUsuario.Texts = "";
            this.tbUsuario.UnderlinedStyle = false;
            // 
            // ellipseComponentes1
            // 
            this.ellipseComponentes1.CornerRadius = 40;
            this.ellipseComponentes1.TargetControl = this;
            // 
            // btnIngresat
            // 
            this.btnIngresat.BorderColor = System.Drawing.Color.Silver;
            this.btnIngresat.ButtonColor = System.Drawing.SystemColors.GrayText;
            this.btnIngresat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIngresat.FlatAppearance.BorderSize = 0;
            this.btnIngresat.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.btnIngresat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngresat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngresat.Location = new System.Drawing.Point(114, 339);
            this.btnIngresat.Name = "btnIngresat";
            this.btnIngresat.OnHoverBorderColor = System.Drawing.Color.Gray;
            this.btnIngresat.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(5)))), ((int)(((byte)(5)))));
            this.btnIngresat.OnHoverTextColor = System.Drawing.Color.White;
            this.btnIngresat.Size = new System.Drawing.Size(174, 49);
            this.btnIngresat.TabIndex = 0;
            this.btnIngresat.Text = "Ingresar";
            this.btnIngresat.TextColor = System.Drawing.Color.White;
            this.btnIngresat.UseVisualStyleBackColor = true;
            this.btnIngresat.Click += new System.EventHandler(this.btnIngresat_Click);
            // 
            // llblRecuperarClave
            // 
            this.llblRecuperarClave.ActiveLinkColor = System.Drawing.SystemColors.GrayText;
            this.llblRecuperarClave.AutoSize = true;
            this.llblRecuperarClave.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llblRecuperarClave.ForeColor = System.Drawing.Color.White;
            this.llblRecuperarClave.LinkColor = System.Drawing.Color.White;
            this.llblRecuperarClave.Location = new System.Drawing.Point(135, 304);
            this.llblRecuperarClave.Name = "llblRecuperarClave";
            this.llblRecuperarClave.Size = new System.Drawing.Size(133, 18);
            this.llblRecuperarClave.TabIndex = 5;
            this.llblRecuperarClave.TabStop = true;
            this.llblRecuperarClave.Text = "Recuperar Clave";
            // 
            // pbLogo
            // 
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(127, 29);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(141, 128);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLogo.TabIndex = 6;
            this.pbLogo.TabStop = false;
            this.pbLogo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbLogo_MouseDown);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.ClientSize = new System.Drawing.Size(401, 450);
            this.Controls.Add(this.pbLogo);
            this.Controls.Add(this.llblRecuperarClave);
            this.Controls.Add(this.btnIngresat);
            this.Controls.Add(this.pbClose);
            this.Controls.Add(this.pbpass);
            this.Controls.Add(this.tbClave);
            this.Controls.Add(this.tbUsuario);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbpass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private componentes.RJTextBox tbUsuario;
        private componentes.EllipseComponentes ellipseComponentes1;
        private componentes.RJTextBox tbClave;
        private System.Windows.Forms.PictureBox pbpass;
        private System.Windows.Forms.PictureBox pbClose;
        private ePOSOne.btnProduct.Button_WOC btnIngresat;
        private System.Windows.Forms.LinkLabel llblRecuperarClave;
        private System.Windows.Forms.PictureBox pbLogo;
    }
}