using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HPA.Common
{
    class Encryption
    {
        public string EncryptionString(string inputVal)
        {
            string returnValue = string.Empty;
            byte[] EncodeAsBytes = System.Text.Encoding.Unicode.GetBytes(inputVal);

            returnValue = System.Convert.ToBase64String(EncodeAsBytes);
            return returnValue;
        }
        public string DecryptionString(string inputVal)
        {
            string returnValue = string.Empty;
            byte[] encodedDataAsBytes = System.Convert.FromBase64String(inputVal);
            returnValue = System.Text.Encoding.Unicode.GetString(encodedDataAsBytes);
            return returnValue;
        }
    }
}
