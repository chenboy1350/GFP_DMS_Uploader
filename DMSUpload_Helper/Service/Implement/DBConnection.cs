using DMSUpload_Helper.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMSUpload_Helper.Service.Implement
{
    public class DBConnection : IDBConect
    {
        public string GetConnection()
        {
            string responseMsg = string.Empty, UserSQL = string.Empty, PassSQL = string.Empty;

            GPFMaintenance.GPFMaintenance ObjWeb = new GPFMaintenance.GPFMaintenance();
            string connStr = string.Empty;

            ObjWeb.GetParameter1("Share", "DMSNew_CON", ref connStr, ref responseMsg);
            ObjWeb.GetParameter2("Share", "DMSNew_USER", ref UserSQL, ref PassSQL, ref responseMsg);
            connStr = string.Format("{0};User ID={1};Password={2}", connStr, UserSQL, PassSQL);

            return connStr;
        }
    }
}
