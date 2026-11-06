
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

    
    public partial class AdminExampleRepository : IExampleRepository
    {

    #region AdminExampleRepository

    public IEnumerable<Example> GetExamples()
    {
    List <Example> exampleLists = new List<Example>();

    using (var connection = ConnectionDb.LiveConnection())
    {
    try
    {
    using (var reader = connection.ExecuteReader(sql: "[dbo].[usp_AdminGetExamples]"))
    {

    while (reader.Read())
    {
    Example example = new Example();
    			if(reader["ExampleID"] != DBNull.Value)
				example.ExampleID = int.Parse(reader["ExampleID"].ToString());
			if(reader["ExampleUserInfoStatusID"] != DBNull.Value)
				example.ExampleUserInfoStatusID = int.Parse(reader["ExampleUserInfoStatusID"].ToString());
			if(reader["ExampleUserInfoCompanyID"] != DBNull.Value)
				example.ExampleUserInfoCompanyID = int.Parse(reader["ExampleUserInfoCompanyID"].ToString());
			example.Title = reader["Title"].ToString();
			if(reader["Release"] != DBNull.Value)
				example.Release = int.Parse(reader["Release"].ToString());
			if(reader["ReleaseDateTime"] != DBNull.Value)
				example.ReleaseDateTime = DateTime.Parse(reader["ReleaseDateTime"].ToString());
			example.Genre = reader["Genre"].ToString();
			if(reader["Price"] != DBNull.Value)
				example.Price = decimal.Parse(reader["Price"].ToString());
			if(reader["PriceYesNo"] != DBNull.Value)
				example.PriceYesNo = bool.Parse(reader["PriceYesNo"].ToString());
			if(reader["ReleaseDate"] != DBNull.Value)
				example.ReleaseDate = DateTime.Parse(reader["ReleaseDate"].ToString());
			if(reader["ReleaseTime"] != DBNull.Value)
				example.ReleaseTime = TimeSpan.Parse(reader["ReleaseTime"].ToString());
			example.Message = reader["Message"].ToString();
			example.Message2 = reader["Message2"].ToString();
			example.PhoneNumber = reader["PhoneNumber"].ToString();
			example.EmailAddress = reader["EmailAddress"].ToString();
			example.CreditCard = reader["CreditCard"].ToString();
			example.Password = reader["Password"].ToString();
			example.Url = reader["Url"].ToString();
			if(reader["ExampleActiveYesNo"] != DBNull.Value)
				example.ExampleActiveYesNo = bool.Parse(reader["ExampleActiveYesNo"].ToString());

    exampleLists.Add(example);
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

    return exampleLists;

    }

    public Example GetExampleById(int exampleID)
    {

    Example example = new Example();

    using (var connection = ConnectionDb.LiveConnection())
    {
    try
    {

    if (exampleID != 0)
    {

    DynamicParameters parameters = new DynamicParameters();
    parameters.Add(name:"@ExampleID", exampleID);


    using (var reader = connection.ExecuteReader(sql: "[dbo].[usp_AdminGetExampleById]", param: parameters, transaction: null, commandTimeout: null, CommandType.StoredProcedure))
    {
    if (reader.Read())
    {
    			if(reader["ExampleID"] != DBNull.Value)
				example.ExampleID = int.Parse(reader["ExampleID"].ToString());
			if(reader["ExampleUserInfoStatusID"] != DBNull.Value)
				example.ExampleUserInfoStatusID = int.Parse(reader["ExampleUserInfoStatusID"].ToString());
			if(reader["ExampleUserInfoCompanyID"] != DBNull.Value)
				example.ExampleUserInfoCompanyID = int.Parse(reader["ExampleUserInfoCompanyID"].ToString());
			example.Title = reader["Title"].ToString();
			if(reader["Release"] != DBNull.Value)
				example.Release = int.Parse(reader["Release"].ToString());
			if(reader["ReleaseDateTime"] != DBNull.Value)
				example.ReleaseDateTime = DateTime.Parse(reader["ReleaseDateTime"].ToString());
			example.Genre = reader["Genre"].ToString();
			if(reader["Price"] != DBNull.Value)
				example.Price = decimal.Parse(reader["Price"].ToString());
			if(reader["PriceYesNo"] != DBNull.Value)
				example.PriceYesNo = bool.Parse(reader["PriceYesNo"].ToString());
			if(reader["ReleaseDate"] != DBNull.Value)
				example.ReleaseDate = DateTime.Parse(reader["ReleaseDate"].ToString());
			if(reader["ReleaseTime"] != DBNull.Value)
				example.ReleaseTime = TimeSpan.Parse(reader["ReleaseTime"].ToString());
			example.Message = reader["Message"].ToString();
			example.Message2 = reader["Message2"].ToString();
			example.PhoneNumber = reader["PhoneNumber"].ToString();
			example.EmailAddress = reader["EmailAddress"].ToString();
			example.CreditCard = reader["CreditCard"].ToString();
			example.Password = reader["Password"].ToString();
			example.Url = reader["Url"].ToString();
			if(reader["ExampleActiveYesNo"] != DBNull.Value)
				example.ExampleActiveYesNo = bool.Parse(reader["ExampleActiveYesNo"].ToString());

    }
    }
    }
    else
    {
    example.ErrID = 1;
    example.ErrText = "exampleID cannot be zero.";
    }

    }
    catch (Exception exception)
    {
    Errors(example);
    Log4ExceptionConnDb.Ex(exception);
    }
    finally
    {
    ConnectionDb.CloseConnection(connection);
    }
    }

    return example;

    }

    public Example InsertExample(Example example)
    {

    using (var connection = ConnectionDb.LiveConnection())
    {
    try
    {

    if(example != null)
    {
    if(example.ExampleID != 0)
    {

    DynamicParameters parameters = new DynamicParameters();
    parameters.Add(name:"@ExampleID", dbType: DbType.Int32, direction: ParameterDirection.Output);
parameters.Add(name:"@ExampleUserInfoStatusID", example.ExampleUserInfoStatusID);
parameters.Add(name:"@ExampleUserInfoCompanyID", example.ExampleUserInfoCompanyID);
parameters.Add(name:"@Title", example.Title);
parameters.Add(name:"@Release", example.Release);
parameters.Add(name:"@ReleaseDateTime", example.ReleaseDateTime);
parameters.Add(name:"@Genre", example.Genre);
parameters.Add(name:"@Price", example.Price);
parameters.Add(name:"@PriceYesNo", example.PriceYesNo);
parameters.Add(name:"@ReleaseDate", example.ReleaseDate);
parameters.Add(name:"@ReleaseTime", example.ReleaseTime);
parameters.Add(name:"@Message", example.Message);
parameters.Add(name:"@Message2", example.Message2);
parameters.Add(name:"@PhoneNumber", example.PhoneNumber);
parameters.Add(name:"@EmailAddress", example.EmailAddress);
parameters.Add(name:"@CreditCard", example.CreditCard);
parameters.Add(name:"@Password", example.Password);
parameters.Add(name:"@Url", example.Url);
parameters.Add(name:"@ExampleActiveYesNo", example.ExampleActiveYesNo);

    parameters.Add(name: "@UpdateUserName", example.UpdateUserName);
    parameters.Add(name: "@UpdateFullName",example.UpdateFullName);
    parameters.Add(name: "@errID", dbType: DbType.Int32, direction: ParameterDirection.Output);
    parameters.Add(name: "@errText", dbType: DbType.String, direction: ParameterDirection.Output, size:2047);

    connection.Execute(sql: "[dbo].[usp_AdminInsertExampleById]", param: parameters, commandType: CommandType.StoredProcedure);

    if (parameters.Get<int?>(name: "@errID") != null)
    {
    int errID = parameters.Get<int>(name: "@errID");
    string errText = parameters.Get<string>(name: "@errText");
    example.ErrID = errID;
    example.ErrText = errText;

    }
    else
    {
    			int exampleID = parameters.Get<int>("@ExampleID");
example.ExampleID = exampleID;
    }

    }
    else
    {
    example.ErrID = 1;
    example.ErrText = "ExampleID cannot be zero.";
    }

    }
    else
    {
    example = new Example(){
    ErrID = 1,
    ErrText = "Example cannot be null."
    };
    }

    }
    catch (Exception exception)
    {
    Errors(example);
    Log4ExceptionConnDb.Ex(exception);
    }
    finally
    {
    ConnectionDb.CloseConnection(connection);
    }
    }
    return example;
    }

    public Example UpdateExample(Example example)
    {

    using (var connection = ConnectionDb.LiveConnection())
    {
    try
    {

    if(example != null)
    {

    if(example.ExampleID != 0)
    {

    DynamicParameters parameters = new DynamicParameters();
    parameters.Add(name:"@ExampleID", example.ExampleID);
parameters.Add(name:"@ExampleUserInfoStatusID", example.ExampleUserInfoStatusID);
parameters.Add(name:"@ExampleUserInfoCompanyID", example.ExampleUserInfoCompanyID);
parameters.Add(name:"@Title", example.Title);
parameters.Add(name:"@Release", example.Release);
parameters.Add(name:"@ReleaseDateTime", example.ReleaseDateTime);
parameters.Add(name:"@Genre", example.Genre);
parameters.Add(name:"@Price", example.Price);
parameters.Add(name:"@PriceYesNo", example.PriceYesNo);
parameters.Add(name:"@ReleaseDate", example.ReleaseDate);
parameters.Add(name:"@ReleaseTime", example.ReleaseTime);
parameters.Add(name:"@Message", example.Message);
parameters.Add(name:"@Message2", example.Message2);
parameters.Add(name:"@PhoneNumber", example.PhoneNumber);
parameters.Add(name:"@EmailAddress", example.EmailAddress);
parameters.Add(name:"@CreditCard", example.CreditCard);
parameters.Add(name:"@Password", example.Password);
parameters.Add(name:"@Url", example.Url);
parameters.Add(name:"@ExampleActiveYesNo", example.ExampleActiveYesNo);

    parameters.Add(name: "@UpdateUserName", example.UpdateUserName);
    parameters.Add(name: "@UpdateFullName",example.UpdateFullName);
    parameters.Add(name: "@errID", dbType: DbType.Int32, direction: ParameterDirection.Output);
    parameters.Add(name: "@errText", dbType: DbType.String, direction: ParameterDirection.Output, size:2047);

    connection.Execute(sql: "[dbo].[usp_AdminUpdateExampleById]", param: parameters, commandType: CommandType.StoredProcedure);

    if (parameters.Get<int?>(name: "@errID") != null)
    {
    int errID = parameters.Get<int>(name: "@errID");
    string errText = parameters.Get<string>(name: "@errText");
    example.ErrID = errID;
    example.ErrText = errText;

    }

    }
    else
    {
    example.ErrID = 1;
    example.ErrText = "ExampleID cannot be zero.";
    }

    }
    else
    {
    example = new Example(){
    ErrID = 1,
    ErrText = "Example cannot be null."
    };
    }

    }
    catch (Exception exception)
    {
    Errors(example);
    Log4ExceptionConnDb.Ex(exception);
    }
    finally
    {
    ConnectionDb.CloseConnection(connection);
    }
    }

    return example;
    }

    public Example DeleteExample(int exampleID,Example example)
    {

    using (var connection = ConnectionDb.LiveConnection())
    {
    try
    {

    if(example != null)
    {

    if(exampleID != 0)
    {

    DynamicParameters parameters = new DynamicParameters();
    parameters.Add(name:"@ExampleID", exampleID);

    parameters.Add(name: "@UpdateUserName", example.UpdateUserName);
    parameters.Add(name: "@UpdateFullName",example.UpdateFullName);
    parameters.Add(name: "@errID", dbType: DbType.Int32, direction: ParameterDirection.Output);
    parameters.Add(name: "@errText", dbType: DbType.String, direction: ParameterDirection.Output, size:2047);

    connection.Execute(sql: "[dbo].[usp_AdminDeleteExampleById]", param: parameters, commandType: CommandType.StoredProcedure);

    if (parameters.Get<int?>(name: "@errID") != null)
    {
    int errID = parameters.Get<int>(name: "@errID");
    string errText = parameters.Get<string>(name: "@errText");
    example.ErrID = errID;
    example.ErrText = errText;
    }
    else
    {
    example.DeleteTrueFalse = true;
    }

    }
    else
    {
    example.ErrID = 1;
    example.ErrText = "exampleID cannot be zero.";
    }
    }
    else
    {
    example = new Example(){
    ErrID = 1,
    ErrText = "Example cannot be null."
    };
    }

    }
    catch (Exception exception)
    {
    Errors(example);
    Log4ExceptionConnDb.Ex(exception);
    }
    finally
    {
    ConnectionDb.CloseConnection(connection);
    }
    }

    return example;
    }

    private void Errors(Example example)
    {
    example.ErrID = 1;
    example.ErrText = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
    }
    #endregion

    }
  

    }
  