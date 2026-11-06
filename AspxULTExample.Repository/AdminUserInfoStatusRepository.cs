
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

    
    public partial class AdminUserInfoStatusRepository : IUserInfoStatusRepository
    {

    #region AdminUserInfoStatusRepository

    public IEnumerable<UserInfoStatus> GetUserInfoStatuss()
    {
    List <UserInfoStatus> userInfoStatusLists = new List<UserInfoStatus>();

    using (var connection = ConnectionDb.LiveConnection())
    {
    try
    {
    using (var reader = connection.ExecuteReader(sql: "[dbo].[usp_AdminGetUserInfoStatuss]"))
    {

    while (reader.Read())
    {
    UserInfoStatus userInfoStatus = new UserInfoStatus();
    			if(reader["UserInfoStatusID"] != DBNull.Value)
				userInfoStatus.UserInfoStatusID = int.Parse(reader["UserInfoStatusID"].ToString());
			userInfoStatus.UserInfoStatusName = reader["UserInfoStatusName"].ToString();
			if(reader["UserInfoStatusActiveYesNo"] != DBNull.Value)
				userInfoStatus.UserInfoStatusActiveYesNo = bool.Parse(reader["UserInfoStatusActiveYesNo"].ToString());

    userInfoStatusLists.Add(userInfoStatus);
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

    return userInfoStatusLists;

    }

    public UserInfoStatus GetUserInfoStatusById(int userInfoStatusID)
    {

    UserInfoStatus userInfoStatus = new UserInfoStatus();

    using (var connection = ConnectionDb.LiveConnection())
    {
    try
    {

    if (userInfoStatusID != 0)
    {

    DynamicParameters parameters = new DynamicParameters();
    parameters.Add(name:"@UserInfoStatusID", userInfoStatusID);


    using (var reader = connection.ExecuteReader(sql: "[dbo].[usp_AdminGetUserInfoStatusById]", param: parameters, transaction: null, commandTimeout: null, CommandType.StoredProcedure))
    {
    if (reader.Read())
    {
    			if(reader["UserInfoStatusID"] != DBNull.Value)
				userInfoStatus.UserInfoStatusID = int.Parse(reader["UserInfoStatusID"].ToString());
			userInfoStatus.UserInfoStatusName = reader["UserInfoStatusName"].ToString();
			if(reader["UserInfoStatusActiveYesNo"] != DBNull.Value)
				userInfoStatus.UserInfoStatusActiveYesNo = bool.Parse(reader["UserInfoStatusActiveYesNo"].ToString());

    }
    }
    }
    else
    {
    userInfoStatus.ErrID = 1;
    userInfoStatus.ErrText = "userInfoStatusID cannot be zero.";
    }

    }
    catch (Exception exception)
    {
    Errors(userInfoStatus);
    Log4ExceptionConnDb.Ex(exception);
    }
    finally
    {
    ConnectionDb.CloseConnection(connection);
    }
    }

    return userInfoStatus;

    }

    public UserInfoStatus InsertUserInfoStatus(UserInfoStatus userInfoStatus)
    {

    using (var connection = ConnectionDb.LiveConnection())
    {
    try
    {

    if(userInfoStatus != null)
    {
    if(userInfoStatus.UserInfoStatusID != 0)
    {

    DynamicParameters parameters = new DynamicParameters();
    parameters.Add(name:"@UserInfoStatusID", dbType: DbType.Int32, direction: ParameterDirection.Output);
parameters.Add(name:"@UserInfoStatusName", userInfoStatus.UserInfoStatusName);
parameters.Add(name:"@UserInfoStatusActiveYesNo", userInfoStatus.UserInfoStatusActiveYesNo);

    parameters.Add(name: "@UpdateUserName", userInfoStatus.UpdateUserName);
    parameters.Add(name: "@UpdateFullName",userInfoStatus.UpdateFullName);
    parameters.Add(name: "@errID", dbType: DbType.Int32, direction: ParameterDirection.Output);
    parameters.Add(name: "@errText", dbType: DbType.String, direction: ParameterDirection.Output, size:2047);

    connection.Execute(sql: "[dbo].[usp_AdminInsertUserInfoStatusById]", param: parameters, commandType: CommandType.StoredProcedure);

    if (parameters.Get<int?>(name: "@errID") != null)
    {
    int errID = parameters.Get<int>(name: "@errID");
    string errText = parameters.Get<string>(name: "@errText");
    userInfoStatus.ErrID = errID;
    userInfoStatus.ErrText = errText;

    }
    else
    {
    			int userInfoStatusID = parameters.Get<int>("@UserInfoStatusID");
userInfoStatus.UserInfoStatusID = userInfoStatusID;
    }

    }
    else
    {
    userInfoStatus.ErrID = 1;
    userInfoStatus.ErrText = "UserInfoStatusID cannot be zero.";
    }

    }
    else
    {
    userInfoStatus = new UserInfoStatus(){
    ErrID = 1,
    ErrText = "UserInfoStatus cannot be null."
    };
    }

    }
    catch (Exception exception)
    {
    Errors(userInfoStatus);
    Log4ExceptionConnDb.Ex(exception);
    }
    finally
    {
    ConnectionDb.CloseConnection(connection);
    }
    }
    return userInfoStatus;
    }

    public UserInfoStatus UpdateUserInfoStatus(UserInfoStatus userInfoStatus)
    {

    using (var connection = ConnectionDb.LiveConnection())
    {
    try
    {

    if(userInfoStatus != null)
    {

    if(userInfoStatus.UserInfoStatusID != 0)
    {

    DynamicParameters parameters = new DynamicParameters();
    parameters.Add(name:"@UserInfoStatusID", userInfoStatus.UserInfoStatusID);
parameters.Add(name:"@UserInfoStatusName", userInfoStatus.UserInfoStatusName);
parameters.Add(name:"@UserInfoStatusActiveYesNo", userInfoStatus.UserInfoStatusActiveYesNo);

    parameters.Add(name: "@UpdateUserName", userInfoStatus.UpdateUserName);
    parameters.Add(name: "@UpdateFullName",userInfoStatus.UpdateFullName);
    parameters.Add(name: "@errID", dbType: DbType.Int32, direction: ParameterDirection.Output);
    parameters.Add(name: "@errText", dbType: DbType.String, direction: ParameterDirection.Output, size:2047);

    connection.Execute(sql: "[dbo].[usp_AdminUpdateUserInfoStatusById]", param: parameters, commandType: CommandType.StoredProcedure);

    if (parameters.Get<int?>(name: "@errID") != null)
    {
    int errID = parameters.Get<int>(name: "@errID");
    string errText = parameters.Get<string>(name: "@errText");
    userInfoStatus.ErrID = errID;
    userInfoStatus.ErrText = errText;

    }

    }
    else
    {
    userInfoStatus.ErrID = 1;
    userInfoStatus.ErrText = "UserInfoStatusID cannot be zero.";
    }

    }
    else
    {
    userInfoStatus = new UserInfoStatus(){
    ErrID = 1,
    ErrText = "UserInfoStatus cannot be null."
    };
    }

    }
    catch (Exception exception)
    {
    Errors(userInfoStatus);
    Log4ExceptionConnDb.Ex(exception);
    }
    finally
    {
    ConnectionDb.CloseConnection(connection);
    }
    }

    return userInfoStatus;
    }

    public UserInfoStatus DeleteUserInfoStatus(int userInfoStatusID,UserInfoStatus userInfoStatus)
    {

    using (var connection = ConnectionDb.LiveConnection())
    {
    try
    {

    if(userInfoStatus != null)
    {

    if(userInfoStatusID != 0)
    {

    DynamicParameters parameters = new DynamicParameters();
    parameters.Add(name:"@UserInfoStatusID", userInfoStatusID);

    parameters.Add(name: "@UpdateUserName", userInfoStatus.UpdateUserName);
    parameters.Add(name: "@UpdateFullName",userInfoStatus.UpdateFullName);
    parameters.Add(name: "@errID", dbType: DbType.Int32, direction: ParameterDirection.Output);
    parameters.Add(name: "@errText", dbType: DbType.String, direction: ParameterDirection.Output, size:2047);

    connection.Execute(sql: "[dbo].[usp_AdminDeleteUserInfoStatusById]", param: parameters, commandType: CommandType.StoredProcedure);

    if (parameters.Get<int?>(name: "@errID") != null)
    {
    int errID = parameters.Get<int>(name: "@errID");
    string errText = parameters.Get<string>(name: "@errText");
    userInfoStatus.ErrID = errID;
    userInfoStatus.ErrText = errText;
    }
    else
    {
    userInfoStatus.DeleteTrueFalse = true;
    }

    }
    else
    {
    userInfoStatus.ErrID = 1;
    userInfoStatus.ErrText = "userInfoStatusID cannot be zero.";
    }
    }
    else
    {
    userInfoStatus = new UserInfoStatus(){
    ErrID = 1,
    ErrText = "UserInfoStatus cannot be null."
    };
    }

    }
    catch (Exception exception)
    {
    Errors(userInfoStatus);
    Log4ExceptionConnDb.Ex(exception);
    }
    finally
    {
    ConnectionDb.CloseConnection(connection);
    }
    }

    return userInfoStatus;
    }

    private void Errors(UserInfoStatus userInfoStatus)
    {
    userInfoStatus.ErrID = 1;
    userInfoStatus.ErrText = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
    }
    #endregion

    }
  

    }
  