using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMSUpload_Helper.Models
{
    public class IndexFileVerifyDtModel
    {
        public int ID { get; set; }
        public int IndexFileVerifyID { get; set; }
        public string Filename { get; set; }
        public string DocName { get; set; }
        public string CitizenID { get; set; }
        public string MemberID { get; set; }
        public string RefCaseID { get; set; }
        public int CaseNumber { get; set; }
        public int FileNumber { get; set; }
        public string Remark { get; set; }
        public string FileIndex { get; set; }
        public string TaskTypeName { get; set; }
        public string RejectReason { get; set; }
        public int RejectReasonID { get; set; }
        public int VerifyStatus { get; set; }
        public int ImportType { get; set; }
        public int MainVerifyStatus { get; set; }
        public int TaskTypeID { get; set; }
        public int TaskSubTypeID { get; set; }
        public int AttachmentTypeID { get; set; }
        public int AllData { get; set; }
        public int AllPass { get; set; }
        public int AllMiss { get; set; }
        public int DocumentID { get; set; }
        public int IsNewCase { get; set; }
        public int AttachmentDtID { get; set; }
        public DateTime ImportDate { get; set; } = DateTime.MinValue;
        public string UnitCode { get; set; }
        public string GovUnitName { get; set; }
        public string UnitRefID { get; set; }
        public int IsUnit { get; set; }
    }
}
