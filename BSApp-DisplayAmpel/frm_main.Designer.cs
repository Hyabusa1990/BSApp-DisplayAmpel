namespace BSApp_DisplayAmpel
{
    partial class Frm_main
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tlp_vert = new System.Windows.Forms.TableLayoutPanel();
            this.pb_yLine = new System.Windows.Forms.PictureBox();
            this.tlp_color = new System.Windows.Forms.TableLayoutPanel();
            this.btn_red = new System.Windows.Forms.Button();
            this.btn_abcd = new System.Windows.Forms.Button();
            this.btn_green = new System.Windows.Forms.Button();
            this.btn_yellow = new System.Windows.Forms.Button();
            this.lbl_time = new System.Windows.Forms.Label();
            this.tim_update = new System.Windows.Forms.Timer(this.components);
            this.bgw_UDPClient = new System.ComponentModel.BackgroundWorker();
            this.tlp_vert.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_yLine)).BeginInit();
            this.tlp_color.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlp_vert
            // 
            this.tlp_vert.ColumnCount = 1;
            this.tlp_vert.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_vert.Controls.Add(this.pb_yLine, 0, 1);
            this.tlp_vert.Controls.Add(this.tlp_color, 0, 2);
            this.tlp_vert.Controls.Add(this.lbl_time, 0, 0);
            this.tlp_vert.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_vert.Location = new System.Drawing.Point(0, 0);
            this.tlp_vert.Margin = new System.Windows.Forms.Padding(0);
            this.tlp_vert.Name = "tlp_vert";
            this.tlp_vert.RowCount = 3;
            this.tlp_vert.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.66666F));
            this.tlp_vert.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 2F));
            this.tlp_vert.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tlp_vert.Size = new System.Drawing.Size(360, 240);
            this.tlp_vert.TabIndex = 0;
            // 
            // pb_yLine
            // 
            this.pb_yLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_yLine.Location = new System.Drawing.Point(0, 158);
            this.pb_yLine.Margin = new System.Windows.Forms.Padding(0);
            this.pb_yLine.Name = "pb_yLine";
            this.pb_yLine.Size = new System.Drawing.Size(360, 2);
            this.pb_yLine.TabIndex = 0;
            this.pb_yLine.TabStop = false;
            // 
            // tlp_color
            // 
            this.tlp_color.ColumnCount = 4;
            this.tlp_color.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlp_color.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlp_color.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlp_color.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlp_color.Controls.Add(this.btn_red, 0, 0);
            this.tlp_color.Controls.Add(this.btn_abcd, 0, 0);
            this.tlp_color.Controls.Add(this.btn_green, 0, 0);
            this.tlp_color.Controls.Add(this.btn_yellow, 0, 0);
            this.tlp_color.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_color.Location = new System.Drawing.Point(3, 163);
            this.tlp_color.Name = "tlp_color";
            this.tlp_color.RowCount = 1;
            this.tlp_color.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlp_color.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tlp_color.Size = new System.Drawing.Size(354, 74);
            this.tlp_color.TabIndex = 1;
            // 
            // btn_red
            // 
            this.btn_red.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_red.Enabled = false;
            this.btn_red.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_red.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_red.Location = new System.Drawing.Point(179, 3);
            this.btn_red.Name = "btn_red";
            this.btn_red.Size = new System.Drawing.Size(82, 68);
            this.btn_red.TabIndex = 5;
            this.btn_red.UseVisualStyleBackColor = true;
            // 
            // btn_abcd
            // 
            this.btn_abcd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_abcd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_abcd.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_abcd.Location = new System.Drawing.Point(267, 3);
            this.btn_abcd.Name = "btn_abcd";
            this.btn_abcd.Size = new System.Drawing.Size(84, 68);
            this.btn_abcd.TabIndex = 4;
            this.btn_abcd.Text = "AB";
            this.btn_abcd.UseVisualStyleBackColor = true;
            this.btn_abcd.Click += new System.EventHandler(this.btn_abcd_Click);
            // 
            // btn_green
            // 
            this.btn_green.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_green.Enabled = false;
            this.btn_green.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_green.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_green.Location = new System.Drawing.Point(3, 3);
            this.btn_green.Name = "btn_green";
            this.btn_green.Size = new System.Drawing.Size(82, 68);
            this.btn_green.TabIndex = 3;
            this.btn_green.UseVisualStyleBackColor = true;
            // 
            // btn_yellow
            // 
            this.btn_yellow.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btn_yellow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_yellow.Enabled = false;
            this.btn_yellow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_yellow.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_yellow.Location = new System.Drawing.Point(91, 3);
            this.btn_yellow.Name = "btn_yellow";
            this.btn_yellow.Size = new System.Drawing.Size(82, 68);
            this.btn_yellow.TabIndex = 2;
            this.btn_yellow.UseVisualStyleBackColor = false;
            // 
            // lbl_time
            // 
            this.lbl_time.AutoSize = true;
            this.lbl_time.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbl_time.Location = new System.Drawing.Point(3, 0);
            this.lbl_time.Name = "lbl_time";
            this.lbl_time.Size = new System.Drawing.Size(354, 158);
            this.lbl_time.TabIndex = 2;
            this.lbl_time.Text = "120";
            this.lbl_time.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tim_update
            // 
            this.tim_update.Enabled = true;
            this.tim_update.Interval = 10;
            this.tim_update.Tick += new System.EventHandler(this.tim_update_Tick);
            // 
            // bgw_UDPClient
            // 
            this.bgw_UDPClient.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_UDPClient_DoWork);
            // 
            // Frm_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(360, 240);
            this.Controls.Add(this.tlp_vert);
            this.Font = new System.Drawing.Font("Open Sans Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_main";
            this.Text = "BSApp-DisplayAmpel";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_main_Load);
            this.ResizeEnd += new System.EventHandler(this.Frm_main_ResizeEnd);
            this.tlp_vert.ResumeLayout(false);
            this.tlp_vert.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_yLine)).EndInit();
            this.tlp_color.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlp_vert;
        private System.Windows.Forms.PictureBox pb_yLine;
        private System.Windows.Forms.TableLayoutPanel tlp_color;
        private System.Windows.Forms.Button btn_red;
        private System.Windows.Forms.Button btn_abcd;
        private System.Windows.Forms.Button btn_green;
        private System.Windows.Forms.Button btn_yellow;
        private System.Windows.Forms.Label lbl_time;
        private System.Windows.Forms.Timer tim_update;
        private System.ComponentModel.BackgroundWorker bgw_UDPClient;
    }
}

