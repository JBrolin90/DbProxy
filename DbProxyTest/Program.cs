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

            IDbProxy dbProxy = new SqlServerProxy(Secrets.HEMS_Econ_connectionString);

            new ClassFromTable(dbProxy, "Employees", "MyNameSpace").Print();
            new ClassFromTable(dbProxy, "Employees", "MyNameSpace").SaveToFile();
            new ClassFromTable(dbProxy, "Schedules", "MyNameSpace").SaveToFile();

            string allTables = new BaseTables(dbProxy).ToString();
            Console.WriteLine(allTables);
        }
    }
}
