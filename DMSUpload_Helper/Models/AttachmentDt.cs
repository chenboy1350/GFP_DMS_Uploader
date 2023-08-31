using System;

namespace DMSUpload_Helper.Models
{
    public class AttachmentDt
    {
        public int ID { get; set; }
        public int DocumentDtID { get; set; }
        public int DocumentID { get; set; }
        public int MoreInfoDtID { get; set; }
        public int AttachmentCount { get; set; }
        public string PathFile { get; set; }
        public string FileName { get; set; }
        public string DocumentName { get; set; }
        public string FileSize { get; set; }


    }
    public class AttachmentTypeDtInfo
    {
        public int ID { get; set; }
        public int AttachmentDtID { get; set; }
        public int AttachmentTypeID { get; set; }
        public int Sq { get; set; }
        public int IsMultiple { get; set; }
        public string PageNumber { get; set; }
        public int SubSq { get; set; }
        public string Remark { get; set; }


    }
    public class MoreInfo
    {
        public int ID { get; set; }
        public string CaseID { get; set; }
        public DateTime SubmitDate { get; set; }


    }
    public class MoreInfoDt
    {
        public int ID { get; set; }
        public int MoreInfoID { get; set; }
        public int AttachmentTypeID { get; set; }

    }
    public class MoreInfoAttachmentDt
    {
        public int ID { get; set; }
        public int DocumentDtID { get; set; }
        public int MoreInfoDtID { get; set; }
        public string PathFile { get; set; }
        public string FileName { get; set; }
        public string DocumentName { get; set; }
        public string FileSize { get; set; }


    }

}
