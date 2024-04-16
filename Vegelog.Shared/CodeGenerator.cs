using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vegelog.Shared
{
    public static class CodeGenerator
    {
        public static string Run()
        {
            string lowerCase = "abcdefghijklmnopqrstuvwxyz";
            string upperCase = "abcdefghijklmnopqrstuvwxyz".ToUpper();
            string number = "0123456789";
            StringBuilder sb = new StringBuilder();
            while (true)
            {
                if (sb.Length == 11)
                {
                    string tmpCode = sb.ToString();
                    if (tmpCode.Any(a => char.IsDigit(a)) && tmpCode.Any(a => char.IsUpper(a)) && tmpCode.Any(a => char.IsLower(a)))
                    {
                        break;
                    }
                    else
                    {
                        sb.Clear();
                    }
                }
                switch (Random.Shared.Next() % 3)
                {
                    case 0:
                        sb.Append(lowerCase[Random.Shared.Next(0, lowerCase.Length)]);
                        break;
                    case 1:
                        sb.Append(upperCase[Random.Shared.Next(0, upperCase.Length)]);
                        break;
                    case 2:
                        sb.Append(number[Random.Shared.Next(0, number.Length)]);
                        break;
                }
            }
            return sb.ToString();
        }
    }
}
