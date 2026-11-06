
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

    
    public partial class AdminExampleFileUpload2Repository : IExampleFileUpload2Repository
    {

    #region AdminExampleFileUpload2Repository

    public IEnumerable<ExampleFileUpload2> GetExampleFileUpload2s()
    {
    List <ExampleFileUpload2> exampleFileUpload2Lists = new List<ExampleFileUpload2>();

    using (var connection = ConnectionDb.LiveConnection())
    {
    try
    {
    using (var reader = connection.ExecuteReader(sql: "[dbo].[usp_AdminGetExampleFileUpload2s]"))
    {

    while (reader.Read())
    {
    ExampleFileUpload2 exampleFileUpload2 = new ExampleFileUpload2();
    			if(reader["ExampleFileUpload2ID"] != DBNull.Value)
				exampleFileUpload2.ExampleFileUpload2ID = int.Parse(reader["ExampleFileUpload2ID"].ToString());
			exampleFileUpload2.FileName = reader["FileName"].ToString();
			exampleFileUpload2.FileContentType = reader["FileContentType"].ToString();
			if(reader["FileContentLength"] != DBNull.Value)
				exampleFileUpload2.FileContentLength = long.Parse(reader["FileContentLength"].ToString());
			if(reader["FileContentLengthKbMb"] != DBNull.Value)
				exampleFileUpload2.FileContentLengthKbMb = decimal.Parse(reader["FileContentLengthKbMb"].ToString());
			exampleFileUpload2.FileContentPath = reader["FileContentPath"].ToString();

    exampleFileUpload2Lists.Add(exampleFileUpload2);
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

    return exampleFileUpload2Lists;

    }

    public ExampleFileUpload2 GetExampleFileUpload2ById(int exampleFileUpload2ID)
    {

    ExampleFileUpload2 exampleFileUpload2 = new ExampleFileUpload2();

    using (var connection = ConnectionDb.LiveConnection())
    {
    try
    {

    if (exampleFileUpload2ID != 0)
    {

    DynamicParameters parameters = new DynamicParameters();
    parameters.Add(name:"@ExampleFileUpload2ID", exampleFileUpload2ID);


    using (var reader = connection.ExecuteReader(sql: "[dbo].[usp_AdminGetExampleFileUpload2ById]", param: parameters, transaction: null, commandTimeout: null, CommandType.StoredProcedure))
    {
    if (reader.Read())
    {
    			if(reader["ExampleFileUpload2ID"] != DBNull.Value)
				exampleFileUpload2.ExampleFileUpload2ID = int.Parse(reader["ExampleFileUpload2ID"].ToString());
			exampleFileUpload2.FileName = reader["FileName"].ToString();
			exampleFileUpload2.FileContentType = reader["FileContentType"].ToString();
			if(reader["FileContentLength"] != DBNull.Value)
				exampleFileUpload2.FileContentLength = long.Parse(reader["FileContentLength"].ToString());
			if(reader["FileContentLengthKbMb"] != DBNull.Value)
				exampleFileUpload2.FileContentLengthKbMb = decimal.Parse(reader["FileContentLengthKbMb"].ToString());
			exampleFileUpload2.FileContentPath = reader["FileContentPath"].ToString();

    }
    }
    }
    else
    {
    exampleFileUpload2.ErrID = 1;
    exampleFileUpload2.ErrText = "exampleFileUpload2ID cannot be zero.";
    }

    }
    catch (Exception exception)
    {
    Errors(exampleFileUpload2);
    Log4ExceptionConnDb.Ex(exception);
    }
    finally
    {
    ConnectionDb.CloseConnection(connection);
    }
    }

    return exampleFileUpload2;

    }

    public ExampleFileUpload2 InsertExampleFileUpload2(ExampleFileUpload2 exampleFileUpload2)
    {

    using (var connection = ConnectionDb.LiveConnection())
    {
    try
    {

    if(exampleFileUpload2 != null)
    {
    if(exampleFileUpload2.ExampleFileUpload2ID != 0)
    {

    DynamicParameters parameters = new DynamicParameters();
    parameters.Add(name:"@ExampleFileUpload2ID", dbType: DbType.Int32, direction: ParameterDirection.Output);
parameters.Add(name:"@FileName", exampleFileUpload2.FileName);
parameters.Add(name:"@FileContentType", exampleFileUpload2.FileContentType);
parameters.Add(name:"@FileContentLength", exampleFileUpload2.FileContentLength);
parameters.Add(name:"@FileContentLengthKbMb", exampleFileUpload2.FileContentLengthKbMb);
parameters.Add(name:"@FileContentPath", exampleFileUpload2.FileContentPath);

    parameters.Add(name: "@UpdateUserName", exampleFileUpload2.UpdateUserName);
    parameters.Add(name: "@UpdateFullName",exampleFileUpload2.UpdateFullName);
    parameters.Add(name: "@errID", dbType: DbType.Int32, direction: ParameterDirection.Output);
    parameters.Add(name: "@errText", dbType: DbType.String, direction: ParameterDirection.Output, size:2047);

    connection.Execute(sql: "[dbo].[usp_AdminInsertExampleFileUpload2ById]", param: parameters, commandType: CommandType.StoredProcedure);

    if (parameters.Get<int?>(name: "@errID") != null)
    {
    int errID = parameters.Get<int>(name: "@errID");
    string errText = parameters.Get<string>(name: "@errText");
    exampleFileUpload2.ErrID = errID;
    exampleFileUpload2.ErrText = errText;

    }
    else
    {
    			int exampleFileUpload2ID = parameters.Get<int>("@ExampleFileUpload2ID");
exampleFileUpload2.ExampleFileUpload2ID = exampleFileUpload2ID;
    }

    }
    else
    {
    exampleFileUpload2.ErrID = 1;
    exampleFileUpload2.ErrText = "ExampleFileUpload2ID cannot be zero.";
    }

    }
    else
    {
    exampleFileUpload2 = new ExampleFileUpload2(){
    ErrID = 1,
    ErrText = "ExampleFileUpload2 cannot be null."
    };
    }

    }
    catch (Exception exception)
    {
    Errors(exampleFileUpload2);
    Log4ExceptionConnDb.Ex(exception);
    }
    finally
    {
    ConnectionDb.CloseConnection(connection);
    }
    }
    return exampleFileUpload2;
    }

    public ExampleFileUpload2 UpdateExampleFileUpload2(ExampleFileUpload2 exampleFileUpload2)
    {

    using (var connection = ConnectionDb.LiveConnection())
    {
    try
    {

    if(exampleFileUpload2 != null)
    {

    if(exampleFileUpload2.ExampleFileUpload2ID != 0)
    {

    DynamicParameters parameters = new DynamicParameters();
    parameters.Add(name:"@ExampleFileUpload2ID", exampleFileUpload2.ExampleFileUpload2ID);
parameters.Add(name:"@FileName", exampleFileUpload2.FileName);
parameters.Add(name:"@FileContentType", exampleFileUpload2.FileContentType);
parameters.Add(name:"@FileContentLength", exampleFileUpload2.FileContentLength);
parameters.Add(name:"@FileContentLengthKbMb", exampleFileUpload2.FileContentLengthKbMb);
parameters.Add(name:"@FileContentPath", exampleFileUpload2.FileContentPath);

    parameters.Add(name: "@UpdateUserName", exampleFileUpload2.UpdateUserName);
    parameters.Add(name: "@UpdateFullName",exampleFileUpload2.UpdateFullName);
    parameters.Add(name: "@errID", dbType: DbType.Int32, direction: ParameterDirection.Output);
    parameters.Add(name: "@errText", dbType: DbType.String, direction: ParameterDirection.Output, size:2047);

    connection.Execute(sql: "[dbo].[usp_AdminUpdateExampleFileUpload2ById]", param: parameters, commandType: CommandType.StoredProcedure);

    if (parameters.Get<int?>(name: "@errID") != null)
    {
    int errID = parameters.Get<int>(name: "@errID");
    string errText = parameters.Get<string>(name: "@errText");
    exampleFileUpload2.ErrID = errID;
    exampleFileUpload2.ErrText = errText;

    }

    }
    else
    {
    exampleFileUpload2.ErrID = 1;
    exampleFileUpload2.ErrText = "ExampleFileUpload2ID cannot be zero.";
    }

    }
    else
    {
    exampleFileUpload2 = new ExampleFileUpload2(){
    ErrID = 1,
    ErrText = "ExampleFileUpload2 cannot be null."
    };
    }

    }
    catch (Exception exception)
    {
    Errors(exampleFileUpload2);
    Log4ExceptionConnDb.Ex(exception);
    }
    finally
    {
    ConnectionDb.CloseConnection(connection);
    }
    }

    return exampleFileUpload2;
    }

    public ExampleFileUpload2 DeleteExampleFileUpload2(int exampleFileUpload2ID,ExampleFileUpload2 exampleFileUpload2)
    {

    using (var connection = ConnectionDb.LiveConnection())
    {
    try
    {

    if(exampleFileUpload2 != null)
    {

    if(exampleFileUpload2ID != 0)
    {

    DynamicParameters parameters = new DynamicParameters();
    parameters.Add(name:"@ExampleFileUpload2ID", exampleFileUpload2ID);

    parameters.Add(name: "@UpdateUserName", exampleFileUpload2.UpdateUserName);
    parameters.Add(name: "@UpdateFullName",exampleFileUpload2.UpdateFullName);
    parameters.Add(name: "@errID", dbType: DbType.Int32, direction: ParameterDirection.Output);
    parameters.Add(name: "@errText", dbType: DbType.String, direction: ParameterDirection.Output, size:2047);

    connection.Execute(sql: "[dbo].[usp_AdminDeleteExampleFileUpload2ById]", param: parameters, commandType: CommandType.StoredProcedure);

    if (parameters.Get<int?>(name: "@errID") != null)
    {
    int errID = parameters.Get<int>(name: "@errID");
    string errText = parameters.Get<string>(name: "@errText");
    exampleFileUpload2.ErrID = errID;
    exampleFileUpload2.ErrText = errText;
    }
    else
    {
    exampleFileUpload2.DeleteTrueFalse = true;
    }

    }
    else
    {
    exampleFileUpload2.ErrID = 1;
    exampleFileUpload2.ErrText = "exampleFileUpload2ID cannot be zero.";
    }
    }
    else
    {
    exampleFileUpload2 = new ExampleFileUpload2(){
    ErrID = 1,
    ErrText = "ExampleFileUpload2 cannot be null."
    };
    }

    }
    catch (Exception exception)
    {
    Errors(exampleFileUpload2);
    Log4ExceptionConnDb.Ex(exception);
    }
    finally
    {
    ConnectionDb.CloseConnection(connection);
    }
    }

    return exampleFileUpload2;
    }

    private void Errors(ExampleFileUpload2 exampleFileUpload2)
    {
    exampleFileUpload2.ErrID = 1;
    exampleFileUpload2.ErrText = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
    }
    #endregion

    }
  

    }
  