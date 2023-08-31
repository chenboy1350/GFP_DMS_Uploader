using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMSUpload_Helper.Models
{
    public class BatchFileStatus
    {
        public int IsFound { get; set; }
        public string msg { get; set; }
        public string base64 { get; set; }
        public string FileName { get; set; }
        public string FileExt { get; set; }
    }

}
