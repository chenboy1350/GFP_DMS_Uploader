using System;

namespace DMSUpload_Helper.Models
{
    public class Document
    {
        public int AttachmentTypeID { get; set; }
        public int DocumentID { get; set; }
        public int ID { get; set; }
        public int RunningCase { get; set; }
        public int InputTypeID { get; set; }
        public int TaskTypeID { get; set; }
        public int TaskSubTypeID { get; set; }
        public int TaskSub2TypeID { get; set; }
        public string GPFMemberID { get; set; }
        public int OfficerID { get; set; }
        public int DocumentStatusID { get; set; }
        public int DocumentSubStatusID { get; set; }
        public int IsDestroy { get; set; }
        public int IsArchive { get; set; }
        public string CaseID { get; set; }
        public int Status { get; set; }
        public int MemberID { get; set; }
        public int CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public int UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public int RunningYear { get; set; }
        public int RunningNumber { get; set; }

        public int GPF_UpdateBy { get; set; }
        public int trackid { get; set; }
        public DateTime GPF_UpdateDate { get; set; }

        public int TransferStatus { get; set; }
        public DateTime TransferDate { get; set; }
        public DateTime PaidDate { get; set; }
        public DateTime FinishDate { get; set; }
        public string Remark { get; set; }
        public int IsNewCase { get; set; }
        public string RefCaseID { get; set; }
        public int BoxID { get; set; }
        public int FolderID { get; set; }
        public int GovUnitID { get; set; }
        public int DocType { get; set; }
        public int IsPreviousDMS { get; set; }

        public int IsSavingFund { get; set; }
        public string SourceSystem { get; set; }
        public string APIPrefix { get; set; }
        public string APIFirstname { get; set; }
        public string APILastname { get; set; }
        public string DummyNumber { get; set; }
        public string EDocumentNumber { get; set; }
        public DateTime ESendDate { get; set; }
        public string EFrom { get; set; }
        public string ESendBy { get; set; }
        public string ERef { get; set; }
        public string EAttachInfo { get; set; }
        public string ERemark { get; set; }
        public string BatchRefNo { get; set; }
        public DateTime SubmitDate { get; set; }

        public int IsInActive { get; set; }
        public int IsProcess { get; set; }
        public int IsWaitingMemberID { get; set; }
    }
}
