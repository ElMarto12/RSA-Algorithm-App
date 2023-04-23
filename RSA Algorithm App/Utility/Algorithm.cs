using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSA_Algorithm_App.Utility
{
    public static class Algorithm
    {
        private static int e = 17;
        
        public static int E
        {
            get { return e; }
            set { e = value; }
        }
        
        //Calculates n 
        public static int findN(int p, int q)
        {
            int result;

            return result = p * q;
        }

        //Calculates phi
        public static int findF(int p, int q)
        {
            int result; 
            
            return result = (p - 1) * (q - 1);
        }

        public static int modulePow(int bse, int pwr, int module)
        {
            int result = 1;

            bse %= module;

            while(pwr > 0)
            {
                if((bse & 1) == 1)
                {
                    result = (result * bse) % module;
                }

                pwr >>= 1;
                bse = (bse * bse) % module;
            }

            return result;
        }

        public static string cypherText(string text, int n)
        {
            string cypherResult = "";

            for (int i = 0; i < text.Length; i++)
            {
                int ascii = (int)text[i];
                int cypherAscii = modulePow(ascii, e, n);
                cypherResult += Convert.ToChar(cypherAscii);
            }

            return cypherResult;
        }

        public static int greatestCommonDivisor(int a , int b)
        {
            while(b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }

            return a;
        }
    }
}
