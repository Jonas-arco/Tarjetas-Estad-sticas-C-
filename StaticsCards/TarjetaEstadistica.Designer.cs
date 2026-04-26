namespace StaticsCards
{
    partial class TarjetaEstadistica
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel_superior = new System.Windows.Forms.Panel();
            this.panel_lateral_izquierdo = new System.Windows.Forms.TableLayoutPanel();
            this.panel_lateral_derecho = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblValor = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.picIcono = new System.Windows.Forms.PictureBox();
            this.panel_superior.SuspendLayout();
            this.panel_lateral_izquierdo.SuspendLayout();
            this.panel_lateral_derecho.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picIcono)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_superior
            // 
            this.panel_superior.Controls.Add(this.lblTitulo);
            this.panel_superior.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_superior.Location = new System.Drawing.Point(20, 20);
            this.panel_superior.Name = "panel_superior";
            this.panel_superior.Size = new System.Drawing.Size(230, 34);
            this.panel_superior.TabIndex = 5;
            // 
            // panel_lateral_izquierdo
            // 
            this.panel_lateral_izquierdo.ColumnCount = 1;
            this.panel_lateral_izquierdo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panel_lateral_izquierdo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panel_lateral_izquierdo.Controls.Add(this.lblSubtitulo, 0, 1);
            this.panel_lateral_izquierdo.Controls.Add(this.lblValor, 0, 0);
            this.panel_lateral_izquierdo.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_lateral_izquierdo.Location = new System.Drawing.Point(20, 54);
            this.panel_lateral_izquierdo.Name = "panel_lateral_izquierdo";
            this.panel_lateral_izquierdo.RowCount = 2;
            this.panel_lateral_izquierdo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 67.60564F));
            this.panel_lateral_izquierdo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 32.39437F));
            this.panel_lateral_izquierdo.Size = new System.Drawing.Size(138, 71);
            this.panel_lateral_izquierdo.TabIndex = 6;
            // 
            // panel_lateral_derecho
            // 
            this.panel_lateral_derecho.Controls.Add(this.picIcono);
            this.panel_lateral_derecho.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_lateral_derecho.Location = new System.Drawing.Point(158, 54);
            this.panel_lateral_derecho.Name = "panel_lateral_derecho";
            this.panel_lateral_derecho.Size = new System.Drawing.Size(92, 71);
            this.panel_lateral_derecho.TabIndex = 7;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblTitulo.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.Gray;
            this.lblTitulo.Location = new System.Drawing.Point(3, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(123, 19);
            this.lblTitulo.TabIndex = 12;
            this.lblTitulo.Text = "Ventas Totales";
            // 
            // lblValor
            // 
            this.lblValor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblValor.AutoSize = true;
            this.lblValor.BackColor = System.Drawing.Color.Transparent;
            this.lblValor.Font = new System.Drawing.Font("Arial Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblValor.Location = new System.Drawing.Point(3, 7);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(95, 33);
            this.lblValor.TabIndex = 13;
            this.lblValor.Text = "label3";
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblSubtitulo.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitulo.Location = new System.Drawing.Point(3, 48);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(46, 20);
            this.lblSubtitulo.TabIndex = 14;
            this.lblSubtitulo.Text = "label4";
            // 
            // picIcono
            // 
            this.picIcono.BackColor = System.Drawing.Color.Transparent;
            this.picIcono.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picIcono.Location = new System.Drawing.Point(0, 0);
            this.picIcono.Name = "picIcono";
            this.picIcono.Size = new System.Drawing.Size(92, 71);
            this.picIcono.TabIndex = 15;
            this.picIcono.TabStop = false;
            // 
            // TarjetaEstadistica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Controls.Add(this.panel_lateral_derecho);
            this.Controls.Add(this.panel_lateral_izquierdo);
            this.Controls.Add(this.panel_superior);
            this.Margin = new System.Windows.Forms.Padding(15);
            this.Name = "TarjetaEstadistica";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.Size = new System.Drawing.Size(270, 145);
            this.panel_superior.ResumeLayout(false);
            this.panel_superior.PerformLayout();
            this.panel_lateral_izquierdo.ResumeLayout(false);
            this.panel_lateral_izquierdo.PerformLayout();
            this.panel_lateral_derecho.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picIcono)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_superior;
        private System.Windows.Forms.TableLayoutPanel panel_lateral_izquierdo;
        private System.Windows.Forms.Panel panel_lateral_derecho;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.PictureBox picIcono;
    }
}
