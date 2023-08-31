using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMSUpload_Helper.Models
{
    public class DocumentBFModel
    {
        public int ID { get; set; }
        public int hdUserID { get; set; }
        public int IsUnit { get; set; }
    }

    public class DocumentBF_IndexFileList_VM
    {
        public int ID { get; set; }
        public string NameTaskType { get; set; }
        public string StrImportDataDate { get; set; }
        public string StrImportData { get; set; }
        public string StrStatus { get; set; }
        public DateTime ImportDate { get; set; }
        public int VerityStatus { get; set; }
        public string TaskType { get; set; }
        public int ImportType { get; set; }
        public string DocName { get; set; }
        public string FileIndex { get; set; }
        public string txtStartDate { get; set; }
        public string txtEndDate { get; set; }
        public int ddlStatus { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public string Duration { get; set; }
        public TimeSpan TimeDuration { get; set; }
        public int IsUnit { get; set; }
        public int IsSuccess { get; set; }
        public int DocumentID { get; set; }
    }

    public class DocumetnBF_IndexFileListDT_item_VM
    {
        public int hdidTabelMain { get; set; }
        public string hdVerityStatus { get; set; }
        public int hdImportType { get; set; }
    }

    public class DocumentBF_IndexFileDTList_VM
    {
        public int ID { get; set; }
        public string StrStatus { get; set; }
        public string CitizenID { get; set; }
        public int MemberID { get; set; }
        public string Reference { get; set; }
        public string Remark { get; set; }
        public int VerityStatus { get; set; }
        public string RefCaseID { get; set; }

    }

    public class DocumentBF_Label_VM
    {
        public string Label1 { get; set; }
        public string Label2 { get; set; }
    }

    public class DocumetnBF_File_VM
    {
        public List<IFormFile> multifile { get; set; }
        public IFormFile file { get; set; }
        public string name { get; set; }
        public int hdUserID { get; set; }
        public string TasktypeName { get; set; }
        public int IndexFileVerifyID { get; set; }
        public string Filename { get; set; }
        public string DocName { get; set; }
        public string CitizenID { get; set; }
        public string MemberID { get; set; }
        public string RefCaseID { get; set; }
        public int CaseNumber { get; set; }
        public int FileNumber { get; set; }
        public string FileIndex { get; set; }
        public int rdformat { get; set; }
        public TimeSpan Ducation { get; set; }
        public int rdUnit { get; set; }
        public string UnitCode { get; set; }
        public string GovUnitName { get; set; }
        public string UnitRefID { get; set; }
    }

    public class DocumetnBF_File_VM2
    {
        public string name { get; set; }
        public int hdUserID { get; set; }
    }
}
