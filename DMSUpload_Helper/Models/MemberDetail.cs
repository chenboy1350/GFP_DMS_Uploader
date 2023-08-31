using System;

namespace DMSUpload_Helper.Models
{
    public class MemberDetail
    {
        public string CitizenID { get; set; }
        public string MemberID { get; set; }
        public string TitleName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmployerName { get; set; }
        public string Code { get; set; }
        public DateTime CommencementDate { get; set; }
        public DateTime JoinedFundDate { get; set; }
    }
}
