# Integration-module

# Scope Overview
The goal of this project is to create a system that can communicate between multiple databases using an integration module.
The main program within the system will receive a global query as input. The program will then forward this query to the integration module. The integration module will contain a global schema to correspond to all connected databases. The integration module will the convert the given query to the appropriate local query for each database. It will retrieve the results and print the results to the screen.

# Software Used
This system was built in the C# language. It uses ADO.NET for the database access and manipulation. The .NET framework was used for all other methods.

# Design Overview
The application program here is the program.cs file. The integration module is a combination of classes called DataAccess.cs, Mappings_Classes.cs, and Mappings_Provider.cs.
The Program.cs will receive the global query from the user. Program.cs will then call the integration module by instantiating a new object of the DataAccess.cs class.
The integration module work with mapping. It will take all the locally stored information in Mappings_Provider.cs and create a Mapping object from Mappings_Classes.cs. This mapping object will allow you to take a global query, and use mapping to translate that query into the local query for that database.
The DataAccess.cs would then take the local queries and send them to it’s local database. The results will be returned and displayed on the screen.
