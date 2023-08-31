using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMSUpload_Helper.Models
{
    public class VerifyMessageModel
    {
        public int status { get; set; }
        public int VerifyStatusDT { get; set; }
        public int VerifyStatus { get; set; }
        public string message { get; set; }
    }
}
