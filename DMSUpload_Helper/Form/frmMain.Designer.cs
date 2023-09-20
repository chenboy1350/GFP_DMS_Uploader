namespace DMSUpload_Helper
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.panelTitle = new System.Windows.Forms.Panel();
            this.lblAuthority = new System.Windows.Forms.Label();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSignOut = new FontAwesome.Sharp.IconButton();
            this.panelLine = new System.Windows.Forms.Panel();
            this.panelContent = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoANSI = new System.Windows.Forms.RadioButton();
            this.rdoUTF8 = new System.Windows.Forms.RadioButton();
            this.lblMessageMIS = new System.Windows.Forms.Label();
            this.pgbStatus = new System.Windows.Forms.ProgressBar();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvDataList = new System.Windows.Forms.DataGridView();
            this.btnImport = new FontAwesome.Sharp.IconButton();
            this.btnCancel = new FontAwesome.Sharp.IconButton();
            this.btnVerify = new FontAwesome.Sharp.IconButton();
            this.btnUpload = new FontAwesome.Sharp.IconButton();
            this.btnCompare = new FontAwesome.Sharp.IconButton();
            this.btnClear = new FontAwesome.Sharp.IconButton();
            this.btnBrowseDir = new FontAwesome.Sharp.IconButton();
            this.btnBrowseFile = new FontAwesome.Sharp.IconButton();
            this.txtPathDirectory = new System.Windows.Forms.TextBox();
            this.txtPathFile = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPercent = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblMessageOK = new System.Windows.Forms.Label();
            this.lblSelectFolder = new System.Windows.Forms.Label();
            this.panelTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelContent.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panelFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataList)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTitle
            // 
            this.panelTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(68)))), ((int)(((byte)(156)))));
            this.panelTitle.Controls.Add(this.lblAuthority);
            this.panelTitle.Controls.Add(this.lblDepartment);
            this.panelTitle.Controls.Add(this.lblUsername);
            this.panelTitle.Controls.Add(this.iconPictureBox1);
            this.panelTitle.Controls.Add(this.pictureBox1);
            this.panelTitle.Controls.Add(this.label5);
            this.panelTitle.Controls.Add(this.btnSignOut);
            this.panelTitle.Controls.Add(this.panelLine);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.Location = new System.Drawing.Point(0, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(1200, 80);
            this.panelTitle.TabIndex = 1;
            this.panelTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PanelTitle_MouseDown);
            // 
            // lblAuthority
            // 
            this.lblAuthority.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAuthority.ForeColor = System.Drawing.Color.White;
            this.lblAuthority.Location = new System.Drawing.Point(820, 51);
            this.lblAuthority.Name = "lblAuthority";
            this.lblAuthority.Size = new System.Drawing.Size(221, 21);
            this.lblAuthority.TabIndex = 6;
            this.lblAuthority.Text = "- AUTHORITY -";
            this.lblAuthority.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDepartment
            // 
            this.lblDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepartment.ForeColor = System.Drawing.Color.White;
            this.lblDepartment.Location = new System.Drawing.Point(823, 30);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(218, 21);
            this.lblDepartment.TabIndex = 6;
            this.lblDepartment.Text = "- DEPARTMENT-";
            this.lblDepartment.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUsername
            // 
            this.lblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.ForeColor = System.Drawing.Color.White;
            this.lblUsername.Location = new System.Drawing.Point(820, 9);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(221, 21);
            this.lblUsername.TabIndex = 6;
            this.lblUsername.Text = "- USERNAME -";
            this.lblUsername.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.UserAlt;
            this.iconPictureBox1.IconColor = System.Drawing.Color.White;
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox1.IconSize = 68;
            this.iconPictureBox1.Location = new System.Drawing.Point(1047, 6);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(70, 68);
            this.iconPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.iconPictureBox1.TabIndex = 5;
            this.iconPictureBox1.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DMSUpload_Helper.Properties.Resources.logo2;
            this.pictureBox1.Location = new System.Drawing.Point(3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(183, 71);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(192, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(500, 64);
            this.label5.TabIndex = 3;
            this.label5.Text = "DMS l UPLOADER";
            this.label5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Label5_MouseDown);
            // 
            // btnSignOut
            // 
            this.btnSignOut.BackColor = System.Drawing.Color.Transparent;
            this.btnSignOut.FlatAppearance.BorderSize = 0;
            this.btnSignOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSignOut.IconChar = FontAwesome.Sharp.IconChar.SignOutAlt;
            this.btnSignOut.IconColor = System.Drawing.Color.White;
            this.btnSignOut.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSignOut.IconSize = 80;
            this.btnSignOut.Location = new System.Drawing.Point(1123, 9);
            this.btnSignOut.Name = "btnSignOut";
            this.btnSignOut.Size = new System.Drawing.Size(66, 63);
            this.btnSignOut.TabIndex = 2;
            this.btnSignOut.UseVisualStyleBackColor = false;
            this.btnSignOut.Click += new System.EventHandler(this.BtnSignOut_Click);
            // 
            // panelLine
            // 
            this.panelLine.BackColor = System.Drawing.Color.Orange;
            this.panelLine.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelLine.Location = new System.Drawing.Point(0, 75);
            this.panelLine.Name = "panelLine";
            this.panelLine.Size = new System.Drawing.Size(1200, 5);
            this.panelLine.TabIndex = 1;
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.White;
            this.panelContent.Controls.Add(this.groupBox1);
            this.panelContent.Controls.Add(this.lblMessageMIS);
            this.panelContent.Controls.Add(this.pgbStatus);
            this.panelContent.Controls.Add(this.panelFooter);
            this.panelContent.Controls.Add(this.label3);
            this.panelContent.Controls.Add(this.dgvDataList);
            this.panelContent.Controls.Add(this.btnImport);
            this.panelContent.Controls.Add(this.btnCancel);
            this.panelContent.Controls.Add(this.btnVerify);
            this.panelContent.Controls.Add(this.btnUpload);
            this.panelContent.Controls.Add(this.btnCompare);
            this.panelContent.Controls.Add(this.btnClear);
            this.panelContent.Controls.Add(this.btnBrowseDir);
            this.panelContent.Controls.Add(this.btnBrowseFile);
            this.panelContent.Controls.Add(this.txtPathDirectory);
            this.panelContent.Controls.Add(this.txtPathFile);
            this.panelContent.Controls.Add(this.label2);
            this.panelContent.Controls.Add(this.label1);
            this.panelContent.Controls.Add(this.lblPercent);
            this.panelContent.Controls.Add(this.lblMessage);
            this.panelContent.Controls.Add(this.lblMessageOK);
            this.panelContent.Controls.Add(this.lblSelectFolder);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(0, 80);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(1200, 720);
            this.panelContent.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoANSI);
            this.groupBox1.Controls.Add(this.rdoUTF8);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(649, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(191, 84);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Encoding";
            // 
            // rdoANSI
            // 
            this.rdoANSI.AutoSize = true;
            this.rdoANSI.Checked = true;
            this.rdoANSI.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoANSI.Location = new System.Drawing.Point(23, 30);
            this.rdoANSI.Name = "rdoANSI";
            this.rdoANSI.Size = new System.Drawing.Size(65, 24);
            this.rdoANSI.TabIndex = 2;
            this.rdoANSI.TabStop = true;
            this.rdoANSI.Text = "ANSI";
            this.rdoANSI.UseVisualStyleBackColor = true;
            // 
            // rdoUTF8
            // 
            this.rdoUTF8.AutoSize = true;
            this.rdoUTF8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoUTF8.Location = new System.Drawing.Point(94, 31);
            this.rdoUTF8.Name = "rdoUTF8";
            this.rdoUTF8.Size = new System.Drawing.Size(72, 24);
            this.rdoUTF8.TabIndex = 2;
            this.rdoUTF8.Text = "UTF-8";
            this.rdoUTF8.UseVisualStyleBackColor = true;
            // 
            // lblMessageMIS
            // 
            this.lblMessageMIS.AutoSize = true;
            this.lblMessageMIS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessageMIS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMessageMIS.Location = new System.Drawing.Point(867, 300);
            this.lblMessageMIS.Name = "lblMessageMIS";
            this.lblMessageMIS.Size = new System.Drawing.Size(145, 16);
            this.lblMessageMIS.TabIndex = 9;
            this.lblMessageMIS.Text = "- MESSAGE MISSING -";
            this.lblMessageMIS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pgbStatus
            // 
            this.pgbStatus.Location = new System.Drawing.Point(869, 271);
            this.pgbStatus.Name = "pgbStatus";
            this.pgbStatus.Size = new System.Drawing.Size(302, 10);
            this.pgbStatus.TabIndex = 7;
            // 
            // panelFooter
            // 
            this.panelFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(68)))), ((int)(((byte)(156)))));
            this.panelFooter.Controls.Add(this.panel1);
            this.panelFooter.Controls.Add(this.label4);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Location = new System.Drawing.Point(0, 684);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(1200, 36);
            this.panelFooter.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Orange;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1200, 5);
            this.panel1.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(453, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(251, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Copyright © 2023 GFP All Right Reserved";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "File List Review";
            // 
            // dgvDataList
            // 
            this.dgvDataList.AllowUserToAddRows = false;
            this.dgvDataList.AllowUserToDeleteRows = false;
            this.dgvDataList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDataList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvDataList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataList.Location = new System.Drawing.Point(30, 134);
            this.dgvDataList.MultiSelect = false;
            this.dgvDataList.Name = "dgvDataList";
            this.dgvDataList.ReadOnly = true;
            this.dgvDataList.RowHeadersVisible = false;
            this.dgvDataList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDataList.Size = new System.Drawing.Size(810, 515);
            this.dgvDataList.TabIndex = 4;
            // 
            // btnImport
            // 
            this.btnImport.BackColor = System.Drawing.Color.DarkGreen;
            this.btnImport.Enabled = false;
            this.btnImport.FlatAppearance.BorderSize = 0;
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.ForeColor = System.Drawing.Color.White;
            this.btnImport.IconChar = FontAwesome.Sharp.IconChar.CheckCircle;
            this.btnImport.IconColor = System.Drawing.Color.White;
            this.btnImport.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnImport.IconSize = 40;
            this.btnImport.Location = new System.Drawing.Point(869, 587);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(302, 62);
            this.btnImport.TabIndex = 3;
            this.btnImport.Text = "IMPORT";
            this.btnImport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Click += new System.EventHandler(this.BtnImport_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Firebrick;
            this.btnCancel.Enabled = false;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.IconChar = FontAwesome.Sharp.IconChar.FileCircleXmark;
            this.btnCancel.IconColor = System.Drawing.Color.White;
            this.btnCancel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCancel.IconSize = 40;
            this.btnCancel.Location = new System.Drawing.Point(869, 519);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(302, 62);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnVerify
            // 
            this.btnVerify.BackColor = System.Drawing.Color.DarkOrange;
            this.btnVerify.Enabled = false;
            this.btnVerify.FlatAppearance.BorderSize = 0;
            this.btnVerify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerify.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerify.ForeColor = System.Drawing.Color.White;
            this.btnVerify.IconChar = FontAwesome.Sharp.IconChar.CodeCompare;
            this.btnVerify.IconColor = System.Drawing.Color.White;
            this.btnVerify.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnVerify.IconSize = 40;
            this.btnVerify.Location = new System.Drawing.Point(869, 451);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(302, 62);
            this.btnVerify.TabIndex = 3;
            this.btnVerify.Text = "VERIFY";
            this.btnVerify.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnVerify.UseVisualStyleBackColor = false;
            this.btnVerify.Click += new System.EventHandler(this.BtnVerify_Click);
            // 
            // btnUpload
            // 
            this.btnUpload.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(68)))), ((int)(((byte)(156)))));
            this.btnUpload.Enabled = false;
            this.btnUpload.FlatAppearance.BorderSize = 0;
            this.btnUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpload.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpload.ForeColor = System.Drawing.Color.White;
            this.btnUpload.IconChar = FontAwesome.Sharp.IconChar.Upload;
            this.btnUpload.IconColor = System.Drawing.Color.White;
            this.btnUpload.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnUpload.IconSize = 40;
            this.btnUpload.Location = new System.Drawing.Point(869, 383);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(302, 62);
            this.btnUpload.TabIndex = 3;
            this.btnUpload.Text = "UPLOAD";
            this.btnUpload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUpload.UseVisualStyleBackColor = false;
            this.btnUpload.Click += new System.EventHandler(this.BtnUpload_Click);
            // 
            // btnCompare
            // 
            this.btnCompare.BackColor = System.Drawing.Color.Orange;
            this.btnCompare.FlatAppearance.BorderSize = 0;
            this.btnCompare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompare.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompare.IconChar = FontAwesome.Sharp.IconChar.FileCircleQuestion;
            this.btnCompare.IconColor = System.Drawing.Color.Black;
            this.btnCompare.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCompare.IconSize = 40;
            this.btnCompare.Location = new System.Drawing.Point(869, 167);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(302, 62);
            this.btnCompare.TabIndex = 3;
            this.btnCompare.Text = "COMPARE";
            this.btnCompare.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCompare.UseVisualStyleBackColor = false;
            this.btnCompare.Click += new System.EventHandler(this.BtnCompare_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.LightGray;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.IconChar = FontAwesome.Sharp.IconChar.Broom;
            this.btnClear.IconColor = System.Drawing.Color.Black;
            this.btnClear.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnClear.IconSize = 40;
            this.btnClear.Location = new System.Drawing.Point(869, 107);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(302, 43);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear                    ";
            this.btnClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // btnBrowseDir
            // 
            this.btnBrowseDir.BackColor = System.Drawing.Color.LightGray;
            this.btnBrowseDir.FlatAppearance.BorderSize = 0;
            this.btnBrowseDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseDir.IconChar = FontAwesome.Sharp.IconChar.FolderOpen;
            this.btnBrowseDir.IconColor = System.Drawing.Color.Black;
            this.btnBrowseDir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBrowseDir.IconSize = 40;
            this.btnBrowseDir.Location = new System.Drawing.Point(869, 60);
            this.btnBrowseDir.Name = "btnBrowseDir";
            this.btnBrowseDir.Size = new System.Drawing.Size(302, 43);
            this.btnBrowseDir.TabIndex = 3;
            this.btnBrowseDir.Text = "Browse Folder  ";
            this.btnBrowseDir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBrowseDir.UseVisualStyleBackColor = false;
            this.btnBrowseDir.Click += new System.EventHandler(this.BtnBrowseDir_Click);
            // 
            // btnBrowseFile
            // 
            this.btnBrowseFile.BackColor = System.Drawing.Color.LightGray;
            this.btnBrowseFile.FlatAppearance.BorderSize = 0;
            this.btnBrowseFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseFile.IconChar = FontAwesome.Sharp.IconChar.FileText;
            this.btnBrowseFile.IconColor = System.Drawing.Color.Black;
            this.btnBrowseFile.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBrowseFile.IconSize = 40;
            this.btnBrowseFile.Location = new System.Drawing.Point(869, 13);
            this.btnBrowseFile.Name = "btnBrowseFile";
            this.btnBrowseFile.Size = new System.Drawing.Size(302, 43);
            this.btnBrowseFile.TabIndex = 3;
            this.btnBrowseFile.Text = "Browse Index File";
            this.btnBrowseFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBrowseFile.UseVisualStyleBackColor = false;
            this.btnBrowseFile.Click += new System.EventHandler(this.BtnBrowseFile_Click);
            // 
            // txtPathDirectory
            // 
            this.txtPathDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPathDirectory.Location = new System.Drawing.Point(167, 64);
            this.txtPathDirectory.Name = "txtPathDirectory";
            this.txtPathDirectory.Size = new System.Drawing.Size(465, 26);
            this.txtPathDirectory.TabIndex = 1;
            this.txtPathDirectory.TextChanged += new System.EventHandler(this.TxtPathDirectory_TextChanged);
            this.txtPathDirectory.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtPathDirectory_KeyPress);
            // 
            // txtPathFile
            // 
            this.txtPathFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPathFile.Location = new System.Drawing.Point(167, 17);
            this.txtPathFile.Name = "txtPathFile";
            this.txtPathFile.ReadOnly = true;
            this.txtPathFile.Size = new System.Drawing.Size(465, 26);
            this.txtPathFile.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Select Folder";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select Index File";
            // 
            // lblPercent
            // 
            this.lblPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPercent.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPercent.Location = new System.Drawing.Point(1032, 248);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(142, 27);
            this.lblPercent.TabIndex = 8;
            this.lblPercent.Text = "- PECENT -";
            this.lblPercent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMessage
            // 
            this.lblMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMessage.Location = new System.Drawing.Point(867, 252);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(159, 16);
            this.lblMessage.TabIndex = 9;
            this.lblMessage.Text = "- MESSAGE -";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMessageOK
            // 
            this.lblMessageOK.AutoSize = true;
            this.lblMessageOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessageOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMessageOK.Location = new System.Drawing.Point(867, 284);
            this.lblMessageOK.Name = "lblMessageOK";
            this.lblMessageOK.Size = new System.Drawing.Size(108, 16);
            this.lblMessageOK.TabIndex = 9;
            this.lblMessageOK.Text = "- MESSAGE OK -";
            this.lblMessageOK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSelectFolder
            // 
            this.lblSelectFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectFolder.ForeColor = System.Drawing.Color.Red;
            this.lblSelectFolder.Location = new System.Drawing.Point(170, 47);
            this.lblSelectFolder.Name = "lblSelectFolder";
            this.lblSelectFolder.Size = new System.Drawing.Size(465, 18);
            this.lblSelectFolder.TabIndex = 11;
            this.lblSelectFolder.Text = "- TXT MESSAGE -";
            this.lblSelectFolder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.ControlBox = false;
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panelFooter.ResumeLayout(false);
            this.panelFooter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Panel panelLine;
        private System.Windows.Forms.Panel panelContent;
        private FontAwesome.Sharp.IconButton btnSignOut;
        private FontAwesome.Sharp.IconButton btnBrowseFile;
        private System.Windows.Forms.RadioButton rdoUTF8;
        private System.Windows.Forms.RadioButton rdoANSI;
        private System.Windows.Forms.TextBox txtPathDirectory;
        private System.Windows.Forms.TextBox txtPathFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvDataList;
        private FontAwesome.Sharp.IconButton btnCompare;
        private FontAwesome.Sharp.IconButton btnClear;
        private FontAwesome.Sharp.IconButton btnBrowseDir;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Label label4;
        private FontAwesome.Sharp.IconButton btnImport;
        private FontAwesome.Sharp.IconButton btnCancel;
        private FontAwesome.Sharp.IconButton btnVerify;
        private FontAwesome.Sharp.IconButton btnUpload;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label lblPercent;
        private System.Windows.Forms.ProgressBar pgbStatus;
        private System.Windows.Forms.Label lblMessageMIS;
        private System.Windows.Forms.Label lblMessageOK;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private System.Windows.Forms.Label lblAuthority;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblSelectFolder;
    }
}