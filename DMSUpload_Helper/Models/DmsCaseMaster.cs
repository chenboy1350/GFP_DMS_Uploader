using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMSUpload_Helper.Models
{
    public class DmsCaseMaster
    {
        public string Doctype { get; set; } = string.Empty;
        public string CitizenID { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string MemberID { get; set; } = string.Empty;
        public string CaseID { get; set; } = string.Empty;
        public string UnitCode { get; set; } = string.Empty;
        public int InputType { get; set; }
    }

    public class Root
    {
        public List<RequestInfo> request_info { get; set; }
    }

    public class RequestInfo
    {
        public string CaseID { get; set; }
        public int InputTypeID { get; set; }
        public int SavingFund { get; set; }
        public string SourceSystem { get; set; }
        public int TaskTypeID { get; set; }
        public int NewCase { get; set; }
        public string ReferenceCaseID { get; set; }
        public string CitizenID { get; set; }
        public string Prefix { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MemberID { get; set; }
        public string GovUnitCode { get; set; }
        public string GovUnitName { get; set; }
        public string StartWork { get; set; }
        public string StartMember { get; set; }
        public string Remark { get; set; }
        public string Createby { get; set; }
        public DateTime CreateDate { get; set; }
        public string r_object_id { get; set; }
        public string FileName { get; set; }
        public string Boxno { get; set; }
        public string FolderNo { get; set; }
    }
}
