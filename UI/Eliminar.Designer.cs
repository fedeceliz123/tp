
namespace UI
{
    partial class Eliminar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Eliminar));
            this.panelBarrasub = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnAceptar = new ePOSOne.btnProduct.Button_WOC();
            this.btnCancelar = new ePOSOne.btnProduct.Button_WOC();
            this.label1 = new System.Windows.Forms.Label();
            this.ellipseComponentes1 = new UI.componentes.EllipseComponentes();
            this.panelBarrasub.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelBarrasub
            // 
            this.panelBarrasub.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.panelBarrasub.Controls.Add(this.pictureBox1);
            this.panelBarrasub.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBarrasub.Location = new System.Drawing.Point(0, 0);
            this.panelBarrasub.Name = "panelBarrasub";
            this.panelBarrasub.Size = new System.Drawing.Size(650, 44);
            this.panelBarrasub.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(591, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(36, 38);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.Transparent;
            this.btnAceptar.BorderColor = System.Drawing.Color.Transparent;
            this.btnAceptar.ButtonColor = System.Drawing.Color.DodgerBlue;
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnAceptar.FlatAppearance.BorderSize = 0;
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.ForeColor = System.Drawing.Color.White;
            this.btnAceptar.Location = new System.Drawing.Point(190, 222);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.OnHoverBorderColor = System.Drawing.SystemColors.GrayText;
            this.btnAceptar.OnHoverButtonColor = System.Drawing.Color.DarkBlue;
            this.btnAceptar.OnHoverTextColor = System.Drawing.Color.Gray;
            this.btnAceptar.Size = new System.Drawing.Size(105, 40);
            this.btnAceptar.TabIndex = 34;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextColor = System.Drawing.Color.White;
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Transparent;
            this.btnCancelar.BorderColor = System.Drawing.Color.Transparent;
            this.btnCancelar.ButtonColor = System.Drawing.Color.DimGray;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.Transparent;
            this.btnCancelar.Location = new System.Drawing.Point(330, 222);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.OnHoverBorderColor = System.Drawing.SystemColors.GrayText;
            this.btnCancelar.OnHoverButtonColor = System.Drawing.Color.DimGray;
            this.btnCancelar.OnHoverTextColor = System.Drawing.Color.Gray;
            this.btnCancelar.Size = new System.Drawing.Size(110, 40);
            this.btnCancelar.TabIndex = 70;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextColor = System.Drawing.Color.White;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(173, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(282, 20);
            this.label1.TabIndex = 74;
            this.label1.Text = "¿Esta seguro que desea eliminar?";
            // 
            // ellipseComponentes1
            // 
            this.ellipseComponentes1.CornerRadius = 35;
            this.ellipseComponentes1.TargetControl = this;
            // 
            // Eliminar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(650, 290);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.panelBarrasub);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Eliminar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Eliminar";
            this.Load += new System.EventHandler(this.Eliminar_Load);
            this.panelBarrasub.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelBarrasub;
        private System.Windows.Forms.PictureBox pictureBox1;
        private ePOSOne.btnProduct.Button_WOC btnAceptar;
        private ePOSOne.btnProduct.Button_WOC btnCancelar;
        private System.Windows.Forms.Label label1;
        private componentes.EllipseComponentes ellipseComponentes1;
    }
}