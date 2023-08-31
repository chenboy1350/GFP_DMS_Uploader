using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMSUpload_Helper.Models
{
    public class SearchdataDocument
    {
        public int InputTypeID { get; set; }
        public string msg { get; set; } = string.Empty;
        public int ID { get; set; }
        public int TasktypeID { get; set; }
        public string CitizenID { get; set; }
        public string MemberID { get; set; }
        public int MemberID2 { get; set; }
        public string CaseID { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public int InputType { get; set; }
        public int GPFMemberID { get; set; }
        public int DocumentStatusID { get; set; }
        public int DocumentSubStatusID { get; set; }
        public int IsPreviousDMS { get; set; }
        public string TypeDms { get; set; }
        public string GovUnitCode { get; set; } = string.Empty;

        public DateTime CreateDate { get; set; }
        public string strCreateDate { get; set; }
        public string FirstNameTh { get; set; } = string.Empty;
        public string LastNameTh { get; set; } = string.Empty;
        public string PrefixName { get; set; }
        public string InputTypeName { get; set; }
        public string RefCaseID { get; set; }
        public string Boxno { get; set; }
        public string FolderNo { get; set; }
        public int CurrentYear { get; set; }

    }

}
