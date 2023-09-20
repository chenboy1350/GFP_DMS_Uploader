using DMSUpload_Helper.Library;
using DMSUpload_Helper.Service.Implement;
using DMSUpload_Helper.Service.Interface;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DMSUpload_Helper
{
    public partial class FrmLogin : Form
    {
        DMSUploaderLibrary _lib;
        private readonly ISharePoint _sharePoint = new SharePoint();

        public FrmLogin()
        {
            InitializeComponent();

            DMS_IAddGovUnit addGov = new DMS_AddGovUnit();
            _lib = new DMSUploaderLibrary(addGov);
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            txtUsername.KeyPress += TextBox_KeyPress;
            txtPassword.KeyPress += TextBox_KeyPress;

            lblMaessage.Text = string.Empty;
        }

        private void BtnSignIn_Click(object sender, EventArgs e)
        {
            try
            {
                SignIn();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((e.KeyChar == (char)Keys.Return))
                {
                    SignIn();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SignIn()
        {
            try
            {
                ButtonEnable(false);
                if (_lib.Authentication(txtUsername.Text, txtPassword.Text))
                {
                    FrmMain frmMain = new FrmMain();
                    frmMain._lib = _lib;
                    Hide();
                    frmMain.ShowDialog();

                    ButtonEnable(true);
                    Show();
                    ClearValue();
                }
                else
                {
                    lblMaessage.Text = "* Username or Password Wrong!";
                    ButtonEnable(true);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void ClearValue()
        {
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
            lblMaessage.Text = string.Empty;
        }

        private void ButtonEnable(bool val)
        {
            txtUsername.Enabled = val;
            txtPassword.Enabled = val;

            btnSignIn.Enabled = val;
            btnSetting.Enabled = val;
        }

        private void BtnSetting_Click(object sender, EventArgs e)
        {
            frmSetting frmSetting = new frmSetting();
            frmSetting.ShowDialog();
            ClearValue();
        }

        [DllImport("User32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("User32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void Label5_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }
    }
}
