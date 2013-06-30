using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace RandomPasswordGeneratorWPF
{
    public class PasswordGenerator
    {
        public string CreatePassword()
        {
            string strPwdchar = "abcdefghijklmnopqrstuvwxyz0123456789#+@&$!?*ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int charNum = 8;
            StringBuilder key = new StringBuilder(charNum);
            Random rmNum = new Random();
            int number = rmNum.Next(1, 5000);
            for (int i = 0; i <= charNum; i++)
            {
                int randNum = rmNum.Next(0, strPwdchar.Length - 1);
                key.Append(strPwdchar.Substring(randNum, 1));
            }

            key.Append(TwoChars(2));
            key.Append(number);


            return key.ToString();
        }

        public string CalcMD5Hash(string pwd)
        {
            MD5 md5 = MD5.Create();
            StringBuilder sb = new StringBuilder();

            byte[] hash = md5.ComputeHash(Encoding.ASCII.GetBytes(pwd));

            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }

            return sb.ToString();
        }

        private String TwoChars(int size)
        {
            StringBuilder stringObtained = new StringBuilder();
            Random rm = new Random();

            char charKey;

            for (int i = 0; i < size; i++)
            {
                charKey = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * rm.NextDouble() + 65)));
                stringObtained.Append(charKey);
            }

            return stringObtained.ToString();
        }
    }
}
