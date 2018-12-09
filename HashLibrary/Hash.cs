using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace HashLibrary
{
    public static class Hash
    {
        /// <summary>
        /// Create MD5 hash from string.
        /// </summary>
        /// <param name="inputText">string that will be converted to MD5 Hash.</param>
        /// <returns>MD5 string</returns>
        public static string MakeMd5(string inputText)
        {
            MD5 md5 = MD5.Create();
            byte[] data = md5.ComputeHash(Encoding.UTF8.GetBytes(inputText));

            StringBuilder builder = new StringBuilder();

            foreach (var item in data)
            {
                builder.Append(item.ToString("x2"));
            }

            return builder.ToString();
        }
    }
}
