
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

    
    public partial class AdminViewExampleRepository : IViewExampleRepository
    {

    #region AdminViewExampleRepository

    public IEnumerable<ViewExample> GetViewExamples(int userInfoID)
    {
    List <ViewExample> viewExampleLists = new List<ViewExample>();

    using (var connection = ConnectionDb.LiveConnection())
    {
    try
    {

    if(userInfoID != 0)
    {
    DynamicParameters parameters = new DynamicParameters();
    parameters.Add(name: "@UserInfoID", userInfoID);

    using (var reader = connection.ExecuteReader(sql: "[dbo].[usp_AdminGetViewExamplesById]", param: parameters, transaction: null, commandTimeout: null, CommandType.StoredProcedure))
    {

    while (reader.Read())
    {
    ViewExample viewExample = new ViewExample();
    			if(reader["ExampleID"] != DBNull.Value)
				viewExample.ExampleID = int.Parse(reader["ExampleID"].ToString());
			if(reader["ExampleUserInfoStatusID"] != DBNull.Value)
				viewExample.ExampleUserInfoStatusID = int.Parse(reader["ExampleUserInfoStatusID"].ToString());
			if(reader["ExampleUserInfoCompanyID"] != DBNull.Value)
				viewExample.ExampleUserInfoCompanyID = int.Parse(reader["ExampleUserInfoCompanyID"].ToString());
			viewExample.Title = reader["Title"].ToString();
			if(reader["Release"] != DBNull.Value)
				viewExample.Release = int.Parse(reader["Release"].ToString());
			if(reader["ReleaseDateTime"] != DBNull.Value)
				viewExample.ReleaseDateTime = DateTime.Parse(reader["ReleaseDateTime"].ToString());
			viewExample.Genre = reader["Genre"].ToString();
			if(reader["Price"] != DBNull.Value)
				viewExample.Price = decimal.Parse(reader["Price"].ToString());
			if(reader["PriceYesNo"] != DBNull.Value)
				viewExample.PriceYesNo = bool.Parse(reader["PriceYesNo"].ToString());
			if(reader["ReleaseDate"] != DBNull.Value)
				viewExample.ReleaseDate = DateTime.Parse(reader["ReleaseDate"].ToString());
			if(reader["ReleaseTime"] != DBNull.Value)
				viewExample.ReleaseTime = TimeSpan.Parse(reader["ReleaseTime"].ToString());
			viewExample.Message = reader["Message"].ToString();
			viewExample.Message2 = reader["Message2"].ToString();
			viewExample.PhoneNumber = reader["PhoneNumber"].ToString();
			viewExample.EmailAddress = reader["EmailAddress"].ToString();
			viewExample.CreditCard = reader["CreditCard"].ToString();
			viewExample.Password = reader["Password"].ToString();
			viewExample.Url = reader["Url"].ToString();
			if(reader["ExampleActiveYesNo"] != DBNull.Value)
				viewExample.ExampleActiveYesNo = bool.Parse(reader["ExampleActiveYesNo"].ToString());
			viewExample.UserInfoCompanyName = reader["UserInfoCompanyName"].ToString();
			viewExample.UserInfoStatusName = reader["UserInfoStatusName"].ToString();

    viewExampleLists.Add(viewExample);
    }
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

    return viewExampleLists;

    }

    public IEnumerable<ExampleApprove> GetViewExampleApprovesById(int exampleID)
    {

    List<ExampleApprove> exampleApproveLists = new List<ExampleApprove>();

    using (var connection = ConnectionDb.LiveConnection())
    {
    try
    {

    if (exampleID != 0)
    {

    DynamicParameters parameters = new DynamicParameters();
    parameters.Add(name:"@ExampleID", exampleID);


    using (var reader = connection.ExecuteReader(sql: "[dbo].[usp_AdminGetViewExampleApprovesById]", param: parameters, transaction: null, commandTimeout: null, CommandType.StoredProcedure))
    {

    while (reader.Read())
    {
    ExampleApprove exampleApprove = new ExampleApprove();
    if (reader["ExampleApproveID"] != DBNull.Value)
    exampleApprove.ExampleApproveID = int.Parse(reader["ExampleApproveID"].ToString());
    if (reader["ExampleID"] != DBNull.Value)
    exampleApprove.ExampleID = int.Parse(reader["ExampleID"].ToString());

    if (reader["UserInfoID"] != DBNull.Value)
    exampleApprove.UserInfoID = int.Parse(reader["UserInfoID"].ToString());

    exampleApprove.UserInfoJobTitle = reader["UserInfoJobTitle"].ToString();

    exampleApprove.CreateFullName = reader["CreateFullName"].ToString();

    if (reader["CreateDate"] != DBNull.Value)
    exampleApprove.CreateDate = DateTime.Parse(reader["CreateDate"].ToString());

    exampleApproveLists.Add(exampleApprove);
    }
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

    public IEnumerable<ExampleLog> GetViewExampleLogsById(int exampleID)
    {

    List<ExampleLog> exampleLogLists = new List<ExampleLog>();
    using (var connection = ConnectionDb.LiveConnection())
    {
    try
    {

    if (exampleID != 0)
    {

    DynamicParameters parameters = new DynamicParameters();
    parameters.Add(name:"@ExampleID", exampleID);


    using (var reader = connection.ExecuteReader(sql: "[dbo].[usp_AdminGetViewExampleLogsById]", param: parameters, transaction: null, commandTimeout: null, CommandType.StoredProcedure))
    {

    while (reader.Read())
    {
    ExampleLog exampleLog = new ExampleLog();
    if (reader["ExampleLogID"] != DBNull.Value)
    exampleLog.ExampleLogID = int.Parse(reader["ExampleLogID"].ToString());
    if (reader["ExampleID"] != DBNull.Value)
    exampleLog.ExampleID = int.Parse(reader["ExampleID"].ToString());
    exampleLog.LogMessage = reader["LogMessage"].ToString();
    exampleLog.CreateFullName = reader["CreateFullName"].ToString();
    if (reader["CreateDate"] != DBNull.Value)
    exampleLog.CreateDate = DateTime.Parse(reader["CreateDate"].ToString());

    exampleLogLists.Add(exampleLog);
    }
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

    public IEnumerable<UserInfoUserInfoCompanyXref> GetLoadUserInfoUserInfoCompanyXrefsById(int userInfoID)
    {
    IEnumerable<UserInfoUserInfoCompanyXref> userInfoUserInfoCompanyXrefLists = new List<UserInfoUserInfoCompanyXref>();

    if (userInfoID != 0)
    {
    LoadUserInfoStringRepository loadUserInfoStringRepository = new LoadUserInfoStringRepository();
    userInfoUserInfoCompanyXrefLists = loadUserInfoStringRepository.GetLoadUserInfoUserInfoCompanyXrefsById(userInfoID);
    }

    return userInfoUserInfoCompanyXrefLists;

    }


    public ViewExample GetViewExampleById(int exampleID)
    {

    ViewExample viewExample = new ViewExample();

    using (var connection = ConnectionDb.LiveConnection())
    {
    try
    {

    if (exampleID != 0)
    {

    DynamicParameters parameters = new DynamicParameters();
    parameters.Add(name:"@ExampleID", exampleID);


    using (var reader = connection.ExecuteReader(sql: "[dbo].[usp_AdminGetViewExampleById]", param: parameters, transaction: null, commandTimeout: null, CommandType.StoredProcedure))
    {
    if (reader.Read())
    {
    			if(reader["ExampleID"] != DBNull.Value)
				viewExample.ExampleID = int.Parse(reader["ExampleID"].ToString());
			if(reader["ExampleUserInfoStatusID"] != DBNull.Value)
				viewExample.ExampleUserInfoStatusID = int.Parse(reader["ExampleUserInfoStatusID"].ToString());
			if(reader["ExampleUserInfoCompanyID"] != DBNull.Value)
				viewExample.ExampleUserInfoCompanyID = int.Parse(reader["ExampleUserInfoCompanyID"].ToString());
			viewExample.Title = reader["Title"].ToString();
			if(reader["Release"] != DBNull.Value)
				viewExample.Release = int.Parse(reader["Release"].ToString());
			if(reader["ReleaseDateTime"] != DBNull.Value)
				viewExample.ReleaseDateTime = DateTime.Parse(reader["ReleaseDateTime"].ToString());
			viewExample.Genre = reader["Genre"].ToString();
			if(reader["Price"] != DBNull.Value)
				viewExample.Price = decimal.Parse(reader["Price"].ToString());
			if(reader["PriceYesNo"] != DBNull.Value)
				viewExample.PriceYesNo = bool.Parse(reader["PriceYesNo"].ToString());
			if(reader["ReleaseDate"] != DBNull.Value)
				viewExample.ReleaseDate = DateTime.Parse(reader["ReleaseDate"].ToString());
			if(reader["ReleaseTime"] != DBNull.Value)
				viewExample.ReleaseTime = TimeSpan.Parse(reader["ReleaseTime"].ToString());
			viewExample.Message = reader["Message"].ToString();
			viewExample.Message2 = reader["Message2"].ToString();
			viewExample.PhoneNumber = reader["PhoneNumber"].ToString();
			viewExample.EmailAddress = reader["EmailAddress"].ToString();
			viewExample.CreditCard = reader["CreditCard"].ToString();
			viewExample.Password = reader["Password"].ToString();
			viewExample.Url = reader["Url"].ToString();
			if(reader["ExampleActiveYesNo"] != DBNull.Value)
				viewExample.ExampleActiveYesNo = bool.Parse(reader["ExampleActiveYesNo"].ToString());
			viewExample.UserInfoCompanyName = reader["UserInfoCompanyName"].ToString();
			viewExample.UserInfoStatusName = reader["UserInfoStatusName"].ToString();

    }
    }

    }
    else
    {
    viewExample.ErrID = 1;
    viewExample.ErrText = "exampleID cannot be zero.";
    }

    }
    catch (Exception exception)
    {
    Errors(viewExample);
    Log4ExceptionConnDb.Ex(exception);
    }
    finally
    {
    ConnectionDb.CloseConnection(connection);
    }
    }

    return viewExample;

    }

    public ViewExample InsertViewExample(ViewExample viewExample)
    {

    using (var connection = ConnectionDb.LiveConnection())
    {
    try
    {

    if(viewExample != null)
    {
    if(viewExample.ExampleID != 0)
    {

    DynamicParameters parameters = new DynamicParameters();
    parameters.Add(name:"@ExampleID", dbType: DbType.Int32, direction: ParameterDirection.Output);
parameters.Add(name:"@ExampleUserInfoStatusID", viewExample.ExampleUserInfoStatusID);
parameters.Add(name:"@ExampleUserInfoCompanyID", viewExample.ExampleUserInfoCompanyID);
parameters.Add(name:"@Title", viewExample.Title);
parameters.Add(name:"@Release", viewExample.Release);
parameters.Add(name:"@ReleaseDateTime", viewExample.ReleaseDateTime);
parameters.Add(name:"@Genre", viewExample.Genre);
parameters.Add(name:"@Price", viewExample.Price);
parameters.Add(name:"@PriceYesNo", viewExample.PriceYesNo);
parameters.Add(name:"@ReleaseDate", viewExample.ReleaseDate);
parameters.Add(name:"@ReleaseTime", viewExample.ReleaseTime);
parameters.Add(name:"@Message", viewExample.Message);
parameters.Add(name:"@Message2", viewExample.Message2);
parameters.Add(name:"@PhoneNumber", viewExample.PhoneNumber);
parameters.Add(name:"@EmailAddress", viewExample.EmailAddress);
parameters.Add(name:"@CreditCard", viewExample.CreditCard);
parameters.Add(name:"@Password", viewExample.Password);
parameters.Add(name:"@Url", viewExample.Url);
parameters.Add(name:"@ExampleActiveYesNo", viewExample.ExampleActiveYesNo);

    parameters.Add(name: "@UpdateUserName", viewExample.UpdateUserName);
    parameters.Add(name: "@UpdateFullName",viewExample.UpdateFullName);
    parameters.Add(name: "@errID", dbType: DbType.Int32, direction: ParameterDirection.Output);
    parameters.Add(name: "@errText", dbType: DbType.String, direction: ParameterDirection.Output, size:2047);

    connection.Execute(sql: "[dbo].[usp_AdminInsertViewExampleById]", param: parameters, commandType: CommandType.StoredProcedure);

    if (parameters.Get<int?>(name: "@errID") != null)
    {
    int errID = parameters.Get<int>(name: "@errID");
    string errText = parameters.Get<string>(name: "@errText");
    viewExample.ErrID = errID;
    viewExample.ErrText = errText;

    }
    else
    {
    			int exampleID = parameters.Get<int>("@ExampleID");
viewExample.ExampleID = exampleID;
    }

    }
    else
    {
    viewExample.ErrID = 1;
    viewExample.ErrText = "ExampleID cannot be zero.";
    }

    }
    else
    {
    viewExample = new ViewExample(){
    ErrID = 1,
    ErrText = "ViewExample cannot be null."
    };
    }

    }
    catch (Exception exception)
    {
    Errors(viewExample);
    Log4ExceptionConnDb.Ex(exception);
    }
    finally
    {
    ConnectionDb.CloseConnection(connection);
    }
    }

    return viewExample;
    }

    public ViewExample UpdateViewExample(ViewExample viewExample)
    {

    using (var connection = ConnectionDb.LiveConnection())
    {
    try
    {

    if(viewExample != null)
    {

    if(viewExample.ExampleID != 0)
    {

    DynamicParameters parameters = new DynamicParameters();
    parameters.Add(name:"@ExampleID", viewExample.ExampleID);
parameters.Add(name:"@ExampleUserInfoStatusID", viewExample.ExampleUserInfoStatusID);
parameters.Add(name:"@ExampleUserInfoCompanyID", viewExample.ExampleUserInfoCompanyID);
parameters.Add(name:"@Title", viewExample.Title);
parameters.Add(name:"@Release", viewExample.Release);
parameters.Add(name:"@ReleaseDateTime", viewExample.ReleaseDateTime);
parameters.Add(name:"@Genre", viewExample.Genre);
parameters.Add(name:"@Price", viewExample.Price);
parameters.Add(name:"@PriceYesNo", viewExample.PriceYesNo);
parameters.Add(name:"@ReleaseDate", viewExample.ReleaseDate);
parameters.Add(name:"@ReleaseTime", viewExample.ReleaseTime);
parameters.Add(name:"@Message", viewExample.Message);
parameters.Add(name:"@Message2", viewExample.Message2);
parameters.Add(name:"@PhoneNumber", viewExample.PhoneNumber);
parameters.Add(name:"@EmailAddress", viewExample.EmailAddress);
parameters.Add(name:"@CreditCard", viewExample.CreditCard);
parameters.Add(name:"@Password", viewExample.Password);
parameters.Add(name:"@Url", viewExample.Url);
parameters.Add(name:"@ExampleActiveYesNo", viewExample.ExampleActiveYesNo);

    parameters.Add(name: "@UpdateUserName", viewExample.UpdateUserName);
    parameters.Add(name: "@UpdateFullName",viewExample.UpdateFullName);
    parameters.Add(name: "@NoteMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 2047);
    parameters.Add(name: "@errID", dbType: DbType.Int32, direction: ParameterDirection.Output);
    parameters.Add(name: "@errText", dbType: DbType.String, direction: ParameterDirection.Output, size:2047);

    connection.Execute(sql: "[dbo].[usp_AdminUpdateViewExampleById]", param: parameters, commandType: CommandType.StoredProcedure);

    if (parameters.Get<int?>(name: "@errID") != null)
    {
    int errID = parameters.Get<int>(name: "@errID");
    string errText = parameters.Get<string>(name: "@errText");
    viewExample.ErrID = errID;
    viewExample.ErrText = errText;

    }

    }
    else
    {
    viewExample.ErrID = 1;
    viewExample.ErrText = "ExampleID cannot be zero.";
    }

    }
    else
    {
    viewExample = new ViewExample(){
    ErrID = 1,
    ErrText = "ViewExample cannot be null."
    };
    }

    }
    catch (Exception exception)
    {
    Errors(viewExample);
    Log4ExceptionConnDb.Ex(exception);
    }
    finally
    {
    ConnectionDb.CloseConnection(connection);
    }
    }

    return viewExample;
    }

    public ViewExample SignedUnsignedUpdateViewExample(ViewExample viewExample)
    {

    using (var connection = ConnectionDb.LiveConnection())
    {
    try
    {

    if(viewExample != null)
    {

    if(viewExample.ExampleID != 0)
    {

    DynamicParameters parameters = new DynamicParameters();
    parameters.Add(name:"@ExampleID", viewExample.ExampleID);
parameters.Add(name:"@ExampleUserInfoStatusID", viewExample.ExampleUserInfoStatusID);
parameters.Add(name:"@ExampleUserInfoCompanyID", viewExample.ExampleUserInfoCompanyID);
parameters.Add(name:"@Title", viewExample.Title);
parameters.Add(name:"@Release", viewExample.Release);
parameters.Add(name:"@ReleaseDateTime", viewExample.ReleaseDateTime);
parameters.Add(name:"@Genre", viewExample.Genre);
parameters.Add(name:"@Price", viewExample.Price);
parameters.Add(name:"@PriceYesNo", viewExample.PriceYesNo);
parameters.Add(name:"@ReleaseDate", viewExample.ReleaseDate);
parameters.Add(name:"@ReleaseTime", viewExample.ReleaseTime);
parameters.Add(name:"@Message", viewExample.Message);
parameters.Add(name:"@Message2", viewExample.Message2);
parameters.Add(name:"@PhoneNumber", viewExample.PhoneNumber);
parameters.Add(name:"@EmailAddress", viewExample.EmailAddress);
parameters.Add(name:"@CreditCard", viewExample.CreditCard);
parameters.Add(name:"@Password", viewExample.Password);
parameters.Add(name:"@Url", viewExample.Url);
parameters.Add(name:"@ExampleActiveYesNo", viewExample.ExampleActiveYesNo);

    parameters.Add(name: "@UpdateUserName", viewExample.UpdateUserName);
    parameters.Add(name: "@UpdateFullName", viewExample.UpdateFullName);
    parameters.Add(name: "@NoteMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 2047);
    parameters.Add(name: "@errID", dbType: DbType.Int32, direction: ParameterDirection.Output);
    parameters.Add(name: "@errText", dbType: DbType.String, direction: ParameterDirection.Output, size: 2047);

    connection.Execute(sql: "[dbo].[usp_AdminUpdateViewExampleById]", param: parameters, commandType: CommandType.StoredProcedure);

    if (parameters.Get<int?>(name: "@errID") != null)
    {
    int errID = parameters.Get<int>(name: "@errID");
    string errText = parameters.Get<string>(name: "@errText");
    viewExample.ErrID = errID;
    viewExample.ErrText = errText;

    }
    else
    {
    string memoMessage = parameters.Get<string>(name: "@NoteMessage");
    viewExample.NoteMessage = memoMessage;
    }

    }
    else
    {
    viewExample.ErrID = 1;
    viewExample.ErrText = "ExampleID cannot be zero.";
    }

    }
    else
    {
    viewExample = new ViewExample()
    {
    ErrID = 1,
    ErrText = "ViewExample cannot be null."
    };
    }

    }
    catch (Exception exception)
    {
    Errors(viewExample);
    Log4ExceptionConnDb.Ex(exception);
    }
    finally
    {
    ConnectionDb.CloseConnection(connection);
    }
    }

    return viewExample;
    }

    public ViewExample ApproveCompeteRejectRevokeViewExample(ViewExample viewExample, string noteMessage)
    {

    using (var connection = ConnectionDb.LiveConnection())
    {
    try
    {

    if(viewExample != null)
    {

    if(viewExample.ExampleID != 0)
    {

    DynamicParameters parameters = new DynamicParameters();
    parameters.Add(name:"@ExampleID", viewExample.ExampleID);

    parameters.Add(name: "@UserInfoID", viewExample._UserInfoID);
    parameters.Add(name: "@UserInfoJobTitle", viewExample._UserInfoJobTitle);
    parameters.Add(name: "@ExampleUserInfoStatusID", viewExample.ExampleUserInfoStatusID);
    parameters.Add(name: "@Message", noteMessage);
    parameters.Add(name: "@UpdateUserName", viewExample.UpdateUserName);
    parameters.Add(name: "@UpdateFullName",viewExample.UpdateFullName);
    parameters.Add(name: "@NoteMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 2047);
    parameters.Add(name: "@errID", dbType: DbType.Int32, direction: ParameterDirection.Output);
    parameters.Add(name: "@errText", dbType: DbType.String, direction: ParameterDirection.Output, size:2047);

    connection.Execute(sql: "[dbo].[usp_AdminApproveCompeteRejectRevokeViewExampleById]", param: parameters, commandType: CommandType.StoredProcedure);

    if (parameters.Get<int?>(name: "@errID") != null)
    {
    int errID = parameters.Get<int>(name: "@errID");
    string errText = parameters.Get<string>(name: "@errText");
    viewExample.ErrID = errID;
    viewExample.ErrText = errText;

    }
    else
    {
    string memoMessage = parameters.Get<string>(name: "@NoteMessage");
    viewExample.NoteMessage = memoMessage;

    }

    }
    else
    {
    viewExample.ErrID = 1;
    viewExample.ErrText = "ExampleID cannot be zero.";
    }

    }
    else
    {
    viewExample = new ViewExample()
    {
    ErrID = 1,
    ErrText = "ViewExample cannot be null."
    };
    }

    }
    catch (Exception exception)
    {
    Errors(viewExample);
    Log4ExceptionConnDb.Ex(exception);
    }
    finally
    {
    ConnectionDb.CloseConnection(connection);
    }
    }

    return viewExample;
    }


    public ViewExample DeleteViewExample(int exampleID,ViewExample viewExample)
    {

    using (var connection = ConnectionDb.LiveConnection())
    {
    try
    {

    if(viewExample != null)
    {

    if(exampleID != 0)
    {

    DynamicParameters parameters = new DynamicParameters();
    parameters.Add(name:"@ExampleID", exampleID);

    parameters.Add(name: "@UpdateUserName", viewExample.UpdateUserName);
    parameters.Add(name: "@UpdateFullName",viewExample.UpdateFullName);
    parameters.Add(name: "@errID", dbType: DbType.Int32, direction: ParameterDirection.Output);
    parameters.Add(name: "@errText", dbType: DbType.String, direction: ParameterDirection.Output, size:2047);

    connection.Execute(sql: "[dbo].[usp_AdminDeleteViewExampleById]", param: parameters, commandType: CommandType.StoredProcedure);

    if (parameters.Get<int?>(name: "@errID") != null)
    {
    int errID = parameters.Get<int>(name: "@errID");
    string errText = parameters.Get<string>(name: "@errText");
    viewExample.ErrID = errID;
    viewExample.ErrText = errText;
    }
    else
    {
    viewExample.DeleteTrueFalse = true;
    }

    }
    else
    {
    viewExample.ErrID = 1;
    viewExample.ErrText = "exampleID cannot be zero.";
    }
    }
    else
    {
    viewExample = new ViewExample(){
    ErrID = 1,
    ErrText = "ViewExample cannot be null."
    };
    }

    }
    catch (Exception exception)
    {
    Errors(viewExample);
    Log4ExceptionConnDb.Ex(exception);
    }
    finally
    {
    ConnectionDb.CloseConnection(connection);
    }
    }

    return viewExample;
    }

    private void Errors(ViewExample viewExample)
    {
    viewExample.ErrID = 1;
    viewExample.ErrText = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
    }
    #endregion

    }
  

    }
  