
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

    
    public partial class AdminUserInfoAccessLevelRepository : IUserInfoAccessLevelRepository
    {

    #region AdminUserInfoAccessLevelRepository

    public IEnumerable<UserInfoAccessLevel> GetUserInfoAccessLevels()
    {
    List <UserInfoAccessLevel> userInfoAccessLevelLists = new List<UserInfoAccessLevel>();

    using (var connection = ConnectionDb.LiveConnection())
    {
    try
    {
    using (var reader = connection.ExecuteReader(sql: "[dbo].[usp_AdminGetUserInfoAccessLevels]"))
    {

    while (reader.Read())
    {
    UserInfoAccessLevel userInfoAccessLevel = new UserInfoAccessLevel();
    			if(reader["UserInfoAccessLevelID"] != DBNull.Value)
				userInfoAccessLevel.UserInfoAccessLevelID = int.Parse(reader["UserInfoAccessLevelID"].ToString());
			userInfoAccessLevel.UserInfoAccessLevelName = reader["UserInfoAccessLevelName"].ToString();
			if(reader["UserInfoAccessLevelNum"] != DBNull.Value)
				userInfoAccessLevel.UserInfoAccessLevelNum = int.Parse(reader["UserInfoAccessLevelNum"].ToString());
			if(reader["UserInfoAccessLevelActiveYesNo"] != DBNull.Value)
				userInfoAccessLevel.UserInfoAccessLevelActiveYesNo = bool.Parse(reader["UserInfoAccessLevelActiveYesNo"].ToString());

    userInfoAccessLevelLists.Add(userInfoAccessLevel);
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

    return userInfoAccessLevelLists;

    }

    public UserInfoAccessLevel GetUserInfoAccessLevelById(int userInfoAccessLevelID)
    {

    UserInfoAccessLevel userInfoAccessLevel = new UserInfoAccessLevel();

    using (var connection = ConnectionDb.LiveConnection())
    {
    try
    {

    if (userInfoAccessLevelID != 0)
    {

    DynamicParameters parameters = new DynamicParameters();
    parameters.Add(name:"@UserInfoAccessLevelID", userInfoAccessLevelID);


    using (var reader = connection.ExecuteReader(sql: "[dbo].[usp_AdminGetUserInfoAccessLevelById]", param: parameters, transaction: null, commandTimeout: null, CommandType.StoredProcedure))
    {
    if (reader.Read())
    {
    			if(reader["UserInfoAccessLevelID"] != DBNull.Value)
				userInfoAccessLevel.UserInfoAccessLevelID = int.Parse(reader["UserInfoAccessLevelID"].ToString());
			userInfoAccessLevel.UserInfoAccessLevelName = reader["UserInfoAccessLevelName"].ToString();
			if(reader["UserInfoAccessLevelNum"] != DBNull.Value)
				userInfoAccessLevel.UserInfoAccessLevelNum = int.Parse(reader["UserInfoAccessLevelNum"].ToString());
			if(reader["UserInfoAccessLevelActiveYesNo"] != DBNull.Value)
				userInfoAccessLevel.UserInfoAccessLevelActiveYesNo = bool.Parse(reader["UserInfoAccessLevelActiveYesNo"].ToString());

    }
    }
    }
    else
    {
    userInfoAccessLevel.ErrID = 1;
    userInfoAccessLevel.ErrText = "userInfoAccessLevelID cannot be zero.";
    }

    }
    catch (Exception exception)
    {
    Errors(userInfoAccessLevel);
    Log4ExceptionConnDb.Ex(exception);
    }
    finally
    {
    ConnectionDb.CloseConnection(connection);
    }
    }

    return userInfoAccessLevel;

    }

    public UserInfoAccessLevel InsertUserInfoAccessLevel(UserInfoAccessLevel userInfoAccessLevel)
    {

    using (var connection = ConnectionDb.LiveConnection())
    {
    try
    {

    if(userInfoAccessLevel != null)
    {
    if(userInfoAccessLevel.UserInfoAccessLevelID != 0)
    {

    DynamicParameters parameters = new DynamicParameters();
    parameters.Add(name:"@UserInfoAccessLevelID", dbType: DbType.Int32, direction: ParameterDirection.Output);
parameters.Add(name:"@UserInfoAccessLevelName", userInfoAccessLevel.UserInfoAccessLevelName);
parameters.Add(name:"@UserInfoAccessLevelNum", userInfoAccessLevel.UserInfoAccessLevelNum);
parameters.Add(name:"@UserInfoAccessLevelActiveYesNo", userInfoAccessLevel.UserInfoAccessLevelActiveYesNo);

    parameters.Add(name: "@UpdateUserName", userInfoAccessLevel.UpdateUserName);
    parameters.Add(name: "@UpdateFullName",userInfoAccessLevel.UpdateFullName);
    parameters.Add(name: "@errID", dbType: DbType.Int32, direction: ParameterDirection.Output);
    parameters.Add(name: "@errText", dbType: DbType.String, direction: ParameterDirection.Output, size:2047);

    connection.Execute(sql: "[dbo].[usp_AdminInsertUserInfoAccessLevelById]", param: parameters, commandType: CommandType.StoredProcedure);

    if (parameters.Get<int?>(name: "@errID") != null)
    {
    int errID = parameters.Get<int>(name: "@errID");
    string errText = parameters.Get<string>(name: "@errText");
    userInfoAccessLevel.ErrID = errID;
    userInfoAccessLevel.ErrText = errText;

    }
    else
    {
    			int userInfoAccessLevelID = parameters.Get<int>("@UserInfoAccessLevelID");
userInfoAccessLevel.UserInfoAccessLevelID = userInfoAccessLevelID;
    }

    }
    else
    {
    userInfoAccessLevel.ErrID = 1;
    userInfoAccessLevel.ErrText = "UserInfoAccessLevelID cannot be zero.";
    }

    }
    else
    {
    userInfoAccessLevel = new UserInfoAccessLevel(){
    ErrID = 1,
    ErrText = "UserInfoAccessLevel cannot be null."
    };
    }

    }
    catch (Exception exception)
    {
    Errors(userInfoAccessLevel);
    Log4ExceptionConnDb.Ex(exception);
    }
    finally
    {
    ConnectionDb.CloseConnection(connection);
    }
    }
    return userInfoAccessLevel;
    }

    public UserInfoAccessLevel UpdateUserInfoAccessLevel(UserInfoAccessLevel userInfoAccessLevel)
    {

    using (var connection = ConnectionDb.LiveConnection())
    {
    try
    {

    if(userInfoAccessLevel != null)
    {

    if(userInfoAccessLevel.UserInfoAccessLevelID != 0)
    {

    DynamicParameters parameters = new DynamicParameters();
    parameters.Add(name:"@UserInfoAccessLevelID", userInfoAccessLevel.UserInfoAccessLevelID);
parameters.Add(name:"@UserInfoAccessLevelName", userInfoAccessLevel.UserInfoAccessLevelName);
parameters.Add(name:"@UserInfoAccessLevelNum", userInfoAccessLevel.UserInfoAccessLevelNum);
parameters.Add(name:"@UserInfoAccessLevelActiveYesNo", userInfoAccessLevel.UserInfoAccessLevelActiveYesNo);

    parameters.Add(name: "@UpdateUserName", userInfoAccessLevel.UpdateUserName);
    parameters.Add(name: "@UpdateFullName",userInfoAccessLevel.UpdateFullName);
    parameters.Add(name: "@errID", dbType: DbType.Int32, direction: ParameterDirection.Output);
    parameters.Add(name: "@errText", dbType: DbType.String, direction: ParameterDirection.Output, size:2047);

    connection.Execute(sql: "[dbo].[usp_AdminUpdateUserInfoAccessLevelById]", param: parameters, commandType: CommandType.StoredProcedure);

    if (parameters.Get<int?>(name: "@errID") != null)
    {
    int errID = parameters.Get<int>(name: "@errID");
    string errText = parameters.Get<string>(name: "@errText");
    userInfoAccessLevel.ErrID = errID;
    userInfoAccessLevel.ErrText = errText;

    }

    }
    else
    {
    userInfoAccessLevel.ErrID = 1;
    userInfoAccessLevel.ErrText = "UserInfoAccessLevelID cannot be zero.";
    }

    }
    else
    {
    userInfoAccessLevel = new UserInfoAccessLevel(){
    ErrID = 1,
    ErrText = "UserInfoAccessLevel cannot be null."
    };
    }

    }
    catch (Exception exception)
    {
    Errors(userInfoAccessLevel);
    Log4ExceptionConnDb.Ex(exception);
    }
    finally
    {
    ConnectionDb.CloseConnection(connection);
    }
    }

    return userInfoAccessLevel;
    }

    public UserInfoAccessLevel DeleteUserInfoAccessLevel(int userInfoAccessLevelID,UserInfoAccessLevel userInfoAccessLevel)
    {

    using (var connection = ConnectionDb.LiveConnection())
    {
    try
    {

    if(userInfoAccessLevel != null)
    {

    if(userInfoAccessLevelID != 0)
    {

    DynamicParameters parameters = new DynamicParameters();
    parameters.Add(name:"@UserInfoAccessLevelID", userInfoAccessLevelID);

    parameters.Add(name: "@UpdateUserName", userInfoAccessLevel.UpdateUserName);
    parameters.Add(name: "@UpdateFullName",userInfoAccessLevel.UpdateFullName);
    parameters.Add(name: "@errID", dbType: DbType.Int32, direction: ParameterDirection.Output);
    parameters.Add(name: "@errText", dbType: DbType.String, direction: ParameterDirection.Output, size:2047);

    connection.Execute(sql: "[dbo].[usp_AdminDeleteUserInfoAccessLevelById]", param: parameters, commandType: CommandType.StoredProcedure);

    if (parameters.Get<int?>(name: "@errID") != null)
    {
    int errID = parameters.Get<int>(name: "@errID");
    string errText = parameters.Get<string>(name: "@errText");
    userInfoAccessLevel.ErrID = errID;
    userInfoAccessLevel.ErrText = errText;
    }
    else
    {
    userInfoAccessLevel.DeleteTrueFalse = true;
    }

    }
    else
    {
    userInfoAccessLevel.ErrID = 1;
    userInfoAccessLevel.ErrText = "userInfoAccessLevelID cannot be zero.";
    }
    }
    else
    {
    userInfoAccessLevel = new UserInfoAccessLevel(){
    ErrID = 1,
    ErrText = "UserInfoAccessLevel cannot be null."
    };
    }

    }
    catch (Exception exception)
    {
    Errors(userInfoAccessLevel);
    Log4ExceptionConnDb.Ex(exception);
    }
    finally
    {
    ConnectionDb.CloseConnection(connection);
    }
    }

    return userInfoAccessLevel;
    }

    private void Errors(UserInfoAccessLevel userInfoAccessLevel)
    {
    userInfoAccessLevel.ErrID = 1;
    userInfoAccessLevel.ErrText = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
    }
    #endregion

    }
  

    }
  