using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMSUpload_Helper.Models
{
    public class TextFormatModel
    {
        public TextFormatModel() { }
        public string FileName { get; set; }
        public string DocName { get; set; }
        public string CitizenID { get; set; }
        public string MemberID { get; set; }
        public string CaseNumber { get; set; }
        public string FileNumber { get; set; }
    }
}
