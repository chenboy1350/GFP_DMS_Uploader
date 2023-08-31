using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMSUpload_Helper.Models
{
    public class DeleteFile
    {
        public string FileName { get; set; }
        public string FileExt { get; set; }
        public string MenuName { get; set; }
        public string MemberCode { get; set; }
        public string IDCard { get; set; }
        public string AttachmentTypeCode { get; set; }
        public int TaskTypeID { get; set; } = 0;
        public int CurrentYear { get; set; } = 0;
    }

}
