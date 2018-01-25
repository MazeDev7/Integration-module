using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public static class MappingsProvider
    {
        public static List<DatabaseMapping> GetMappings()
        {
            List<DatabaseMapping> DbMappings = new List<DatabaseMapping>();

            //Initialise Database 1
            DatabaseMapping Db1 = new DatabaseMapping(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ali\Downloads\Project1\Database2.mdf;Integrated Security=True");

            //Db1 Tables
            Db1.AddTableMapping("Cars", "Cars");
            Db1.AddTableMapping("Customers", "Customer");
            Db1.AddTableMapping("Rentals", "Rentals");

            //Cars Columns
            Db1.AddColumnMapping("Cars", "G-Vin", "VinNum");
            Db1.AddColumnMapping("Cars", "G-Make", "Maker");
            Db1.AddColumnMapping("Cars", "G-Year", "Year");
            Db1.AddColumnMapping("Cars", "G-Type", "NULL AS [Type]");
            Db1.AddColumnMapping("Cars", "G-Color", "Color");
            Db1.AddColumnMapping("Cars", "G-NumOfPassengers", "NumOfPasger");
            Db1.AddColumnMapping("Cars", "G-Price", "DailyRentalPrice");

            //Customers Columns
            Db1.AddColumnMapping("Customers", "G-License", "License");
            Db1.AddColumnMapping("Customers", "G-FullName", "FirstName + ' ' + MiddleName + ' ' + LastName AS [full_name]");
            Db1.AddColumnMapping("Customers", "G-FullAddress", "Street + ', ' + City + ', ' + State + ', ' + ZipCode AS [full_address]");
            Db1.AddColumnMapping("Customers", "G-Age", "NULL AS [Age]");

            //Rentals Columns
            Db1.AddColumnMapping("Rentals", "G-Vin", "VinNum");
            Db1.AddColumnMapping("Rentals", "G-License", "License");
            Db1.AddColumnMapping("Rentals", "G-StartDate", "CAST(StartRentDate AS DATE) AS [StartDate]");
            Db1.AddColumnMapping("Rentals", "G-NumberOfDays", "DATEDIFF(DAY,CAST(StartRentDate AS DATE),CAST(EndDate AS DATE)) AS [NumberOfDays]");
            Db1.AddColumnMapping("Rentals", "G-Discount", "Discount");

            DbMappings.Add(Db1);

            //Initialise Database 1
            DatabaseMapping Db2 = new DatabaseMapping(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ali\Downloads\Project1\Database1.mdf;Integrated Security=True");

            //Db2 Tables
            Db2.AddTableMapping("Cars", "Cars");
            Db2.AddTableMapping("Customers", "Customers");
            Db2.AddTableMapping("Rentals", "Rentals");

            //Cars Columns
            Db2.AddColumnMapping("Cars", "G-Vin", "Vin");
            Db2.AddColumnMapping("Cars", "G-Make", "NULL AS [Make]");
            Db2.AddColumnMapping("Cars", "G-Year", "CAST(Year AS VARCHAR(10)) AS [Year]");
            Db2.AddColumnMapping("Cars", "G-Type", "Type");
            Db2.AddColumnMapping("Cars", "G-Color", "NULL AS [Color]");
            Db2.AddColumnMapping("Cars", "G-NumOfPassengers", "NULL AS [NumberOfPassengers]");
            Db2.AddColumnMapping("Cars", "G-Price", "Price");

            //Customers Columns
            Db2.AddColumnMapping("Customers", "G-License", "Drivers_License");
            Db2.AddColumnMapping("Customers", "G-FullName", "Full_name");
            Db2.AddColumnMapping("Customers", "G-FullAddress", "Full_Address");

            Db2.AddColumnMapping("Customers", "G-Age", "DATEDIFF(YEAR, DOB,GETDATE()) AS [Age]");

            //Rentals Columns
            Db2.AddColumnMapping("Rentals", "G-Vin", "Vin");
            Db2.AddColumnMapping("Rentals", "G-License", "Drivers_License");
            Db2.AddColumnMapping("Rentals", "G-StartDate", "Start_Rental_Date");
            Db2.AddColumnMapping("Rentals", "G-NumberOfDays", "DATEDIFF(DAY,start_rental_date,end_rental_date) AS [NumberOfDays]");
            Db2.AddColumnMapping("Rentals", "G-Discount", "NULL AS [Discount]");

            DbMappings.Add(Db2);

            //Return
            return DbMappings;
        }

        public static List<string> GetGlobalNames()
        {
            return new List<string> { "Cars", "Customers", "Rentals", "G-Vin", "G-Make", "G-Year", "G-Type", "G-Color", "G-NumOfPassengers", "G-Price", "G-License", "G-FullName", "G-FullAddress", "G-Age", "G-Vin", "G-License", "G-StartDate", "G-NumberOfDays", "G-Discount" };
        }

        public static char[] GetSplitCharacters()
        {
            return new char[] { ' ', ',', '.', ':', '\t' };
        }
    }
}
