using DMSUpload_Helper.Service.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMSUpload_Helper.Service.Implement
{
    public class DetectEncode : IDetectEncode
    {
        public Encoding DetectEncoding(byte[] fileBytes)
        {
            Encoding[] encodings = {
                Encoding.UTF8,
                Encoding.GetEncoding(874),
            };

            foreach (Encoding encoding in encodings)
            {
                if (IsEncodingCorrect(fileBytes, encoding))
                {
                    return encoding;
                }
            }

            throw new NotSupportedException("No suitable encoding was detected for the provided byte array.");
        }

        public static bool IsEncodingCorrect(byte[] fileBytes, Encoding encoding)
        {
            try
            {
                string testString = encoding.GetString(fileBytes);
                byte[] reencodedBytes = encoding.GetBytes(testString);

                return StructuralComparisons.StructuralEqualityComparer.Equals(fileBytes, reencodedBytes);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
