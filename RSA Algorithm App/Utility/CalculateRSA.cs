using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSA_Algorithm_App.Utility
{
    public class CalculateRSA
    {
        public int CalculatePhi(int p,  int q)
        {
            return (p - 1) * (q - 1);
        }
        public int CalculateN(int p, int q)
        {
            return p * q;
        }
        public int CalculateE(int phi, int n)
        {
            Random rnd = new Random();
            int e = rnd.Next(2,phi);
            while (true)
            {
                if (IsPrime(e, phi) && IsPrime(e, n))
                {
                    return e;
                }
                
                e++;
                
                
            }
        }
        public int ModuloPower(int a,  int b, int n)
        {
            int result = 1;

            while(b > 0)
            {
                if (b % 2 == 1)
                {
                    result = (result * a) % n;

                }
                
                    a = (a * a) % n;
                    b = b / 2;
                
            }

            return result;
        } 
        public int ModuloInverse(int a, int m)
        {
            int m0 = m;
            int y = 0, x = 1;

            if(m == 1)
            {
                return 0;
            }

            while(a > 1)
            {
                int q = a / m;
                int t = m;

                m = a % m;
                a = t;
                t = y;

                y = x - q * y;
                x = t;
            }

            if(x < 0)
            {
                x += m0;
            }

            return x;
        }
        public bool IsPrime(int e, int phi)
        {
           while (phi != 0)
           {
                int temp = phi;
                phi = e % phi;
                e = temp;
           }

            return e == 1;
        }
    }
}
