using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class DatabaseMapping
    {
        public SqlConnection Connection;

        private List<TableMapping> TableMappings;

        public DatabaseMapping(string ConnectionStringText)
        {
            this.Connection = new SqlConnection(ConnectionStringText);
            this.TableMappings = new List<TableMapping>();
        }

        public void AddTableMapping(string TableNameFromUser, string TableNameInDB)
        {
            this.TableMappings.Add(new TableMapping { UserTableName = TableNameFromUser, DatabaseTableName = TableNameInDB });
        }

        public void AddColumnMapping(string TableNameFromUser, string ColumnNameFromUser, string ColumnNameInDB)
        {
            var columnMappings = this.TableMappings
                .Where(x => x.UserTableName.Equals(TableNameFromUser, StringComparison.OrdinalIgnoreCase))
                .First().ColumnMappings;

                columnMappings.Add(new ColumnMapping
                    {
                        UserColumnName = ColumnNameFromUser,
                        DatabaseColumnName = ColumnNameInDB
                    });
        }

        public string GetLocalName(string GlobalName)
        {
            foreach (var tableMap in TableMappings)
            {
                if (tableMap.UserTableName.Equals(GlobalName, StringComparison.OrdinalIgnoreCase))
                    return tableMap.DatabaseTableName;
                foreach (var columnMap in tableMap.ColumnMappings)
                {
                    if (columnMap.UserColumnName.Equals(GlobalName, StringComparison.OrdinalIgnoreCase))
                        return columnMap.DatabaseColumnName;
                }
            }
            //No mappings were found, return global name
            return GlobalName;
        }
    }

    class TableMapping
    {
        public string UserTableName { get; set; }
        public string DatabaseTableName { get; set; }
        public List<ColumnMapping> ColumnMappings { get; set; }
        public TableMapping()
        {
            this.ColumnMappings = new List<ColumnMapping>();
        }
    }

    class ColumnMapping
    {
        public string UserColumnName { get; set; }
        public string DatabaseColumnName { get; set; }
    }
}
