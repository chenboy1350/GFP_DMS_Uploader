using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMSUpload_Helper.Service.Interface
{
    internal interface IDetectEncode
    {
        Encoding DetectEncoding(byte[] fileBytes);
    }
}
