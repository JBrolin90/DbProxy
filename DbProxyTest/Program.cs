using DbProxy;
using DbProxy.SqlServer;
using System.Data;

namespace DbProxyTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World from DbProxy!");
            Console.WriteLine();
            // Print current directory
            Console.WriteLine("Current directory: " + Environment.CurrentDirectory);

            IDbProxy dbProxy = new SqlServerProxy(Secrets.HEMS_Econ_connectionString);

            new ClassFromTable(dbProxy, "Employees", "MyNameSpace").Print();
            new ClassFromTable(dbProxy, "Employees", "MyNameSpace").SaveToFile();
            new ClassFromTable(dbProxy, "Schedules", "MyNameSpace").SaveToFile();
            new ClassFromTable(dbProxy, "Customers", "MyNameSpace").SaveToFile();

            string allTables = new BaseTables(dbProxy).ToString();
            Console.WriteLine(allTables);

            DbTableCrud dbTableCrud = new DbTableCrud(dbProxy, "TestTable");
            DataTable dataTable = dbTableCrud.Read();
            Console.WriteLine(dataTable.Rows.Count);
            Console.WriteLine(dataTable.Columns.Count);
            Console.WriteLine(dataTable.Rows[0][0]);
            dataTable.Rows[0][1] = "New Value";
            dbTableCrud.CreateUpdateDelete();

        }
    }
}
