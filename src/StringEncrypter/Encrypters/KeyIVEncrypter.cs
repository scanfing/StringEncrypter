using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace StringEncrypter.Encrypters
{
    public abstract class KeyIVEncrypter : Encrypter
    {
        #region Constructors

        public KeyIVEncrypter()
        {
            Encoding = Encoding.Unicode;
        }

        #endregion Constructors

        #region Properties

        public byte[] IV { get; set; }

        public string IVStr
        {
            get => Encoding.GetString(IV);
            set => IV = Encoding.GetBytes(value);
        }

        public byte[] Key { get; set; }

        public string KeyStr
        {
            get => Encoding.GetString(Key);
            set
            {
                Key = Encoding.GetBytes(value);
            }
        }

        #endregion Properties

        #region Methods

        public override string Decrypt(string str)
        {
            var cTransform = CreateDecryptor();
            byte[] data = Convert.FromBase64String(str);
            byte[] outputbuff = cTransform.TransformFinalBlock(data, 0, data.Length);
            return Encoding.GetString(outputbuff);
        }

        public override string Encrypt(string str)
        {
            byte[] data = Encoding.GetBytes(str);
            ICryptoTransform cTransform = CreateEncryptor();
            byte[] outputbuff = cTransform.TransformFinalBlock(data, 0, data.Length);
            return Convert.ToBase64String(outputbuff);

            //byte[] data = Encoding.GetBytes(str);
            //MemoryStream MStream = new MemoryStream();
            //CryptoStream CStream = new CryptoStream(MStream, ict, CryptoStreamMode.Write);
            //CStream.Write(data, 0, data.Length);
            //CStream.FlushFinalBlock();
            //return Convert.ToBase64String(MStream.ToArray());
        }

        protected abstract ICryptoTransform CreateDecryptor();

        protected abstract ICryptoTransform CreateEncryptor();

        #endregion Methods
    }
}