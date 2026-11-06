
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

    
    public partial class AdminExampleApproveRepository : IExampleApproveRepository
    {

    #region AdminExampleApproveRepository

    public IEnumerable<ExampleApprove> GetExampleApproves()
    {
    List <ExampleApprove> exampleApproveLists = new List<ExampleApprove>();

    using (var connection = ConnectionDb.LiveConnection())
    {
    try
    {
    using (var reader = connection.ExecuteReader(sql: "[dbo].[usp_AdminGetExampleApproves]"))
    {

    while (reader.Read())
    {
    ExampleApprove exampleApprove = new ExampleApprove();
    			if(reader["ExampleApproveID"] != DBNull.Value)
				exampleApprove.ExampleApproveID = int.Parse(reader["ExampleApproveID"].ToString());
			if(reader["ExampleID"] != DBNull.Value)
				exampleApprove.ExampleID = int.Parse(reader["ExampleID"].ToString());
			if(reader["UserInfoID"] != DBNull.Value)
				exampleApprove.UserInfoID = int.Parse(reader["UserInfoID"].ToString());
			exampleApprove.UserInfoJobTitle = reader["UserInfoJobTitle"].ToString();

    exampleApproveLists.Add(exampleApprove);
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

    return exampleApproveLists;

    }

    public ExampleApprove GetExampleApproveById(int exampleApproveID)
    {

    ExampleApprove exampleApprove = new ExampleApprove();

    using (var connection = ConnectionDb.LiveConnection())
    {
    try
    {

    if (exampleApproveID != 0)
    {

    DynamicParameters parameters = new DynamicParameters();
    parameters.Add(name:"@ExampleApproveID", exampleApproveID);


    using (var reader = connection.ExecuteReader(sql: "[dbo].[usp_AdminGetExampleApproveById]", param: parameters, transaction: null, commandTimeout: null, CommandType.StoredProcedure))
    {
    if (reader.Read())
    {
    			if(reader["ExampleApproveID"] != DBNull.Value)
				exampleApprove.ExampleApproveID = int.Parse(reader["ExampleApproveID"].ToString());
			if(reader["ExampleID"] != DBNull.Value)
				exampleApprove.ExampleID = int.Parse(reader["ExampleID"].ToString());
			if(reader["UserInfoID"] != DBNull.Value)
				exampleApprove.UserInfoID = int.Parse(reader["UserInfoID"].ToString());
			exampleApprove.UserInfoJobTitle = reader["UserInfoJobTitle"].ToString();

    }
    }
    }
    else
    {
    exampleApprove.ErrID = 1;
    exampleApprove.ErrText = "exampleApproveID cannot be zero.";
    }

    }
    catch (Exception exception)
    {
    Errors(exampleApprove);
    Log4ExceptionConnDb.Ex(exception);
    }
    finally
    {
    ConnectionDb.CloseConnection(connection);
    }
    }

    return exampleApprove;

    }

    public ExampleApprove InsertExampleApprove(ExampleApprove exampleApprove)
    {

    using (var connection = ConnectionDb.LiveConnection())
    {
    try
    {

    if(exampleApprove != null)
    {
    if(exampleApprove.ExampleApproveID != 0)
    {

    DynamicParameters parameters = new DynamicParameters();
    parameters.Add(name:"@ExampleApproveID", dbType: DbType.Int32, direction: ParameterDirection.Output);
parameters.Add(name:"@ExampleID", exampleApprove.ExampleID);
parameters.Add(name:"@UserInfoID", exampleApprove.UserInfoID);
parameters.Add(name:"@UserInfoJobTitle", exampleApprove.UserInfoJobTitle);

    parameters.Add(name: "@UpdateUserName", exampleApprove.UpdateUserName);
    parameters.Add(name: "@UpdateFullName",exampleApprove.UpdateFullName);
    parameters.Add(name: "@errID", dbType: DbType.Int32, direction: ParameterDirection.Output);
    parameters.Add(name: "@errText", dbType: DbType.String, direction: ParameterDirection.Output, size:2047);

    connection.Execute(sql: "[dbo].[usp_AdminInsertExampleApproveById]", param: parameters, commandType: CommandType.StoredProcedure);

    if (parameters.Get<int?>(name: "@errID") != null)
    {
    int errID = parameters.Get<int>(name: "@errID");
    string errText = parameters.Get<string>(name: "@errText");
    exampleApprove.ErrID = errID;
    exampleApprove.ErrText = errText;

    }
    else
    {
    			int exampleApproveID = parameters.Get<int>("@ExampleApproveID");
exampleApprove.ExampleApproveID = exampleApproveID;
    }

    }
    else
    {
    exampleApprove.ErrID = 1;
    exampleApprove.ErrText = "ExampleApproveID cannot be zero.";
    }

    }
    else
    {
    exampleApprove = new ExampleApprove(){
    ErrID = 1,
    ErrText = "ExampleApprove cannot be null."
    };
    }

    }
    catch (Exception exception)
    {
    Errors(exampleApprove);
    Log4ExceptionConnDb.Ex(exception);
    }
    finally
    {
    ConnectionDb.CloseConnection(connection);
    }
    }
    return exampleApprove;
    }

    public ExampleApprove UpdateExampleApprove(ExampleApprove exampleApprove)
    {

    using (var connection = ConnectionDb.LiveConnection())
    {
    try
    {

    if(exampleApprove != null)
    {

    if(exampleApprove.ExampleApproveID != 0)
    {

    DynamicParameters parameters = new DynamicParameters();
    parameters.Add(name:"@ExampleApproveID", exampleApprove.ExampleApproveID);
parameters.Add(name:"@ExampleID", exampleApprove.ExampleID);
parameters.Add(name:"@UserInfoID", exampleApprove.UserInfoID);
parameters.Add(name:"@UserInfoJobTitle", exampleApprove.UserInfoJobTitle);

    parameters.Add(name: "@UpdateUserName", exampleApprove.UpdateUserName);
    parameters.Add(name: "@UpdateFullName",exampleApprove.UpdateFullName);
    parameters.Add(name: "@errID", dbType: DbType.Int32, direction: ParameterDirection.Output);
    parameters.Add(name: "@errText", dbType: DbType.String, direction: ParameterDirection.Output, size:2047);

    connection.Execute(sql: "[dbo].[usp_AdminUpdateExampleApproveById]", param: parameters, commandType: CommandType.StoredProcedure);

    if (parameters.Get<int?>(name: "@errID") != null)
    {
    int errID = parameters.Get<int>(name: "@errID");
    string errText = parameters.Get<string>(name: "@errText");
    exampleApprove.ErrID = errID;
    exampleApprove.ErrText = errText;

    }

    }
    else
    {
    exampleApprove.ErrID = 1;
    exampleApprove.ErrText = "ExampleApproveID cannot be zero.";
    }

    }
    else
    {
    exampleApprove = new ExampleApprove(){
    ErrID = 1,
    ErrText = "ExampleApprove cannot be null."
    };
    }

    }
    catch (Exception exception)
    {
    Errors(exampleApprove);
    Log4ExceptionConnDb.Ex(exception);
    }
    finally
    {
    ConnectionDb.CloseConnection(connection);
    }
    }

    return exampleApprove;
    }

    public ExampleApprove DeleteExampleApprove(int exampleApproveID,ExampleApprove exampleApprove)
    {

    using (var connection = ConnectionDb.LiveConnection())
    {
    try
    {

    if(exampleApprove != null)
    {

    if(exampleApproveID != 0)
    {

    DynamicParameters parameters = new DynamicParameters();
    parameters.Add(name:"@ExampleApproveID", exampleApproveID);

    parameters.Add(name: "@UpdateUserName", exampleApprove.UpdateUserName);
    parameters.Add(name: "@UpdateFullName",exampleApprove.UpdateFullName);
    parameters.Add(name: "@errID", dbType: DbType.Int32, direction: ParameterDirection.Output);
    parameters.Add(name: "@errText", dbType: DbType.String, direction: ParameterDirection.Output, size:2047);

    connection.Execute(sql: "[dbo].[usp_AdminDeleteExampleApproveById]", param: parameters, commandType: CommandType.StoredProcedure);

    if (parameters.Get<int?>(name: "@errID") != null)
    {
    int errID = parameters.Get<int>(name: "@errID");
    string errText = parameters.Get<string>(name: "@errText");
    exampleApprove.ErrID = errID;
    exampleApprove.ErrText = errText;
    }
    else
    {
    exampleApprove.DeleteTrueFalse = true;
    }

    }
    else
    {
    exampleApprove.ErrID = 1;
    exampleApprove.ErrText = "exampleApproveID cannot be zero.";
    }
    }
    else
    {
    exampleApprove = new ExampleApprove(){
    ErrID = 1,
    ErrText = "ExampleApprove cannot be null."
    };
    }

    }
    catch (Exception exception)
    {
    Errors(exampleApprove);
    Log4ExceptionConnDb.Ex(exception);
    }
    finally
    {
    ConnectionDb.CloseConnection(connection);
    }
    }

    return exampleApprove;
    }

    private void Errors(ExampleApprove exampleApprove)
    {
    exampleApprove.ErrID = 1;
    exampleApprove.ErrText = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
    }
    #endregion

    }
  

    }
  