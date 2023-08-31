using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMSUpload_Helper.Models
{
    public class Download
    {
        public string FileName { get; set; }
        public string Extension { get; set; }
        public string FileBase64 { get; set; } = String.Empty;
        public string salt { get; set; } = String.Empty;
        public string IDCard { get; set; }
        public string AttachmentTypeCode { get; set; }
    }

}
