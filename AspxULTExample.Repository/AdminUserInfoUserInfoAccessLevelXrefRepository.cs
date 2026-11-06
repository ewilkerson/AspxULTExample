
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

    
    public partial class AdminUserInfoUserInfoAccessLevelXrefRepository : IUserInfoUserInfoAccessLevelXrefRepository
    {

    #region AdminUserInfoUserInfoAccessLevelXrefRepository

    public IEnumerable<UserInfoUserInfoAccessLevelXref> GetUserInfoUserInfoAccessLevelXrefs()
    {
    List <UserInfoUserInfoAccessLevelXref> userInfoUserInfoAccessLevelXrefLists = new List<UserInfoUserInfoAccessLevelXref>();

    using (var connection = ConnectionDb.LiveConnection())
    {
    try
    {
    using (var reader = connection.ExecuteReader(sql: "[dbo].[usp_AdminGetUserInfoUserInfoAccessLevelXrefs]"))
    {

    while (reader.Read())
    {
    UserInfoUserInfoAccessLevelXref userInfoUserInfoAccessLevelXref = new UserInfoUserInfoAccessLevelXref();
    			if(reader["UserInfoUserInfoAccessLevelXrefID"] != DBNull.Value)
				userInfoUserInfoAccessLevelXref.UserInfoUserInfoAccessLevelXrefID = int.Parse(reader["UserInfoUserInfoAccessLevelXrefID"].ToString());
			if(reader["UserInfoID"] != DBNull.Value)
				userInfoUserInfoAccessLevelXref.UserInfoID = int.Parse(reader["UserInfoID"].ToString());
			if(reader["UserInfoAccessLevelID"] != DBNull.Value)
				userInfoUserInfoAccessLevelXref.UserInfoAccessLevelID = int.Parse(reader["UserInfoAccessLevelID"].ToString());
			if(reader["UserInfoUserInfoAccessLevelXrefActiveYesNo"] != DBNull.Value)
				userInfoUserInfoAccessLevelXref.UserInfoUserInfoAccessLevelXrefActiveYesNo = bool.Parse(reader["UserInfoUserInfoAccessLevelXrefActiveYesNo"].ToString());

    userInfoUserInfoAccessLevelXrefLists.Add(userInfoUserInfoAccessLevelXref);
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

    return userInfoUserInfoAccessLevelXrefLists;

    }

    public UserInfoUserInfoAccessLevelXref GetUserInfoUserInfoAccessLevelXrefById(int userInfoUserInfoAccessLevelXrefID)
    {

    UserInfoUserInfoAccessLevelXref userInfoUserInfoAccessLevelXref = new UserInfoUserInfoAccessLevelXref();

    using (var connection = ConnectionDb.LiveConnection())
    {
    try
    {

    if (userInfoUserInfoAccessLevelXrefID != 0)
    {

    DynamicParameters parameters = new DynamicParameters();
    parameters.Add(name:"@UserInfoUserInfoAccessLevelXrefID", userInfoUserInfoAccessLevelXrefID);


    using (var reader = connection.ExecuteReader(sql: "[dbo].[usp_AdminGetUserInfoUserInfoAccessLevelXrefById]", param: parameters, transaction: null, commandTimeout: null, CommandType.StoredProcedure))
    {
    if (reader.Read())
    {
    			if(reader["UserInfoUserInfoAccessLevelXrefID"] != DBNull.Value)
				userInfoUserInfoAccessLevelXref.UserInfoUserInfoAccessLevelXrefID = int.Parse(reader["UserInfoUserInfoAccessLevelXrefID"].ToString());
			if(reader["UserInfoID"] != DBNull.Value)
				userInfoUserInfoAccessLevelXref.UserInfoID = int.Parse(reader["UserInfoID"].ToString());
			if(reader["UserInfoAccessLevelID"] != DBNull.Value)
				userInfoUserInfoAccessLevelXref.UserInfoAccessLevelID = int.Parse(reader["UserInfoAccessLevelID"].ToString());
			if(reader["UserInfoUserInfoAccessLevelXrefActiveYesNo"] != DBNull.Value)
				userInfoUserInfoAccessLevelXref.UserInfoUserInfoAccessLevelXrefActiveYesNo = bool.Parse(reader["UserInfoUserInfoAccessLevelXrefActiveYesNo"].ToString());

    }
    }
    }
    else
    {
    userInfoUserInfoAccessLevelXref.ErrID = 1;
    userInfoUserInfoAccessLevelXref.ErrText = "userInfoUserInfoAccessLevelXrefID cannot be zero.";
    }

    }
    catch (Exception exception)
    {
    Errors(userInfoUserInfoAccessLevelXref);
    Log4ExceptionConnDb.Ex(exception);
    }
    finally
    {
    ConnectionDb.CloseConnection(connection);
    }
    }

    return userInfoUserInfoAccessLevelXref;

    }

    public UserInfoUserInfoAccessLevelXref InsertUserInfoUserInfoAccessLevelXref(UserInfoUserInfoAccessLevelXref userInfoUserInfoAccessLevelXref)
    {

    using (var connection = ConnectionDb.LiveConnection())
    {
    try
    {

    if(userInfoUserInfoAccessLevelXref != null)
    {
    if(userInfoUserInfoAccessLevelXref.UserInfoUserInfoAccessLevelXrefID != 0)
    {

    DynamicParameters parameters = new DynamicParameters();
    parameters.Add(name:"@UserInfoUserInfoAccessLevelXrefID", dbType: DbType.Int32, direction: ParameterDirection.Output);
parameters.Add(name:"@UserInfoID", userInfoUserInfoAccessLevelXref.UserInfoID);
parameters.Add(name:"@UserInfoAccessLevelID", userInfoUserInfoAccessLevelXref.UserInfoAccessLevelID);
parameters.Add(name:"@UserInfoUserInfoAccessLevelXrefActiveYesNo", userInfoUserInfoAccessLevelXref.UserInfoUserInfoAccessLevelXrefActiveYesNo);

    parameters.Add(name: "@UpdateUserName", userInfoUserInfoAccessLevelXref.UpdateUserName);
    parameters.Add(name: "@UpdateFullName",userInfoUserInfoAccessLevelXref.UpdateFullName);
    parameters.Add(name: "@errID", dbType: DbType.Int32, direction: ParameterDirection.Output);
    parameters.Add(name: "@errText", dbType: DbType.String, direction: ParameterDirection.Output, size:2047);

    connection.Execute(sql: "[dbo].[usp_AdminInsertUserInfoUserInfoAccessLevelXrefById]", param: parameters, commandType: CommandType.StoredProcedure);

    if (parameters.Get<int?>(name: "@errID") != null)
    {
    int errID = parameters.Get<int>(name: "@errID");
    string errText = parameters.Get<string>(name: "@errText");
    userInfoUserInfoAccessLevelXref.ErrID = errID;
    userInfoUserInfoAccessLevelXref.ErrText = errText;

    }
    else
    {
    			int userInfoUserInfoAccessLevelXrefID = parameters.Get<int>("@UserInfoUserInfoAccessLevelXrefID");
userInfoUserInfoAccessLevelXref.UserInfoUserInfoAccessLevelXrefID = userInfoUserInfoAccessLevelXrefID;
    }

    }
    else
    {
    userInfoUserInfoAccessLevelXref.ErrID = 1;
    userInfoUserInfoAccessLevelXref.ErrText = "UserInfoUserInfoAccessLevelXrefID cannot be zero.";
    }

    }
    else
    {
    userInfoUserInfoAccessLevelXref = new UserInfoUserInfoAccessLevelXref(){
    ErrID = 1,
    ErrText = "UserInfoUserInfoAccessLevelXref cannot be null."
    };
    }

    }
    catch (Exception exception)
    {
    Errors(userInfoUserInfoAccessLevelXref);
    Log4ExceptionConnDb.Ex(exception);
    }
    finally
    {
    ConnectionDb.CloseConnection(connection);
    }
    }
    return userInfoUserInfoAccessLevelXref;
    }

    public UserInfoUserInfoAccessLevelXref UpdateUserInfoUserInfoAccessLevelXref(UserInfoUserInfoAccessLevelXref userInfoUserInfoAccessLevelXref)
    {

    using (var connection = ConnectionDb.LiveConnection())
    {
    try
    {

    if(userInfoUserInfoAccessLevelXref != null)
    {

    if(userInfoUserInfoAccessLevelXref.UserInfoUserInfoAccessLevelXrefID != 0)
    {

    DynamicParameters parameters = new DynamicParameters();
    parameters.Add(name:"@UserInfoUserInfoAccessLevelXrefID", userInfoUserInfoAccessLevelXref.UserInfoUserInfoAccessLevelXrefID);
parameters.Add(name:"@UserInfoID", userInfoUserInfoAccessLevelXref.UserInfoID);
parameters.Add(name:"@UserInfoAccessLevelID", userInfoUserInfoAccessLevelXref.UserInfoAccessLevelID);
parameters.Add(name:"@UserInfoUserInfoAccessLevelXrefActiveYesNo", userInfoUserInfoAccessLevelXref.UserInfoUserInfoAccessLevelXrefActiveYesNo);

    parameters.Add(name: "@UpdateUserName", userInfoUserInfoAccessLevelXref.UpdateUserName);
    parameters.Add(name: "@UpdateFullName",userInfoUserInfoAccessLevelXref.UpdateFullName);
    parameters.Add(name: "@errID", dbType: DbType.Int32, direction: ParameterDirection.Output);
    parameters.Add(name: "@errText", dbType: DbType.String, direction: ParameterDirection.Output, size:2047);

    connection.Execute(sql: "[dbo].[usp_AdminUpdateUserInfoUserInfoAccessLevelXrefById]", param: parameters, commandType: CommandType.StoredProcedure);

    if (parameters.Get<int?>(name: "@errID") != null)
    {
    int errID = parameters.Get<int>(name: "@errID");
    string errText = parameters.Get<string>(name: "@errText");
    userInfoUserInfoAccessLevelXref.ErrID = errID;
    userInfoUserInfoAccessLevelXref.ErrText = errText;

    }

    }
    else
    {
    userInfoUserInfoAccessLevelXref.ErrID = 1;
    userInfoUserInfoAccessLevelXref.ErrText = "UserInfoUserInfoAccessLevelXrefID cannot be zero.";
    }

    }
    else
    {
    userInfoUserInfoAccessLevelXref = new UserInfoUserInfoAccessLevelXref(){
    ErrID = 1,
    ErrText = "UserInfoUserInfoAccessLevelXref cannot be null."
    };
    }

    }
    catch (Exception exception)
    {
    Errors(userInfoUserInfoAccessLevelXref);
    Log4ExceptionConnDb.Ex(exception);
    }
    finally
    {
    ConnectionDb.CloseConnection(connection);
    }
    }

    return userInfoUserInfoAccessLevelXref;
    }

    public UserInfoUserInfoAccessLevelXref DeleteUserInfoUserInfoAccessLevelXref(int userInfoUserInfoAccessLevelXrefID,UserInfoUserInfoAccessLevelXref userInfoUserInfoAccessLevelXref)
    {

    using (var connection = ConnectionDb.LiveConnection())
    {
    try
    {

    if(userInfoUserInfoAccessLevelXref != null)
    {

    if(userInfoUserInfoAccessLevelXrefID != 0)
    {

    DynamicParameters parameters = new DynamicParameters();
    parameters.Add(name:"@UserInfoUserInfoAccessLevelXrefID", userInfoUserInfoAccessLevelXrefID);

    parameters.Add(name: "@UpdateUserName", userInfoUserInfoAccessLevelXref.UpdateUserName);
    parameters.Add(name: "@UpdateFullName",userInfoUserInfoAccessLevelXref.UpdateFullName);
    parameters.Add(name: "@errID", dbType: DbType.Int32, direction: ParameterDirection.Output);
    parameters.Add(name: "@errText", dbType: DbType.String, direction: ParameterDirection.Output, size:2047);

    connection.Execute(sql: "[dbo].[usp_AdminDeleteUserInfoUserInfoAccessLevelXrefById]", param: parameters, commandType: CommandType.StoredProcedure);

    if (parameters.Get<int?>(name: "@errID") != null)
    {
    int errID = parameters.Get<int>(name: "@errID");
    string errText = parameters.Get<string>(name: "@errText");
    userInfoUserInfoAccessLevelXref.ErrID = errID;
    userInfoUserInfoAccessLevelXref.ErrText = errText;
    }
    else
    {
    userInfoUserInfoAccessLevelXref.DeleteTrueFalse = true;
    }

    }
    else
    {
    userInfoUserInfoAccessLevelXref.ErrID = 1;
    userInfoUserInfoAccessLevelXref.ErrText = "userInfoUserInfoAccessLevelXrefID cannot be zero.";
    }
    }
    else
    {
    userInfoUserInfoAccessLevelXref = new UserInfoUserInfoAccessLevelXref(){
    ErrID = 1,
    ErrText = "UserInfoUserInfoAccessLevelXref cannot be null."
    };
    }

    }
    catch (Exception exception)
    {
    Errors(userInfoUserInfoAccessLevelXref);
    Log4ExceptionConnDb.Ex(exception);
    }
    finally
    {
    ConnectionDb.CloseConnection(connection);
    }
    }

    return userInfoUserInfoAccessLevelXref;
    }

    private void Errors(UserInfoUserInfoAccessLevelXref userInfoUserInfoAccessLevelXref)
    {
    userInfoUserInfoAccessLevelXref.ErrID = 1;
    userInfoUserInfoAccessLevelXref.ErrText = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
    }
    #endregion

    }
  

    }
  