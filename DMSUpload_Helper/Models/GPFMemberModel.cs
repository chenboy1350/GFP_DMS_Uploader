using System;
using System.Collections.Generic;

namespace DMSUpload_Helper.Models
{
    public class DataInToken
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UnitCode { get; set; }
        public string UnitName { get; set; }
        public string UnitMain { get; set; }
        public string UnitMainName { get; set; }
        public string Menu { get; set; }
        public DateTime ExpireDate { get; set; }
    }

    public class MemberResult
    {
        public string Message { get; set; }
        public List<GPFMemberModel> MemberList { get; set; }
    } 
    public class GPFMemberModel
    {
        public string Menu { get; set; }
        public string MemberStatus { get; set; }
        public int ID { get; set; }
        public int IsEdit { get; set; }
        public int MemberID { get; set; }
        public int UserID { get; set; }
        public string IDCard { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string RoleTypeName { get; set; } = string.Empty;
        public string GPFMemberID { get; set; } = string.Empty;
        public string CaseID { get; set; } = string.Empty;
        public int PrefixID { get; set; }
        public string PrefixName { get; set; } = string.Empty;
        public string GovUnitNameTh { get; set; } = string.Empty;
        public string FirstNameTh { get; set; } = string.Empty;
        public string FirstNameEn { get; set; } = string.Empty;
        public string LastNameTh { get; set; } = string.Empty;
        public string LastNameEn { get; set; } = string.Empty;
        public int GovUnitID { get; set; }
        public DateTime JoinGovDate { get; set; } = DateTime.MinValue;
        public string StrJoinGovDate { get; set; } = string.Empty;
        public DateTime JoinGPFDate { get; set; } = DateTime.MinValue;
        public string StrJoinGPFDate { get; set; } = string.Empty;
        public int IsDestroy { get; set; }
        public int IsActive { get; set; }
        public int CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string StrCreateDate { get; set; }
        public int UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public string StrUpdateDate { get; set; }
        public string EmployerName { get; set; }
        public string SendType { get; set; } = string.Empty;
        public string base64 { get; set; } = string.Empty;
        public int DocumentID { get; set; }
        public int Status { get; set; }
        public int TaskSub2TypeID { get; set; }

        public int MultipleMember { get; set; }
        public int IsSelectGPFMemberID { get; set; }
        public int DocumentStatusID { get; set; }
        public int DocumentSubStatusID { get; set; }
        public int TaskTypeID { get; set; }
        public int TaskSubTypeID { get; set; }
        public int MoreInfoID { get; set; }
        public int RoleTypeID { get; set; }
        public string FileGuidelinesBase64 { get; set; } = string.Empty;
        public string UnitMain { get; set; } = string.Empty;
        public string UnitMainName { get; set; } = string.Empty;
        public int IsInActive { get; set; }
        public int IsProcess { get; set; }
        public int IsWaitingMemberID { get; set; }

    }
}
