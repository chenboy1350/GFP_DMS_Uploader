using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMSUpload_Helper.Models
{
    public class DownloadFile
    {
        public string FileName { get; set; }
        public string DocumentName { get; set; }
        public string FileExt { get; set; }

        public string MenuName { get; set; }
        public string StringBase64 { get; set; } = string.Empty;
        public string MemberCode { get; set; }
        public string salt { get; set; } = String.Empty;
        public string IDCard { get; set; }
        public string AttachmentTypeCode { get; set; }
        public string CaseID { get; set; }
        public string Menu { get; set; }
        public string Status { get; set; }
        public Byte[] FileBytes { get; set; }
        public int CurrentYear { get; set; }
        public int RunningYear { get; set; }
        public int TaskTypeID { get; set; } = 0;
    }

}
