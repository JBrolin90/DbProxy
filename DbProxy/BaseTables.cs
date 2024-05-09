using DbProxy;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbProxyTest;

public class BaseTables
{
    private IDbProxy dbProxy;
    public BaseTables(IDbProxy dbProxy)
    {
        this.dbProxy = dbProxy;
    }

    // Retrieve all base tables from the database
    public List<string> RetrieveAllBaseTables()
    {
        DataTable baseTables = new DbTableCrud(dbProxy, dbProxy.BaseTablesCommand(), "baseTables").Read();

        List<string> list = new List<string>();
        foreach (DataRow row in baseTables.Rows)
        {
            Console.WriteLine(row["TABLE_NAME"]);
            list.Add(row["TABLE_NAME"].ToString() ?? throw new NullReferenceException());
        }
        return list;
    }
    public bool Empty(string tableName)
    {
        DataTable table = new DbTableCrud(dbProxy, tableName).Read();
        return table.Rows.Count == 0;
    }
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        foreach (string table in RetrieveAllBaseTables())
        {
            sb.AppendLine(table);
        }
        return sb.ToString();

    }

}


