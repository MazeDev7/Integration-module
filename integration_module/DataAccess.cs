using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Project1
{
    public class DataAccess
    {
        private List<DatabaseMapping> DbMappings;

        public DataAccess()
        {
            this.DbMappings = new List<DatabaseMapping>();
            foreach (var map in MappingsProvider.GetMappings())
            {
                AddDbMapping(map);
            }
        }

        private void AddDbMapping(DatabaseMapping Mapping)
        {
            DbMappings.Add(Mapping);  
        }

        public StringBuilder ExecuteQueries(string QueryText)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var map in DbMappings)
            {
                string query = GetQuery(QueryText, map);

                using (SqlCommand command = new SqlCommand(query, map.Connection))
                {
                    map.Connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    // This will return false - just want to make sure the schema table is there.
                    reader.Read();

                    var tableSchema = reader.GetSchemaTable();

                    string columns = "";

                    // Each row in the table schema describes a column
                    foreach (DataRow row in tableSchema.Rows)
                    {
                        columns += row["ColumnName"] + " | ";
                    }
                    // print schema
                    sb.AppendLine("");
                    sb.AppendLine(columns);
                    sb.AppendLine("");

                    // go through reader and print query results
                    while (reader.Read())
                    {
                        string rowData = "";
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            if (i == reader.FieldCount - 1)
                            {
                                rowData += reader[i];
                            }
                            else
                            {
                                rowData += reader[i] + ", ";
                            }
                        }
                        sb.AppendLine(rowData);
                    }
                    reader.Close();
                    map.Connection.Close();
                }
            }
            return sb;
        }

        private string GetQuery(string QueryText, DatabaseMapping Mapping)
        {
            foreach (var m in MappingsProvider.GetGlobalNames())
            {
                //Using regex replace so that the case doesn't need to match
                QueryText = Regex.Replace(QueryText, m, Mapping.GetLocalName(m), RegexOptions.IgnoreCase);
            }
            return QueryText;
        }
    }
}
