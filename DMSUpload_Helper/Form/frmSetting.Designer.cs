namespace DMSUpload_Helper
{
    partial class frmSetting
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
            this.panelTitle = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.btnExit = new FontAwesome.Sharp.IconButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panelContent = new System.Windows.Forms.Panel();
            this.gbService = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txtGPFMaintenance = new System.Windows.Forms.TextBox();
            this.txtGPFDBService = new System.Windows.Forms.TextBox();
            this.btnCancel = new FontAwesome.Sharp.IconButton();
            this.btnConfirm = new FontAwesome.Sharp.IconButton();
            this.lblMassage = new System.Windows.Forms.Label();
            this.gbAPI = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtGPFApi = new System.Windows.Forms.TextBox();
            this.txtDFILEApi = new System.Windows.Forms.TextBox();
            this.txtDMSApi = new System.Windows.Forms.TextBox();
            this.gbPath = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDFILEPath = new System.Windows.Forms.TextBox();
            this.txtBDSPath = new System.Windows.Forms.TextBox();
            this.txtTempPath = new System.Windows.Forms.TextBox();
            this.gbDomain = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtDomain = new System.Windows.Forms.TextBox();
            this.panelTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            this.panelContent.SuspendLayout();
            this.gbService.SuspendLayout();
            this.gbAPI.SuspendLayout();
            this.gbPath.SuspendLayout();
            this.gbDomain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTitle
            // 
            this.panelTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(68)))), ((int)(((byte)(156)))));
            this.panelTitle.Controls.Add(this.label5);
            this.panelTitle.Controls.Add(this.iconPictureBox1);
            this.panelTitle.Controls.Add(this.btnExit);
            this.panelTitle.Controls.Add(this.panel3);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(879, 57);
            this.panelTitle.TabIndex = 0;
            this.panelTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelTitle_MouseDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(48, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(156, 37);
            this.label5.TabIndex = 5;
            this.label5.Text = "SETTING";
            this.label5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label5_MouseDown);
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(68)))), ((int)(((byte)(156)))));
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.Gear;
            this.iconPictureBox1.IconColor = System.Drawing.Color.White;
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox1.IconSize = 43;
            this.iconPictureBox1.Location = new System.Drawing.Point(8, 3);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(45, 43);
            this.iconPictureBox1.TabIndex = 7;
            this.iconPictureBox1.TabStop = false;
            this.iconPictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.iconPictureBox1_MouseDown);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(68)))), ((int)(((byte)(156)))));
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.IconChar = FontAwesome.Sharp.IconChar.Xmark;
            this.btnExit.IconColor = System.Drawing.Color.White;
            this.btnExit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnExit.IconSize = 60;
            this.btnExit.Location = new System.Drawing.Point(831, 7);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(43, 45);
            this.btnExit.TabIndex = 6;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Orange;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 52);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(879, 5);
            this.panel3.TabIndex = 1;
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.gbService);
            this.panelContent.Controls.Add(this.btnCancel);
            this.panelContent.Controls.Add(this.btnConfirm);
            this.panelContent.Controls.Add(this.lblMassage);
            this.panelContent.Controls.Add(this.gbAPI);
            this.panelContent.Controls.Add(this.gbPath);
            this.panelContent.Controls.Add(this.gbDomain);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 57);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(879, 417);
            this.panelContent.TabIndex = 1;
            // 
            // gbService
            // 
            this.gbService.Controls.Add(this.label9);
            this.gbService.Controls.Add(this.label13);
            this.gbService.Controls.Add(this.txtGPFMaintenance);
            this.gbService.Controls.Add(this.txtGPFDBService);
            this.gbService.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbService.Location = new System.Drawing.Point(12, 27);
            this.gbService.Name = "gbService";
            this.gbService.Size = new System.Drawing.Size(428, 186);
            this.gbService.TabIndex = 5;
            this.gbService.TabStop = false;
            this.gbService.Text = "Service Setting";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(10, 78);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(114, 16);
            this.label9.TabIndex = 1;
            this.label9.Text = "GPF Maintenance";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(10, 30);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(146, 16);
            this.label13.TabIndex = 1;
            this.label13.Text = "GPF Database Service";
            // 
            // txtGPFMaintenance
            // 
            this.txtGPFMaintenance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGPFMaintenance.Location = new System.Drawing.Point(10, 97);
            this.txtGPFMaintenance.Name = "txtGPFMaintenance";
            this.txtGPFMaintenance.Size = new System.Drawing.Size(404, 21);
            this.txtGPFMaintenance.TabIndex = 1;
            // 
            // txtGPFDBService
            // 
            this.txtGPFDBService.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGPFDBService.Location = new System.Drawing.Point(10, 49);
            this.txtGPFDBService.Name = "txtGPFDBService";
            this.txtGPFDBService.Size = new System.Drawing.Size(404, 21);
            this.txtGPFDBService.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Gray;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.IconChar = FontAwesome.Sharp.IconChar.Xmark;
            this.btnCancel.IconColor = System.Drawing.Color.White;
            this.btnCancel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCancel.IconSize = 38;
            this.btnCancel.Location = new System.Drawing.Point(676, 86);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(192, 44);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(68)))), ((int)(((byte)(156)))));
            this.btnConfirm.Enabled = false;
            this.btnConfirm.FlatAppearance.BorderSize = 0;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.ForeColor = System.Drawing.Color.White;
            this.btnConfirm.IconChar = FontAwesome.Sharp.IconChar.Check;
            this.btnConfirm.IconColor = System.Drawing.Color.White;
            this.btnConfirm.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnConfirm.IconSize = 38;
            this.btnConfirm.Location = new System.Drawing.Point(676, 36);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(192, 44);
            this.btnConfirm.TabIndex = 3;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConfirm.UseVisualStyleBackColor = false;
            this.btnConfirm.Click += new System.EventHandler(this.BtnConfirm_Click);
            // 
            // lblMassage
            // 
            this.lblMassage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMassage.ForeColor = System.Drawing.Color.Black;
            this.lblMassage.Location = new System.Drawing.Point(236, 8);
            this.lblMassage.Name = "lblMassage";
            this.lblMassage.Size = new System.Drawing.Size(632, 16);
            this.lblMassage.TabIndex = 2;
            this.lblMassage.Text = "- MESSAGE -";
            this.lblMassage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gbAPI
            // 
            this.gbAPI.Controls.Add(this.label10);
            this.gbAPI.Controls.Add(this.label11);
            this.gbAPI.Controls.Add(this.label12);
            this.gbAPI.Controls.Add(this.txtGPFApi);
            this.gbAPI.Controls.Add(this.txtDFILEApi);
            this.gbAPI.Controls.Add(this.txtDMSApi);
            this.gbAPI.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbAPI.Location = new System.Drawing.Point(12, 219);
            this.gbAPI.Name = "gbAPI";
            this.gbAPI.Size = new System.Drawing.Size(428, 186);
            this.gbAPI.TabIndex = 2;
            this.gbAPI.TabStop = false;
            this.gbAPI.Text = "API Setting";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(7, 126);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 16);
            this.label10.TabIndex = 1;
            this.label10.Text = "GPF API";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(10, 78);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 16);
            this.label11.TabIndex = 1;
            this.label11.Text = "PFILE API";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(10, 30);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(61, 16);
            this.label12.TabIndex = 1;
            this.label12.Text = "DMS API";
            // 
            // txtGPFApi
            // 
            this.txtGPFApi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGPFApi.Location = new System.Drawing.Point(10, 145);
            this.txtGPFApi.Name = "txtGPFApi";
            this.txtGPFApi.Size = new System.Drawing.Size(404, 21);
            this.txtGPFApi.TabIndex = 1;
            // 
            // txtDFILEApi
            // 
            this.txtDFILEApi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDFILEApi.Location = new System.Drawing.Point(10, 97);
            this.txtDFILEApi.Name = "txtDFILEApi";
            this.txtDFILEApi.Size = new System.Drawing.Size(404, 21);
            this.txtDFILEApi.TabIndex = 1;
            // 
            // txtDMSApi
            // 
            this.txtDMSApi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDMSApi.Location = new System.Drawing.Point(10, 49);
            this.txtDMSApi.Name = "txtDMSApi";
            this.txtDMSApi.Size = new System.Drawing.Size(404, 21);
            this.txtDMSApi.TabIndex = 1;
            // 
            // gbPath
            // 
            this.gbPath.Controls.Add(this.label4);
            this.gbPath.Controls.Add(this.label6);
            this.gbPath.Controls.Add(this.label7);
            this.gbPath.Controls.Add(this.txtDFILEPath);
            this.gbPath.Controls.Add(this.txtBDSPath);
            this.gbPath.Controls.Add(this.txtTempPath);
            this.gbPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPath.Location = new System.Drawing.Point(453, 219);
            this.gbPath.Name = "gbPath";
            this.gbPath.Size = new System.Drawing.Size(206, 186);
            this.gbPath.TabIndex = 1;
            this.gbPath.TabStop = false;
            this.gbPath.Text = "Path Setting";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "DFILE Path";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(10, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 16);
            this.label6.TabIndex = 1;
            this.label6.Text = "BDS Path";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(10, 30);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 16);
            this.label7.TabIndex = 1;
            this.label7.Text = "TempBatchFile";
            // 
            // txtDFILEPath
            // 
            this.txtDFILEPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDFILEPath.Location = new System.Drawing.Point(10, 145);
            this.txtDFILEPath.Name = "txtDFILEPath";
            this.txtDFILEPath.Size = new System.Drawing.Size(182, 21);
            this.txtDFILEPath.TabIndex = 1;
            // 
            // txtBDSPath
            // 
            this.txtBDSPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBDSPath.Location = new System.Drawing.Point(10, 97);
            this.txtBDSPath.Name = "txtBDSPath";
            this.txtBDSPath.Size = new System.Drawing.Size(182, 21);
            this.txtBDSPath.TabIndex = 1;
            // 
            // txtTempPath
            // 
            this.txtTempPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTempPath.Location = new System.Drawing.Point(10, 49);
            this.txtTempPath.Name = "txtTempPath";
            this.txtTempPath.Size = new System.Drawing.Size(182, 21);
            this.txtTempPath.TabIndex = 1;
            // 
            // gbDomain
            // 
            this.gbDomain.Controls.Add(this.label3);
            this.gbDomain.Controls.Add(this.label2);
            this.gbDomain.Controls.Add(this.label1);
            this.gbDomain.Controls.Add(this.txtPassword);
            this.gbDomain.Controls.Add(this.txtUsername);
            this.gbDomain.Controls.Add(this.txtDomain);
            this.gbDomain.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDomain.Location = new System.Drawing.Point(453, 27);
            this.gbDomain.Name = "gbDomain";
            this.gbDomain.Size = new System.Drawing.Size(206, 186);
            this.gbDomain.TabIndex = 0;
            this.gbDomain.TabStop = false;
            this.gbDomain.Text = "Domain Setting";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 16);
            this.label3.TabIndex = 1;
            this.label3.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(10, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Username";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Domain";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(10, 145);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(182, 21);
            this.txtPassword.TabIndex = 1;
            // 
            // txtUsername
            // 
            this.txtUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsername.Location = new System.Drawing.Point(10, 97);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(182, 21);
            this.txtUsername.TabIndex = 1;
            // 
            // txtDomain
            // 
            this.txtDomain.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDomain.Location = new System.Drawing.Point(10, 49);
            this.txtDomain.Name = "txtDomain";
            this.txtDomain.Size = new System.Drawing.Size(182, 21);
            this.txtDomain.TabIndex = 1;
            // 
            // frmSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(879, 474);
            this.ControlBox = false;
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSetting";
            this.Load += new System.EventHandler(this.FrmSetting_Load);
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            this.panelContent.ResumeLayout(false);
            this.gbService.ResumeLayout(false);
            this.gbService.PerformLayout();
            this.gbAPI.ResumeLayout(false);
            this.gbAPI.PerformLayout();
            this.gbPath.ResumeLayout(false);
            this.gbPath.PerformLayout();
            this.gbDomain.ResumeLayout(false);
            this.gbDomain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Label label5;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private FontAwesome.Sharp.IconButton btnExit;
        private System.Windows.Forms.GroupBox gbDomain;
        private System.Windows.Forms.GroupBox gbPath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDFILEPath;
        private System.Windows.Forms.TextBox txtBDSPath;
        private System.Windows.Forms.TextBox txtTempPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtDomain;
        private System.Windows.Forms.GroupBox gbAPI;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtGPFApi;
        private System.Windows.Forms.TextBox txtDFILEApi;
        private System.Windows.Forms.TextBox txtDMSApi;
        private System.Windows.Forms.Label lblMassage;
        private FontAwesome.Sharp.IconButton btnConfirm;
        private FontAwesome.Sharp.IconButton btnCancel;
        private System.Windows.Forms.GroupBox gbService;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtGPFMaintenance;
        private System.Windows.Forms.TextBox txtGPFDBService;
    }
}