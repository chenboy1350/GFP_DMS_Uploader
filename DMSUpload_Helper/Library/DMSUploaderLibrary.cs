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
        public IDBConect _dBConect;
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
            _dBConect = new DBConnection();

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
            string responseMsg = string.Empty, UserSQL = string.Empty, PassSQL = string.Empty;

            try
            {
                GPFDBService.GPFDBService ObjWeb2 = new GPFDBService.GPFDBService();
                if (ObjWeb2.IsAuthenticated(Username, Password))
                {
                    GPFMaintenance.GPFMaintenance ObjWeb = new GPFMaintenance.GPFMaintenance();
                    string connStr = string.Empty;

                    ObjWeb.GetParameter1("Share", "DMSNew_CON", ref connStr, ref responseMsg);
                    ObjWeb.GetParameter2("Share", "DMSNew_USER", ref UserSQL, ref PassSQL, ref responseMsg);
                    connStr = string.Format("{0};User ID={1};Password={2}", connStr, UserSQL, PassSQL);

                    using (SqlConnection sqlConn = new SqlConnection(connStr))
                    {
                        sqlConn.Open();
                        string sqlStatment = "CheckUserUploadBatch";
                        SqlCommand sqlComm = new SqlCommand(sqlStatment, sqlConn);
                        sqlComm.CommandType = CommandType.StoredProcedure;

                        SqlParameter sqlUserParam = new SqlParameter("@Username", SqlDbType.VarChar);
                        sqlUserParam.Value = Username;
                        sqlComm.Parameters.Add(sqlUserParam);

                        DataTable dt = new DataTable();
                        dt.Load(sqlComm.ExecuteReader());

                        var result = ConvertToList<UserAuthenModel>(dt).FirstOrDefault();

                        if (result != null)
                        {
                            username = result.Username;
                            department = result.Department;
                            authority = result.Authority;
                            hdUserID = result.ID;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
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

        public void StreamCopyTo(string inputFilePath, string outputFilePath, string fileName)
        {
            try
            {
                int bufferSize = 1024 * 1024;
                using(FileStream StreamRead = new FileStream(inputFilePath, FileMode.Open, FileAccess.Read))
                {
                    using (FileStream StreamWrite = new FileStream(Path.Combine(outputFilePath, fileName), FileMode.Create, FileAccess.Write))
                    {
                        byte[] bytes = new byte[bufferSize];
                        int bytesRead = 0;

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

        public void FileIOCopyTo(string inputFilePath, string outputFilePath, string fileName)
        {
            try
            {
                File.Copy(inputFilePath, Path.Combine(outputFilePath, fileName), true);
            }
            catch (Exception ex)
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

            try
            {
                string connStr = _dBConect.GetConnection();

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

            try
            {
                string connStr = _dBConect.GetConnection();

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

            try
            {
                string connStr = _dBConect.GetConnection();

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
