using DMSUpload_Helper.Library;
using DMSUpload_Helper.Service.Implement;
using DMSUpload_Helper.Service.Interface;
using System;
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
            _sharePoint.WrappedImpersonationContext(Properties.Settings.Default.Domain, Properties.Settings.Default.User, Properties.Settings.Default.Password);
            _sharePoint.Enter();

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
                if (_lib.Authentication(txtUsername.Text, txtPassword.Text))
                {
                    FrmMain frmMain = new FrmMain();
                    frmMain._lib = _lib;
                    Hide();
                    frmMain.ShowDialog();
                    Show();
                    ClearValue();
                }
                else
                {
                    lblMaessage.Text = "* Username or Password Wrong!";
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

        private void BtnSetting_Click(object sender, EventArgs e)
        {
            frmSetting frmSetting = new frmSetting();
            frmSetting.ShowDialog();
            ClearValue();
        }
    }
}
