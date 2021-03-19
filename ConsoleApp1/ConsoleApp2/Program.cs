using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            var cultureInfos = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            var countries = new List<string>();

            foreach (var info in cultureInfos)
            {
                var regionalInfo = new RegionInfo(info.LCID);

                if (!countries.Contains(regionalInfo.EnglishName) && !regionalInfo.EnglishName.ToLower().Equals("south africa"))
                {
                    countries.Add(regionalInfo.EnglishName);
                }
            }

            // Add to the database here
            string countriesInsert = "INSERT INTO Countries (CountryName,Active,TimeStamp) Values (@CountryName,1,GETDATE());";

            foreach (var country in countries)
            {
                using (var connection = new SqlConnection("Server=KAGISOCV-NB;Database=Nuddle;Trusted_Connection=True;"))
                {
                    var affectedRows = connection.Execute(countriesInsert, new { CountryName = country });
                    Console.WriteLine($"Country [{country}] has been added successfully,");
                }
            }
        }
    }
}
