using System;
using DbProxy;
using DbProxy.SqlServer;

namespace Login.Models;

public class CredentialsModel
{
    public string Server { get; set; } = "localhost";
    public string Database { get; set; } = "master";
    public string Username { get; set; } = "sa";
    public string Password { get; set; } = "P@ssw0rd!";
}

public class DatabaseModel
{
    private CredentialsModel? _credentials;

    public DatabaseModel()
    {
    }
    public void Login(CredentialsModel credentials)
    {
        _credentials = credentials;
        string connectionString = $"Data Source={credentials.Server}; ";
        connectionString += $"User ID={credentials.Username}; ";
        connectionString += $"Password={credentials.Password}; ";
        connectionString += $"Database={credentials.Database}; ";
        connectionString += $"Connect Timeout=30;Encrypt=True; ";
        connectionString += $"Trust Server Certificate=True; ";
        connectionString += $"Application Intent=ReadWrite; ";
        connectionString += $"Multi Subnet Failover=False ";
        Console.WriteLine(connectionString);

        IDbProxy dbProxy = new SqlServerProxy(connectionString);

    }
}


