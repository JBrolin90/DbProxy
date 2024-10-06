using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbProxy;

public class ClassFromTable
{
    private DataTable dataTable { get; set; }
    private string nameSpace { get; set; }
    public ClassFromTable(IDbProxy dbProxy, string tableName, string nameSpace)
    {
        dataTable = new DbTableCrud(dbProxy, tableName).Read();
        this.nameSpace = nameSpace;
    }
    public ClassFromTable(IDbProxy dbProxy, DataTable dataTable, string nameSpace)
    {
        this.dataTable = dataTable;
        this.nameSpace = nameSpace;
    }

    private string getClassString(DataTable table, string nameSpace = "")
    {
        StringBuilder sb = new StringBuilder();

        if (nameSpace != "") sb.AppendLine("namespace " + nameSpace + ";");

        sb.AppendLine("public class " + table.TableName);
        sb.AppendLine("{");
        foreach (DataColumn column in table.Columns)
        {
            sb.Append("  public " + column.DataType.Name + " " + column.ColumnName + " { get; set; }");
            if (column.DataType.Name == "String") sb.Append(" = string.Empty;");
            sb.AppendLine();
        }
        sb.AppendLine("}");
        return sb.ToString();
    }

    public override string ToString() => getClassString(dataTable, nameSpace);

    public void Print() => Console.WriteLine(ToString());
    public void SaveToFile(string path = "")
    {

        string fullFilename = System.IO.Path.Combine(path, dataTable.TableName + ".cs");
        System.IO.File.WriteAllText(fullFilename, ToString());
    }

}