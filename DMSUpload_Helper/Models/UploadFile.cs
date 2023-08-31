using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMSUpload_Helper.Models
{
    public class UploadFile
    {
        public IFormFile File { get; set; }
        public string FileName { get; set; }
        public string DocumentName { get; set; }
        public string FileExt { get; set; }
        public double FileSize { get; set; }
        public string MenuName { get; set; }
        public string MemberCode { get; set; }
        public int TaskSubType2ID { get; set; }
        public int AttachmentTypeID { get; set; }
        public string GPFMemberID { get; set; }
        public string IDCard { get; set; }
        public string AttachmentTypeCode { get; set; }
        public int DocumentID { get; set; }
        public int UploadType { get; set; }
        public int TaskSubTypeID { get; set; }
        public int TaskTypeID { get; set; }


    }

}
