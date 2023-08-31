using DMSUpload_Helper.Library;
using DMSUpload_Helper.Models;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Path = System.IO.Path;

namespace DMSUpload_Helper
{
    public partial class FrmMain : Form
    {
        public DMSUploaderLibrary _lib;

        public string PathFile = string.Empty;
        public string PathDirectory = string.Empty;
        public int IndexID = 0;
        public int Unit = 0;

        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            pgbStatus.Maximum = 100;
            pgbStatus.Minimum = 0;
            pgbStatus.Step = 1;

            lblMessage.Text = "READY";
            lblMessageOK.Text = string.Empty;
            lblMessageMIS.Text = string.Empty;
            lblPercent.Text = string.Empty;

            btnUpload.BackColor = Color.LightGray;
            btnVerify.BackColor = Color.LightGray;
            btnCancel.BackColor = Color.LightGray;
            btnImport.BackColor = Color.LightGray;

            btnUpload.ForeColor = Color.Black;
            btnVerify.ForeColor = Color.Black;
            btnCancel.ForeColor = Color.Black;
            btnImport.ForeColor = Color.Black;

            lblUsername.Text = _lib.username;
            lblDepartment.Text = _lib.department;
            lblAuthority.Text = _lib.authority;
        }

        private void BtnBrowseFile_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog theDialog = new OpenFileDialog();
                theDialog.Title = "Select Text File";
                theDialog.Filter = "TXT files|*.txt";
                theDialog.InitialDirectory = @"C:\";
                if (theDialog.ShowDialog() == DialogResult.OK)
                {
                    txtPathFile.Text = theDialog.FileName;
                    PathFile = theDialog.FileName;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnBrowseDir_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog theDialog = new FolderBrowserDialog();
                if (theDialog.ShowDialog() == DialogResult.OK)
                {
                    txtPathDirectory.Text = theDialog.SelectedPath;
                    PathDirectory = theDialog.SelectedPath;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnSignOut_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            try
            {
                ClearValues();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TxtPathDirectory_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((e.KeyChar == (char)Keys.Return))
                {
                    if (Directory.Exists(txtPathDirectory.Text))
                    {
                        PathDirectory = txtPathDirectory.Text;
                        MessageBox.Show("Exists");
                    }
                    else
                    {
                        MessageBox.Show("Not Exists");
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DataGridCellFormatCompare(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 3 && e.Value != null)
                {
                    string status = Convert.ToString(e.Value);

                    if (status == "OK")
                    {
                        e.CellStyle.BackColor = Color.Green;
                        e.CellStyle.ForeColor = Color.White;
                    }
                    else
                    {
                        e.CellStyle.BackColor = Color.Red;
                        e.CellStyle.ForeColor = Color.White;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DataGridCellFormatVerify(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 5 && e.Value != null)
                {
                    string status = Convert.ToString(e.Value);

                    if (status == "Accepted")
                    {
                        e.CellStyle.BackColor = Color.Green;
                        e.CellStyle.ForeColor = Color.White;
                    }
                    else
                    {
                        e.CellStyle.BackColor = Color.Red;
                        e.CellStyle.ForeColor = Color.White;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DataGridMode(string Mode)
        {
            try
            {
                dgvDataList.Columns.Clear();
                dgvDataList.Rows.Clear();

                switch (Mode)
                {
                    case "Compare":
                        dgvDataList.CellFormatting -= DataGridCellFormatVerify;

                        dgvDataList.Columns.Add("txt", "From TXT");
                        dgvDataList.Columns.Add("dir", "From DIR");
                        dgvDataList.Columns.Add("docName", "Document Name");
                        dgvDataList.Columns.Add("status", "Status");

                        dgvDataList.Columns[0].Width = 50;
                        dgvDataList.Columns[1].Width = 50;
                        dgvDataList.Columns[2].Width = 300;
                        dgvDataList.Columns[3].Width = 100;

                        dgvDataList.CellFormatting += DataGridCellFormatCompare;
                        break;
                    case "Verify":
                        dgvDataList.CellFormatting -= DataGridCellFormatCompare;

                        dgvDataList.Columns.Add("txt", "FileName");
                        dgvDataList.Columns.Add("cid", "CitizenID");
                        dgvDataList.Columns.Add("mid", "MemberID");
                        dgvDataList.Columns.Add("doc", "DocName");
                        dgvDataList.Columns.Add("remark", "Remark");
                        dgvDataList.Columns.Add("status", "Status");

                        dgvDataList.Columns[0].Width = 100;
                        dgvDataList.Columns[1].Width = 100;
                        dgvDataList.Columns[2].Width = 100;
                        dgvDataList.Columns[3].Width = 300;
                        dgvDataList.Columns[4].Width = 300;
                        dgvDataList.Columns[5].Width = 100;

                        dgvDataList.CellFormatting += DataGridCellFormatVerify;
                        break;
                    default: return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonEneble(bool val)
        {
            try
            {
                if (!val)
                {
                    txtPathDirectory.Enabled = val;

                    btnBrowseFile.Enabled = val;
                    btnBrowseDir.Enabled = val;
                    btnClear.Enabled = val;
                    btnCompare.Enabled = val;
                    btnUpload.Enabled = val;
                    btnVerify.Enabled = val;
                    btnCancel.Enabled = val;
                    btnImport.Enabled = val;

                    btnUpload.BackColor = Color.LightGray;
                    btnVerify.BackColor = Color.LightGray;
                    btnCancel.BackColor = Color.LightGray;
                    btnImport.BackColor = Color.LightGray;

                    btnUpload.ForeColor = Color.Black;
                    btnVerify.ForeColor = Color.Black;
                    btnCancel.ForeColor = Color.Black;
                    btnImport.ForeColor = Color.Black;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ClearValues()
        {
            try
            {
                txtPathDirectory.Text = string.Empty;
                txtPathFile.Text = string.Empty;

                IndexID = 0;
                Unit = 0;

                _lib.FilteredTextList = new List<TextFormatModel>();
                _lib.tempDT = new DataTable();
                _lib.taskType = string.Empty;
                _lib.fileIndex = string.Empty;

                dgvDataList.Rows.Clear();
                dgvDataList.Columns.Clear();

                btnBrowseFile.Enabled = true;
                btnBrowseDir.Enabled = true;
                txtPathDirectory.Enabled = true;
                txtPathFile.Enabled = true;
                btnCompare.Enabled = true;

                btnUpload.Enabled = false;
                btnVerify.Enabled = false;
                btnCancel.Enabled = false;
                btnImport.Enabled = false;

                lblMessageOK.Text = string.Empty;
                lblMessageMIS.Text = string.Empty;
                lblMessage.Text = "READY";
                lblPercent.Text = string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BtnCompare_Click(object sender, EventArgs e)
        {
            try
            {
                ButtonEneble(false);
                DataGridMode("Compare");
                Compare();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                btnClear.Enabled = true;
            }
        }

        private void BtnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                ButtonEneble(false);
                Upload();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                btnClear.Enabled = true;
            }
        }

        private void BtnVerify_Click(object sender, EventArgs e)
        {
            try
            {
                ButtonEneble(false);
                DocumentBFModel documentBFModel = new DocumentBFModel()
                {
                    ID = IndexID,
                    IsUnit = Unit,
                    hdUserID = _lib.hdUserID
                };

                DataGridMode("Verify");

                var result = VerifyData(documentBFModel);

                if (result.VerifyStatusDT == 1)
                {
                    btnImport.Enabled = true;
                    btnImport.ForeColor = Color.White;
                    btnImport.BackColor = Color.MediumSeaGreen;

                    lblMessage.Text = "Verified!";
                }
                else if (result.VerifyStatusDT == 2)
                {
                    btnCancel.Enabled = true;
                    btnCancel.ForeColor = Color.White;
                    btnCancel.BackColor = Color.Firebrick;

                    lblMessage.Text = "Verified!";
                }
                else
                {
                    btnVerify.Enabled = true;
                    btnVerify.ForeColor = Color.White;
                    btnVerify.BackColor = Color.Orange;

                    lblMessage.Text = "Please Verify Again!";
                }

                btnClear.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                btnClear.Enabled = true;
            }
        }

        private void BtnImport_Click(object sender, EventArgs e)
        {
            try
            {
                ButtonEneble(false);
                DocumentBFModel documentBFModel = new DocumentBFModel()
                {
                    ID = IndexID,
                    IsUnit = Unit,
                    hdUserID = _lib.hdUserID
                };

                ImportDMS(documentBFModel);
                _lib.CountFile(documentBFModel);

                lblMessage.Text = "Imported!";
                lblMessageOK.Text = string.Empty;
                lblMessageMIS.Text = string.Empty;
                lblPercent.Text = string.Empty;

                btnClear.Enabled = true;

                btnImport.Enabled = false;
                btnImport.ForeColor = Color.Black;
                btnImport.BackColor = Color.LightGray;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                btnClear.Enabled = true;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                ButtonEneble(false);
                DocumentBFModel documentBFModel = new DocumentBFModel()
                {
                    ID = IndexID,
                    IsUnit = Unit,
                    hdUserID = _lib.hdUserID
                };

                lblMessage.Text = "Canceling...";
                lblMessageOK.Text = string.Empty;
                lblMessageMIS.Text = string.Empty;
                lblPercent.Text = string.Empty;

                _lib.CancleImportDMS(documentBFModel);

                lblMessage.Text = "Canceled!";

                btnClear.Enabled = true;

                btnCancel.Enabled = false;
                btnCancel.ForeColor = Color.Black;
                btnCancel.BackColor = Color.LightGray;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                btnClear.Enabled = true;
            }
        }

        private void Compare()
        {
            var enc874 = CodePagesEncodingProvider.Instance.GetEncoding(874);
            string[] files = Directory.GetFiles(PathDirectory);

            if (PathFile == string.Empty && PathDirectory == string.Empty)
            {
                MessageBox.Show("Please Select all path");
                return;
            }

            try
            {
                string readText;
                if (rdoANSI.Checked)
                {
                    readText = File.ReadAllText(PathFile, enc874);
                }
                else if (rdoUTF8.Checked)
                {
                    readText = File.ReadAllText(PathFile);
                }
                else
                {
                    MessageBox.Show("Encoding Wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }

                if (!_lib.TextFileFormatValidate(readText.Replace("\r", "").Trim().Split('\n')))
                {
                    MessageBox.Show("Format Wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return;
                }

                List<string> lines = new List<string>();
                foreach (string file in files)
                {
                    lines.Add(Path.GetFileName(file));
                }

                dgvDataList.Rows.Clear();
                int OK = 0, MISSING = 0;
                int round = 0;

                foreach (var Item in _lib.FilteredTextList)
                {
                    var result = lines.Find(s => s == Item.FileName);

                    if (result != null)
                    {
                        dgvDataList.Rows.Add(Item.FileName, result, Item.DocName, "OK");
                        OK += 1;
                    }
                    else
                    {
                        dgvDataList.Rows.Add(Item.FileName, result, Item.DocName, "MISSING");
                        MISSING += 1;
                    }

                    round += 1;
                    int tmp = ((round * 100) / _lib.FilteredTextList.Count);
                    pgbStatus.Value = tmp;
                    lblPercent.Text = tmp + "%";
                    lblMessage.Text = "Comparing : " + Item.FileName;
                    lblMessageOK.Text = string.Format("OK  : {0} File", OK);
                    lblMessageMIS.Text = string.Format("MIS : {0} File", MISSING);
                    Application.DoEvents();
                }

                lblMessage.Text = "Compared!";
                lblPercent.Text = string.Empty;

                btnUpload.Enabled = true;
                btnUpload.ForeColor = Color.White;
                btnUpload.BackColor = Color.DodgerBlue;

                btnClear.Enabled = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Upload()
        {
            string[] files = Directory.GetFiles(PathDirectory);
            _lib.fileIndex = Path.GetFileName(PathFile);

            string DFILE_Path = Properties.Settings.Default.DFILEPath;
            string BDS_Path = Properties.Settings.Default.BDSPath;
            string LOCAL_Path = Properties.Settings.Default.TempBatchFile;

            try
            {
                lblMessageOK.Text = "Starting...";
                lblMessageMIS.Text = string.Empty;
                Application.DoEvents();

                if (_lib.Insert_ExpensionData(_lib.taskType, _lib.fileIndex, _lib.tempDT))
                {
                    IndexID = _lib.GetMaxID(_lib.fileIndex);
                    Unit = _lib.GetUnit(IndexID);

                    string YearNow = "";
                    YearNow = DateTime.Now.Year.ToString();
                    int fYear = Convert.ToInt32(YearNow);
                    int bcYear = fYear + 543;
                    string allname = Convert.ToString(bcYear) + "-" + "Temp";

                    string LOCALPathFileTemp = LOCAL_Path + allname + "\\" + IndexID;
                    string BDSPathFileTemp = BDS_Path + allname + "\\" + IndexID;
                    string DFILEPathFileTemp = DFILE_Path + allname + "\\" + IndexID;

                    if (!Directory.Exists(LOCALPathFileTemp))
                    {
                        Directory.CreateDirectory(LOCALPathFileTemp);
                    }

                    if (!Directory.Exists(BDSPathFileTemp))
                    {
                        Directory.CreateDirectory(BDSPathFileTemp);
                    }

                    if (!Directory.Exists(DFILEPathFileTemp))
                    {
                        Directory.CreateDirectory(DFILEPathFileTemp);
                    }

                    int round = 0;

                    foreach (string file in files)
                    {
                        string fileName = Path.GetFileName(file);

                        _lib.Copy(file, LOCALPathFileTemp, fileName);
                        _lib.Copy(file, BDSPathFileTemp, fileName);
                        _lib.Copy(file, DFILEPathFileTemp, fileName);

                        round += 1;
                        int tmp = ((round * 100) / files.Length);
                        pgbStatus.Value = tmp;
                        lblPercent.Text = tmp + "%";
                        lblMessage.Text = string.Format("Uploading : {0}/{1}", round, files.Length);
                        lblMessageOK.Text = string.Format("> {0}", fileName);
                        Application.DoEvents();
                    }

                    lblMessage.Text = "Uploaded!";
                    lblMessageOK.Text = string.Empty;
                    lblPercent.Text = string.Empty;

                    btnVerify.Enabled = true;
                    btnVerify.ForeColor = Color.White;
                    btnVerify.BackColor = Color.Orange;

                    btnUpload.Enabled = false;
                    btnUpload.ForeColor = Color.Black;
                    btnUpload.BackColor = Color.LightGray;

                    btnClear.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public VerifyMessageModel VerifyData(DocumentBFModel data)
        {
            DocumetnBF_IndexFileListDT_item_VM IndexDT = new DocumetnBF_IndexFileListDT_item_VM();

            int round = 0, PASS = 0, NOT = 0, tmp = 0;
            lblMessage.Text = "Starting...";
            lblPercent.Text = string.Empty;
            lblMessageOK.Text = string.Empty;
            lblMessageMIS.Text = string.Empty;
            Application.DoEvents();

            var detail = _lib.ConvertToList<IndexFileVerifyDtModel>(_lib._batch.GetDetail(data));

            foreach (var item in detail)
            {
                int is_valid = 1;

                //เคส2
                var attr = new AttachmentType();
                attr.FullName = item.DocName;
                DataTable dtAtt = _lib._batch.GetAttachmentTypeByName(attr);
                if (dtAtt.Rows.Count == 0)
                {
                    var msg = new VerifyMessageModel();
                    msg.status = 2;
                    msg.message = "ไม่พบชื่อประเภทเอกสารนี้ในระบบ";
                    is_valid = 2;

                    var verDT = new IndexFileVerifyDtModel();
                    verDT.VerifyStatus = 2;
                    verDT.RejectReasonID = 1;
                    verDT.ID = item.ID;
                    _lib._batch.UpdateIndexFileVerifyDt(verDT);

                    dgvDataList.Rows.Add(item.Filename, item.CitizenID, item.MemberID, item.DocName, msg.message, "Rejected");
                    NOT += 1;

                    round += 1;
                    tmp = ((round * 100) / detail.Count);
                    pgbStatus.Value = tmp;
                    lblPercent.Text = tmp + "%";
                    lblMessage.Text = string.Format("Verifying : {0}/{1}", round, detail.Count);
                    lblMessageOK.Text = string.Format("Accepted : {0} File", PASS);
                    lblMessageMIS.Text = string.Format("Rejected : {0} File", NOT);
                    Application.DoEvents();
                    continue;
                }


                //เคส4
                if (!String.IsNullOrEmpty(item.Filename))
                {
                    CultureInfo _cultureThInfo = new CultureInfo("th-TH");
                    string YearNow = "";
                    DateTime today = DateTime.Today;
                    DateTime dateNow = Convert.ToDateTime(today, _cultureThInfo);
                    YearNow = dateNow.ToString("yyyy", _cultureThInfo);

                    var dt_file = new FindBatchFile();
                    dt_file.IndexFileVerifyID = item.IndexFileVerifyID;
                    dt_file.Filename = item.Filename;
                    dt_file.SubFolder = $"{YearNow}-Temp";

                    var client = new RestClient($"{_lib._UrlPFILE}api/VerifyBatch/GetBatchFile");
                    var request = new RestRequest();
                    request.AddHeader("Content-Type", "application/json");
                    var model = JsonConvert.SerializeObject(dt_file);
                    request.AddParameter("application/json", model, ParameterType.RequestBody);
                    RestResponse response = client.ExecutePost(request);
                    if (response.IsSuccessful)
                    {
                        var content = JsonConvert.DeserializeObject<BatchFileStatus>(response.Content);

                        if (content.IsFound == 1)
                        {

                        }
                        else if (content.IsFound == 2)
                        {
                            var msg = new VerifyMessageModel();
                            msg.status = 2;
                            msg.message = "ไม่พบไฟล์เอกสารที่ Import เข้าระบบ";
                            is_valid = 2;

                            var verDT = new IndexFileVerifyDtModel();
                            verDT.VerifyStatus = 2;
                            verDT.RejectReasonID = 3;
                            verDT.ID = item.ID;
                            _lib._batch.UpdateIndexFileVerifyDt(verDT);

                            dgvDataList.Rows.Add(item.Filename, item.CitizenID, item.MemberID, item.DocName, msg.message, "Rejected");
                            NOT += 1;

                            round += 1;
                            tmp = ((round * 100) / detail.Count);
                            pgbStatus.Value = tmp;
                            lblPercent.Text = tmp + "%";
                            lblMessage.Text = string.Format("Verifying : {0}/{1}", round, detail.Count);
                            lblMessageOK.Text = string.Format("Accepted : {0} File", PASS);
                            lblMessageMIS.Text = string.Format("Rejected : {0} File", NOT);
                            Application.DoEvents();
                            continue;
                        }

                    }
                }

                if (item.IsUnit != 1)
                {
                    //เคส5
                    var member = new MemberDetail();
                    member.CitizenID = item.CitizenID;
                    DataTable dtM = _lib._batch.GetMemberDetailByCitizenID(member);
                    if (dtM.Rows.Count == 0)
                    {
                        var msg = new VerifyMessageModel();
                        msg.status = 2;
                        msg.message = "ไม่พบ Citizen ID นี้ในระบบ GFAST";
                        is_valid = 2;

                        var verDT = new IndexFileVerifyDtModel();
                        verDT.VerifyStatus = 2;
                        verDT.RejectReasonID = 4;
                        verDT.ID = item.ID;
                        _lib._batch.UpdateIndexFileVerifyDt(verDT);

                        dgvDataList.Rows.Add(item.Filename, item.CitizenID, item.MemberID, item.DocName, msg.message, "Rejected");
                        NOT += 1;

                        round += 1;
                        tmp = ((round * 100) / detail.Count);
                        pgbStatus.Value = tmp;
                        lblPercent.Text = tmp + "%";
                        lblMessage.Text = string.Format("Verifying : {0}/{1}", round, detail.Count);
                        lblMessageOK.Text = string.Format("Accepted : {0} File", PASS);
                        lblMessageMIS.Text = string.Format("Rejected : {0} File", NOT);
                        Application.DoEvents();
                        continue;
                    }

                    //เคส6
                    member.MemberID = item.MemberID;
                    DataTable dtMember = _lib._batch.GetMemberDetailByMemberID(member);
                    if (dtMember.Rows.Count == 0)
                    {
                        var msg = new VerifyMessageModel();
                        msg.status = 2;
                        msg.message = "ไม่พบ Member ID นี้ในระบบ GFAST";
                        is_valid = 2;

                        var verDT = new IndexFileVerifyDtModel();
                        verDT.VerifyStatus = 2;
                        verDT.RejectReasonID = 5;
                        verDT.ID = item.ID;
                        _lib._batch.UpdateIndexFileVerifyDt(verDT);

                        dgvDataList.Rows.Add(item.Filename, item.CitizenID, item.MemberID, item.DocName, msg.message, "Rejected");
                        NOT += 1;

                        round += 1;
                        tmp = ((round * 100) / detail.Count);
                        pgbStatus.Value = tmp;
                        lblPercent.Text = tmp + "%";
                        lblMessage.Text = string.Format("Verifying : {0}/{1}", round, detail.Count);
                        lblMessageOK.Text = string.Format("Accepted : {0} File", PASS);
                        lblMessageMIS.Text = string.Format("Rejected : {0} File", NOT);
                        Application.DoEvents();
                        continue;
                    }

                    //เคส7
                    DataTable dtCM = _lib._batch.GetMemberDetailByMemberIDAndCitizenID(member);
                    if (dtCM.Rows.Count == 0)
                    {
                        var msg = new VerifyMessageModel();
                        msg.status = 2;
                        msg.message = "ไม่พบ Member ID และ Citizen ID นี้ในระบบ GFAST";
                        is_valid = 2;

                        var verDT = new IndexFileVerifyDtModel();
                        verDT.VerifyStatus = 2;
                        verDT.RejectReasonID = 6;
                        verDT.ID = item.ID;
                        _lib._batch.UpdateIndexFileVerifyDt(verDT);

                        dgvDataList.Rows.Add(item.Filename, item.CitizenID, item.MemberID, item.DocName, msg.message, "Rejected");
                        NOT += 1;

                        round += 1;
                        tmp = ((round * 100) / detail.Count);
                        pgbStatus.Value = tmp;
                        lblPercent.Text = tmp + "%";
                        lblMessage.Text = string.Format("Verifying : {0}/{1}", round, detail.Count);
                        lblMessageOK.Text = string.Format("Accepted : {0} File", PASS);
                        lblMessageMIS.Text = string.Format("Rejected : {0} File", NOT);
                        Application.DoEvents();
                        continue;
                    }
                }

                var ifv = new IndexFileVerifyDtModel();
                ifv.FileIndex = item.FileIndex;
                ifv.IndexFileVerifyID = item.IndexFileVerifyID;
                DataTable dtifv = _lib._batch.CheckFileIndex_Depicate(ifv);
                if (dtifv.Rows.Count > 0)
                {
                    var msg = new VerifyMessageModel();
                    msg.status = 2;
                    msg.message = "Index File นี้ ซ้ำกับที่เคยนำเข้าระบบแล้ว";
                    is_valid = 2;

                    var verDT = new IndexFileVerifyDtModel();
                    verDT.VerifyStatus = 2;
                    verDT.RejectReasonID = 7;
                    verDT.ID = item.ID;
                    _lib._batch.UpdateIndexFileVerifyDt(verDT);

                    dgvDataList.Rows.Add(item.Filename, item.CitizenID, item.MemberID, item.DocName, msg.message, "Rejected");
                    NOT += 1;

                    round += 1;
                    tmp = ((round * 100) / detail.Count);
                    pgbStatus.Value = tmp;
                    lblPercent.Text = tmp + "%";
                    lblMessage.Text = string.Format("Verifying : {0}/{1}", round, detail.Count);
                    lblMessageOK.Text = string.Format("Accepted : {0} File", PASS);
                    lblMessageMIS.Text = string.Format("Rejected : {0} File", NOT);
                    Application.DoEvents();
                    continue;
                }


                if (is_valid == 1)
                {
                    var verDT = new IndexFileVerifyDtModel();
                    verDT.VerifyStatus = 1;
                    verDT.RejectReasonID = 0;
                    verDT.ID = item.ID;
                    _lib._batch.UpdateIndexFileVerifyDt(verDT);
                    dgvDataList.Rows.Add(item.Filename, item.CitizenID, item.MemberID, item.DocName, string.Empty, "Accepted");
                    PASS += 1;
                }

                round += 1;
                tmp = ((round * 100) / detail.Count);
                pgbStatus.Value = tmp;
                lblPercent.Text = tmp + "%";
                lblMessage.Text = string.Format("Verifying : {0}/{1}", round, detail.Count);
                lblMessageOK.Text = string.Format("Accepted : {0} File", PASS);
                lblMessageMIS.Text = string.Format("Rejected : {0} File", NOT);
                Application.DoEvents();
            }

            lblMessage.Text = "Finishing...";
            //lblMessageOK.Text = string.Empty;
            //lblMessageMIS.Text = string.Empty;
            lblPercent.Text = string.Empty;
            Application.DoEvents();

            var detail_pass = _lib.ConvertToList<IndexFileVerifyDtModel>(_lib._batch.GetDetail(data));
            foreach (var item in detail_pass)
            {
                item.RefCaseID = (!String.IsNullOrEmpty(item.RefCaseID)) ? item.RefCaseID : string.Empty;
            }
            var ed_detail_pass = detail_pass.Where(x => x.VerifyStatus == 1 && Regex.Replace(x.RefCaseID, @"[\d-]", string.Empty) != string.Empty).ToList();


            foreach (var item in ed_detail_pass)
            {
                var doc = new Document();
                doc.CaseID = item.RefCaseID;
                string GetIsPrevious = _lib._batch.GetIsPreviousDMS(doc);

                string GetIsNewCase = _lib._batch.GetIsNewCase(doc);

                var DmsCaseM = new DmsCaseMaster();
                if (!String.IsNullOrEmpty(item.RefCaseID))
                {
                    var output = Regex.Replace(item.RefCaseID, @"[\d-]", string.Empty);
                    DmsCaseM.Doctype = output;
                    DmsCaseM.CaseID = item.RefCaseID;
                }

                var client = new RestClient(_lib._UrlGPFAPI + "api/GetDmsCaseMaster");
                var request = new RestRequest();
                request.AddHeader("Content-Type", "application/json");

                var model = JsonConvert.SerializeObject(DmsCaseM);
                request.AddParameter("application/json", model, ParameterType.RequestBody);
                RestResponse response = client.ExecutePost(request);
                if (response.IsSuccessful)
                {
                    var myDeserializedClass = JsonConvert.DeserializeObject<string>(response.Content);
                    var myDeserializedClassV2 = JsonConvert.DeserializeObject<Root>(myDeserializedClass);

                    if (myDeserializedClassV2.request_info.Count > 0)
                    {
                        var myDeserializedClassV3 = myDeserializedClassV2.request_info.Where(x => x.NewCase == 1).GroupBy(x => x.CaseID).Select(x => x.First()).ToList();
                        foreach (var subitem in myDeserializedClassV3)
                        {

                            var tableDmsApi = new SearchdataDocument();
                            tableDmsApi.CaseID = subitem.CaseID;
                            tableDmsApi.MemberID = Convert.ToString(subitem.MemberID);
                            tableDmsApi.FirstNameTh = Convert.ToString(subitem.FirstName);
                            tableDmsApi.LastNameTh = Convert.ToString(subitem.LastName);
                            tableDmsApi.PrefixName = Convert.ToString(subitem.Prefix);
                            tableDmsApi.CitizenID = Convert.ToString(subitem.CitizenID);
                            tableDmsApi.GovUnitCode = Convert.ToString(subitem.GovUnitCode);
                            tableDmsApi.TasktypeID = subitem.TaskTypeID;
                            tableDmsApi.InputType = subitem.InputTypeID;
                            tableDmsApi.Boxno = subitem.Boxno;
                            tableDmsApi.FolderNo = subitem.FolderNo;
                            if (subitem.CreateDate != DateTime.MinValue)
                            {
                                DateTime date = Convert.ToDateTime(subitem.CreateDate, new CultureInfo("th-TH"));
                                tableDmsApi.strCreateDate = date.ToString("dd/MM/yyyy HH:mm", new CultureInfo("th-TH"));
                            }

                            tableDmsApi.TypeDms = "Api";

                            //---------------------------------

                            if (!String.IsNullOrEmpty(subitem.GovUnitName) && !String.IsNullOrEmpty(subitem.GovUnitCode))
                            {
                                var gov = new GovUnitModel();
                                gov.Code = subitem.GovUnitCode;
                                gov.GovUnitNameTh = subitem.GovUnitName;
                                string GovId = _lib._batch.GetGovID(gov);

                                if (GovId != string.Empty)
                                {
                                    doc.GovUnitID = Convert.ToInt32(GovId);
                                }
                                else
                                {
                                    _lib._batch.Insert_GovUnit(gov.Code, gov.GovUnitNameTh);
                                    gov.Code = gov.Code;
                                    string GovId2 = _lib._batch.GetGovID(gov);

                                    doc.GovUnitID = Convert.ToInt32(GovId2);
                                }
                            }

                            doc.TaskTypeID = subitem.TaskTypeID;
                            doc.IsPreviousDMS = subitem.InputTypeID;
                            doc.CreateBy = data.hdUserID;
                            doc.UpdateBy = data.hdUserID;
                            doc.IsNewCase = 1;
                            doc.IsPreviousDMS = 1;
                            doc.CaseID = subitem.CaseID;

                            if (GetIsPrevious == string.Empty && GetIsNewCase == string.Empty)
                            {
                                _lib._batch.Insert_Document_WithAPI(doc);
                            }
                        }

                        if (GetIsPrevious == string.Empty && GetIsNewCase == string.Empty && myDeserializedClassV3.Count == 0)
                        {
                            var verDT = new IndexFileVerifyDtModel();
                            verDT.VerifyStatus = 2;
                            verDT.RejectReasonID = 2;
                            verDT.ID = item.ID;
                            _lib._batch.UpdateIndexFileVerifyDt(verDT);
                        }
                    }
                }

                if (GetIsPrevious == string.Empty && GetIsNewCase == string.Empty && response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    var verDT = new IndexFileVerifyDtModel();
                    verDT.VerifyStatus = 2;
                    verDT.RejectReasonID = 2;
                    verDT.ID = item.ID;
                    _lib._batch.UpdateIndexFileVerifyDt(verDT);
                }
            }

            return _lib.CheckIndexFileVerifyDt(data);
        }

        public void ImportDMS(DocumentBFModel data)
        {
            //-----Init Log Variable----------
            string pathDirectory = Properties.Settings.Default.LogPath;
            string log_path = Path.Combine(pathDirectory, string.Format("Import2DMS_log_{0}.txt", DateTime.Now.Date.ToString("yyMMdd")));
            StringBuilder log_content = new StringBuilder();

            //-----Start Import----------
            try
            {
                IndexFileVerifyDtModel verDT = new IndexFileVerifyDtModel();
                verDT.VerifyStatus = 3;
                verDT.IndexFileVerifyID = data.ID;

                //------Write Log------
                log_content.AppendFormat(Environment.NewLine);

                _lib._batch.UpdateIndexFileVerify(verDT);

                //------Write Log------
                log_content.AppendFormat(Environment.NewLine);
                log_content.AppendFormat("Excuted Query UpdateIndexFileVerify" + Environment.NewLine);
                log_content.AppendFormat(Environment.NewLine);

                int round = 0;
                lblMessage.Text = "Starting...";
                lblPercent.Text = string.Empty;
                Application.DoEvents();

                var detail = _lib.ConvertToList<IndexFileVerifyDtModel>(_lib._batch.GetTempIndexFileVerifyDT(data));
                if (detail.Count > 0)
                {
                    var group_data = detail.GroupBy(x => x.CaseNumber).Select(grp => grp.First()).OrderBy(or => or.CaseNumber).ToList();

                    //สร้าง case และ นำเข้าเอกสาร
                    foreach (var item in group_data)
                    {
                        #region Member
                        if (item.IsUnit != 1)
                        {
                            //------Write Log------
                            log_content.AppendFormat("----- Create Member Case -----" + Environment.NewLine);

                            var member = new GPFMemberModel();
                            member.IDCard = item.CitizenID;
                            member.GPFMemberID = item.MemberID;

                            //------Write Log------
                            log_content.AppendFormat("IDCard : {0}" + Environment.NewLine, member.IDCard);
                            log_content.AppendFormat("GPFMemberID : {0}" + Environment.NewLine, member.GPFMemberID);
                            log_content.AppendFormat(Environment.NewLine);

                            //ตรวจสอบ Member ใน DMS
                            DataTable dtM = _lib._batch.GetGPFMember(member);
                            if (dtM.Rows.Count == 0)
                            {
                                var memberlist = _lib.ConvertToList<GPFMemberModel>(_lib._batch.Get_vw_MemberDetail(member));
                                foreach (var member_item in memberlist)
                                {
                                    var gov = new GovUnitModel();
                                    gov.Code = member_item.Code;
                                    gov.GovUnitNameTh = member_item.EmployerName;
                                    gov.GovUnitMain = member_item.UnitMain;

                                    var pre = new Prefix_Model();
                                    member_item.PrefixName = member_item.PrefixName.Replace(" ", string.Empty);
                                    pre.NameTh = member_item.PrefixName;

                                    if (member_item.PrefixName != string.Empty)
                                    {
                                        string PrefixId = _lib._batch.GetPrefixID(pre);
                                        if (PrefixId == string.Empty)
                                        {
                                            _lib._batch.Insert_Prefix(pre.NameTh);

                                            gov.Code = member_item.Code;
                                            string PrefixId2 = _lib._batch.GetPrefixID(pre);
                                            member_item.PrefixID = (PrefixId2 != string.Empty) ? Convert.ToInt32(PrefixId2) : 0;
                                        }
                                        else
                                        {
                                            member_item.PrefixID = (PrefixId != string.Empty) ? Convert.ToInt32(PrefixId) : 0;
                                        }
                                    }

                                    if (member_item.EmployerName != string.Empty)
                                    {
                                        string GovId = _lib._batch.GetGovID(gov);
                                        if (GovId == string.Empty)
                                        {
                                            _lib._addgov.AddNewGovUnit(gov);

                                            gov.Code = member_item.Code;
                                            string GovId2 = _lib._batch.GetGovID(gov);
                                            member_item.GovUnitID = (GovId2 != string.Empty) ? Convert.ToInt32(GovId2) : 0;
                                        }
                                        else
                                        {
                                            member_item.GovUnitID = (GovId != string.Empty) ? Convert.ToInt32(GovId) : 0;
                                        }
                                    }

                                    var gpfmodel2 = new GPFMemberModel();
                                    gpfmodel2.IDCard = member_item.IDCard;
                                    gpfmodel2.GPFMemberID = member_item.MemberID.ToString();
                                    gpfmodel2.PrefixID = member_item.PrefixID;
                                    gpfmodel2.FirstNameTh = member_item.FirstNameTh;
                                    gpfmodel2.FirstNameEn = member_item.FirstNameEn;
                                    gpfmodel2.LastNameTh = member_item.LastNameTh;
                                    gpfmodel2.LastNameEn = member_item.LastNameEn;
                                    gpfmodel2.GovUnitID = member_item.GovUnitID;
                                    gpfmodel2.SendType = member_item.SendType;
                                    gpfmodel2.JoinGovDate = member_item.JoinGovDate;
                                    gpfmodel2.JoinGPFDate = member_item.JoinGPFDate;
                                    gpfmodel2.JoinGPFDate = member_item.JoinGPFDate;
                                    gpfmodel2.IsActive = 1;
                                    gpfmodel2.CreateBy = data.hdUserID;
                                    gpfmodel2.UpdateBy = data.hdUserID;
                                    gpfmodel2.MemberStatus = member_item.MemberStatus;

                                    CultureInfo _cultureThInfo = new CultureInfo("th-TH");
                                    if (member_item.JoinGovDate != DateTime.MinValue)
                                    {
                                        gpfmodel2.JoinGovDate = gpfmodel2.JoinGovDate;
                                        member_item.JoinGovDate = member_item.JoinGovDate;
                                    }
                                    if (member_item.JoinGPFDate != DateTime.MinValue)
                                    {
                                        gpfmodel2.JoinGPFDate = gpfmodel2.JoinGPFDate;
                                        member_item.JoinGPFDate = member_item.JoinGPFDate;
                                    }

                                    member_item.GPFMemberID = member_item.MemberID.ToString();

                                    string ID = _lib._batch.Insert_GPFMember(gpfmodel2);
                                    member_item.ID = (ID != string.Empty) ? Convert.ToInt32(ID) : 0;

                                    item.RefCaseID = (!String.IsNullOrEmpty(item.RefCaseID)) ? item.RefCaseID : string.Empty;
                                    if (Regex.Replace(item.RefCaseID, @"[\d-]", string.Empty) != string.Empty)
                                    {
                                        var doc = new Document();
                                        doc.CaseID = item.RefCaseID;
                                        doc.BatchRefNo = item.RefCaseID;
                                        doc.MemberID = member_item.ID;
                                        _lib._batch.UpdateDocument(doc);

                                        DataTable dt = _lib._batch.GetDocByCaseID(doc);
                                        if (dt.Rows.Count > 0)
                                        {
                                            item.DocumentID = (dt.Rows[0]["ID"].ToString() != string.Empty) ? Convert.ToInt32(dt.Rows[0]["ID"].ToString()) : 0;

                                        }
                                    }
                                    else
                                    {
                                        var doc = new Document();
                                        doc.MemberID = member_item.ID;
                                        doc.GovUnitID = gpfmodel2.GovUnitID;
                                        doc.TaskTypeID = item.TaskTypeID;
                                        doc.CreateBy = data.hdUserID;
                                        doc.UpdateBy = data.hdUserID;
                                        doc.SubmitDate = DateTime.Now;

                                        string FirstText = "";
                                        if (doc.TaskTypeID == 1)
                                        {
                                            FirstText = "CLM";
                                        }
                                        if (doc.TaskTypeID == 2)
                                        {
                                            FirstText = "MR6";
                                        }
                                        if (doc.TaskTypeID == 3)
                                        {
                                            FirstText = "INI";
                                        }
                                        if (doc.TaskTypeID == 4)
                                        {
                                            FirstText = "RIS";
                                        }
                                        if (doc.TaskTypeID == 5)
                                        {
                                            FirstText = "MIC";
                                        }
                                        if (doc.TaskTypeID == 6)
                                        {
                                            FirstText = "STB";
                                        }
                                        if (doc.TaskTypeID == 7)
                                        {
                                            FirstText = "RPA";
                                        }
                                        if (doc.TaskTypeID == 8)
                                        {
                                            FirstText = "REF";
                                        }
                                        if (doc.TaskTypeID == 9)
                                        {
                                            FirstText = "EDI";
                                        }
                                        if (doc.TaskTypeID == 10)
                                        {
                                            FirstText = "OTH";
                                        }
                                        if (doc.TaskTypeID == 11)
                                        {
                                            FirstText = "TMD";
                                        }

                                        int Year = _lib.GetCurrentYear();

                                        string RunningNumber = string.Empty;

                                        if (Year > 2565) RunningNumber = "00001";
                                        else RunningNumber = "60001";

                                        DateTime dt_year = Convert.ToDateTime(DateTime.Now, _cultureThInfo);
                                        string RUNNING_YEAR = dt_year.ToString("yy", _cultureThInfo);

                                        string RNumber = _lib._batch.GetRunningNumber_BillPayment(Convert.ToInt32(RUNNING_YEAR), doc.TaskTypeID);
                                        string NewRunningNumber = (RNumber != string.Empty) ? String.Format("{0:D5}", Convert.ToInt32(RNumber) + 1)
                                                                    : String.Format("{0:D5}", Convert.ToInt32(RunningNumber));

                                        string B = "2";
                                        if (RNumber != string.Empty)
                                        {
                                            if (Convert.ToInt32(RNumber) < 60001)
                                            {
                                                string rnnCase = _lib._batch.GetRunningCase(Convert.ToInt32(RUNNING_YEAR), doc.TaskTypeID);
                                                B = rnnCase;
                                            }
                                            else
                                            {
                                                B = "2";
                                            }
                                        }

                                        doc.CaseID = $"{FirstText}{RUNNING_YEAR}{B}{NewRunningNumber}";
                                        if (RNumber == string.Empty)
                                        {
                                            doc.RunningNumber = Convert.ToInt32(RunningNumber);
                                        }
                                        else
                                        {
                                            if (RNumber == "99999")
                                            {
                                                B = Convert.ToString(Convert.ToInt32(B) + 1);

                                                NewRunningNumber = "00000";
                                                doc.RunningNumber = 00000;
                                                doc.CaseID = $"{FirstText}{RUNNING_YEAR}{B}{NewRunningNumber}";
                                            }
                                            else
                                            {
                                                doc.RunningNumber = Convert.ToInt32(RNumber) + 1;
                                            }
                                        }

                                        doc.RunningYear = Convert.ToInt32(RUNNING_YEAR);
                                        doc.RunningCase = (B != string.Empty) ? Convert.ToInt32(B) : 0;
                                        doc.BatchRefNo = string.Empty;
                                        doc.IsNewCase = 1;
                                        string docid = _lib._batch.Exec_Insert_Document(doc);

                                        item.DocumentID = (docid != string.Empty) ? Convert.ToInt32(docid) : 0;

                                        //------Write Log------
                                        log_content.AppendFormat("<-- Exec_Insert_Document with param -->" + Environment.NewLine);
                                        log_content.AppendFormat("> MemberID : {0}" + Environment.NewLine, doc.MemberID);
                                        log_content.AppendFormat("> GovUnitID : {0}" + Environment.NewLine, doc.GovUnitID);
                                        log_content.AppendFormat("> TaskTypeID : {0}" + Environment.NewLine, doc.TaskTypeID);
                                        log_content.AppendFormat("> CreateBy : {0}" + Environment.NewLine, doc.CreateBy);
                                        log_content.AppendFormat("> UpdateBy : {0}" + Environment.NewLine, doc.UpdateBy);
                                        log_content.AppendFormat("> SubmitDate : {0}" + Environment.NewLine, doc.SubmitDate);
                                        log_content.AppendFormat("> CaseID : {0}" + Environment.NewLine, doc.CaseID);
                                        log_content.AppendFormat("> RunningNumber : {0}" + Environment.NewLine, doc.RunningNumber);
                                        log_content.AppendFormat("> RunningCase : {0}" + Environment.NewLine, doc.RunningCase);
                                        log_content.AppendFormat("> BatchRefNo : {0}" + Environment.NewLine, doc.BatchRefNo);
                                        log_content.AppendFormat("> IsNewCase : {0}" + Environment.NewLine, doc.IsNewCase);
                                        log_content.AppendFormat("--- Get DocumentID ---" + Environment.NewLine);
                                        log_content.AppendFormat(">> DocumentID : {0}" + Environment.NewLine, item.DocumentID);
                                        log_content.AppendFormat("----------------------" + Environment.NewLine);
                                        log_content.AppendFormat(Environment.NewLine);
                                    }
                                }
                            }
                            else
                            {
                                //------Write Log------
                                log_content.AppendFormat("Checked Is Member in DMS" + Environment.NewLine);
                                log_content.AppendFormat(Environment.NewLine);

                                var doc = new Document();
                                doc.MemberID = (dtM.Rows[0]["ID"].ToString() != string.Empty) ? Convert.ToInt32(dtM.Rows[0]["ID"]) : 0;

                                item.RefCaseID = (!String.IsNullOrEmpty(item.RefCaseID)) ? item.RefCaseID : string.Empty;

                                if (Regex.Replace(item.RefCaseID, @"[\d-]", string.Empty) != string.Empty)
                                {

                                    doc.CaseID = item.RefCaseID;
                                    doc.BatchRefNo = item.RefCaseID;
                                    _lib._batch.UpdateDocument(doc);

                                    DataTable dt = _lib._batch.GetDocByCaseID(doc);
                                    if (dt.Rows.Count > 0)
                                    {
                                        item.DocumentID = (dt.Rows[0]["ID"].ToString() != string.Empty) ? Convert.ToInt32(dt.Rows[0]["ID"].ToString()) : 0;

                                    }
                                }
                                else
                                {
                                    doc.GovUnitID = (dtM.Rows[0]["GovUnitID"].ToString() != string.Empty) ? Convert.ToInt32(dtM.Rows[0]["GovUnitID"]) : 0;
                                    doc.TaskTypeID = item.TaskTypeID;
                                    doc.CreateBy = data.hdUserID;
                                    doc.UpdateBy = data.hdUserID;

                                    string FirstText = "";
                                    if (doc.TaskTypeID == 1)
                                    {
                                        FirstText = "CLM";
                                    }
                                    if (doc.TaskTypeID == 2)
                                    {
                                        FirstText = "MR6";
                                    }
                                    if (doc.TaskTypeID == 3)
                                    {
                                        FirstText = "INI";
                                    }
                                    if (doc.TaskTypeID == 4)
                                    {
                                        FirstText = "RIS";
                                    }
                                    if (doc.TaskTypeID == 5)
                                    {
                                        FirstText = "MIC";
                                    }
                                    if (doc.TaskTypeID == 6)
                                    {
                                        FirstText = "STB";
                                    }
                                    if (doc.TaskTypeID == 7)
                                    {
                                        FirstText = "RPA";
                                    }
                                    if (doc.TaskTypeID == 8)
                                    {
                                        FirstText = "REF";
                                    }
                                    if (doc.TaskTypeID == 9)
                                    {
                                        FirstText = "EDI";
                                    }
                                    if (doc.TaskTypeID == 10)
                                    {
                                        FirstText = "OTH";
                                    }
                                    if (doc.TaskTypeID == 11)
                                    {
                                        FirstText = "TMD";
                                    }

                                    int Year = _lib.GetCurrentYear();

                                    string RunningNumber = string.Empty;

                                    if (Year > 2565) RunningNumber = "00001";
                                    else RunningNumber = "60001";

                                    CultureInfo _cultureThInfo = new CultureInfo("th-TH");

                                    DateTime dt_year = Convert.ToDateTime(DateTime.Now, _cultureThInfo);
                                    string RUNNING_YEAR = dt_year.ToString("yy", _cultureThInfo);

                                    string RNumber = _lib._batch.GetRunningNumber_BillPayment(Convert.ToInt32(RUNNING_YEAR), doc.TaskTypeID);
                                    string NewRunningNumber = (RNumber != string.Empty) ? String.Format("{0:D5}", Convert.ToInt32(RNumber) + 1)
                                                                : String.Format("{0:D5}", Convert.ToInt32(RunningNumber));



                                    string B = "2";
                                    if (RNumber != string.Empty)
                                    {
                                        if (Convert.ToInt32(RNumber) < 60001)
                                        {
                                            string rnnCase = _lib._batch.GetRunningCase(Convert.ToInt32(RUNNING_YEAR), doc.TaskTypeID);
                                            B = rnnCase;
                                        }
                                        else
                                        {
                                            B = "2";
                                        }
                                    }

                                    doc.CaseID = $"{FirstText}{RUNNING_YEAR}{B}{NewRunningNumber}";
                                    if (RNumber == string.Empty)
                                    {
                                        doc.RunningNumber = Convert.ToInt32(RunningNumber);
                                    }
                                    else
                                    {
                                        if (RNumber == "99999")
                                        {
                                            B = Convert.ToString(Convert.ToInt32(B) + 1);

                                            NewRunningNumber = "00000";
                                            doc.RunningNumber = 00000;
                                            doc.CaseID = $"{FirstText}{RUNNING_YEAR}{B}{NewRunningNumber}";
                                        }
                                        else
                                        {
                                            doc.RunningNumber = Convert.ToInt32(RNumber) + 1;
                                        }
                                    }

                                    doc.RunningYear = Convert.ToInt32(RUNNING_YEAR);
                                    doc.RunningCase = (B != string.Empty) ? Convert.ToInt32(B) : 0;
                                    doc.SubmitDate = DateTime.Now;
                                    doc.BatchRefNo = String.Empty;
                                    doc.IsNewCase = 1;
                                    string docid = _lib._batch.Exec_Insert_Document(doc);
                                    item.DocumentID = (docid != string.Empty) ? Convert.ToInt32(docid) : 0;

                                    //------Write Log------
                                    log_content.AppendFormat("<-- Exec_Insert_Document with param -->" + Environment.NewLine);
                                    log_content.AppendFormat("> MemberID : {0}" + Environment.NewLine, doc.MemberID);
                                    log_content.AppendFormat("> GovUnitID : {0}" + Environment.NewLine, doc.GovUnitID);
                                    log_content.AppendFormat("> TaskTypeID : {0}" + Environment.NewLine, doc.TaskTypeID);
                                    log_content.AppendFormat("> CreateBy : {0}" + Environment.NewLine, doc.CreateBy);
                                    log_content.AppendFormat("> UpdateBy : {0}" + Environment.NewLine, doc.UpdateBy);
                                    log_content.AppendFormat("> SubmitDate : {0}" + Environment.NewLine, doc.SubmitDate);
                                    log_content.AppendFormat("> CaseID : {0}" + Environment.NewLine, doc.CaseID);
                                    log_content.AppendFormat("> RunningNumber : {0}" + Environment.NewLine, doc.RunningNumber);
                                    log_content.AppendFormat("> RunningCase : {0}" + Environment.NewLine, doc.RunningCase);
                                    log_content.AppendFormat("> BatchRefNo : {0}" + Environment.NewLine, doc.BatchRefNo);
                                    log_content.AppendFormat("> IsNewCase : {0}" + Environment.NewLine, doc.IsNewCase);
                                    log_content.AppendFormat("--- Get DocumentID ---" + Environment.NewLine);
                                    log_content.AppendFormat(">> DocumentID : {0}" + Environment.NewLine, item.DocumentID);
                                    log_content.AppendFormat("----------------------" + Environment.NewLine);
                                    log_content.AppendFormat(Environment.NewLine);
                                }
                            }
                        }
                        #endregion
                        #region Unit
                        else
                        {
                            //------Write Log------
                            log_content.AppendFormat("----- Create Unit Case -----" + Environment.NewLine);

                            CultureInfo _cultureThInfo = new CultureInfo("th-TH");

                            int GovUnitID = 0;
                            if (item.GovUnitName != string.Empty)
                            {
                                var gov = new GovUnitModel();
                                gov.GovUnitNameTh = item.GovUnitName;
                                gov.GovUnitMain = item.UnitCode;
                                gov.Code = item.UnitCode;

                                //------Write Log------
                                log_content.AppendFormat("GovUnitNameTh : {0}" + Environment.NewLine, gov.GovUnitNameTh);
                                log_content.AppendFormat("GovUnitMain : {0}" + Environment.NewLine, gov.GovUnitMain);
                                log_content.AppendFormat("Code : {0}" + Environment.NewLine, gov.Code);
                                log_content.AppendFormat(Environment.NewLine);

                                string GovId = _lib._batch.GetGovID(gov);
                                if (GovId == string.Empty)
                                {
                                    _lib._addgov.AddNewGovUnit(gov);

                                    string GovId2 = _lib._batch.GetGovID(gov);
                                    GovUnitID = (GovId2 != string.Empty) ? Convert.ToInt32(GovId2) : 0;
                                }
                                else
                                {
                                    GovUnitID = (GovId != string.Empty) ? Convert.ToInt32(GovId) : 0;
                                }
                            }

                            item.UnitRefID = (!String.IsNullOrEmpty(item.UnitRefID)) ? item.UnitRefID : string.Empty;
                            if (Regex.Replace(item.UnitRefID, @"[\d-]", string.Empty) != string.Empty)
                            {

                                var doc = new Document();
                                doc.CaseID = item.UnitRefID;
                                doc.BatchRefNo = item.UnitRefID;
                                doc.GovUnitID = GovUnitID;
                                _lib._batch.UpdateDocument(doc);

                                DataTable dt = _lib._batch.GetDocByCaseID(doc);
                                if (dt.Rows.Count > 0)
                                {
                                    item.DocumentID = (dt.Rows[0]["ID"].ToString() != string.Empty) ? Convert.ToInt32(dt.Rows[0]["ID"].ToString()) : 0;

                                }
                                //item.DocumentID = (doc.ID != string.Empty) ? Convert.ToInt32(docid) : 0;

                            }
                            else
                            {
                                var doc = new Document();
                                //doc.MemberID = member_item.ID;
                                doc.GovUnitID = GovUnitID;
                                doc.TaskTypeID = item.TaskTypeID;
                                doc.CreateBy = data.hdUserID;
                                doc.UpdateBy = data.hdUserID;
                                doc.SubmitDate = DateTime.Now;

                                string FirstText = "";
                                if (doc.TaskTypeID == 1)
                                {
                                    FirstText = "CLM";
                                }
                                if (doc.TaskTypeID == 2)
                                {
                                    FirstText = "MR6";
                                }
                                if (doc.TaskTypeID == 3)
                                {
                                    FirstText = "INI";
                                }
                                if (doc.TaskTypeID == 4)
                                {
                                    FirstText = "RIS";
                                }
                                if (doc.TaskTypeID == 5)
                                {
                                    FirstText = "MIC";
                                }
                                if (doc.TaskTypeID == 6)
                                {
                                    FirstText = "STB";
                                }
                                if (doc.TaskTypeID == 7)
                                {
                                    FirstText = "RPA";
                                }
                                if (doc.TaskTypeID == 8)
                                {
                                    FirstText = "REF";
                                }
                                if (doc.TaskTypeID == 9)
                                {
                                    FirstText = "EDI";
                                }
                                if (doc.TaskTypeID == 10)
                                {
                                    FirstText = "OTH";
                                }
                                if (doc.TaskTypeID == 11)
                                {
                                    FirstText = "TMD";
                                }

                                int Year = _lib.GetCurrentYear();

                                string RunningNumber = string.Empty;

                                if (Year > 2565) RunningNumber = "00001";
                                else RunningNumber = "60001";

                                DateTime dt_year = Convert.ToDateTime(DateTime.Now, _cultureThInfo);
                                string RUNNING_YEAR = dt_year.ToString("yy", _cultureThInfo);

                                string RNumber = _lib._batch.GetRunningNumber_BillPayment(Convert.ToInt32(RUNNING_YEAR), doc.TaskTypeID);
                                string NewRunningNumber = (RNumber != string.Empty) ? String.Format("{0:D5}", Convert.ToInt32(RNumber) + 1)
                                                            : String.Format("{0:D5}", Convert.ToInt32(RunningNumber));



                                string B = "2";
                                if (RNumber != string.Empty)
                                {
                                    if (Convert.ToInt32(RNumber) < 60001)
                                    {
                                        string rnnCase = _lib._batch.GetRunningCase(Convert.ToInt32(RUNNING_YEAR), doc.TaskTypeID);
                                        B = rnnCase;
                                    }
                                    else
                                    {
                                        B = "2";
                                    }
                                }

                                doc.CaseID = $"{FirstText}{RUNNING_YEAR}{B}{NewRunningNumber}";
                                if (RNumber == string.Empty)
                                {
                                    doc.RunningNumber = Convert.ToInt32(RunningNumber);
                                }
                                else
                                {
                                    if (RNumber == "99999")
                                    {
                                        B = Convert.ToString(Convert.ToInt32(B) + 1);

                                        NewRunningNumber = "00000";
                                        doc.RunningNumber = 00000;
                                        //doc.RunningCase = (B != string.Empty)? Convert.ToInt32(B) : 0;
                                        doc.CaseID = $"{FirstText}{RUNNING_YEAR}{B}{NewRunningNumber}";
                                    }
                                    else
                                    {
                                        doc.RunningNumber = Convert.ToInt32(RNumber) + 1;
                                    }
                                }

                                doc.RunningYear = Convert.ToInt32(RUNNING_YEAR);
                                doc.RunningCase = (B != string.Empty) ? Convert.ToInt32(B) : 0;
                                doc.BatchRefNo = string.Empty;
                                //doc.TaskSubTypeID = item.Select(x => x.tas).First();
                                doc.IsNewCase = 1;
                                //string docid = _batch.Insert_Document(doc);
                                string docid = _lib._batch.Exec_Insert_Document(doc);

                                item.DocumentID = (docid != string.Empty) ? Convert.ToInt32(docid) : 0;

                                //------Write Log------
                                log_content.AppendFormat("<-- Exec_Insert_Document with param -->" + Environment.NewLine);
                                log_content.AppendFormat("> MemberID : {0}" + Environment.NewLine, doc.MemberID);
                                log_content.AppendFormat("> GovUnitID : {0}" + Environment.NewLine, doc.GovUnitID);
                                log_content.AppendFormat("> TaskTypeID : {0}" + Environment.NewLine, doc.TaskTypeID);
                                log_content.AppendFormat("> CreateBy : {0}" + Environment.NewLine, doc.CreateBy);
                                log_content.AppendFormat("> UpdateBy : {0}" + Environment.NewLine, doc.UpdateBy);
                                log_content.AppendFormat("> SubmitDate : {0}" + Environment.NewLine, doc.SubmitDate);
                                log_content.AppendFormat("> CaseID : {0}" + Environment.NewLine, doc.CaseID);
                                log_content.AppendFormat("> RunningNumber : {0}" + Environment.NewLine, doc.RunningNumber);
                                log_content.AppendFormat("> RunningCase : {0}" + Environment.NewLine, doc.RunningCase);
                                log_content.AppendFormat("> BatchRefNo : {0}" + Environment.NewLine, doc.BatchRefNo);
                                log_content.AppendFormat("> IsNewCase : {0}" + Environment.NewLine, doc.IsNewCase);
                                log_content.AppendFormat("--- Get DocumentID ---" + Environment.NewLine);
                                log_content.AppendFormat(">> DocumentID : {0}" + Environment.NewLine, item.DocumentID);
                                log_content.AppendFormat("----------------------" + Environment.NewLine);
                                log_content.AppendFormat(Environment.NewLine);

                            }
                        }
                        #endregion

                        int DocumentID = item.DocumentID;

                        var data_dt = detail.Where(x => x.CaseNumber == item.CaseNumber).ToList();
                        foreach (var subitem in data_dt)
                        {
                            var attr = new AttachmentDt();
                            attr.DocumentID = DocumentID;
                            attr.DocumentName = subitem.Filename;
                            attr.FileName = subitem.Filename;
                            string sttrid = _lib._batch.Exec_Insert_AttachmentDt(attr);

                            int attrid = (sttrid != string.Empty) ? Convert.ToInt32(sttrid) : 0;

                            subitem.DocumentID = attr.DocumentID;
                            subitem.AttachmentDtID = (sttrid != string.Empty) ? Convert.ToInt32(sttrid) : 0;
                            _lib._batch.UpdateIndexFileVerifyDt_With_AttachmentDtID(subitem);

                            var dtd = new DocumentDt();
                            dtd.AttachmentTypeID = subitem.AttachmentTypeID;
                            dtd.TaskType = subitem.TaskTypeID;
                            string getsq = _lib._batch.CheckDocumentDtID(dtd);
                            int sqid = (getsq != string.Empty) ? Convert.ToInt32(getsq) : 0;
                            _lib._batch.Exec_InsertAttachmentTypeDtInfo(attrid, subitem.AttachmentTypeID, sqid);

                            var f = new GetFileName_DMS();
                            f.DocID = attr.DocumentID;

                            var datalist = _lib.ConvertToList<GetFileName_DMS>(_lib._batch.GetFileName(f));
                            foreach (var fileitem in datalist)
                            {
                                if (fileitem.FileName == attr.FileName)
                                {
                                    CultureInfo _cultureThInfo = new CultureInfo("th-TH");
                                    string YearNow = "";
                                    DateTime today = DateTime.Today;
                                    DateTime dateNow = Convert.ToDateTime(today, _cultureThInfo);
                                    YearNow = dateNow.ToString("yyyy", _cultureThInfo);

                                    var dt_file = new FindBatchFile();
                                    dt_file.IndexFileVerifyID = subitem.IndexFileVerifyID;
                                    dt_file.Filename = subitem.Filename;
                                    dt_file.SubFolder = $"{YearNow}-Temp";

                                    var client_b = new RestClient($"{_lib._UrlPFILE}api/VerifyBatch/GetBatchFile");
                                    var request_b = new RestRequest();
                                    request_b.AddHeader("Content-Type", "application/json");
                                    var model_b = JsonConvert.SerializeObject(dt_file);
                                    request_b.AddParameter("application/json", model_b, ParameterType.RequestBody);
                                    RestResponse response_b = client_b.ExecutePost(request_b);
                                    if (response_b.IsSuccessful)
                                    {
                                        var content = JsonConvert.DeserializeObject<BatchFileStatus>(response_b.Content);

                                        if (content.IsFound == 1)
                                        {
                                            if (!String.IsNullOrEmpty(content.base64))
                                            {
                                                byte[] bytes2 = Convert.FromBase64String(content.base64);

                                                using (var ms = new MemoryStream(bytes2))
                                                {
                                                    IFormFile fromFile = new FormFile(ms, 0, ms.Length, content.FileName, content.FileExt);

                                                    var bytearr = _lib._encrypt.EncryptFileData(fromFile, attr.DocumentID, 5);

                                                }

                                                var client = new RestClient($"{_lib._UrlPFILE}api/ImportDocumentDMS/UploadFile");
                                                var request = new RestRequest();

                                                string[] files2 = Directory.GetFiles(Path.Combine($"{_lib.FilePath}{fileitem.DocumentID}_{5}_Temp\\"));

                                                foreach (string fileNo2 in files2)
                                                {
                                                    request.AddFile("File", fileNo2);
                                                    request.AddParameter("FileName", content.FileName);
                                                    request.AddParameter("FileExt", content.FileExt.Replace(".", string.Empty));
                                                    request.AddParameter("DocumentID", f.DocID);
                                                    request.AddParameter("Year", YearNow);

                                                    RestResponse response = client.ExecutePost(request);
                                                    if (response.IsSuccessful)
                                                    {
                                                        string[] Encryptfiles = Directory.GetFiles(Path.Combine($"{_lib.FilePath}{fileitem.DocumentID}_{5}_Temp\\"));
                                                        foreach (string fileNod in Encryptfiles)
                                                        {
                                                            var fileInfo = new FileInfo(fileNod);
                                                            fileInfo.Delete();
                                                        }

                                                    }
                                                }
                                                Directory.Delete(Path.Combine($"{_lib.FilePath}{fileitem.DocumentID}_{5}_Temp"), true);
                                            }
                                        }
                                    }
                                    break;
                                }
                            }
                            _lib._batch.UpdateIsProcess(subitem.ID, 1);
                        }

                        round += 1;
                        int tmp = ((round * 100) / group_data.Count);
                        pgbStatus.Value = tmp;
                        lblPercent.Text = tmp + "%";
                        lblMessage.Text = string.Format("Importing : {0}/{1}", round, group_data.Count);
                        Application.DoEvents();
                    }
                }

                lblMessage.Text = "Finishing...";
                lblPercent.Text = string.Empty;
                Application.DoEvents();

                var VerSuccess = new IndexFileVerifyDtModel();
                VerSuccess.VerifyStatus = 4;
                VerSuccess.IndexFileVerifyID = data.ID;
                _lib._batch.UpdateIndexFileVerify(VerSuccess);

                string YearNow_Del = "";
                DateTime today_Del = DateTime.Today;
                DateTime dateNow_Del = Convert.ToDateTime(today_Del, new CultureInfo("th-TH"));
                YearNow_Del = dateNow_Del.ToString("yyyy", new CultureInfo("th-TH"));
                var dt_file_Del = new FindBatchFile();
                dt_file_Del.IndexFileVerifyID = data.ID;
                dt_file_Del.SubFolder = $"{YearNow_Del}-Temp";

                var client_Del = new RestClient($"{_lib._UrlPFILE}api/VerifyBatch/DeleteFile");
                var request_Del = new RestRequest();
                request_Del.AddHeader("Content-Type", "application/json");
                var model_Del = JsonConvert.SerializeObject(dt_file_Del);
                request_Del.AddParameter("application/json", model_Del, ParameterType.RequestBody);
                RestResponse response_Del = client_Del.ExecutePost(request_Del);

                string pathLocal = Path.Combine($"{_lib.TempBatchFile}{dt_file_Del.SubFolder}\\{dt_file_Del.IndexFileVerifyID}");
                Directory.Delete(pathLocal, true);

                string pathBDS = Path.Combine($"{_lib.BDSFile}{dt_file_Del.SubFolder}\\{dt_file_Del.IndexFileVerifyID}");
                Directory.Delete(pathBDS, true);

                string pathDFILE = Path.Combine($"{_lib.DFILEFile}{dt_file_Del.SubFolder}\\{dt_file_Del.IndexFileVerifyID}");
                Directory.Delete(pathDFILE, true);

                var msg = new VerifyMessageModel();
                msg.VerifyStatus = 1;

                //-----Create Log File----------
                if (!Directory.Exists(pathDirectory))
                {
                    Directory.CreateDirectory(pathDirectory);
                }

                if (!File.Exists(log_path))
                {
                    using (StreamWriter sw = File.CreateText(log_path))
                    {
                        sw.WriteLine("Log created: {0}{1}", DateTime.Now.ToString(), Environment.NewLine);
                        sw.Write(log_content.ToString());
                    }
                }
                else
                {
                    File.Delete(log_path);

                    using (StreamWriter sw = File.CreateText(log_path))
                    {
                        sw.WriteLine("Log created: {0}{1}", DateTime.Now.ToString(), Environment.NewLine);
                        sw.Write(log_content.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Import Fail!";
                lblMessageOK.Text = ex.Message;
                lblPercent.Text = string.Empty;
                Application.DoEvents();

                //------Write Log------
                log_content.AppendFormat(Environment.NewLine);
                log_content.AppendFormat("Exception : {0}" + Environment.NewLine, ex.Message);
                log_content.AppendFormat(Environment.NewLine);

                //-----Create Log File----------
                if (!Directory.Exists(pathDirectory))
                {
                    Directory.CreateDirectory(pathDirectory);
                }

                if (!File.Exists(log_path))
                {
                    using (StreamWriter sw = File.CreateText(log_path))
                    {
                        sw.WriteLine("Log created: {0}{1}", DateTime.Now.ToString(), Environment.NewLine);
                        sw.Write(log_content.ToString());
                    }
                }
                else
                {
                    File.Delete(log_path);

                    using (StreamWriter sw = File.CreateText(log_path))
                    {
                        sw.WriteLine("Log created: {0}{1}", DateTime.Now.ToString(), Environment.NewLine);
                        sw.Write(log_content.ToString());
                    }
                }
            }
        }
    }
}
