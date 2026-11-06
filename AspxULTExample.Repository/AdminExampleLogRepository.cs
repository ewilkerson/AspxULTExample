
    using System;
    using System.Collections.Generic;
    using System.Data;
    using Dapper;
    using System.IO;
    using System.Web;
    using System.Xml.Serialization;
    using System.Linq;
    using AspxULTExample.Models;
    using AspxULTExample.Models.Interface;

    namespace AspxULTExample.Repository
    {

    
    public partial class AdminExampleLogRepository : IExampleLogRepository
    {

    #region AdminExampleLogRepository

    public IEnumerable<ExampleLog> GetExampleLogs()
    {
    List <ExampleLog> exampleLogLists = new List<ExampleLog>();

    using (var connection = ConnectionDb.LiveConnection())
    {
    try
    {
    using (var reader = connection.ExecuteReader(sql: "[dbo].[usp_AdminGetExampleLogs]"))
    {

    while (reader.Read())
    {
    ExampleLog exampleLog = new ExampleLog();
    			if(reader["ExampleLogID"] != DBNull.Value)
				exampleLog.ExampleLogID = int.Parse(reader["ExampleLogID"].ToString());
			if(reader["ExampleID"] != DBNull.Value)
				exampleLog.ExampleID = int.Parse(reader["ExampleID"].ToString());
			exampleLog.LogMessage = reader["LogMessage"].ToString();

    exampleLogLists.Add(exampleLog);
    }
    }
    }
    catch (Exception exception)
    {
    Log4ExceptionConnDb.Ex(exception);
    }
    finally
    {
    ConnectionDb.CloseConnection(connection);
    }
    }

    return exampleLogLists;

    }

    public ExampleLog GetExampleLogById(int exampleLogID)
    {

    ExampleLog exampleLog = new ExampleLog();

    using (var connection = ConnectionDb.LiveConnection())
    {
    try
    {

    if (exampleLogID != 0)
    {

    DynamicParameters parameters = new DynamicParameters();
    parameters.Add(name:"@ExampleLogID", exampleLogID);


    using (var reader = connection.ExecuteReader(sql: "[dbo].[usp_AdminGetExampleLogById]", param: parameters, transaction: null, commandTimeout: null, CommandType.StoredProcedure))
    {
    if (reader.Read())
    {
    			if(reader["ExampleLogID"] != DBNull.Value)
				exampleLog.ExampleLogID = int.Parse(reader["ExampleLogID"].ToString());
			if(reader["ExampleID"] != DBNull.Value)
				exampleLog.ExampleID = int.Parse(reader["ExampleID"].ToString());
			exampleLog.LogMessage = reader["LogMessage"].ToString();

    }
    }
    }
    else
    {
    exampleLog.ErrID = 1;
    exampleLog.ErrText = "exampleLogID cannot be zero.";
    }

    }
    catch (Exception exception)
    {
    Errors(exampleLog);
    Log4ExceptionConnDb.Ex(exception);
    }
    finally
    {
    ConnectionDb.CloseConnection(connection);
    }
    }

    return exampleLog;

    }

    public ExampleLog InsertExampleLog(ExampleLog exampleLog)
    {

    using (var connection = ConnectionDb.LiveConnection())
    {
    try
    {

    if(exampleLog != null)
    {
    if(exampleLog.ExampleLogID != 0)
    {

    DynamicParameters parameters = new DynamicParameters();
    parameters.Add(name:"@ExampleLogID", dbType: DbType.Int32, direction: ParameterDirection.Output);
parameters.Add(name:"@ExampleID", exampleLog.ExampleID);
parameters.Add(name:"@LogMessage", exampleLog.LogMessage);

    parameters.Add(name: "@UpdateUserName", exampleLog.UpdateUserName);
    parameters.Add(name: "@UpdateFullName",exampleLog.UpdateFullName);
    parameters.Add(name: "@errID", dbType: DbType.Int32, direction: ParameterDirection.Output);
    parameters.Add(name: "@errText", dbType: DbType.String, direction: ParameterDirection.Output, size:2047);

    connection.Execute(sql: "[dbo].[usp_AdminInsertExampleLogById]", param: parameters, commandType: CommandType.StoredProcedure);

    if (parameters.Get<int?>(name: "@errID") != null)
    {
    int errID = parameters.Get<int>(name: "@errID");
    string errText = parameters.Get<string>(name: "@errText");
    exampleLog.ErrID = errID;
    exampleLog.ErrText = errText;

    }
    else
    {
    			int exampleLogID = parameters.Get<int>("@ExampleLogID");
exampleLog.ExampleLogID = exampleLogID;
    }

    }
    else
    {
    exampleLog.ErrID = 1;
    exampleLog.ErrText = "ExampleLogID cannot be zero.";
    }

    }
    else
    {
    exampleLog = new ExampleLog(){
    ErrID = 1,
    ErrText = "ExampleLog cannot be null."
    };
    }

    }
    catch (Exception exception)
    {
    Errors(exampleLog);
    Log4ExceptionConnDb.Ex(exception);
    }
    finally
    {
    ConnectionDb.CloseConnection(connection);
    }
    }
    return exampleLog;
    }

    public ExampleLog UpdateExampleLog(ExampleLog exampleLog)
    {

    using (var connection = ConnectionDb.LiveConnection())
    {
    try
    {

    if(exampleLog != null)
    {

    if(exampleLog.ExampleLogID != 0)
    {

    DynamicParameters parameters = new DynamicParameters();
    parameters.Add(name:"@ExampleLogID", exampleLog.ExampleLogID);
parameters.Add(name:"@ExampleID", exampleLog.ExampleID);
parameters.Add(name:"@LogMessage", exampleLog.LogMessage);

    parameters.Add(name: "@UpdateUserName", exampleLog.UpdateUserName);
    parameters.Add(name: "@UpdateFullName",exampleLog.UpdateFullName);
    parameters.Add(name: "@errID", dbType: DbType.Int32, direction: ParameterDirection.Output);
    parameters.Add(name: "@errText", dbType: DbType.String, direction: ParameterDirection.Output, size:2047);

    connection.Execute(sql: "[dbo].[usp_AdminUpdateExampleLogById]", param: parameters, commandType: CommandType.StoredProcedure);

    if (parameters.Get<int?>(name: "@errID") != null)
    {
    int errID = parameters.Get<int>(name: "@errID");
    string errText = parameters.Get<string>(name: "@errText");
    exampleLog.ErrID = errID;
    exampleLog.ErrText = errText;

    }

    }
    else
    {
    exampleLog.ErrID = 1;
    exampleLog.ErrText = "ExampleLogID cannot be zero.";
    }

    }
    else
    {
    exampleLog = new ExampleLog(){
    ErrID = 1,
    ErrText = "ExampleLog cannot be null."
    };
    }

    }
    catch (Exception exception)
    {
    Errors(exampleLog);
    Log4ExceptionConnDb.Ex(exception);
    }
    finally
    {
    ConnectionDb.CloseConnection(connection);
    }
    }

    return exampleLog;
    }

    public ExampleLog DeleteExampleLog(int exampleLogID,ExampleLog exampleLog)
    {

    using (var connection = ConnectionDb.LiveConnection())
    {
    try
    {

    if(exampleLog != null)
    {

    if(exampleLogID != 0)
    {

    DynamicParameters parameters = new DynamicParameters();
    parameters.Add(name:"@ExampleLogID", exampleLogID);

    parameters.Add(name: "@UpdateUserName", exampleLog.UpdateUserName);
    parameters.Add(name: "@UpdateFullName",exampleLog.UpdateFullName);
    parameters.Add(name: "@errID", dbType: DbType.Int32, direction: ParameterDirection.Output);
    parameters.Add(name: "@errText", dbType: DbType.String, direction: ParameterDirection.Output, size:2047);

    connection.Execute(sql: "[dbo].[usp_AdminDeleteExampleLogById]", param: parameters, commandType: CommandType.StoredProcedure);

    if (parameters.Get<int?>(name: "@errID") != null)
    {
    int errID = parameters.Get<int>(name: "@errID");
    string errText = parameters.Get<string>(name: "@errText");
    exampleLog.ErrID = errID;
    exampleLog.ErrText = errText;
    }
    else
    {
    exampleLog.DeleteTrueFalse = true;
    }

    }
    else
    {
    exampleLog.ErrID = 1;
    exampleLog.ErrText = "exampleLogID cannot be zero.";
    }
    }
    else
    {
    exampleLog = new ExampleLog(){
    ErrID = 1,
    ErrText = "ExampleLog cannot be null."
    };
    }

    }
    catch (Exception exception)
    {
    Errors(exampleLog);
    Log4ExceptionConnDb.Ex(exception);
    }
    finally
    {
    ConnectionDb.CloseConnection(connection);
    }
    }

    return exampleLog;
    }

    private void Errors(ExampleLog exampleLog)
    {
    exampleLog.ErrID = 1;
    exampleLog.ErrText = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
    }
    #endregion

    }
  

    }
  