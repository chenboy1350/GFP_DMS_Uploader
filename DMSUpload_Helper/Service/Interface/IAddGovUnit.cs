using DMSUpload_Helper.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMSUpload_Helper.Service.Interface
{
    public interface IAddGovUnit
    {
        void AddNewGovUnit(GovUnitModel data);
    }

    public interface DMS_IAddGovUnit
    {
        string Insert_GovUnit(GovUnitModel data);
    }
}
