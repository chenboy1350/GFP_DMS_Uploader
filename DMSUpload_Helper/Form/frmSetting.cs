using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DMSUpload_Helper
{
    public partial class frmSetting : Form
    {
        public frmSetting()
        {
            InitializeComponent();
        }

        private void FrmSetting_Load(object sender, EventArgs e)
        {
            lblMassage.Text = string.Empty;

            txtDomain.KeyPress += TextBox_KeyPress;
            txtUsername.KeyPress += TextBox_KeyPress;
            txtPassword.KeyPress += TextBox_KeyPress;

            txtDMSApi.KeyPress += TextBox_KeyPress;
            txtDFILEApi.KeyPress += TextBox_KeyPress;
            txtGPFApi.KeyPress += TextBox_KeyPress;

            txtTempPath.KeyPress += TextBox_KeyPress;
            txtDFILEPath.KeyPress += TextBox_KeyPress;
            txtBDSPath.KeyPress += TextBox_KeyPress;

            txtGPFDBService.KeyPress += TextBox_KeyPress;
            txtGPFMaintenance.KeyPress += TextBox_KeyPress;

            btnConfirm.BackColor = Color.Gray;
            btnConfirm.ForeColor = Color.White;

            InitialTextBox();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                SaveSetting();
                InitialTextBox();

                lblMassage.Text = "Saved";
                lblMassage.ForeColor = Color.Green;
                btnConfirm.Enabled = false;

                btnConfirm.BackColor = Color.Gray;
                btnConfirm.ForeColor = Color.White;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((e.KeyChar == (char)Keys.Return))
                {
                    lblMassage.Text = "* Setting has been change but never save.";
                    lblMassage.ForeColor = Color.Red;
                    btnConfirm.Enabled = true;

                    btnConfirm.BackColor = Color.FromArgb(32, 68, 156);
                    btnConfirm.ForeColor = Color.White;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void InitialTextBox()
        {
            try
            {
                txtDomain.Text = Properties.Settings.Default.Domain;
                txtUsername.Text = Properties.Settings.Default.User;
                txtPassword.Text = Properties.Settings.Default.Password;

                txtDMSApi.Text = Properties.Settings.Default.DMS_API;
                txtDFILEApi.Text = Properties.Settings.Default.PFILE_API;
                txtGPFApi.Text = Properties.Settings.Default.GPF_API;

                txtTempPath.Text = Properties.Settings.Default.TempBatchFile;
                txtBDSPath.Text = Properties.Settings.Default.BDSPath;
                txtDFILEPath.Text = Properties.Settings.Default.DFILEPath;

                txtGPFDBService.Text = Properties.Settings.Default.DMSUpload_Helper_GPFDBService_GPFDBService;
                txtGPFMaintenance.Text = Properties.Settings.Default.DMSUpload_Helper_GPFMaintenance_GPFMaintenance;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void SaveSetting()
        {
            try
            {
                Properties.Settings.Default.Domain = txtDomain.Text;
                Properties.Settings.Default.User = txtUsername.Text;
                Properties.Settings.Default.Password = txtPassword.Text;

                Properties.Settings.Default.DMS_API = txtDMSApi.Text;
                Properties.Settings.Default.PFILE_API = txtDFILEApi.Text;
                Properties.Settings.Default.GPF_API = txtGPFApi.Text;

                Properties.Settings.Default.TempBatchFile = txtTempPath.Text;
                Properties.Settings.Default.DFILEPath = txtDFILEPath.Text;
                Properties.Settings.Default.BDSPath = txtBDSPath.Text;

                Properties.Settings.Default.DMSUpload_Helper_GPFDBService_GPFDBService = txtGPFDBService.Text;
                Properties.Settings.Default.DMSUpload_Helper_GPFMaintenance_GPFMaintenance = txtGPFMaintenance.Text;

                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        [DllImport("User32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("User32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void PanelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void label5_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void iconPictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }
    }
}
