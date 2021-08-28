using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace StringEncrypter.Encrypters
{
    public class AES : RijndaelEncrypter
    {
        #region Constructors

        public AES()
        {
            CanDecrypt = true;
            KeyLength = 32;
            RijndaelManaged.Padding = PaddingMode.Zeros;
        }

        #endregion Constructors
    }
}