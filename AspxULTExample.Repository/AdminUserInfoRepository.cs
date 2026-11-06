
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

    
    public partial class AdminUserInfoRepository : IUserInfoRepository
    {

    #region AdminUserInfoRepository

    public IEnumerable<UserInfo> GetUserInfos()
    {
    List <UserInfo> userInfoLists = new List<UserInfo>();

    using (var connection = ConnectionDb.LiveConnection())
    {
    try
    {
    using (var reader = connection.ExecuteReader(sql: "[dbo].[usp_AdminGetUserInfos]"))
    {

    while (reader.Read())
    {
    UserInfo userInfo = new UserInfo();
    			if(reader["UserInfoID"] != DBNull.Value)
				userInfo.UserInfoID = int.Parse(reader["UserInfoID"].ToString());
			userInfo.UserInfoUserIdentityName = reader["UserInfoUserIdentityName"].ToString();
			userInfo.UserInfoUserName = reader["UserInfoUserName"].ToString();
			userInfo.UserInfoFullName = reader["UserInfoFullName"].ToString();
			userInfo.UserInfoEmailAddress = reader["UserInfoEmailAddress"].ToString();
			userInfo.UserInfoJobTitle = reader["UserInfoJobTitle"].ToString();
			if(reader["UserInfoActiveYesNo"] != DBNull.Value)
				userInfo.UserInfoActiveYesNo = bool.Parse(reader["UserInfoActiveYesNo"].ToString());

    userInfoLists.Add(userInfo);
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

    return userInfoLists;

    }

    public UserInfo GetUserInfoById(int userInfoID)
    {

    UserInfo userInfo = new UserInfo();

    using (var connection = ConnectionDb.LiveConnection())
    {
    try
    {

    if (userInfoID != 0)
    {

    DynamicParameters parameters = new DynamicParameters();
    parameters.Add(name:"@UserInfoID", userInfoID);


    using (var reader = connection.ExecuteReader(sql: "[dbo].[usp_AdminGetUserInfoById]", param: parameters, transaction: null, commandTimeout: null, CommandType.StoredProcedure))
    {
    if (reader.Read())
    {
    			if(reader["UserInfoID"] != DBNull.Value)
				userInfo.UserInfoID = int.Parse(reader["UserInfoID"].ToString());
			userInfo.UserInfoUserIdentityName = reader["UserInfoUserIdentityName"].ToString();
			userInfo.UserInfoUserName = reader["UserInfoUserName"].ToString();
			userInfo.UserInfoFullName = reader["UserInfoFullName"].ToString();
			userInfo.UserInfoEmailAddress = reader["UserInfoEmailAddress"].ToString();
			userInfo.UserInfoJobTitle = reader["UserInfoJobTitle"].ToString();
			if(reader["UserInfoActiveYesNo"] != DBNull.Value)
				userInfo.UserInfoActiveYesNo = bool.Parse(reader["UserInfoActiveYesNo"].ToString());

    }
    }
    }
    else
    {
    userInfo.ErrID = 1;
    userInfo.ErrText = "userInfoID cannot be zero.";
    }

    }
    catch (Exception exception)
    {
    Errors(userInfo);
    Log4ExceptionConnDb.Ex(exception);
    }
    finally
    {
    ConnectionDb.CloseConnection(connection);
    }
    }

    return userInfo;

    }

    public UserInfo InsertUserInfo(UserInfo userInfo)
    {

    using (var connection = ConnectionDb.LiveConnection())
    {
    try
    {

    if(userInfo != null)
    {
    if(userInfo.UserInfoID != 0)
    {

    DynamicParameters parameters = new DynamicParameters();
    parameters.Add(name:"@UserInfoID", dbType: DbType.Int32, direction: ParameterDirection.Output);
parameters.Add(name:"@UserInfoUserIdentityName", userInfo.UserInfoUserIdentityName);
parameters.Add(name:"@UserInfoUserName", userInfo.UserInfoUserName);
parameters.Add(name:"@UserInfoFullName", userInfo.UserInfoFullName);
parameters.Add(name:"@UserInfoEmailAddress", userInfo.UserInfoEmailAddress);
parameters.Add(name:"@UserInfoJobTitle", userInfo.UserInfoJobTitle);
parameters.Add(name:"@UserInfoActiveYesNo", userInfo.UserInfoActiveYesNo);

    parameters.Add(name: "@UpdateUserName", userInfo.UpdateUserName);
    parameters.Add(name: "@UpdateFullName",userInfo.UpdateFullName);
    parameters.Add(name: "@errID", dbType: DbType.Int32, direction: ParameterDirection.Output);
    parameters.Add(name: "@errText", dbType: DbType.String, direction: ParameterDirection.Output, size:2047);

    connection.Execute(sql: "[dbo].[usp_AdminInsertUserInfoById]", param: parameters, commandType: CommandType.StoredProcedure);

    if (parameters.Get<int?>(name: "@errID") != null)
    {
    int errID = parameters.Get<int>(name: "@errID");
    string errText = parameters.Get<string>(name: "@errText");
    userInfo.ErrID = errID;
    userInfo.ErrText = errText;

    }
    else
    {
    			int userInfoID = parameters.Get<int>("@UserInfoID");
userInfo.UserInfoID = userInfoID;
    }

    }
    else
    {
    userInfo.ErrID = 1;
    userInfo.ErrText = "UserInfoID cannot be zero.";
    }

    }
    else
    {
    userInfo = new UserInfo(){
    ErrID = 1,
    ErrText = "UserInfo cannot be null."
    };
    }

    }
    catch (Exception exception)
    {
    Errors(userInfo);
    Log4ExceptionConnDb.Ex(exception);
    }
    finally
    {
    ConnectionDb.CloseConnection(connection);
    }
    }
    return userInfo;
    }

    public UserInfo UpdateUserInfo(UserInfo userInfo)
    {

    using (var connection = ConnectionDb.LiveConnection())
    {
    try
    {

    if(userInfo != null)
    {

    if(userInfo.UserInfoID != 0)
    {

    DynamicParameters parameters = new DynamicParameters();
    parameters.Add(name:"@UserInfoID", userInfo.UserInfoID);
parameters.Add(name:"@UserInfoUserIdentityName", userInfo.UserInfoUserIdentityName);
parameters.Add(name:"@UserInfoUserName", userInfo.UserInfoUserName);
parameters.Add(name:"@UserInfoFullName", userInfo.UserInfoFullName);
parameters.Add(name:"@UserInfoEmailAddress", userInfo.UserInfoEmailAddress);
parameters.Add(name:"@UserInfoJobTitle", userInfo.UserInfoJobTitle);
parameters.Add(name:"@UserInfoActiveYesNo", userInfo.UserInfoActiveYesNo);

    parameters.Add(name: "@UpdateUserName", userInfo.UpdateUserName);
    parameters.Add(name: "@UpdateFullName",userInfo.UpdateFullName);
    parameters.Add(name: "@errID", dbType: DbType.Int32, direction: ParameterDirection.Output);
    parameters.Add(name: "@errText", dbType: DbType.String, direction: ParameterDirection.Output, size:2047);

    connection.Execute(sql: "[dbo].[usp_AdminUpdateUserInfoById]", param: parameters, commandType: CommandType.StoredProcedure);

    if (parameters.Get<int?>(name: "@errID") != null)
    {
    int errID = parameters.Get<int>(name: "@errID");
    string errText = parameters.Get<string>(name: "@errText");
    userInfo.ErrID = errID;
    userInfo.ErrText = errText;

    }

    }
    else
    {
    userInfo.ErrID = 1;
    userInfo.ErrText = "UserInfoID cannot be zero.";
    }

    }
    else
    {
    userInfo = new UserInfo(){
    ErrID = 1,
    ErrText = "UserInfo cannot be null."
    };
    }

    }
    catch (Exception exception)
    {
    Errors(userInfo);
    Log4ExceptionConnDb.Ex(exception);
    }
    finally
    {
    ConnectionDb.CloseConnection(connection);
    }
    }

    return userInfo;
    }

    public UserInfo DeleteUserInfo(int userInfoID,UserInfo userInfo)
    {

    using (var connection = ConnectionDb.LiveConnection())
    {
    try
    {

    if(userInfo != null)
    {

    if(userInfoID != 0)
    {

    DynamicParameters parameters = new DynamicParameters();
    parameters.Add(name:"@UserInfoID", userInfoID);

    parameters.Add(name: "@UpdateUserName", userInfo.UpdateUserName);
    parameters.Add(name: "@UpdateFullName",userInfo.UpdateFullName);
    parameters.Add(name: "@errID", dbType: DbType.Int32, direction: ParameterDirection.Output);
    parameters.Add(name: "@errText", dbType: DbType.String, direction: ParameterDirection.Output, size:2047);

    connection.Execute(sql: "[dbo].[usp_AdminDeleteUserInfoById]", param: parameters, commandType: CommandType.StoredProcedure);

    if (parameters.Get<int?>(name: "@errID") != null)
    {
    int errID = parameters.Get<int>(name: "@errID");
    string errText = parameters.Get<string>(name: "@errText");
    userInfo.ErrID = errID;
    userInfo.ErrText = errText;
    }
    else
    {
    userInfo.DeleteTrueFalse = true;
    }

    }
    else
    {
    userInfo.ErrID = 1;
    userInfo.ErrText = "userInfoID cannot be zero.";
    }
    }
    else
    {
    userInfo = new UserInfo(){
    ErrID = 1,
    ErrText = "UserInfo cannot be null."
    };
    }

    }
    catch (Exception exception)
    {
    Errors(userInfo);
    Log4ExceptionConnDb.Ex(exception);
    }
    finally
    {
    ConnectionDb.CloseConnection(connection);
    }
    }

    return userInfo;
    }

    private void Errors(UserInfo userInfo)
    {
    userInfo.ErrID = 1;
    userInfo.ErrText = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
    }
    #endregion

    }
  

    }
  