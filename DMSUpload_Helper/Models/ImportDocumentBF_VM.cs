using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMSUpload_Helper.Models
{
    public class ImportDocumentBF_VM
    {
        public int ID { get; set; }
        public int DocumentID { get; set; }
        public string FileName { get; set; }
        public string FileExt { get; set; }
        public int Year { get; set; }
        public IFormFile File { get; set; }
        public string allname { get; set; }
        public int GetMaxID { get; set; }
    }
}
