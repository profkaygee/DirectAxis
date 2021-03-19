using RestSharp;
using System;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using System.Text;

namespace OZOW_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var test = ContatinatedString();

            Console.ReadKey();
        }

        public static string ContatinatedString()
        {
            var siteCode = "NUDDLEPTYLTDCA4CBE54D6";
            var CountryCode = "ZA";
            var CurrencyCode = "ZAR";
            var Amount = 100.50;
            var TransactionReference = "Nuddle_Test";
            var BankReference = "Nuddle_PtyLtd";
            var Customer = "Kagiso Mahlobogoane";
            var isTest = true;
            var secretKey = "375ac8c6e5524b41a6af3fe3b8a237af";

            StringBuilder builder = new StringBuilder();

            builder.Append(siteCode);
            builder.Append(CountryCode); 
            builder.Append(CurrencyCode); 
            builder.Append(Amount); 
            builder.Append(TransactionReference); 
            builder.Append(BankReference); builder.Append(Customer); 
            builder.Append(isTest);

            builder.Append(secretKey);

            var secret = builder.ToString().ToLower();

           
            using (SHA512 shaM = new SHA512Managed())
            {
                // From string to byte array
                byte[] data = System.Text.Encoding.UTF8.GetBytes(secret);

                var hash = shaM.ComputeHash(data);                

                // From byte array to string
                var encryptedString = System.Text.Encoding.UTF8.GetString(hash, 0, hash.Length);
            }

            var client = new RestClient("https://pay.ozow.com");

            var requestLink = "";
            var request = new RestRequest("", Method.POST);

        }
    }
}