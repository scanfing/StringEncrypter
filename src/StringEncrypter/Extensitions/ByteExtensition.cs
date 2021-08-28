using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringEncrypter.Extensitions
{
    public static class ByteExtensition
    {
        #region Methods

        /// <summary>
        /// 将 <see cref="byte[]"/> 转换为 16进制字符串
        /// </summary>
        /// <param name="buff">原始byte数组</param>
        /// <param name="splitStr">分割字符串</param>
        /// <returns></returns>
        public static string ToHexString(this byte[] buff, string splitStr = null)
        {
            var sBuilder = new StringBuilder();
            for (int i = 0; i < buff.Length; i++)
            {
                sBuilder.Append(buff[i].ToString("x2"));
                sBuilder.Append(splitStr);
            }
            return sBuilder.ToString();
        }

        #endregion Methods
    }
}