using MySqlX.XDevAPI.Common;
using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RSA_Algorithm_App.Utility
{
    public class Algorithm : CalculateRSA
    {
        private int n;
        private int phi;
        private int e;
        private int d;

        public int D
        {
            set { d = value; }
            get { return d; }
        }
        public int N
        {
           get { return n; }
           set { n = value; }
        }

        public int Phi
        {
            get { return phi; }
            set { phi = value; }
        }

        public int E
        {
            get { return e; }
            set { e = value; }
        }

        public string Encrypt(string text, int e, int n)
        {
            byte[] unicodeBytes = Encoding.Unicode.GetBytes(text);

            List<int> encrypted = new List<int>();
            foreach (byte b in unicodeBytes)
            {
                encrypted.Add(ModuloPower(b, e, n));
            }

            StringBuilder sb = new StringBuilder();
            foreach (int num in encrypted)
            {
                sb.Append(num.ToString()).Append(' ');
            }

            return sb.ToString().TrimEnd();
        }
        public string Decrypt(string text, int d, int n)
        {
            List<byte> decrypted = new List<byte>();
            string[] numbers = text.Trim().Split(' ');
            foreach (string num in numbers)
            {
                if (!string.IsNullOrEmpty(num))
                {
                    int encryptedByte = int.Parse(num);
                    decrypted.Add((byte)ModuloPower(encryptedByte, d, n));
                }
            }

            string decryptedMessage = Encoding.Unicode.GetString(decrypted.ToArray());

            return decryptedMessage;
        }
    }
        
}
