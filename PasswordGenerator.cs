using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PasswordGenerator
{
    public class PasswordGenerator
    {
        public string createPassword()
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

            key.Append(twoChars(2));
            key.Append(number);


            return key.ToString();
        }

        private String twoChars(int size)
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
