using Microsoft.AspNetCore.Http;
using System;

namespace DMSUpload_Helper.Models
{
    public class ImportDocumentDMS_VM
    {
        public int ID { get; set; }
        public int InputTypeID { get; set; }
        public int TaskTypeID { get; set; }
        public int TaskSubTypeID { get; set; }
        public int TaskSub2TypeID { get; set; }
        public int GPFMemberID { get; set; }
        public int OfficerID { get; set; }
        public int DocumentStatusID { get; set; }
        public int DocumentSubStatusID { get; set; }
        public int IsDestroy { get; set; }
        public int IsArchive { get; set; }
        public string CaseID { get; set; }
        public int CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public int UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public int IsSelectGPFMemberID { get; set; }
        public int Status { get; set; }
        public int RunningYear { get; set; }
        public int RunningNumber { get; set; }
        public int GPFUpdateBy { get; set; }
        public DateTime GPFUpdateDate { get; set; }
        public DateTime GPFPaymentDate { get; set; }
        public int TransferStatus { get; set; }
        public DateTime TransferDate { get; set; }
        public DateTime PaidDate { get; set; }
        public DateTime FinishDate { get; set; }
        public int IsNewCase { get; set; }
        public string Remark { get; set; }
        public string RefCaseID { get; set; }
        public int Year { get; set; }
        public int BoxID { get; set; }
        public int FolderID { get; set; }
        public int GovUnitID { get; set; }
        public string GovUnitCode { get; set; }
        public string GovUnitName { get; set; }
        public string PrefixName { get; set; }
        public int DocType { get; set; }

        public int condition { get; set; }
        public string message { get; set; }

        public string strUpdateBy { get; set; }
        public string strUpdateDate { get; set; }
        public string strStatusName { get; set; }
        public int CheckcaseSq { get; set; }
        public int checkmode { get; set; }
        public int hdConfirmSaraban { get; set; }
        public int checkvalNote { get; set; }
        public DateTime SubmitDate { get; set; }
        public int IsInActive { get; set; }
        public string CitizenID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int MemberID { get; set; }
        public string StartWork { get; set; }
        public string StartMember { get; set; }
        public string Prefix { get; set; }
        public DateTime JoinGovDate { get; set; }
        public DateTime JoinGPFDate { get; set; }
        public int hdoldDms1 { get; set; }
        public int hdoldDms2 { get; set; }
    }

    public class ResponseMessage
    {
        public int condition { get; set; }
        public string message { get; set; }
    }

    public class ImportDocumentDMS_Update
    {
        public int ID { get; set; }

        public string txtStatusdocument { get; set; }
        public string txtCaseNumber { get; set; }
        public int ddlTaskType { get; set; }
        public int ddlTaskSubType { get; set; }
        public int ddlJob { get; set; }
        public string txtCaseother { get; set; }
        public string txtCitizen { get; set; }
        public string txtFullname { get; set; }
        public string txtMemberID { get; set; }
        public string txtCodeagency { get; set; }
        public string txtNameagency { get; set; }
        public int ddlBox { get; set; }
        public int ddlFolder { get; set; }
        public string txtDate1 { get; set; }
        public string txtDate2 { get; set; }
        public string txtRemark { get; set; }
        public string txtdocstatus { get; set; }
        public string txtUpdateby { get; set; }
        public string txtUpdatedate { get; set; }
        public int UserID { get; set; }

        public int hdUserID { get; set; }
        public int hdDocumentID { get; set; }
        public int hdStatus { get; set; }
        public string txtbox { get; set; }
        public string txtfolder { get; set; }
        public int hdnewbox { get; set; }
        public int hdnewfolder { get; set; }
        public string txtFirstname { get; set; }
        public string txtLastname { get; set; }

        public int TasksubID { get; set; }
        public string TasksubName { get; set; }
        public int DocumentStatus { get; set; }
        public int IsSavingFund { get; set; }


        public string txtEdocnumber { get; set; }
        public string txtEsenddate { get; set; }
        public string txtEform { get; set; }
        public string txtEsendby { get; set; }
        public string txtEref { get; set; }
        public string txtEattinfo { get; set; }

        public string txtEremark { get; set; }

        public string EDocumentNumber { get; set; }
        public DateTime ESendDate { get; set; }
        public string ESendBy { get; set; }
        public string ERef { get; set; }
        public string EAttachInfo { get; set; }
        public string ERemark { get; set; }
        public string EFrom { get; set; }
        public int hdTaskType { get; set; }
        public int hdIsNewCase { get; set; }
        public int hdTaskSubTypeID { get; set; }
        public int hdConfirmSaraban { get; set; }
        public int checkvalNote { get; set; }
        public string Message { get; set; }
        public int rdActive { get; set; }
        public int IsInActive { get; set; }
        public int hdoldDms1 { get; set; }
    }

    public class ImportDocumentDMS_Detail_VM
    {
        public int ID { get; set; }
        // 13/12/65
        public int gpfID { get; set; }
        public int UserID { get; set; }
        public string CreateBy { get; set; }
        public string UpdateBy { get; set; }
        public string StrID { get; set; }
        public string CitizenID { get; set; }
        public string StrCitizenID { get; set; }
        public DateTime Date1 { get; set; }
        public DateTime Date2 { get; set; }
        public string StrDate1 { get; set; } = string.Empty;
        public string StrDate2 { get; set; } = string.Empty;

        public int MemberID { get; set; }
        public int TaskTypeID { get; set; }
        public int TaskSubTypeID { get; set; }
        public string InputTypeName { get; set; }
        public string GPFMemberID { get; set; }
        public string Codeagency { get; set; }
        public string Nameagency { get; set; }
        public int BoxID { get; set; }
        public int FolderID { get; set; }
        public string DocumentStatusName { get; set; }
        public string TitleName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmployerName { get; set; }
        public string Code { get; set; }
        public string FullName { get; set; }
        public string CaseID { get; set; }
        public int IsNewCase { get; set; }
        public string RefCaseID { get; set; }
        public string TitleName2 { get; set; }
        public string FirstName2 { get; set; }
        public string LastName2 { get; set; }
        public string strUpdateBy { get; set; }
        public string Remark { get; set; }

        public DateTime UpdateDate { get; set; }
        public string strUpdateDate { get; set; }
        public int Status { get; set; }
        public string txtbox { get; set; }
        public string txtfolder { get; set; }
        public string txtFirstname { get; set; }
        public string txtLastname { get; set; }
        public int DocumentStatus { get; set; }
        public int IsSavingFund { get; set; }

        public string txtEdocnumber { get; set; }
        public string txtEsenddate { get; set; }
        public string txtEform { get; set; }
        public string txtEsendby { get; set; }
        public string txtEref { get; set; }
        public string txtEattinfo { get; set; }

        public string txtEremark { get; set; }

        public string EDocumentNumber { get; set; }
        public DateTime ESendDate { get; set; }
        public string ESendBy { get; set; }
        public string ERef { get; set; }
        public string EAttachInfo { get; set; }
        public string ERemark { get; set; }
        public string EFrom { get; set; }
        public int IsInActive { get; set; }

    }

    public class GPFMember_Model
    {
        public int ID { get; set; }
        public string IDCard { get; set; }
        public string GPFMemberID { get; set; }
        public int PrefixID { get; set; }
        public string FirstNameTh { get; set; }
        public string FirstNameEn { get; set; }
        public string LastNameTh { get; set; }
        public string LastNameEn { get; set; }
        public int GovUnitID { get; set; }
        public DateTime JoinGovDate { get; set; }
        public DateTime JoinGPFDate { get; set; }
        public int IsDestroy { get; set; }
        public int IsActive { get; set; }
        public int CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public int UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public string MemberStatus { get; set; }


    }

    public class GovUnit_Model
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string GovUnitNameTh { get; set; }
        public int IsActive { get; set; }
        public int CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public int UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }
        public string GovUnitMain { get; set; }

    }

    public class Prefix_Model
    {
        public int ID { get; set; }
        public string NameTh { get; set; }
        public string NameEn { get; set; }
        public int IsActive { get; set; }
        public int CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public int UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }

    }


    public class vw_MemberDetail_Model
    {
        public string CitizenID { get; set; }
        public int MemberID { get; set; }
        public string TitleName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmployerName { get; set; }
        public string Code { get; set; }
        public DateTime CommencementDate { get; set; }
        public DateTime JoinedFundDate { get; set; }

    }

    public class TaskTypeddl
    {
        public int TaskID { get; set; }
        public string TaskNameTh { get; set; }
    }
    public class ImportDocumentDMS_Citizen
    {
        public int ID { get; set; }
        public string CitizenID { get; set; }
        public string CitizenID2 { get; set; }
        public string FullName { get; set; }
        public string Codeagency { get; set; }
        public string Nameagency { get; set; }
        public DateTime Date1 { get; set; }
        public DateTime Date2 { get; set; }
        public string Datestr1 { get; set; }
        public string Datestr2 { get; set; }
        public int MemberID { get; set; }
        public string Strcitizen { get; set; }
        public string Strmember { get; set; }
        public int TaskTypeID { get; set; }
    }
    public class ImportDocumentDMS_Citizen_Search
    {
        public int ID { get; set; }
        public string Citizen { get; set; }
        public string Word { get; set; }
        public string strCitizen { get; set; }
        public string CitizenID { get; set; }
    }

    public class Box_New_VM
    {
        public int ID { get; set; }
        public string CodeName { get; set; }
    }
    public class Folder_New_VM
    {
        public int ID { get; set; }
        public string CodeName { get; set; }
    }

    public class Box_Model
    {
        public int ID { get; set; }
        public string Code { get; set; }

        public int ddlTaskType { get; set; }
        public int UserID { get; set; }

        public int TaskTypeID { get; set; }
        public string Description { get; set; }
        public int IsActive { get; set; }
        public int BoxID { get; set; }

        public int condition { get; set; }
        public string message { get; set; }
        public string year_now { get; set; }
    }

    public class Folder_Model
    {
        public int ID { get; set; }
        public string Code { get; set; }

        public int ddlBox { get; set; }
        public int UserID { get; set; }

        public int BoxID { get; set; }
        public string Description { get; set; }
        public int IsActive { get; set; }
        public int FolderID { get; set; }

        public int condition { get; set; }
        public string message { get; set; }
        public string hdnewboxcode { get; set; }
        public int ddlTaskType { get; set; }
    }

    public class AttachmentType_Model
    {
        public int ID { get; set; }
        public string AttachmentTypeName { get; set; }

        public int ddlTaskType { get; set; }
        public int TaskTypeID { get; set; }
        public int DataType { get; set; }
        public int TaskSubTypeID { get; set; }
    }

    public class AttachmentType_Update
    {
        public int DocumentID { get; set; }
        public int ddlAttachmentType { get; set; }
        public string txtSq { get; set; }
        public int hdAttachmentTypeDtInfo { get; set; }

        public int ID { get; set; }
        public int AttachmentDtID { get; set; }
        public int AttachmentTypeID { get; set; }
        public int Sq { get; set; }
        public int SubSq { get; set; }
        public string txtRemarkincard { get; set; }
        public string Remark { get; set; }
    }

    public class ImportDocumentDMS_Codeagency
    {
        public int MemberID { get; set; }
        public string Codeagency { get; set; }
        public string Nameagency { get; set; }

    }

    public class Case_Auto
    {
        public int ID { get; set; }
        public string CaseID { get; set; }
        public int TaskTypeID { get; set; }
        public string CitizenID { get; set; }

        public string Doctype { get; set; }
        public string FullName { get; set; }
        public string TitleName { get; set; }
        public string FirstNameTh { get; set; }
        public string LastNameTh { get; set; }
        public string Codeagency { get; set; }
        public string Nameagency { get; set; }
        public DateTime Date1 { get; set; }
        public DateTime Date2 { get; set; }
        public string Datestr1 { get; set; }
        public string Datestr2 { get; set; }
        public string MemberID { get; set; }
        public string StrDate1 { get; set; } = string.Empty;
        public string StrDate2 { get; set; } = string.Empty;

        public int condition { get; set; }
        public string message { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int IsPreviousDMS { get; set; }
        public string APIPrefix { get; set; }
        public string APIFirstname { get; set; }
        public string APILastname { get; set; }
    }

    public class AttachmentDt_Medel
    {
        public int ID { get; set; }
        public int DocumentID { get; set; }
        public int DocumentDtID { get; set; }
        public string PathFile { get; set; }
        public string FileName { get; set; }
        public string FileSize { get; set; }
        public string FileExt { get; set; }
        public int AttachmentTypeDtInfoID { get; set; }
        public int AttachmentTypeID { get; set; }
        public int Sq { get; set; }
        public int IsMultiple { get; set; }
        public int PageNumber { get; set; }
        public string Remark { get; set; }
        public int SubSq { get; set; }
    }

    public class AttachmentTypeDtInfo_Medel
    {
        public int ID { get; set; }
        public int AttachmentDtID { get; set; }
        public int AttachmentTypeID { get; set; }
        public string AttachmentTypeName { get; set; }
        public int Sq { get; set; }
        public int IsMultiple { get; set; }
        public string PageNumber { get; set; }
        public string Remark { get; set; }
        public int SubSq { get; set; }
    }


    public class UploadFile_Model
    {
        public int ID { get; set; }
        public int DocumentID { get; set; }
        public string FileName { get; set; }
        public string PathFile { get; set; }
        public string FileSize { get; set; }
        public byte[] Byte { get; set; }
        public IFormFile File { get; set; }
        public string FileExt { get; set; }

        public int condition { get; set; }
        public string message { get; set; }
    }

    public class FileSetting_Model
    {
        public int ID { get; set; }
        public string FileType { get; set; }
        public int FileSize { get; set; }

        public int condition { get; set; }
        public string message { get; set; }
    }

    public class GetFileName_DMS
    {
        public int DocID { get; set; }
        public int AttInfoID { get; set; }
        public string Base64 { get; set; }
        public string FileName { get; set; }
        public int DocumentID { get; set; }
        public int AttchmentID { get; set; }
        public int Sq { get; set; }
        public int AttchmentType { get; set; }
        public int IsMultiple { get; set; } = 0;
        public int Year { get; set; }
        public string FileExt { get; set; }
        public string PageNumber { get; set; }
        public string Code { get; set; }
        public string CitizenID { get; set; }
        public string DocumentName { get; set; }
        public int InputTypeID { get; set; }
        public int TaskTypeID { get; set; }

    }

    public class DeleteFileModel
    {
        public int AttchmentID { get; set; }
        public int DocumentID { get; set; }
        public string FileName { get; set; }
        public string FileExt { get; set; }
        public string Year { get; set; }
        public int AttachmentTypeDtInfoDtID { get; set; }

        public int condition { get; set; }
        public string message { get; set; }
    }

    public class AttachmentTypeDtInfoDtID_Model
    {
        public int ID { get; set; }
        public int DocumentID { get; set; }
        public int AttachmentDtID { get; set; }
        public int AttachmentTypeDtInfoID { get; set; }
        public int AttachmentTypeID { get; set; }
        public int Sq { get; set; }
        public string PageNumber { get; set; }
        public int IsMultiple { get; set; }

        public int condition { get; set; }
        public string message { get; set; }
        public string Remark2 { get; set; }
        public int ddlAttachmentType { get; set; }
        public string txtSq_Add { get; set; }
        public int ddlTaskSubType { get; set; }
    }  
    
    public class BinddataNew_Citizen
    {
        public string StrCitizenID { get; set; }
        public int ID { get; set; }
        public int UserID { get; set; }
        public string CreateBy { get; set; }
        public string UpdateBy { get; set; }
        public string StrID { get; set; }
        public string CitizenID { get; set; }
        public DateTime Date1 { get; set; }
        public DateTime Date2 { get; set; }
        public string StrDate1 { get; set; } = string.Empty;
        public string StrDate2 { get; set; } = string.Empty;

        public string MemberID { get; set; }
        public int intMemberID { get; set; }
        public string TitleName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmployerName { get; set; }
        public string Code { get; set; }
        public string FullName { get; set; }
        public string hdmodalcitizen { get; set; }
        public int hdmodalmember { get; set; }
        public int hdcaseotherID { get; set; }
        public int hdcaseothermemID { get; set; }
        public string strMemberID { get; set; }
        public string CaseID { get; set; }
        public int hdIsolddms { get; set; }
        public string Prefix { get; set; }
        public string Empname { get; set; }
        public string EmpCode { get; set; }
       public string StrCommentDate { get; set; }
        public string StrJoinedDate { get;set; }
    }



    public class GetListCitizenNew_VM
    {
        public int ID { get; set; }
        public int GPFmemberId { get; set; }
        public string CitizenID { get; set; }
        public string MemberID { get; set; }
        public string Prefix { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Empname { get; set; }
        public string EmpCode { get; set; }
        public DateTime CommentcementDate { get; set; }
        public DateTime JoinedDate { get; set; }
        public string hdcitizenvalNew { get; set; }
        public string StrCommentDate { get; set; }
        public string StrJoinedDate { get; set; }
        public int Isactive { get; set; }
        public string Strisactive { get; set; }
        public int hdCaseotherNew { get; set; }
        public string CaseID { get; set; }

        public string hdcitizenvalNew2 { get; set; }
        public string StrMemberID { get; set; }
        public int TasktypeID { get; set; }
        public string MemberStatus { get; set; }
        public int IsNewCase { get; set; }
        public string StrIsNewCase { get; set; }
        public string RefCaseID { get; set; }
        public int IsoldDMS { get; set; }
        public string Message { get; set; }
        public string GovUnitName { get; set; }
        public string GovUnitCode { get; set; }
        public string CommencementDate { get; set; }
        public string JoinedFundDate { get; set; }
        public Int64 db_type { get; set; }
    }

    public class ListAllname_VM
    {
        public int ID { get; set; }
        public string txtFirstname { get; set; }
        public string txtLastname { get; set; }
        public string StrFirstName { get; set; }
        public string StrLastName { get; set; }
        public int MemberID { get; set; }
        public string FirstName { get; set; }
    }

    public class GetListAllnameNew_VM
    {
        public int ID { get; set; }
        public int GPFmemberId { get; set; }
        public string CitizenID { get; set; }
        public int MemberID { get; set; }
        public string Prefix { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Empname { get; set; }
        public string EmpCode { get; set; }
        public DateTime CommentcementDate { get; set; }
        public DateTime JoinedDate { get; set; }
        public string hdcitizenvalNew { get; set; }
        public string StrCommentDate { get; set; }
        public string StrJoinedDate { get; set; }
        public int Isactive { get; set; }
        public string Strisactive { get; set; }
        public int hdCaseotherNew { get; set; }
        public int hdFullName { get; set; }
        public string hdFirstName { get; set; }
        public string hdLastName { get; set; }

    }

    public class BinddataNew_Fullname
    {
        public string StrCitizenID { get; set; }
        public int ID { get; set; }
        public int UserID { get; set; }
        public string CreateBy { get; set; }
        public string UpdateBy { get; set; }
        public string StrID { get; set; }
        public string CitizenID { get; set; }
        public DateTime Date1 { get; set; }
        public DateTime Date2 { get; set; }
        public string StrDate1 { get; set; } = string.Empty;
        public string StrDate2 { get; set; } = string.Empty;

        public int MemberID { get; set; }
        public string TitleName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmployerName { get; set; }
        public string Code { get; set; }
        public string FullName { get; set; }

        public string hdmodalcitizen { get; set; }
        public int hdmodalmember { get; set; }
        public int hdcaseotherID { get; set; }
        public int hdcaseothermemID { get; set; }
        public int hdmodalmemberfullname { get; set; }
        public string CaseID { get; set; }
        public string strMemberID { get; set; }
    }

    public class BinddataNew_Employer
    {
        public int ID { get; set; }
        public int GPFmemberId { get; set; }
        public string CitizenID { get; set; }
        public int MemberID { get; set; }
        public string Prefix { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Empname { get; set; }
        public string EmpCode { get; set; }
        public DateTime CommentcementDate { get; set; }
        public DateTime JoinedDate { get; set; }
        public string hdcitizenvalNew { get; set; }
        public string StrCommentDate { get; set; }
        public string StrJoinedDate { get; set; }
        public int Isactive { get; set; }
        public string Strisactive { get; set; }
        public int hdCaseotherNew { get; set; }
        public string hdCodeEmployer { get; set; }
        public string hdEmployertext { get; set; }
        public int testid { get; set; }
    }


    public class BinddataNew_Employer_List
    {
        public string StrCitizenID { get; set; }
        public int ID { get; set; }
        public int UserID { get; set; }
        public string CreateBy { get; set; }
        public string UpdateBy { get; set; }
        public string StrID { get; set; }
        public string CitizenID { get; set; }
        public DateTime Date1 { get; set; }
        public DateTime Date2 { get; set; }
        public string StrDate1 { get; set; } = string.Empty;
        public string StrDate2 { get; set; } = string.Empty;

        public int MemberID { get; set; }
        public string TitleName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmployerName { get; set; }
        public string Code { get; set; }
        public string FullName { get; set; }

        public string hdmodalcitizen { get; set; }
        public int hdmodalmember { get; set; }
        public int hdcaseotherID { get; set; }
        public int hdcaseothermemID { get; set; }
        public int hdmodalmemberfullname { get; set; }
        public int hdEmployerId { get; set; }
        public string hdEmployercode { get; set; }
        public string Empname { get; set; }
        public string EmpCode { get; set; }
        public string hdEmployercode3 { get; set; }
    }
    public class MemberNew_VM
    {
        public int MemberID { get; set; }
        public string StrMemberID { get; set; }
        public int TasktypeID { get; set; }
        public int ddljob { get; set; }
    }

    //แก้ไขวันที่ 1/12/65
    public class ListMember_VM
    {
        public int MemberName { get; set; }  
        public string MemberID { get; set; }
        public string MemberName2 { get; set; }
    }

    public class Tasksubtype
    {
        public int ID { get; set; }
        public int ddlTaskType { get; set; }
        public string FullName { get; set; }
    }

    public class ApiDocumetn_VM
    {   
        public int ID { get; set; }
    }

    public class Newinfodt_VM
    {
        public int txtsubSq_Add { get; set; }
        public int AttachmentTypeDtInfoID { get; set; }
        public string message { get; set; }
        public int condition { get; set; }
    }

    //palm
    public class ApiDocument_VM
    {
        public int ID { get; set; }
        public string CaseID { get; set; }
        public int IsNewCase { get; set; }
        public string RefCaseID { get; set; }
        public int InputTypeID { get; set; }
        public string SourceSystem { get; set; }
        public int TaskTypeID { get; set; }
        public int CheckcaseApi { get; set; }  // 1 = รับมาจาก Api 2 = ไม่ได้รับมาจาก api
        public string APIPrefix { get; set; }
        public string APIFirstname { get; set; }
        public string APILastname { get; set; }
        public DateTime CreateDate { get; set; }
        public int IsPreviousDMS { get; set; }
        public int IsSavingFund { get; set; }
        public string IDCard { get; set; }
        public string GPFMemberID { get; set; }
        public int PrefixID { get; set; }
        public string FirstNameTh { get; set; }
        public string FirstNameEn { get; set; }
        public string LastNameTh { get; set; }
        public string LastNameEn { get; set; }
        public int GovUnitID { get; set; }
        public DateTime JoinGovDate { get; set; }
        public DateTime JoinGPFDate { get; set; }
        public int IsDestroy { get; set; }
        public int IsActive { get; set; }
        public DateTime UpdateDate { get; set; }
        public int CreateBy { get; set; }
        public int UpdateBy { get; set; }

        public string Code { get; set; }
        public string GovUnitNameTh { get; set; }
        public int GPFMemberID2 { get; set; }
    }
}
