using System;

namespace DMSUpload_Helper.Models
{
    public class GovUnitModel
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string GovUnitMain { get; set; }
        public string GovUnitNameTh { get; set; }
        public string GovUnitNameEn { get; set; }
        public int IsActive { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime UpdateDate { get; set; }

    }
}
