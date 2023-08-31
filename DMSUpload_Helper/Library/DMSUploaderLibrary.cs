using DMSUpload_Helper.Models;
using DMSUpload_Helper.Service.Implement;
using DMSUpload_Helper.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DMSUpload_Helper.Library
{
    public class DMSUploaderLibrary
    {
        public readonly DMS_DT_BATCH_FILE_DETAIL _batch;
        public IAddGovUnit _addgov;
        public IEncryptFile _encrypt;
        public string _UrlPFILE;
        public string _UrlAPI;
        public string _UrlGPFAPI;
        public readonly string FilePath;
        public readonly string TempBatchFile;
        public readonly string BDSFile;
        public readonly string DFILEFile;

        public List<TextFormatModel> FilteredTextList = new List<TextFormatModel>();
        public DataTable tempDT = new DataTable();
        public string taskType = string.Empty;
        public string fileIndex = string.Empty;
        public string AllFilePath = string.Empty;

        public int hdUserID = 0;
        public string username = string.Empty;
        public string department = string.Empty;
        public string authority = string.Empty;

        public DMSUploaderLibrary(DMS_IAddGovUnit addGov)
        {
            _batch = new DMS_DT_BATCH_FILE_DETAIL();

            _addgov = new AddGovUnit(addGov);
            _encrypt = new EncryptFile();

            _UrlPFILE = Properties.Settings.Default.PFILE_API;
            _UrlAPI = Properties.Settings.Default.DMS_API;
            _UrlGPFAPI = Properties.Settings.Default.GPF_API;

            FilePath = Properties.Settings.Default.FilePath;
            TempBatchFile = Properties.Settings.Default.TempBatchFile;
            BDSFile = Properties.Settings.Default.BDSPath;
            DFILEFile = Properties.Settings.Default.DFILEPath;
        }

        public bool Authentication(string Username, string Password)
        {
            try
            {
                if (Username == "admin" && Password == "1234")
                {
                    username = "admin";
                    department = "IT";
                    authority = "Full Control";
                    hdUserID = 2;

                    return true;
                }
                else
                {
                    return false;

                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection props =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }

        public List<T> ConvertToList<T>(DataTable data)
        {
            var columnNames = data.Columns.Cast<DataColumn>().Select(c => c.ColumnName.ToLower()).ToList();
            var properties = typeof(T).GetProperties();
            return data.AsEnumerable().Select(row =>
            {
                var list = Activator.CreateInstance<T>();
                foreach (var pro in properties)
                {
                    if (columnNames.Contains(pro.Name.ToLower()))
                    {
                        try
                        {
                            pro.SetValue(list, row[pro.Name]);
                        }
                        catch (Exception) { }
                    }
                }
                return list;
            }).ToList();
        }

        public int GetCurrentYear()
        {
            CultureInfo _cultureThInfo = new CultureInfo("th-TH");
            DateTime date = Convert.ToDateTime(DateTime.Now, _cultureThInfo);
            string Year = date.ToString("yyyy", _cultureThInfo);
            int intYear = !String.IsNullOrEmpty(Year) ? Convert.ToInt32(Year) : 0;
            return intYear;
        }

        public void Copy(string inputFilePath, string outputFilePath, string fileName)
        {
            try
            {
                int bufferSize = 1024 * 1024;
                using (FileStream StreamRead = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read))
                {
                    using (FileStream StreamWrite = new FileStream(outputFilePath + "\\" + fileName, FileMode.Create, FileAccess.Write))
                    {
                        int bytesRead = 0;
                        byte[] bytes = new byte[bufferSize];
                        while ((bytesRead = StreamRead.Read(bytes, 0, bytes.Length)) > 0)
                        {
                            StreamWrite.Write(bytes, 0, bytesRead);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool TextFileFormatValidate(string[] textList)
        {
            try
            {
                FilteredTextList.Clear();

                if (textList[0].Length != 3)
                {
                    return false;
                }

                taskType = textList[0];

                for (int i = 1; i <= textList.Length - 1; i++)
                {
                    if(textList[i].Split('|').Length != 7)
                    {
                        return false;
                    }

                    string[] arrTemp = textList[i].Split('|');

                    FilteredTextList.Add(new TextFormatModel { FileName = arrTemp[0], DocName = arrTemp[1], CitizenID = arrTemp[2], MemberID = arrTemp[3], CaseNumber = arrTemp[5], FileNumber = arrTemp[6] });
                }

                tempDT = ConvertToDataTable(FilteredTextList);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Insert_ExpensionData(string TaskType, string FileIndex, DataTable dtFileData)
        {
            bool returnResult = false;
            string responseMsg = string.Empty, UserSQL = string.Empty, PassSQL = string.Empty;

            try
            {
                GPFMaintenance.GPFMaintenance ObjWeb = new GPFMaintenance.GPFMaintenance();
                string connStr = string.Empty;

                ObjWeb.GetParameter1("Share", "DMSNew_CON", ref connStr, ref responseMsg);
                ObjWeb.GetParameter2("Share", "DMSNew_USER", ref UserSQL, ref PassSQL, ref responseMsg);
                connStr = string.Format("{0};User ID={1};Password={2}", connStr, UserSQL, PassSQL);

                using (SqlConnection sqlConn = new SqlConnection(connStr))
                {
                    sqlConn.Open();
                    string sqlStatment = "TranferBatchFileText";
                    SqlCommand sqlComm = new SqlCommand(sqlStatment, sqlConn);
                    sqlComm.CommandType = CommandType.StoredProcedure;

                    SqlParameter sqlTaskTypeParam = new SqlParameter("@TaskType", SqlDbType.VarChar);
                    sqlTaskTypeParam.Value = TaskType;

                    SqlParameter sqlFileIndexParam = new SqlParameter("@FileIndex", SqlDbType.VarChar);
                    sqlFileIndexParam.Value = FileIndex;

                    SqlParameter sqlFileDataParam = new SqlParameter("@FileData", SqlDbType.Structured);
                    sqlFileDataParam.TypeName = "BatchFileData";
                    sqlFileDataParam.Value = dtFileData;

                    sqlComm.Parameters.Add(sqlTaskTypeParam);
                    sqlComm.Parameters.Add(sqlFileIndexParam);
                    sqlComm.Parameters.Add(sqlFileDataParam);

                    sqlComm.ExecuteNonQuery();
                }

                returnResult = true;

                return returnResult;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return returnResult;
            }
        }

        public void ClearVal()
        {
            FilteredTextList.Clear();
            tempDT.Clear();
            taskType = string.Empty;
            fileIndex = string.Empty;
        }

        public int GetMaxID(string FileIndex)
        {
            int maxID = 0;
            string responseMsg = string.Empty, UserSQL = string.Empty, PassSQL = string.Empty;

            try
            {
                GPFMaintenance.GPFMaintenance ObjWeb = new GPFMaintenance.GPFMaintenance();
                string connStr = string.Empty;

                ObjWeb.GetParameter1("Share", "DMSNew_CON", ref connStr, ref responseMsg);
                ObjWeb.GetParameter2("Share", "DMSNew_USER", ref UserSQL, ref PassSQL, ref responseMsg);
                connStr = string.Format("{0};User ID={1};Password={2}", connStr, UserSQL, PassSQL);

                using (SqlConnection sqlConn = new SqlConnection(connStr))
                {
                    sqlConn.Open();
                    string sqlStatment = "GetMaxIDBatchFile";
                    SqlCommand sqlComm = new SqlCommand(sqlStatment, sqlConn);
                    sqlComm.CommandType = CommandType.StoredProcedure;

                    SqlParameter sqlFileIndexParam = new SqlParameter("@FileIndex", SqlDbType.VarChar);
                    sqlFileIndexParam.Value = FileIndex;
                    sqlComm.Parameters.Add(sqlFileIndexParam);

                    sqlComm.Parameters.Add("@ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

                    sqlComm.ExecuteNonQuery();

                    maxID = (int)sqlComm.Parameters["@ReturnValue"].Value;
                }

                return maxID;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }

        public int GetUnit(int ID)
        {
            int IsUnit = 0;
            string responseMsg = string.Empty, UserSQL = string.Empty, PassSQL = string.Empty;

            try
            {
                GPFMaintenance.GPFMaintenance ObjWeb = new GPFMaintenance.GPFMaintenance();
                string connStr = string.Empty;

                ObjWeb.GetParameter1("Share", "DMSNew_CON", ref connStr, ref responseMsg);
                ObjWeb.GetParameter2("Share", "DMSNew_USER", ref UserSQL, ref PassSQL, ref responseMsg);
                connStr = string.Format("{0};User ID={1};Password={2}", connStr, UserSQL, PassSQL);

                using (SqlConnection sqlConn = new SqlConnection(connStr))
                {
                    sqlConn.Open();
                    string sqlStatment = "GetUnitBatchFile";
                    SqlCommand sqlComm = new SqlCommand(sqlStatment, sqlConn);
                    sqlComm.CommandType = CommandType.StoredProcedure;

                    SqlParameter sqID = new SqlParameter("@ID", SqlDbType.Int);
                    sqID.Value = ID;
                    sqlComm.Parameters.Add(sqID);

                    sqlComm.Parameters.Add("@ReturnValue", SqlDbType.Int).Direction = ParameterDirection.ReturnValue;

                    sqlComm.ExecuteNonQuery();

                    IsUnit = (int)sqlComm.Parameters["@ReturnValue"].Value;
                }

                return IsUnit;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
        }

        public List<IndexFileVerifyDtModel> VerifyData(DocumentBFModel item)
        {
            try
            {
                GetFileName_DMS previrw = new GetFileName_DMS();
                var client = new RestClient($"{_UrlAPI}api/DocumentBF/VerifyData");
                var request = new RestRequest();
                request.AddHeader("Content-Type", "application/json");
                var model = JsonConvert.SerializeObject(item);
                request.AddParameter("application/json", model, ParameterType.RequestBody);
                RestResponse response = client.ExecutePost(request);
                if (response.IsSuccessful)
                {
                    var data = JsonConvert.DeserializeObject<List<IndexFileVerifyDtModel>>(response.Content);
                    return data;
                }
                else
                {
                    return new List<IndexFileVerifyDtModel>();
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public VerifyMessageModel CheckIndexFileVerifyDt(DocumentBFModel item)
        {
            GetFileName_DMS previrw = new GetFileName_DMS();
            var client = new RestClient($"{_UrlAPI}api/DocumentBF/CheckIndexFileVerifyDt");
            var request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");
            var model = JsonConvert.SerializeObject(item);
            request.AddParameter("application/json", model, ParameterType.RequestBody);
            RestResponse response = client.ExecutePost(request);
            if (response.IsSuccessful)
            {
                var data = JsonConvert.DeserializeObject<VerifyMessageModel>(response.Content);
                return data;
            }
            return new VerifyMessageModel();
        }

        public VerifyMessageModel ImportDMS(DocumentBFModel data)
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

                _batch.UpdateIndexFileVerify(verDT);

                //------Write Log------
                log_content.AppendFormat(Environment.NewLine);
                log_content.AppendFormat("Excuted Query UpdateIndexFileVerify" + Environment.NewLine);
                log_content.AppendFormat(Environment.NewLine);

                var detail = ConvertToList<IndexFileVerifyDtModel>(_batch.GetTempIndexFileVerifyDT(data));
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
                            DataTable dtM = _batch.GetGPFMember(member);
                            if (dtM.Rows.Count == 0)
                            {
                                var memberlist = ConvertToList<GPFMemberModel>(_batch.Get_vw_MemberDetail(member));
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
                                        string PrefixId = _batch.GetPrefixID(pre);
                                        if (PrefixId == string.Empty)
                                        {
                                            _batch.Insert_Prefix(pre.NameTh);

                                            gov.Code = member_item.Code;
                                            string PrefixId2 = _batch.GetPrefixID(pre);
                                            member_item.PrefixID = (PrefixId2 != string.Empty) ? Convert.ToInt32(PrefixId2) : 0;
                                        }
                                        else
                                        {
                                            member_item.PrefixID = (PrefixId != string.Empty) ? Convert.ToInt32(PrefixId) : 0;
                                        }
                                    }

                                    if (member_item.EmployerName != string.Empty)
                                    {
                                        string GovId = _batch.GetGovID(gov);
                                        if (GovId == string.Empty)
                                        {
                                            _addgov.AddNewGovUnit(gov);

                                            gov.Code = member_item.Code;
                                            string GovId2 = _batch.GetGovID(gov);
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

                                    string ID = _batch.Insert_GPFMember(gpfmodel2);
                                    member_item.ID = (ID != string.Empty) ? Convert.ToInt32(ID) : 0;

                                    item.RefCaseID = (!String.IsNullOrEmpty(item.RefCaseID)) ? item.RefCaseID : string.Empty;
                                    if (Regex.Replace(item.RefCaseID, @"[\d-]", string.Empty) != string.Empty)
                                    {
                                        var doc = new Document();
                                        doc.CaseID = item.RefCaseID;
                                        doc.BatchRefNo = item.RefCaseID;
                                        doc.MemberID = member_item.ID;
                                        _batch.UpdateDocument(doc);

                                        DataTable dt = _batch.GetDocByCaseID(doc);
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

                                        int Year = GetCurrentYear();

                                        string RunningNumber = string.Empty;

                                        if (Year > 2565) RunningNumber = "00001";
                                        else RunningNumber = "60001";

                                        DateTime dt_year = Convert.ToDateTime(DateTime.Now, _cultureThInfo);
                                        string RUNNING_YEAR = dt_year.ToString("yy", _cultureThInfo);

                                        string RNumber = _batch.GetRunningNumber_BillPayment(Convert.ToInt32(RUNNING_YEAR), doc.TaskTypeID);
                                        string NewRunningNumber = (RNumber != string.Empty) ? String.Format("{0:D5}", Convert.ToInt32(RNumber) + 1)
                                                                    : String.Format("{0:D5}", Convert.ToInt32(RunningNumber));

                                        string B = "2";
                                        if (RNumber != string.Empty)
                                        {
                                            if (Convert.ToInt32(RNumber) < 60001)
                                            {
                                                string rnnCase = _batch.GetRunningCase(Convert.ToInt32(RUNNING_YEAR), doc.TaskTypeID);
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
                                        string docid = _batch.Exec_Insert_Document(doc);

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
                                    _batch.UpdateDocument(doc);

                                    DataTable dt = _batch.GetDocByCaseID(doc);
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

                                    int Year = GetCurrentYear();

                                    string RunningNumber = string.Empty;

                                    if (Year > 2565) RunningNumber = "00001";
                                    else RunningNumber = "60001";

                                    CultureInfo _cultureThInfo = new CultureInfo("th-TH");

                                    DateTime dt_year = Convert.ToDateTime(DateTime.Now, _cultureThInfo);
                                    string RUNNING_YEAR = dt_year.ToString("yy", _cultureThInfo);

                                    string RNumber = _batch.GetRunningNumber_BillPayment(Convert.ToInt32(RUNNING_YEAR), doc.TaskTypeID);
                                    string NewRunningNumber = (RNumber != string.Empty) ? String.Format("{0:D5}", Convert.ToInt32(RNumber) + 1)
                                                                : String.Format("{0:D5}", Convert.ToInt32(RunningNumber));



                                    string B = "2";
                                    if (RNumber != string.Empty)
                                    {
                                        if (Convert.ToInt32(RNumber) < 60001)
                                        {
                                            string rnnCase = _batch.GetRunningCase(Convert.ToInt32(RUNNING_YEAR), doc.TaskTypeID);
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
                                    string docid = _batch.Exec_Insert_Document(doc);
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

                                string GovId = _batch.GetGovID(gov);
                                if (GovId == string.Empty)
                                {
                                    _addgov.AddNewGovUnit(gov);

                                    string GovId2 = _batch.GetGovID(gov);
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
                                _batch.UpdateDocument(doc);

                                DataTable dt = _batch.GetDocByCaseID(doc);
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

                                int Year = GetCurrentYear();

                                string RunningNumber = string.Empty;

                                if (Year > 2565) RunningNumber = "00001";
                                else RunningNumber = "60001";

                                DateTime dt_year = Convert.ToDateTime(DateTime.Now, _cultureThInfo);
                                string RUNNING_YEAR = dt_year.ToString("yy", _cultureThInfo);

                                string RNumber = _batch.GetRunningNumber_BillPayment(Convert.ToInt32(RUNNING_YEAR), doc.TaskTypeID);
                                string NewRunningNumber = (RNumber != string.Empty) ? String.Format("{0:D5}", Convert.ToInt32(RNumber) + 1)
                                                            : String.Format("{0:D5}", Convert.ToInt32(RunningNumber));



                                string B = "2";
                                if (RNumber != string.Empty)
                                {
                                    if (Convert.ToInt32(RNumber) < 60001)
                                    {
                                        string rnnCase = _batch.GetRunningCase(Convert.ToInt32(RUNNING_YEAR), doc.TaskTypeID);
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
                                string docid = _batch.Exec_Insert_Document(doc);

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
                            string sttrid = _batch.Exec_Insert_AttachmentDt(attr);

                            int attrid = (sttrid != string.Empty) ? Convert.ToInt32(sttrid) : 0;

                            subitem.DocumentID = attr.DocumentID;
                            subitem.AttachmentDtID = (sttrid != string.Empty) ? Convert.ToInt32(sttrid) : 0;
                            _batch.UpdateIndexFileVerifyDt_With_AttachmentDtID(subitem);

                            var dtd = new DocumentDt();
                            dtd.AttachmentTypeID = subitem.AttachmentTypeID;
                            dtd.TaskType = subitem.TaskTypeID;
                            string getsq = _batch.CheckDocumentDtID(dtd);
                            int sqid = (getsq != string.Empty) ? Convert.ToInt32(getsq) : 0;
                            _batch.Exec_InsertAttachmentTypeDtInfo(attrid, subitem.AttachmentTypeID, sqid);

                            var f = new GetFileName_DMS();
                            f.DocID = attr.DocumentID;

                            var datalist = ConvertToList<GetFileName_DMS>(_batch.GetFileName(f));
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

                                    var client_b = new RestClient($"{_UrlPFILE}api/VerifyBatch/GetBatchFile");
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

                                                    var bytearr = _encrypt.EncryptFileData(fromFile, attr.DocumentID, 5);

                                                }

                                                var client = new RestClient($"{_UrlPFILE}api/ImportDocumentDMS/UploadFile");
                                                var request = new RestRequest();

                                                string[] files2 = Directory.GetFiles(Path.Combine($"{FilePath}{fileitem.DocumentID}_{5}_Temp\\"));

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
                                                        string[] Encryptfiles = Directory.GetFiles(Path.Combine($"{FilePath}{fileitem.DocumentID}_{5}_Temp\\"));
                                                        foreach (string fileNod in Encryptfiles)
                                                        {
                                                            var fileInfo = new System.IO.FileInfo(fileNod);
                                                            fileInfo.Delete();
                                                        }

                                                    }
                                                }
                                                Directory.Delete(Path.Combine($"{FilePath}{fileitem.DocumentID}_{5}_Temp"), true);
                                            }

                                        }
                                    }

                                    break;
                                }

                            }

                            _batch.UpdateIsProcess(subitem.ID, 1);
                        }
                    }
                }


                var VerSuccess = new IndexFileVerifyDtModel();
                VerSuccess.VerifyStatus = 4;
                VerSuccess.IndexFileVerifyID = data.ID;
                _batch.UpdateIndexFileVerify(VerSuccess);

                string YearNow_Del = "";
                DateTime today_Del = DateTime.Today;
                DateTime dateNow_Del = Convert.ToDateTime(today_Del, new CultureInfo("th-TH"));
                YearNow_Del = dateNow_Del.ToString("yyyy", new CultureInfo("th-TH"));
                var dt_file_Del = new FindBatchFile();
                dt_file_Del.IndexFileVerifyID = data.ID;
                dt_file_Del.SubFolder = $"{YearNow_Del}-Temp";

                var client_Del = new RestClient($"{_UrlPFILE}api/VerifyBatch/DeleteFile");
                var request_Del = new RestRequest();
                request_Del.AddHeader("Content-Type", "application/json");
                var model_Del = JsonConvert.SerializeObject(dt_file_Del);
                request_Del.AddParameter("application/json", model_Del, ParameterType.RequestBody);
                RestResponse response_Del = client_Del.ExecutePost(request_Del);
                if (response_Del.IsSuccessful)
                {

                }

                string path = Path.Combine($"{TempBatchFile}{dt_file_Del.SubFolder}\\{dt_file_Del.IndexFileVerifyID}");
                Directory.Delete(path, true);

                string pathBDS = Path.Combine($"{BDSFile}{dt_file_Del.SubFolder}\\{dt_file_Del.IndexFileVerifyID}");
                Directory.Delete(pathBDS, true);

                string pathDFOLE = Path.Combine($"{DFILEFile}{dt_file_Del.SubFolder}\\{dt_file_Del.IndexFileVerifyID}");
                Directory.Delete(pathDFOLE, true);

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

                return msg;
            }
            catch (Exception ex)
            {
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

                return new VerifyMessageModel();
            }
        }

        public VerifyMessageModel CancleImportDMS(DocumentBFModel item)
        {
            try
            {
                GetFileName_DMS previrw = new GetFileName_DMS();
                var client = new RestClient($"{_UrlAPI}api/DocumentBF/CancleImportDMS");
                var request = new RestRequest();
                request.AddHeader("Content-Type", "application/json");
                var model = JsonConvert.SerializeObject(item);
                request.AddParameter("application/json", model, ParameterType.RequestBody);
                RestResponse response = client.ExecutePost(request);
                if (response.IsSuccessful)
                {
                    var data = JsonConvert.DeserializeObject<VerifyMessageModel>(response.Content);
                    return data;
                }
                return new VerifyMessageModel();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void CountFile(DocumentBFModel item)
        {
            GetFileName_DMS previrw = new GetFileName_DMS();
            var client = new RestClient($"{_UrlAPI}api/DocumentBF/CountFile");
            var request = new RestRequest();
            request.AddHeader("Content-Type", "application/json");
            var model = JsonConvert.SerializeObject(item);
            request.AddParameter("application/json", model, ParameterType.RequestBody);
            RestResponse response = client.ExecutePost(request);
            if (response.IsSuccessful)
            {
                var data = JsonConvert.DeserializeObject<DocumentBFModel>(response.Content);
            }
        }
    }
}
