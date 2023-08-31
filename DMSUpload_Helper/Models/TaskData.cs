using System;

namespace DMSUpload_Helper.Models
{
    public class TaskData
    {
        public int TaskTypeID { get; set; }
        public int DocumentID { get; set; }
        public int TaskAttachmentTypeID { get; set; }
        public string TaskTypeCode { get; set; }
        public string TaskTypeFullName { get; set; }
        public string TaskTypeInitialName { get; set; }

        public int TaskSubTypeID { get; set; }
        public string TaskSubTypeCode { get; set; }
        public string TaskSubTypeFullName { get; set; }
        public string TaskSubTypeInitialName { get; set; }

        public int TaskSubType2ID { get; set; }
        public string TaskSubType2Code { get; set; }
        public string TaskSubType2FullName { get; set; }
        public string TaskSubType2InitialName { get; set; }
        public string GPFMemberID { get; set; }
        public int MemberID { get; set; }


    }

    public class AttachmentType
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string FullName { get; set; }
        public string InitialName { get; set; }
        public string StrActionDate { get; set; }
        public int IsSensitive { get; set; }
        public int IsActive { get; set; }
        public int DocumentID { get; set; }
        public int AttachmentCount { get; set; }
        public int TaskSubTypeID { get; set; }
        public int TaskSubType2ID { get; set; }
        public int AttachmentTypeID { get; set; }
        public int MoreInfoDtID { get; set; }
        public int MoreInfoID { get; set; }
        public int IsRequire { get; set; }
        public DateTime ActionDate { get; set; }
        public DateTime TransferDate { get; set; }
        public DateTime SubmitDate { get; set; }


    }

    public class TrackStatusSearch
    {
        public string CitizenID { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string StrStartDate { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public string StrEndDate { get; set; } = string.Empty;
        public DateTime EndDate { get; set; }
        public string Menu { get; set; } = string.Empty;

        //-----palm------
        public string Department { get; set; } = string.Empty;
        public string UnitMain { get; set; } = string.Empty;
        public int Status { get; set; }
        public int UserID { get; set; }
        //-----palm------
    }
}
