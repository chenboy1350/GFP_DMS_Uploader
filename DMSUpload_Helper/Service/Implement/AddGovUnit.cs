using DMSUpload_Helper.Library;
using DMSUpload_Helper.Models;
using DMSUpload_Helper.Service.Interface;
using System.Data;

namespace DMSUpload_Helper.Service.Implement
{
    public class AddGovUnit : IAddGovUnit
    {
        private readonly DMS_IAddGovUnit _addGov;
        public AddGovUnit(DMS_IAddGovUnit addGov)
        {
            _addGov = addGov;
        }

        public void AddNewGovUnit(GovUnitModel data)
        {
            data.IsActive = 1;
            _addGov.Insert_GovUnit(data);
        }
    }

    public class DMS_AddGovUnit : DMS_IAddGovUnit
    {
        ConnectDB conn = new ConnectDB();
        DataTable dt = new DataTable();

        string SQL;
        string _datasource;
        private string responseMsg = string.Empty;
        private string UserSQL = string.Empty;
        private string PassSQL = string.Empty;

        public IDbDataParameter BindParameter(string parameterName, object value)
        {
            return new ClassParamsAdd(parameterName, value);
        }

        public string Insert_GovUnit(GovUnitModel data)
        {
            GPFMaintenance.GPFMaintenance ObjWeb = new GPFMaintenance.GPFMaintenance();
            string connStr = string.Empty;

            ObjWeb.GetParameter1("Share", "DMSNew_CON", ref connStr, ref responseMsg);
            ObjWeb.GetParameter2("Share", "DMSNew_USER", ref UserSQL, ref PassSQL, ref responseMsg);
            _datasource = string.Format("{0};User ID={1};Password={2}", connStr, UserSQL, PassSQL);

            string UserID = "";

            IDataParameter[] iDP = new IDataParameter[4];

            SQL = @"INSERT INTO [mt].[GovUnit] ([Code] ,[GovUnitNameTh], [IsActive], [GovUnitMain])

                                                VALUES ( @Code, 
                                                         @GovUnitNameTh, 
                                                         @IsActive,
                                                         @UnitMain )";

            iDP[0] = BindParameter("@Code", data.Code);
            iDP[1] = BindParameter("@GovUnitNameTh", data.GovUnitNameTh);
            iDP[2] = BindParameter("@IsActive", data.IsActive);
            iDP[3] = BindParameter("@UnitMain", data.GovUnitMain);

            dt = conn.ExecuteReaderWithParams(SQL, iDP, _datasource);

            if (dt.Rows.Count > 0)
            {
                UserID = dt.Rows[0][0].ToString();
            }

            return UserID;
        }
    }

}
