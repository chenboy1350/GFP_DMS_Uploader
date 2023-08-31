using DMSUpload_Helper.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;

namespace DMSUpload_Helper.Library
{
    public class DMS_DT_BATCH_FILE_DETAIL
    {
        ConnectDB conn = new ConnectDB();
        DataTable dt = new DataTable();

        string SQL;
        private readonly string _datasource;
        private readonly string responseMsg;
        private readonly string UserSQL;
        private readonly string PassSQL;

        public DMS_DT_BATCH_FILE_DETAIL()
        {
            GPFMaintenance.GPFMaintenance ObjWeb = new GPFMaintenance.GPFMaintenance();
            string connStr = string.Empty;

            ObjWeb.GetParameter1("Share", "DMSNew_CON", ref connStr, ref responseMsg);
            ObjWeb.GetParameter2("Share", "DMSNew_USER", ref UserSQL, ref PassSQL, ref responseMsg);
            _datasource = string.Format("{0};User ID={1};Password={2}", connStr, UserSQL, PassSQL);
        }

        public IDbDataParameter BindParameter(string parameterName, object value)
        {
            return new ClassParamsAdd(parameterName, value);
        }

        public DataTable GetDetail(DocumentBFModel item)
        {
            IDataParameter[] iDP = new IDataParameter[1];

            SQL = "";
            SQL += @"   SELECT
	                           fvdt.[ID]
                                  ,fvdt.[IndexFileVerifyID]
                                  ,fvdt.[Filename]
                                  ,fvdt.[DocName]
                                  ,fvdt.[CitizenID]
                                  ,fvdt.[MemberID]
                                  ,fvdt.[RefCaseID]
                                  ,fvdt.[CaseNumber]
                                  ,fvdt.[FileNumber]
                                  ,fvdt.[Remark]
                                  ,fvdt.[RejectReasonID]
                                  ,fvdt.[VerifyStatus]
                                  ,fvdt.[UnitCode]
                                  ,fvdt.[GovUnitName]
                                  ,fvdt.[UnitRefID]
                                  ,fv.[VerityStatus] as MainVerifyStatus
                                  ,tt.[FullName] as TaskTypeName
                                  ,fv.ImportType
                                  ,fv.FileIndex
                                  ,fv.IsUnit
                                  ,r.[RejectReason]

                        FROM temp.IndexFileVerify fv
                        LEFT JOIN [temp].[IndexFileVerifyDt] fvdt ON  fvdt.IndexFileVerifyID = fv.ID
                        LEFT JOIN [mt].[TaskType] tt ON  tt.[Code] = fv.[TaskType]
                        LEFT JOIN [mt].[RejectReasonID] r ON  r.ID = fvdt.[RejectReasonID]
                        WHERE fv.ID = @ID";

            iDP[0] = BindParameter("@ID", item.ID);
            //iDP[1] = BindParameter("@VerifyStatus", 2);

            SQL += " Order By fvdt.CitizenID ASC";
            return dt = conn.ExecuteReaderWithParams(SQL, iDP, _datasource);
        }

        public DataTable GetAttachmentTypeByName(AttachmentType item)
        {
            IDataParameter[] iDP = new IDataParameter[1];

            SQL = "";
            SQL += @"   SELECT
	                           [ID]
                              ,[Code]
                              ,[FullName]
                              ,[InitialName]

                        FROM [mt].[AttachmentType]
                        WHERE [ShortName] = @FullName ";

            iDP[0] = BindParameter("@FullName", item.FullName);

            return dt = conn.ExecuteReaderWithParams(SQL, iDP, _datasource);
        }
        public DataTable CheckFileIndex_Depicate(IndexFileVerifyDtModel data)
        {
            IDataParameter[] iDP = new IDataParameter[4];

            SQL = "";
            SQL += @"   SELECT
	                           [ID]

                        FROM temp.IndexFileVerify
                        WHERE FileIndex = @FileIndex AND VerityStatus in (@VerityStatus1,@VerityStatus2) AND ID != @ID ";

            iDP[0] = BindParameter("@FileIndex", data.FileIndex);
            iDP[1] = BindParameter("@VerityStatus1", 1);
            iDP[2] = BindParameter("@VerityStatus2", 0);
            iDP[3] = BindParameter("@ID", data.IndexFileVerifyID);

            return dt = conn.ExecuteReaderWithParams(SQL, iDP, _datasource);
        }

        public DataTable GetMemberDetailByCitizenID(MemberDetail item)
        {
            IDataParameter[] iDP = new IDataParameter[1];

            SQL = "";
            SQL += @"   SELECT DISTINCT 
	                           [CitizenID]

                        FROM [dbo].[vw_MemberDetail]
                        WHERE CitizenID = @CitizenID ";

            iDP[0] = BindParameter("@CitizenID", item.CitizenID);

            return dt = conn.ExecuteReaderWithParams(SQL, iDP, _datasource);
        }

        public DataTable GetMemberDetailByMemberID(MemberDetail item)
        {
            IDataParameter[] iDP = new IDataParameter[1];

            SQL = "";
            SQL += @"   SELECT DISTINCT
	                           [MemberID]

                        FROM [dbo].[vw_MemberDetail]
                        WHERE MemberID = @MemberID ";

            iDP[0] = BindParameter("@MemberID", Convert.ToInt32(item.MemberID));

            return dt = conn.ExecuteReaderWithParams(SQL, iDP, _datasource);
        }

        public DataTable GetMemberDetailByMemberIDAndCitizenID(MemberDetail item)
        {
            IDataParameter[] iDP = new IDataParameter[2];

            SQL = "";
            SQL += @"   SELECT DISTINCT
	                           [MemberID]

                        FROM [dbo].[vw_MemberDetail]
                        WHERE MemberID = @MemberID AND CitizenID = @CitizenID ";

            iDP[0] = BindParameter("@MemberID", Convert.ToInt32(item.MemberID));
            iDP[1] = BindParameter("@CitizenID", item.CitizenID);

            return dt = conn.ExecuteReaderWithParams(SQL, iDP, _datasource);
        }

        public void UpdateIndexFileVerifyDt(IndexFileVerifyDtModel model)
        {
            IDataParameter[] iDP = new IDataParameter[3];
            SQL = @"UPDATE [temp].[IndexFileVerifyDt]
                       SET [VerifyStatus] = @VerifyStatus, [RejectReasonID] = @RejectReasonID
                          
                     WHERE ID = @ID";

            iDP[0] = BindParameter("@VerifyStatus", model.VerifyStatus);

            if(model.RejectReasonID != 0)
            {
                iDP[1] = BindParameter("@RejectReasonID", model.RejectReasonID);
            }
            else
            {
                iDP[1] = BindParameter("@RejectReasonID", DBNull.Value);
            }

            iDP[2] = BindParameter("@ID", model.ID);

            conn.ExecuteReaderWithParams(SQL, iDP, _datasource);
        }

        public void UpdateIndexFileVerify(IndexFileVerifyDtModel model)
        {
            IDataParameter[] iDP = new IDataParameter[2];
            SQL = @"UPDATE [temp].[IndexFileVerify]
                       SET [VerityStatus] = @VerityStatus
                          
                     WHERE ID = @ID";

            iDP[0] = BindParameter("@VerityStatus", model.VerifyStatus);

            iDP[1] = BindParameter("@ID", model.IndexFileVerifyID);

            conn.ExecuteReaderWithParams(SQL, iDP, _datasource);
        }

        public string GetPrefixID(Prefix_Model pre)
        {
            IDataParameter[] iDP = new IDataParameter[1];
            string str = "";
            SQL = @" SELECT [ID]
                    FROM [mt].[Prefix]
                    WHERE [NameTh] = @NameTh";

            iDP[0] = BindParameter("@NameTh", pre.NameTh);

            DataTable DT = conn.ExecuteReaderWithParams(SQL, iDP, _datasource);
            if (DT.Rows.Count > 0 && DT.Rows[0][0].ToString() != "")
            {
                str = DT.Rows[0][0].ToString();
            }
            return str;
        }

        public string Insert_Prefix(string Name)
        {
            string UserID = "";

            IDataParameter[] iDP = new IDataParameter[2];

            SQL = @"INSERT INTO [mt].[Prefix] ([NameTh], [IsActive])

                                                VALUES ( @NameTh, 
                                                         @IsActive )";

            iDP[0] = BindParameter("@NameTh", Name);
            iDP[1] = BindParameter("@IsActive", 1);

            dt = conn.ExecuteReaderWithParams(SQL, iDP, _datasource);

            if (dt.Rows.Count > 0)
            {
                UserID = dt.Rows[0][0].ToString();
            }

            return UserID;
        }
        public string GetGovID(GovUnitModel gov)
        {
            IDataParameter[] iDP = new IDataParameter[2];
            string str = "";
            SQL = @" SELECT [ID]
                    FROM [mt].[GovUnit]
                    WHERE [Code] = @Code AND [GovUnitNameTh] = @GovUnitNameTh";

            iDP[0] = BindParameter("@Code", gov.Code);
            iDP[1] = BindParameter("@GovUnitNameTh", gov.GovUnitNameTh);

            DataTable DT = conn.ExecuteReaderWithParams(SQL, iDP, _datasource);
            if (DT.Rows.Count > 0 && DT.Rows[0][0].ToString() != "")
            {
                str = DT.Rows[0][0].ToString();
            }
            return str;
        }
        public DataTable GetDocByCaseID(Document item)
        {
            IDataParameter[] iDP = new IDataParameter[1];

            SQL = "";
            SQL += @"   SELECT
	                           [ID]

                        FROM [dms].[Document]
                        WHERE CaseID = @CaseID  ";

            iDP[0] = BindParameter("@CaseID", item.CaseID);

            return dt = conn.ExecuteReaderWithParams(SQL, iDP, _datasource);
        }

        public DataTable GetDetailToCreateDoc(DocumentBFModel item)
        {
            IDataParameter[] iDP = new IDataParameter[2];

            SQL = "";
            SQL += @"   SELECT
	                           fvdt.[ID]
                                  ,fvdt.[IndexFileVerifyID]
                                  ,fvdt.[Filename]
                                  ,fvdt.[DocName]
                                  ,fvdt.[CitizenID]
                                  ,fvdt.[MemberID]
                                  ,fvdt.[RefCaseID]
                                  ,fvdt.[CaseNumber]
                                  ,fvdt.[FileNumber]
                                  ,fvdt.[Remark]
                                  ,fvdt.[RejectReasonID]
                                  ,fvdt.[VerifyStatus]
                                  ,fv.[VerityStatus] as MainVerifyStatus
                                  ,tt.[FullName] as TaskTypeName
                                  ,fv.ImportType
                                  ,fv.FileIndex
                                  ,r.[RejectReason]
								  ,tt.ID as TaskTypeID
								  ,it.ID as AttachmentTypeID

                        FROM temp.IndexFileVerify fv
                        LEFT JOIN [temp].[IndexFileVerifyDt] fvdt ON  fvdt.IndexFileVerifyID = fv.ID
                        LEFT JOIN [mt].[TaskType] tt ON  tt.[Code] = fv.[TaskType]
                        LEFT JOIN [mt].[RejectReasonID] r ON  r.ID = fvdt.[RejectReasonID]
                        LEFT JOIN [mt].[AttachmentType] it ON  it.[ShortName] = fvdt.[DocName]

                        WHERE fv.ID = @ID AND fv.VerityStatus = @VerityStatus ";

            iDP[0] = BindParameter("@ID", item.ID);
            iDP[1] = BindParameter("@VerityStatus", 3);

            SQL += " Order By fvdt.CitizenID ASC";
            return dt = conn.ExecuteReaderWithParams(SQL, iDP, _datasource);
        }

        public void UpdateIsProcess(int id, int is_process) 
        {
            IDataParameter[] iDP = new IDataParameter[2];

            SQL = "UPDATE temp.IndexFileVerifyDt SET IsProcess = @IsProcess WHERE ID = @ID ";

            iDP[0] = BindParameter("@IsProcess", is_process);
            iDP[1] = BindParameter("@ID", id);

            conn.ExecuteNonQueryWithParams(SQL, iDP, _datasource);
        }

        public DataTable GetTempIndexFileVerifyDT(DocumentBFModel item)
        {
            IDataParameter[] iDP = new IDataParameter[2];

            SQL = "";
            SQL += @"   EXEC [dbo].[GetTempIndexFileVerifyDT] @ID, @VerityStatus ";

            iDP[0] = BindParameter("@ID", item.ID);
            iDP[1] = BindParameter("@VerityStatus", 3);

            return dt = conn.ExecuteReaderWithParams(SQL, iDP, _datasource);
        }

        public string GetRunningNumber_BillPayment(int RunningYear, int TaskTypeID)
        {
            string str = "";
            IDataParameter[] iDP = new IDataParameter[4];

            SQL = @" SELECT TOP(1) RunningNumber
                    FROM [dms].[Document]
                    WHERE RunningYear = @RunningYear AND TaskTypeID = @TaskTypeID AND (InputTypeID = @InputTypeID or InputTypeID = @InputTypeID2)
                    order by SubmitDate DESC, RunningCase DESC, RunningNumber DESC";

            iDP[0] = BindParameter("@RunningYear", RunningYear);
            iDP[1] = BindParameter("@TaskTypeID", TaskTypeID);
            iDP[2] = BindParameter("@InputTypeID", 4);
            iDP[3] = BindParameter("@InputTypeID2", 5);

            DataTable DT = conn.ExecuteReaderWithParams(SQL, iDP, _datasource);
            if (DT.Rows.Count > 0 && DT.Rows[0][0].ToString() != "")
            {
                str = DT.Rows[0][0].ToString();
            }
            return str;
        }

        public string GetRunningCase(int RunningYear, int TaskTypeID)
        {
            string str = "";
            IDataParameter[] iDP = new IDataParameter[4];

            SQL = @" SELECT TOP(1) RunningCase
                    FROM [dms].[Document]
                    WHERE RunningYear = @RunningYear AND TaskTypeID = @TaskTypeID AND (InputTypeID = @InputTypeID or InputTypeID = @InputTypeID2)
                    order by SubmitDate DESC, RunningCase DESC, RunningNumber DESC";

            iDP[0] = BindParameter("@RunningYear", RunningYear);
            iDP[1] = BindParameter("@TaskTypeID", TaskTypeID);
            iDP[2] = BindParameter("@InputTypeID", 4);
            iDP[3] = BindParameter("@InputTypeID2", 5);

            DataTable DT = conn.ExecuteReaderWithParams(SQL, iDP, _datasource);
            if (DT.Rows.Count > 0 && DT.Rows[0][0].ToString() != "")
            {
                str = DT.Rows[0][0].ToString();
            }
            return str;
        }

        public DataTable GetGPFMember(GPFMemberModel item)
        {
            IDataParameter[] iDP = new IDataParameter[2];

            SQL = "";
            SQL += @"  SELECT [ID]
                          ,[IDCard]
                          ,[GPFMemberID]
                          ,[PrefixID]
                          ,[FirstNameTh]
                          ,[FirstNameEn]
                          ,[LastNameTh]
                          ,[LastNameEn]
                          ,[GovUnitID]
                          ,[JoinGovDate]
                          ,[JoinGPFDate]
                          ,[IsDestroy]
                          ,[IsActive]
                          ,[CreateBy]
                          ,[CreateDate]
                          ,[UpdateBy]
                          ,[UpdateDate]
                          ,[SendType]
                      FROM [mt].[GPFMember]
                     
                        WHERE IDCard = @IDCard AND GPFMemberID = @GPFMemberID ";

            iDP[0] = BindParameter("@IDCard", item.IDCard);
            iDP[1] = BindParameter("@GPFMemberID", item.GPFMemberID);

            return dt = conn.ExecuteReaderWithParams(SQL, iDP, _datasource);
        }
        //------------------------------------------------------------------------------GPF แก้เรื่อง member Status -------------------------------------------------------------------------------------------
        public DataTable Get_vw_MemberDetail(GPFMemberModel item)
        {
            IDataParameter[] iDP = new IDataParameter[2];

            SQL = "";
            SQL += @"  SELECT DISTINCT m.CitizenID as [IDCard]
                              ,m.MemberID as MemberID
                              ,p.ID as PrefixID
                              ,m.FirstName as [FirstNameTh]
                              ,m.LastName as [LastNameTh]
                              ,g.ID as [GovUnitID]
                              ,m.CommencementDate as [JoinGovDate]
                              ,m.JoinedFundDate as [JoinGPFDate]
                              ,m.[Code]
                              ,m.[EmployerName]
                              ,m.SendType
                              , m.[TitleName] as PrefixName
                              , m.UnitMain
                              , m.MemberStatus
                             
	                    FROM [dbo].[vw_MemberDetail] m

                        LEFT JOIN [mt].[Prefix] p ON p.[NameTh] collate Thai_CI_AS = m.[TitleName] collate Thai_CI_AS
                        LEFT JOIN [mt].[GovUnit] g ON g.Code collate Thai_CI_AS = m.Code collate Thai_CI_AS  
						and g.GovUnitNameTh collate Thai_CI_AS = m.EmployerName collate Thai_CI_AS 
						and g.[GovUnitMain] collate Thai_CI_AS = m.[UnitMain] collate Thai_CI_AS

                        WHERE m.CitizenID = @CitizenID AND m.MemberID = @MemberID ";
                                  //AND m.MemberStatus = 'Active'
            iDP[0] = BindParameter("@CitizenID", item.IDCard);

            if (!String.IsNullOrEmpty(item.GPFMemberID))
            {
                iDP[1] = BindParameter("@MemberID", Convert.ToInt32(item.GPFMemberID));
            }
           

            return dt = conn.ExecuteReaderWithParams(SQL, iDP, _datasource);
        }
        public string Insert_GPFMember(GPFMemberModel member)
        {
            string UserID = "";

            IDataParameter[] iDP = new IDataParameter[16];

            SQL = @"INSERT INTO [mt].[GPFMember] ( [IDCard]
                                                      ,[GPFMemberID]
                                                      ,[PrefixID]
                                                      ,[FirstNameTh]
                                                      ,[FirstNameEn]
                                                      ,[LastNameTh]
                                                      ,[LastNameEn]
                                                      ,[GovUnitID]
                                                      ,[JoinGovDate]
                                                      ,[JoinGPFDate]
                                                      ,[IsDestroy]
                                                      ,[IsActive]
                                                      ,[CreateBy]
                                                      ,[CreateDate]
                                                      ,[UpdateBy]
                                                      ,[UpdateDate]
                                                      ,[SendType]
                                                      ,[MemberStatus])

                                                VALUES (@IDCard, 
                                                        @GPFMemberID, 
                                                        @PrefixID, 
                                                        @FirstNameTh, 
                                                        @FirstNameEn, 
                                                        @LastNameTh, 
                                                        @LastNameEn, 
                                                        @GovUnitID, 
                                                        @JoinGovDate, 
                                                        @JoinGPFDate, 
                                                        @IsDestroy, 
                                                        @IsActive, 
                                                        @CreateBy, 
                                                        GETDATE(), 
                                                        @UpdateBy, 
                                                        GETDATE(), 
                                                        @SendType,
                                                        @MemberStatus ) SELECT SCOPE_IDENTITY()";

            iDP[0] = BindParameter("@IDCard", member.IDCard);
            iDP[1] = BindParameter("@GPFMemberID", member.GPFMemberID);

            if (member.PrefixID != 0)
            {
                iDP[2] = BindParameter("@PrefixID", member.PrefixID);
            }
            else
            {
                iDP[2] = BindParameter("@PrefixID", DBNull.Value);
            }

            iDP[3] = BindParameter("@FirstNameTh", member.FirstNameTh);
            iDP[4] = BindParameter("@FirstNameEn", member.FirstNameEn);
            iDP[5] = BindParameter("@LastNameTh", member.LastNameTh);
            iDP[6] = BindParameter("@LastNameEn", member.LastNameEn);

            if (member.PrefixID != 0)
            {
                iDP[7] = BindParameter("@GovUnitID", member.GovUnitID);
            }
            else
            {
                iDP[7] = BindParameter("@GovUnitID", DBNull.Value);
            }

            if (member.JoinGovDate != DateTime.MinValue)
            {
                iDP[8] = BindParameter("@JoinGovDate", member.JoinGovDate);
            }
            else
            {
                iDP[8] = BindParameter("@JoinGovDate", DBNull.Value);
            }

            if (member.JoinGPFDate != DateTime.MinValue)
            {
                iDP[9] = BindParameter("@JoinGPFDate", member.JoinGPFDate);
            }
            else
            {
                iDP[9] = BindParameter("@JoinGPFDate", DBNull.Value);
            }

            iDP[10] = BindParameter("@IsDestroy", member.IsDestroy);
            iDP[11] = BindParameter("@IsActive", member.IsActive);
            iDP[12] = BindParameter("@CreateBy", 1);
            iDP[13] = BindParameter("@UpdateBy", 1);
            iDP[14] = BindParameter("@SendType", member.SendType);
            iDP[15] = BindParameter("@MemberStatus", member.MemberStatus);

            dt = conn.ExecuteReaderWithParams(SQL, iDP, _datasource);

            if (dt.Rows.Count > 0)
            {
                UserID = dt.Rows[0][0].ToString();
            }
            return UserID;
        }
        public string Exec_GPFMember(GPFMemberModel member)
        {
            string UserID = "";

            IDataParameter[] iDP = new IDataParameter[15];

            SQL = @"EXEC dbo.InsertGPFMember @IDCard, 
                                                        @GPFMemberID, 
                                                        @PrefixID, 
                                                        @FirstNameTh, 
                                                        @FirstNameEn, 
                                                        @LastNameTh, 
                                                        @LastNameEn, 
                                                        @GovUnitID, 
                                                        @JoinGovDate, 
                                                        @JoinGPFDate, 
                                                        @IsDestroy, 
                                                        @IsActive, 
                                                        @CreateBy, 
                                                        GETDATE(), 
                                                        @UpdateBy, 
                                                        GETDATE(), @SendType";

            iDP[0] = BindParameter("@IDCard", member.IDCard);
            iDP[1] = BindParameter("@GPFMemberID", member.GPFMemberID);

            if (member.PrefixID != 0)
            {
                iDP[2] = BindParameter("@PrefixID", member.PrefixID);
            }
            else
            {
                iDP[2] = BindParameter("@PrefixID", DBNull.Value);
            }

            iDP[3] = BindParameter("@FirstNameTh", member.FirstNameTh);
            iDP[4] = BindParameter("@FirstNameEn", member.FirstNameEn);
            iDP[5] = BindParameter("@LastNameTh", member.LastNameTh);
            iDP[6] = BindParameter("@LastNameEn", member.LastNameEn);

            if (member.PrefixID != 0)
            {
                iDP[7] = BindParameter("@GovUnitID", member.GovUnitID);
            }
            else
            {
                iDP[7] = BindParameter("@GovUnitID", DBNull.Value);
            }

            if (member.JoinGovDate != DateTime.MinValue)
            {
                iDP[8] = BindParameter("@JoinGovDate", member.JoinGovDate);
            }
            else
            {
                iDP[8] = BindParameter("@JoinGovDate", DBNull.Value);
            }

            if (member.JoinGPFDate != DateTime.MinValue)
            {
                iDP[9] = BindParameter("@JoinGPFDate", member.JoinGPFDate);
            }
            else
            {
                iDP[9] = BindParameter("@JoinGPFDate", DBNull.Value);
            }

            iDP[10] = BindParameter("@IsDestroy", member.IsDestroy);
            iDP[11] = BindParameter("@IsActive", member.IsActive);
            iDP[12] = BindParameter("@CreateBy", 1);
            iDP[13] = BindParameter("@UpdateBy", 1);
            iDP[14] = BindParameter("@SendType", member.SendType);

            dt = conn.ExecuteReaderWithParams(SQL, iDP, _datasource);

            if (dt.Rows.Count > 0)
            {
                UserID = dt.Rows[0][0].ToString();
            }
            return UserID;
        }
        public string Insert_Document(Document doc)
        {

            string UserID = "";

            IDataParameter[] iDP = new IDataParameter[21];

            SQL = @"INSERT INTO [dms].[Document] ( [InputTypeID]
                                                      ,[TaskTypeID]
                                                      ,[TaskSubTypeID]
                                                      ,[GPFMemberID]
                                                      ,[DocumentStatusID]
                                                      ,[DocumentSubStatusID]
                                                      ,[CaseID]
                                                      ,[CreateBy]
                                                      ,[CreateDate]
                                                      ,[UpdateBy]
                                                      ,[UpdateDate]
                                                      ,[Status]
                                                      ,[RunningYear]
                                                      ,[RunningNumber]
                                                      ,[Remark]
                                                      ,[IsNewCase]
                                                      ,[RefCaseID]
                                                      ,[GovUnitID]
                                                      ,[IsPreviousDMS]
                                                      ,[RunningCase]
                                                      ,[SubmitDate]
                                                      ,[BatchRefNo]
                                                )

                                                VALUES (@InputTypeID, 
                                                        @TaskTypeID, 
                                                        @TaskSubTypeID, 
                                                        @GPFMemberID, 
                                                        @DocumentStatusID, 
                                                        @DocumentSubStatusID, 
                                                        @CaseID, 
                                                        @CreateBy, 
                                                        GETDATE(), 
                                                        @UpdateBy, 
                                                        GETDATE(),
                                                        @Status,
                                                        @RunningYear,
                                                        @RunningNumber,
                                                        @Remark,
                                                        @IsNewCase,
                                                        @RefCaseID,
                                                        @GovUnitID,
                                                        @IsPreviousDMS,
                                                        @RunningCase,
                                                        @SubmitDate,
                                                        @BatchRefNo
                                                    ) SELECT SCOPE_IDENTITY()";

            iDP[0] = BindParameter("@InputTypeID", 5);

            if (doc.TaskTypeID != 0 && doc.TaskTypeID != null)
            {
                iDP[1] = BindParameter("@TaskTypeID", doc.TaskTypeID);
            }
            else
            {
                iDP[1] = BindParameter("@TaskTypeID", DBNull.Value);
            }

            if (doc.TaskSub2TypeID != 0 && doc.TaskSub2TypeID != null)
            {
                iDP[2] = BindParameter("@TaskSub2TypeID", doc.TaskSub2TypeID);
            }
            else
            {
                iDP[2] = BindParameter("@TaskSub2TypeID", DBNull.Value);
            }

            if (doc.MemberID != 0 && doc.MemberID != null)
            {
                iDP[3] = BindParameter("@GPFMemberID", doc.MemberID);
            }
            else
            {
                iDP[3] = BindParameter("@GPFMemberID", DBNull.Value);
            }

            iDP[4] = BindParameter("@DocumentStatusID", 8);

            if (doc.DocumentSubStatusID != 0 && doc.DocumentSubStatusID != null)
            {
                iDP[5] = BindParameter("@DocumentSubStatusID", doc.DocumentSubStatusID);
            }
            else
            {
                iDP[5] = BindParameter("@DocumentSubStatusID", DBNull.Value);
            }

            if (!String.IsNullOrEmpty(doc.CaseID))
            {
                iDP[6] = BindParameter("@CaseID", doc.CaseID);
            }
            else
            {
                iDP[6] = BindParameter("@CaseID", DBNull.Value);
            }


            iDP[7] = BindParameter("@CreateBy", doc.CreateBy);
            iDP[8] = BindParameter("@UpdateBy", doc.UpdateBy);
            iDP[9] = BindParameter("@Status", 1);
            iDP[10] = BindParameter("@RunningYear", doc.RunningYear);
            iDP[11] = BindParameter("@RunningNumber", doc.RunningNumber);

            if (!String.IsNullOrEmpty(doc.Remark))
            {
                iDP[12] = BindParameter("@Remark", doc.Remark);
            }
            else
            {
                iDP[12] = BindParameter("@Remark", DBNull.Value);
            }

            if (doc.IsNewCase != 0 && doc.IsNewCase != null)
            {
                iDP[13] = BindParameter("@IsNewCase", doc.IsNewCase);
            }
            else
            {
                iDP[13] = BindParameter("@IsNewCase", DBNull.Value);
            }

            if (!String.IsNullOrEmpty(doc.RefCaseID))
            {
                iDP[14] = BindParameter("@RefCaseID", doc.RefCaseID);
            }
            else
            {
                iDP[14] = BindParameter("@RefCaseID", DBNull.Value);
            }

            if (doc.GovUnitID != 0 && doc.GovUnitID != null)
            {
                iDP[15] = BindParameter("@GovUnitID", doc.GovUnitID);
            }
            else
            {
                iDP[15] = BindParameter("@GovUnitID", DBNull.Value);
            }

            if (doc.IsPreviousDMS != 0 && doc.IsPreviousDMS != null)
            {
                iDP[16] = BindParameter("@IsPreviousDMS", doc.IsPreviousDMS);
            }
            else
            {
                iDP[16] = BindParameter("@IsPreviousDMS", DBNull.Value);
            }

            if (doc.TaskSubTypeID != 0 && doc.TaskSubTypeID != null)
            {
                iDP[17] = BindParameter("@TaskSubTypeID", doc.TaskSubTypeID);
            }
            else
            {
                iDP[17] = BindParameter("@TaskSubTypeID", DBNull.Value);
            }

            iDP[18] = BindParameter("@RunningCase", doc.RunningCase);
            iDP[19] = BindParameter("@SubmitDate", doc.SubmitDate);
            iDP[20] = BindParameter("@BatchRefNo", doc.BatchRefNo);


            dt = conn.ExecuteReaderWithParams(SQL, iDP, _datasource);

            if (dt.Rows.Count > 0)
            {
                UserID = dt.Rows[0][0].ToString();
            }
            return UserID;
        }
        public DataTable GetCheckDataEntryByMemberId(string memberid)
        {
            IDataParameter[] iDP = new IDataParameter[1];
            SQL = " EXEC [fps].[CheckDataEntryHistory] @memberid ";
            iDP[0] = BindParameter("@memberid", memberid);

            return conn.ExecuteReaderWithParams(SQL, iDP, "");
        }
        public string Exec_Insert_Document(Document doc)
        {

            string UserID = "";

            IDataParameter[] iDP = new IDataParameter[23];

            SQL = @"EXEC [dbo].[InsertDocument] @InputTypeID, 
                                                        @TaskTypeID, 
                                                        @TaskSubTypeID, 
                                                        @GPFMemberID, 
                                                        @DocumentStatusID, 
                                                        @DocumentSubStatusID, 
                                                        @CaseID, 
                                                        @CreateBy, 
                                                        '2011-03-12', 
                                                        @UpdateBy, 
                                                        '2011-03-12',
                                                        @Status,
                                                        @RunningYear,
                                                        @RunningNumber,
                                                        @Remark,
                                                        @IsNewCase,
                                                        @RefCaseID,
                                                        @GovUnitID,
                                                        @IsPreviousDMS,
                                                        @RunningCase,
                                                        @SubmitDate,
                                                        @BatchRefNo  ";

            iDP[0] = BindParameter("@InputTypeID", 5);

            if (doc.TaskTypeID != 0 && doc.TaskTypeID != null)
            {
                iDP[1] = BindParameter("@TaskTypeID", doc.TaskTypeID);
            }
            else
            {
                iDP[1] = BindParameter("@TaskTypeID", DBNull.Value);
            }

            if (doc.TaskSub2TypeID != 0 && doc.TaskSub2TypeID != null)
            {
                iDP[2] = BindParameter("@TaskSub2TypeID", doc.TaskSub2TypeID);
            }
            else
            {
                iDP[2] = BindParameter("@TaskSub2TypeID", DBNull.Value);
            }

            if (doc.MemberID != 0 && doc.MemberID != null)
            {
                iDP[3] = BindParameter("@GPFMemberID", doc.MemberID);
            }
            else
            {
                iDP[3] = BindParameter("@GPFMemberID", DBNull.Value);
            }

            iDP[4] = BindParameter("@DocumentStatusID", 8);

            if (doc.DocumentSubStatusID != 0 && doc.DocumentSubStatusID != null)
            {
                iDP[5] = BindParameter("@DocumentSubStatusID", doc.DocumentSubStatusID);
            }
            else
            {
                iDP[5] = BindParameter("@DocumentSubStatusID", DBNull.Value);
            }

            if (!String.IsNullOrEmpty(doc.CaseID))
            {
                iDP[6] = BindParameter("@CaseID", doc.CaseID);
            }
            else
            {
                iDP[6] = BindParameter("@CaseID", DBNull.Value);
            }


            iDP[7] = BindParameter("@CreateBy", doc.CreateBy);
            iDP[8] = BindParameter("@CreateDate", DateTime.Now);
            iDP[9] = BindParameter("@UpdateBy", doc.UpdateBy);
            iDP[10] = BindParameter("@UpdateDate", DateTime.Now);
            iDP[11] = BindParameter("@Status", 1);
            iDP[12] = BindParameter("@RunningYear", doc.RunningYear);
            iDP[13] = BindParameter("@RunningNumber", doc.RunningNumber);

            if (!String.IsNullOrEmpty(doc.Remark))
            {
                iDP[14] = BindParameter("@Remark", doc.Remark);
            }
            else
            {
                iDP[14] = BindParameter("@Remark", DBNull.Value);
            }

            if (doc.IsNewCase != 0 && doc.IsNewCase != null)
            {
                iDP[15] = BindParameter("@IsNewCase", doc.IsNewCase);
            }
            else
            {
                iDP[15] = BindParameter("@IsNewCase", DBNull.Value);
            }

            if (!String.IsNullOrEmpty(doc.RefCaseID))
            {
                iDP[16] = BindParameter("@RefCaseID", doc.RefCaseID);
            }
            else
            {
                iDP[16] = BindParameter("@RefCaseID", DBNull.Value);
            }

            if (doc.GovUnitID != 0 && doc.GovUnitID != null)
            {
                iDP[17] = BindParameter("@GovUnitID", doc.GovUnitID);
            }
            else
            {
                iDP[17] = BindParameter("@GovUnitID", DBNull.Value);
            }

            if (doc.IsPreviousDMS != 0 && doc.IsPreviousDMS != null)
            {
                iDP[18] = BindParameter("@IsPreviousDMS", doc.IsPreviousDMS);
            }
            else
            {
                iDP[18] = BindParameter("@IsPreviousDMS", DBNull.Value);
            }

            if (doc.TaskSubTypeID != 0 && doc.TaskSubTypeID != null)
            {
                iDP[19] = BindParameter("@TaskSubTypeID", doc.TaskSubTypeID);
            }
            else
            {
                iDP[19] = BindParameter("@TaskSubTypeID", DBNull.Value);
            }

            iDP[20] = BindParameter("@RunningCase", doc.RunningCase);
            iDP[21] = BindParameter("@SubmitDate", doc.SubmitDate);
            iDP[22] = BindParameter("@BatchRefNo", doc.BatchRefNo);


            dt = conn.ExecuteReaderWithParams(SQL, iDP, _datasource);

            if (dt.Rows.Count > 0)
            {
                UserID = dt.Rows[0][0].ToString();
            }
            return UserID;
        }

        public string Insert_AttachmentDt(AttachmentDt doc)
        {

            string UserID = "";

            IDataParameter[] iDP = new IDataParameter[5];

            SQL = @"INSERT INTO [dms].[AttachmentDt] ( [DocumentID]
                                                          ,[PathFile]
                                                          ,[FileName]
                                                          ,[FileSize],[DocumentName] )

                                                VALUES (@DocumentID, 
                                                        @PathFile, 
                                                        @FileName, 
                                                        @FileSize, 
                                                        @DocumentName
                                                        ) SELECT SCOPE_IDENTITY()";

            iDP[0] = BindParameter("@DocumentID", doc.DocumentID);
            iDP[1] = BindParameter("@PathFile", doc.PathFile);
            iDP[2] = BindParameter("@FileName", doc.FileName);
            iDP[3] = BindParameter("@FileSize", doc.FileSize);
            iDP[4] = BindParameter("@DocumentName", doc.DocumentName);

            dt = conn.ExecuteReaderWithParams(SQL, iDP, _datasource);

            if (dt.Rows.Count > 0)
            {
                UserID = dt.Rows[0][0].ToString();
            }
            return UserID;
        }

        public string Exec_Insert_AttachmentDt(AttachmentDt doc)
        {

            string AttachmentDtID = "";
            IDataParameter[] iDP = new IDataParameter[5];

            SQL = @"EXEC [dbo].[InsertAttachmentDt] @DocumentID, 
                                                        @PathFile, 
                                                        @FileName, 
                                                        @FileSize, 
                                                        @DocumentName
                                                        ";

            iDP[0] = BindParameter("@DocumentID", doc.DocumentID);
            iDP[1] = BindParameter("@PathFile", doc.PathFile);
            iDP[2] = BindParameter("@FileName", doc.FileName);
            iDP[3] = BindParameter("@FileSize", doc.FileSize);
            iDP[4] = BindParameter("@DocumentName", doc.DocumentName);

            dt = conn.ExecuteReaderWithParams(SQL, iDP, _datasource);

            if (dt.Rows.Count > 0)
            {
                AttachmentDtID = dt.Rows[0][0].ToString();
            }
            return AttachmentDtID;
        }
        public string InsertAttachmentTypeDtInfo(int AttachmentDtID, int AttachmentTypeID, int Sq)
        {
            string str = "";
            IDataParameter[] iDP = new IDataParameter[3];
            SQL = "";
            SQL = @" INSERT INTO dms.AttachmentTypeDtInfo
                        (
                            AttachmentDtID
                          ,[AttachmentTypeID]
                          ,[Sq]
                        )
                        VALUES
                        (
                             @AttachmentDtID
                             ,@AttachmentTypeID
                             ,@Sq
                        ) SELECT SCOPE_IDENTITY() ";

            iDP[0] = BindParameter("@AttachmentDtID", AttachmentDtID);
            iDP[1] = BindParameter("@AttachmentTypeID", AttachmentTypeID);
            iDP[2] = BindParameter("@Sq", Sq);

            dt = conn.ExecuteReaderWithParams(SQL, iDP, _datasource);
            if (dt.Rows.Count > 0)
            {
                str = dt.Rows[0][0].ToString();
            }
            return str;
        }

        public string Exec_InsertAttachmentTypeDtInfo(int AttachmentDtID, int AttachmentTypeID, int Sq)
        {
            string str = "";
            IDataParameter[] iDP = new IDataParameter[3];
            SQL = "";
            SQL = @" EXEC [dbo].[InsertAttachmentTypeDtInfo] @AttachmentDtID
                             ,@AttachmentTypeID
                             ,@Sq";

            iDP[0] = BindParameter("@AttachmentDtID", AttachmentDtID);
            iDP[1] = BindParameter("@AttachmentTypeID", AttachmentTypeID);
            iDP[2] = BindParameter("@Sq", Sq);

            dt = conn.ExecuteReaderWithParams(SQL, iDP, _datasource);
            if (dt.Rows.Count > 0)
            {
                str = dt.Rows[0][0].ToString();
            }
            return str;
        }

        public DataTable GetFileName(GetFileName_DMS getfilename)
        {
            IDataParameter[] iDP = new IDataParameter[2];
            SQL = @"  SELECT   adt.[FileName] 
                              ,adt.[DocumentID] 
                              ,adt.[ID] as AttchmentID
                              ,adtinfo.[Sq] as Sq
                              ,adtinfo.[AttachmentTypeID]  as AttchmentType
                              ,adtinfo.[IsMultiple] 
                              ,d.[RunningYear] as Year
                              ,adtinfo.[PageNumber]
    
                     FROM [dms].[Document] as d
                        --LEFT JOIN [mt].[GPFMember] m ON m.GPFMemberID = d.GPFMemberID 
                        --LEFT JOIN [dms].[DocumentDt] dt ON dt.DocumentID = d.ID   
                        LEFT JOIN [dms].[AttachmentDt] adt ON adt.DocumentID = d.ID  
                        LEFT JOIN [dms].[AttachmentTypeDtInfo] adtinfo ON adtinfo.AttachmentDtID = adt.ID  
                        LEFT JOIN [mt].[AttachmentType] atype ON atype.ID = adtinfo.AttachmentTypeID 
                        --LEFT JOIN [mt].[User] u ON u.ID = d.UpdateBy
                        --LEFT JOIN [mt].[Employee] emp ON emp.ID = u.EmployeeID
                        --LEFT JOIN [mt].[Prefix] p ON p.ID = emp.PrefixID
                        --LEFT JOIN [mt].[Box] b ON b.ID = d.BoxID
                        --LEFT JOIN [mt].[Folder] f ON f.ID = d.FolderID
                        

                        ";

            SQL += " WHERE 1=1 ";

            if (getfilename.DocID != 0)
            {
                SQL += " AND adt.DocumentID = @DocID ";
                iDP[0] = BindParameter("@DocID", getfilename.DocID);
            }
            else
            {
                iDP[0] = BindParameter("@DocID", DBNull.Value);
            }

            if (getfilename.AttInfoID != 0)
            {
                SQL += " AND adt.ID = @AttInfoID ";
                iDP[1] = BindParameter("@AttInfoID", getfilename.AttInfoID);
            }
            else
            {
                iDP[1] = BindParameter("@AttInfoID", DBNull.Value);
            }

            return dt = conn.ExecuteReaderWithParams(SQL, iDP, _datasource);
        }

        public string CheckDocumentDtID(DocumentDt doc)
        {
            IDataParameter[] iDP = new IDataParameter[2];
            string str = "";
            SQL = @" SELECT 
                              [Sq]
                          FROM [mt].[TaskAttachmentTypeMappingDt]

                    WHERE IsMCSWeb IS NULL AND TaskTypeID = @TaskTypeID AND AttachmentTypeID = @AttachmentTypeID";

            iDP[0] = BindParameter("@TaskTypeID", doc.TaskType);
            iDP[1] = BindParameter("@AttachmentTypeID", doc.AttachmentTypeID);

            DataTable DT = conn.ExecuteReaderWithParams(SQL, iDP, _datasource);
            if (DT.Rows.Count > 0 && DT.Rows[0][0].ToString() != "")
            {
                str = DT.Rows[0][0].ToString();
            }
            return str;
        }


        public string GetIsPreviousDMS(Document doc)
        {
            IDataParameter[] iDP = new IDataParameter[2];
            string str = "";
            SQL = @" select ID
                    from [dms].[Document]
                    where CaseID = @CaseID and IsPreviousDMS = @IsPreviousDMS";

            iDP[0] = BindParameter("@CaseID", doc.CaseID);
            iDP[1] = BindParameter("@IsPreviousDMS", 1);

            DataTable DT = conn.ExecuteReaderWithParams(SQL, iDP, _datasource);
            if (DT.Rows.Count > 0 && DT.Rows[0][0].ToString() != "")
            {
                str = DT.Rows[0][0].ToString();
            }
            return str;
        }

        public string GetIsNewCase(Document doc)
        {
            IDataParameter[] iDP = new IDataParameter[3];
            string str = "";
            SQL = @" select ID
                    from [dms].[Document]
                    where CaseID = @CaseID and IsPreviousDMS = @IsPreviousDMS and IsNewCase = @IsNewCase";

            iDP[0] = BindParameter("@CaseID", doc.CaseID);
            iDP[1] = BindParameter("@IsPreviousDMS", DBNull.Value);
            iDP[2] = BindParameter("@IsNewCase", 1);

            DataTable DT = conn.ExecuteReaderWithParams(SQL, iDP, _datasource);
            if (DT.Rows.Count > 0 && DT.Rows[0][0].ToString() != "")
            {
                str = DT.Rows[0][0].ToString();
            }
            return str;
        }
        public string Insert_GovUnit(string Code, string Name)
        {
            string UserID = "";

            IDataParameter[] iDP = new IDataParameter[3];

            SQL = @"INSERT INTO [mt].[GovUnit] ([Code] ,[GovUnitNameTh], [IsActive])

                                                VALUES ( @Code, 
                                                         @GovUnitNameTh, 
                                                         @IsActive )";

            iDP[0] = BindParameter("@Code", Code);
            iDP[1] = BindParameter("@GovUnitNameTh", Name);
            iDP[2] = BindParameter("@IsActive", 1);

            dt = conn.ExecuteReaderWithParams(SQL, iDP, _datasource);

            if (dt.Rows.Count > 0)
            {
                UserID = dt.Rows[0][0].ToString();
            }

            return UserID;
        }

        public string Insert_Document_WithAPI(Document doc)
        {

            string DocID = "";

            IDataParameter[] iDP = new IDataParameter[24];

            SQL = @"INSERT INTO [dms].[Document] ( [InputTypeID]
                                                  ,[TaskTypeID]
                                                  ,[GPFMemberID]
                                                  ,[CreateBy]
                                                  ,[CreateDate]
                                                  ,[UpdateBy]
                                                  ,[UpdateDate]
                                                  ,[Status]
                                                  ,[TransferStatus]
                                                  ,[TransferDate]
                                                  ,[Remark]
                                                  ,[IsNewCase]
                                                  ,[RefCaseID]
                                                  ,[IsSavingFund]
                                                  ,[SourceSystem]
                                                  ,[APIPrefix]
                                                  ,[APIFirstname]
                                                  ,[APILastname]
                                                  ,[DummyNumber]
                                                  ,[RunningYear]
                                                  ,[RunningNumber]
                                                  ,[CaseID]
                                                  ,[GovUnitID]
                                                  ,[RunningCase]
                                                  ,[SubmitDate]
                                                  ,[IsPreviousDMS]
                                                )

                                                VALUES (@InputTypeID, 
                                                        @TaskTypeID, 
                                                        @GPFMemberID, 
                                                        @CreateBy, 
                                                        GETDATE(), 
                                                        @UpdateBy, 
                                                        GETDATE(),
                                                        @Status,
                                                        @TransferStatus,
                                                        @TransferDate,
                                                        @Remark,
                                                        @IsNewCase,
                                                        @RefCaseID
                                                        ,@IsSavingFund
                                                      ,@SourceSystem
                                                      ,@APIPrefix
                                                      ,@APIFirstname
                                                      ,@APILastname
                                                      ,@DummyNumber
                                                      ,@RunningYear
                                                      ,@RunningNumber
                                                      ,@CaseID
                                                      ,@GovUnitID
                                                      ,@RunningCase
                                                      ,@SubmitDate
                                                      ,@IsPreviousDMS
                                                    ) SELECT SCOPE_IDENTITY()";

            iDP[0] = BindParameter("@InputTypeID", 5);
            iDP[1] = BindParameter("@TaskTypeID", doc.TaskTypeID);
            iDP[2] = BindParameter("@GPFMemberID", DBNull.Value);
            iDP[3] = BindParameter("@CreateBy", doc.CreateBy);
            iDP[4] = BindParameter("@UpdateBy", doc.UpdateBy);
            iDP[5] = BindParameter("@Status", DBNull.Value);
            iDP[6] = BindParameter("@TransferStatus", DBNull.Value);
            iDP[7] = BindParameter("@TransferDate", DBNull.Value);
            iDP[8] = BindParameter("@Remark", doc.Remark);
            iDP[9] = BindParameter("@IsNewCase", doc.IsNewCase);
            iDP[10] = BindParameter("@RefCaseID", doc.RefCaseID);
            iDP[11] = BindParameter("@IsSavingFund", DBNull.Value);
            iDP[12] = BindParameter("@SourceSystem", DBNull.Value);
            iDP[13] = BindParameter("@APIPrefix", DBNull.Value);
            iDP[14] = BindParameter("@APIFirstname", DBNull.Value);
            iDP[15] = BindParameter("@APILastname", DBNull.Value);
            iDP[16] = BindParameter("@DummyNumber", DBNull.Value);
            iDP[17] = BindParameter("@RunningYear", DBNull.Value);
            iDP[18] = BindParameter("@RunningNumber", DBNull.Value);
            iDP[19] = BindParameter("@CaseID", doc.CaseID);
            iDP[20] = BindParameter("@GovUnitID", doc.GovUnitID);
            iDP[21] = BindParameter("@RunningCase", DBNull.Value);
            iDP[22] = BindParameter("@SubmitDate", DateTime.Now);
            iDP[23] = BindParameter("@IsPreviousDMS", doc.IsPreviousDMS);

            dt = conn.ExecuteReaderWithParams(SQL, iDP, _datasource);

            if (dt.Rows.Count > 0)
            {
                DocID = dt.Rows[0][0].ToString();
            }

            return DocID;
        }

        public void UpdateDocument(Document doc)
        {
            IDataParameter[] iDP = new IDataParameter[4];
            SQL = @"UPDATE [dms].[Document]
                       SET [GPFMemberID] = @GPFMemberID, [BatchRefNo] = @BatchRefNo, [SubmitDate] = @SubmitDate
                          
                     WHERE CaseID = @CaseID";

            if (doc.MemberID != 0 && doc.MemberID !=  null)
            {
                iDP[0] = BindParameter("@GPFMemberID", doc.MemberID);
            }
            else
            {
                iDP[0] = BindParameter("@GPFMemberID", DBNull.Value);
            }

            if (!String.IsNullOrEmpty(doc.BatchRefNo))
            {
                iDP[1] = BindParameter("@BatchRefNo", doc.BatchRefNo);
            }
            else
            {
                iDP[1] = BindParameter("@BatchRefNo", DBNull.Value);
            }

            iDP[2] = BindParameter("@SubmitDate", DateTime.Now);

            iDP[3] = BindParameter("@CaseID", doc.CaseID);

            conn.ExecuteReaderWithParams(SQL, iDP, _datasource);
        }

        public void UpdateIndexFileVerifyDt_With_AttachmentDtID(IndexFileVerifyDtModel model)
        {
            IDataParameter[] iDP = new IDataParameter[3];
            SQL = @"UPDATE [temp].[IndexFileVerifyDt]
                       SET [AttachmentDtID] = @AttachmentDtID,
                            [DocumentID] = @DocumentID
                          
                     WHERE ID = @ID";

            iDP[0] = BindParameter("@AttachmentDtID", model.AttachmentDtID);
            iDP[1] = BindParameter("@DocumentID", model.DocumentID);
            iDP[2] = BindParameter("@ID", model.ID);

            conn.ExecuteReaderWithParams(SQL, iDP, _datasource);
        }
    }
}
