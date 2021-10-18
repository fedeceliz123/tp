
namespace UI
{
    partial class MensajeOk
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MensajeOk));
            this.lblMensaje = new System.Windows.Forms.Label();
            this.btnModificar = new ePOSOne.btnProduct.Button_WOC();
            this.panelBarrasub = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ellipseComponentes1 = new UI.componentes.EllipseComponentes();
            this.panelBarrasub.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMensaje
            // 
            this.lblMensaje.AutoSize = true;
            this.lblMensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMensaje.ForeColor = System.Drawing.Color.White;
            this.lblMensaje.Location = new System.Drawing.Point(60, 93);
            this.lblMensaje.Name = "lblMensaje";
            this.lblMensaje.Size = new System.Drawing.Size(12, 15);
            this.lblMensaje.TabIndex = 1;
            this.lblMensaje.Text = "-";
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnModificar.BorderColor = System.Drawing.Color.Transparent;
            this.btnModificar.ButtonColor = System.Drawing.Color.DodgerBlue;
            this.btnModificar.FlatAppearance.BorderSize = 0;
            this.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.ForeColor = System.Drawing.Color.White;
            this.btnModificar.Location = new System.Drawing.Point(261, 181);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.OnHoverBorderColor = System.Drawing.SystemColors.GrayText;
            this.btnModificar.OnHoverButtonColor = System.Drawing.Color.DarkBlue;
            this.btnModificar.OnHoverTextColor = System.Drawing.Color.Gray;
            this.btnModificar.Size = new System.Drawing.Size(110, 40);
            this.btnModificar.TabIndex = 79;
            this.btnModificar.Text = "Aceptar";
            this.btnModificar.TextColor = System.Drawing.Color.White;
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // panelBarrasub
            // 
            this.panelBarrasub.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.panelBarrasub.Controls.Add(this.pictureBox1);
            this.panelBarrasub.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBarrasub.Location = new System.Drawing.Point(0, 0);
            this.panelBarrasub.Name = "panelBarrasub";
            this.panelBarrasub.Size = new System.Drawing.Size(646, 44);
            this.panelBarrasub.TabIndex = 80;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(587, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(36, 38);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // ellipseComponentes1
            // 
            this.ellipseComponentes1.CornerRadius = 35;
            this.ellipseComponentes1.TargetControl = this;
            // 
            // MensajeOk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(646, 245);
            this.Controls.Add(this.panelBarrasub);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.lblMensaje);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MensajeOk";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MensajeOk";
            this.panelBarrasub.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblMensaje;
        private ePOSOne.btnProduct.Button_WOC btnModificar;
        private System.Windows.Forms.Panel panelBarrasub;
        private System.Windows.Forms.PictureBox pictureBox1;
        private componentes.EllipseComponentes ellipseComponentes1;
    }
}