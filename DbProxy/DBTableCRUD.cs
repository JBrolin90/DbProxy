using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbProxy;

public class DbTableCrud
{
    public DbConnection connection { get; }
    public DbCommand command { get; }
    public DbDataAdapter adapter { get; }
    public DbCommandBuilder commandBuilder { get; }
    public DataSet dataSet { get; }
    public string tableName { get; }

    public IDbProxy dbProxy { get; set; }
    public DbTableCrud(IDbProxy dbProxy, string tableName)
    {
        this.dbProxy = dbProxy;
        this.connection = dbProxy.connection;
        this.command = dbProxy.command;
        this.command.CommandText = "SELECT * FROM " + tableName;
        this.command.Connection = this.connection;
        this.adapter = dbProxy.adapter;
        this.commandBuilder = dbProxy.commandBuilder;
        this.tableName = tableName;
        this.dataSet = new DataSet();
    }
    public DbTableCrud(IDbProxy dbProxy, DataSet dataSet, string tableName)
    {
        this.dbProxy = dbProxy;
        this.connection = dbProxy.connection;
        this.command = dbProxy.command;
        this.command.CommandText = "SELECT * FROM " + tableName;
        this.command.Connection = this.connection;
        this.adapter = dbProxy.adapter;
        this.commandBuilder = dbProxy.commandBuilder;
        this.tableName = tableName;
        this.dataSet = dataSet;
    }
    public DbTableCrud(IDbProxy dbProxy, DbCommand command, string tableName)
    {
        this.dbProxy = dbProxy;
        this.connection = dbProxy.connection;
        this.command = command;
        this.command.Connection = this.connection;
        this.adapter = dbProxy.adapter;
        this.commandBuilder = dbProxy.commandBuilder;
        this.tableName = tableName;
        this.dataSet = new DataSet();
    }

    public DataTable Read()
    {
        connection.Open();
        adapter.SelectCommand = command;
        adapter.Fill(dataSet, tableName);
        connection.Close();
        return dataSet.Tables[tableName] ?? throw new NullReferenceException();
    }
    public void CreateUpdateDelete()
    {
        // Reconcile the changes in the DataTable tableName with the database
        if (dataSet.Tables[tableName] == null) return;
        if (adapter.SelectCommand == null) return;
        connection.Open();
        adapter.UpdateCommand = commandBuilder.GetUpdateCommand();
        adapter.DeleteCommand = commandBuilder.GetDeleteCommand();
        adapter.InsertCommand = commandBuilder.GetInsertCommand();
        adapter.Update(dataSet, tableName);
        connection.Close();
    }
}