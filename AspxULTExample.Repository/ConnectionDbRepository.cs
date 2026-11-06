
    using System;
    using System.Configuration;
    using System.Data;
    using System.Data.Common;
    using System.Data.SqlClient;
    using System.Collections.Generic;
    using System.Linq;
    using Dapper;
    using System.Web;
    using System.Text;
    using System.IO;
    using AspxULTExample.Models;
    using AspxULTExample.Models.Interface;

    namespace AspxULTExample.Repository
    {

    public class ConnectionDb
    {

    public ConnectionDb() { }

    private static string connString = ConfigurationManager.ConnectionStrings["ULTExampleDb"].ConnectionString;

    public static SqlConnectionStringBuilder ConnectionString => new SqlConnectionStringBuilder(connString);

    public static DbConnection LiveConnection()
    {
    var connection = new SqlConnection(connString);
    connection.Open();
    return connection;
    }

    public static bool CloseConnection(DbConnection connection)
    {
    if (connection.State != ConnectionState.Closed)
    {
    connection.Close();
    // connection.Dispose();
    }
    return true;
    }

    private static void ClearPool()
    {
    SqlConnection.ClearAllPools();
    }

    public static void Dispose()
    {
    ClearPool();
    }

    }

    }
  