
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

    
    public partial class AdminUserInfoUserInfoCompanyXrefRepository : IUserInfoUserInfoCompanyXrefRepository
    {

    #region AdminUserInfoUserInfoCompanyXrefRepository

    public IEnumerable<UserInfoUserInfoCompanyXref> GetUserInfoUserInfoCompanyXrefs()
    {
    List <UserInfoUserInfoCompanyXref> userInfoUserInfoCompanyXrefLists = new List<UserInfoUserInfoCompanyXref>();

    using (var connection = ConnectionDb.LiveConnection())
    {
    try
    {
    using (var reader = connection.ExecuteReader(sql: "[dbo].[usp_AdminGetUserInfoUserInfoCompanyXrefs]"))
    {

    while (reader.Read())
    {
    UserInfoUserInfoCompanyXref userInfoUserInfoCompanyXref = new UserInfoUserInfoCompanyXref();
    			if(reader["UserInfoUserInfoCompanyXrefID"] != DBNull.Value)
				userInfoUserInfoCompanyXref.UserInfoUserInfoCompanyXrefID = int.Parse(reader["UserInfoUserInfoCompanyXrefID"].ToString());
			if(reader["UserInfoID"] != DBNull.Value)
				userInfoUserInfoCompanyXref.UserInfoID = int.Parse(reader["UserInfoID"].ToString());
			if(reader["UserInfoCompanyID"] != DBNull.Value)
				userInfoUserInfoCompanyXref.UserInfoCompanyID = int.Parse(reader["UserInfoCompanyID"].ToString());
			if(reader["UserInfoUserInfoCompanyXrefEmailAddressActiveYesNo"] != DBNull.Value)
				userInfoUserInfoCompanyXref.UserInfoUserInfoCompanyXrefEmailAddressActiveYesNo = bool.Parse(reader["UserInfoUserInfoCompanyXrefEmailAddressActiveYesNo"].ToString());
			if(reader["UserInfoUserInfoCompanyXrefActiveYesNo"] != DBNull.Value)
				userInfoUserInfoCompanyXref.UserInfoUserInfoCompanyXrefActiveYesNo = bool.Parse(reader["UserInfoUserInfoCompanyXrefActiveYesNo"].ToString());

    userInfoUserInfoCompanyXrefLists.Add(userInfoUserInfoCompanyXref);
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

    return userInfoUserInfoCompanyXrefLists;

    }

    public UserInfoUserInfoCompanyXref GetUserInfoUserInfoCompanyXrefById(int userInfoUserInfoCompanyXrefID)
    {

    UserInfoUserInfoCompanyXref userInfoUserInfoCompanyXref = new UserInfoUserInfoCompanyXref();

    using (var connection = ConnectionDb.LiveConnection())
    {
    try
    {

    if (userInfoUserInfoCompanyXrefID != 0)
    {

    DynamicParameters parameters = new DynamicParameters();
    parameters.Add(name:"@UserInfoUserInfoCompanyXrefID", userInfoUserInfoCompanyXrefID);


    using (var reader = connection.ExecuteReader(sql: "[dbo].[usp_AdminGetUserInfoUserInfoCompanyXrefById]", param: parameters, transaction: null, commandTimeout: null, CommandType.StoredProcedure))
    {
    if (reader.Read())
    {
    			if(reader["UserInfoUserInfoCompanyXrefID"] != DBNull.Value)
				userInfoUserInfoCompanyXref.UserInfoUserInfoCompanyXrefID = int.Parse(reader["UserInfoUserInfoCompanyXrefID"].ToString());
			if(reader["UserInfoID"] != DBNull.Value)
				userInfoUserInfoCompanyXref.UserInfoID = int.Parse(reader["UserInfoID"].ToString());
			if(reader["UserInfoCompanyID"] != DBNull.Value)
				userInfoUserInfoCompanyXref.UserInfoCompanyID = int.Parse(reader["UserInfoCompanyID"].ToString());
			if(reader["UserInfoUserInfoCompanyXrefEmailAddressActiveYesNo"] != DBNull.Value)
				userInfoUserInfoCompanyXref.UserInfoUserInfoCompanyXrefEmailAddressActiveYesNo = bool.Parse(reader["UserInfoUserInfoCompanyXrefEmailAddressActiveYesNo"].ToString());
			if(reader["UserInfoUserInfoCompanyXrefActiveYesNo"] != DBNull.Value)
				userInfoUserInfoCompanyXref.UserInfoUserInfoCompanyXrefActiveYesNo = bool.Parse(reader["UserInfoUserInfoCompanyXrefActiveYesNo"].ToString());

    }
    }
    }
    else
    {
    userInfoUserInfoCompanyXref.ErrID = 1;
    userInfoUserInfoCompanyXref.ErrText = "userInfoUserInfoCompanyXrefID cannot be zero.";
    }

    }
    catch (Exception exception)
    {
    Errors(userInfoUserInfoCompanyXref);
    Log4ExceptionConnDb.Ex(exception);
    }
    finally
    {
    ConnectionDb.CloseConnection(connection);
    }
    }

    return userInfoUserInfoCompanyXref;

    }

    public UserInfoUserInfoCompanyXref InsertUserInfoUserInfoCompanyXref(UserInfoUserInfoCompanyXref userInfoUserInfoCompanyXref)
    {

    using (var connection = ConnectionDb.LiveConnection())
    {
    try
    {

    if(userInfoUserInfoCompanyXref != null)
    {
    if(userInfoUserInfoCompanyXref.UserInfoUserInfoCompanyXrefID != 0)
    {

    DynamicParameters parameters = new DynamicParameters();
    parameters.Add(name:"@UserInfoUserInfoCompanyXrefID", dbType: DbType.Int32, direction: ParameterDirection.Output);
parameters.Add(name:"@UserInfoID", userInfoUserInfoCompanyXref.UserInfoID);
parameters.Add(name:"@UserInfoCompanyID", userInfoUserInfoCompanyXref.UserInfoCompanyID);
parameters.Add(name:"@UserInfoUserInfoCompanyXrefEmailAddressActiveYesNo", userInfoUserInfoCompanyXref.UserInfoUserInfoCompanyXrefEmailAddressActiveYesNo);
parameters.Add(name:"@UserInfoUserInfoCompanyXrefActiveYesNo", userInfoUserInfoCompanyXref.UserInfoUserInfoCompanyXrefActiveYesNo);

    parameters.Add(name: "@UpdateUserName", userInfoUserInfoCompanyXref.UpdateUserName);
    parameters.Add(name: "@UpdateFullName",userInfoUserInfoCompanyXref.UpdateFullName);
    parameters.Add(name: "@errID", dbType: DbType.Int32, direction: ParameterDirection.Output);
    parameters.Add(name: "@errText", dbType: DbType.String, direction: ParameterDirection.Output, size:2047);

    connection.Execute(sql: "[dbo].[usp_AdminInsertUserInfoUserInfoCompanyXrefById]", param: parameters, commandType: CommandType.StoredProcedure);

    if (parameters.Get<int?>(name: "@errID") != null)
    {
    int errID = parameters.Get<int>(name: "@errID");
    string errText = parameters.Get<string>(name: "@errText");
    userInfoUserInfoCompanyXref.ErrID = errID;
    userInfoUserInfoCompanyXref.ErrText = errText;

    }
    else
    {
    			int userInfoUserInfoCompanyXrefID = parameters.Get<int>("@UserInfoUserInfoCompanyXrefID");
userInfoUserInfoCompanyXref.UserInfoUserInfoCompanyXrefID = userInfoUserInfoCompanyXrefID;
    }

    }
    else
    {
    userInfoUserInfoCompanyXref.ErrID = 1;
    userInfoUserInfoCompanyXref.ErrText = "UserInfoUserInfoCompanyXrefID cannot be zero.";
    }

    }
    else
    {
    userInfoUserInfoCompanyXref = new UserInfoUserInfoCompanyXref(){
    ErrID = 1,
    ErrText = "UserInfoUserInfoCompanyXref cannot be null."
    };
    }

    }
    catch (Exception exception)
    {
    Errors(userInfoUserInfoCompanyXref);
    Log4ExceptionConnDb.Ex(exception);
    }
    finally
    {
    ConnectionDb.CloseConnection(connection);
    }
    }
    return userInfoUserInfoCompanyXref;
    }

    public UserInfoUserInfoCompanyXref UpdateUserInfoUserInfoCompanyXref(UserInfoUserInfoCompanyXref userInfoUserInfoCompanyXref)
    {

    using (var connection = ConnectionDb.LiveConnection())
    {
    try
    {

    if(userInfoUserInfoCompanyXref != null)
    {

    if(userInfoUserInfoCompanyXref.UserInfoUserInfoCompanyXrefID != 0)
    {

    DynamicParameters parameters = new DynamicParameters();
    parameters.Add(name:"@UserInfoUserInfoCompanyXrefID", userInfoUserInfoCompanyXref.UserInfoUserInfoCompanyXrefID);
parameters.Add(name:"@UserInfoID", userInfoUserInfoCompanyXref.UserInfoID);
parameters.Add(name:"@UserInfoCompanyID", userInfoUserInfoCompanyXref.UserInfoCompanyID);
parameters.Add(name:"@UserInfoUserInfoCompanyXrefEmailAddressActiveYesNo", userInfoUserInfoCompanyXref.UserInfoUserInfoCompanyXrefEmailAddressActiveYesNo);
parameters.Add(name:"@UserInfoUserInfoCompanyXrefActiveYesNo", userInfoUserInfoCompanyXref.UserInfoUserInfoCompanyXrefActiveYesNo);

    parameters.Add(name: "@UpdateUserName", userInfoUserInfoCompanyXref.UpdateUserName);
    parameters.Add(name: "@UpdateFullName",userInfoUserInfoCompanyXref.UpdateFullName);
    parameters.Add(name: "@errID", dbType: DbType.Int32, direction: ParameterDirection.Output);
    parameters.Add(name: "@errText", dbType: DbType.String, direction: ParameterDirection.Output, size:2047);

    connection.Execute(sql: "[dbo].[usp_AdminUpdateUserInfoUserInfoCompanyXrefById]", param: parameters, commandType: CommandType.StoredProcedure);

    if (parameters.Get<int?>(name: "@errID") != null)
    {
    int errID = parameters.Get<int>(name: "@errID");
    string errText = parameters.Get<string>(name: "@errText");
    userInfoUserInfoCompanyXref.ErrID = errID;
    userInfoUserInfoCompanyXref.ErrText = errText;

    }

    }
    else
    {
    userInfoUserInfoCompanyXref.ErrID = 1;
    userInfoUserInfoCompanyXref.ErrText = "UserInfoUserInfoCompanyXrefID cannot be zero.";
    }

    }
    else
    {
    userInfoUserInfoCompanyXref = new UserInfoUserInfoCompanyXref(){
    ErrID = 1,
    ErrText = "UserInfoUserInfoCompanyXref cannot be null."
    };
    }

    }
    catch (Exception exception)
    {
    Errors(userInfoUserInfoCompanyXref);
    Log4ExceptionConnDb.Ex(exception);
    }
    finally
    {
    ConnectionDb.CloseConnection(connection);
    }
    }

    return userInfoUserInfoCompanyXref;
    }

    public UserInfoUserInfoCompanyXref DeleteUserInfoUserInfoCompanyXref(int userInfoUserInfoCompanyXrefID,UserInfoUserInfoCompanyXref userInfoUserInfoCompanyXref)
    {

    using (var connection = ConnectionDb.LiveConnection())
    {
    try
    {

    if(userInfoUserInfoCompanyXref != null)
    {

    if(userInfoUserInfoCompanyXrefID != 0)
    {

    DynamicParameters parameters = new DynamicParameters();
    parameters.Add(name:"@UserInfoUserInfoCompanyXrefID", userInfoUserInfoCompanyXrefID);

    parameters.Add(name: "@UpdateUserName", userInfoUserInfoCompanyXref.UpdateUserName);
    parameters.Add(name: "@UpdateFullName",userInfoUserInfoCompanyXref.UpdateFullName);
    parameters.Add(name: "@errID", dbType: DbType.Int32, direction: ParameterDirection.Output);
    parameters.Add(name: "@errText", dbType: DbType.String, direction: ParameterDirection.Output, size:2047);

    connection.Execute(sql: "[dbo].[usp_AdminDeleteUserInfoUserInfoCompanyXrefById]", param: parameters, commandType: CommandType.StoredProcedure);

    if (parameters.Get<int?>(name: "@errID") != null)
    {
    int errID = parameters.Get<int>(name: "@errID");
    string errText = parameters.Get<string>(name: "@errText");
    userInfoUserInfoCompanyXref.ErrID = errID;
    userInfoUserInfoCompanyXref.ErrText = errText;
    }
    else
    {
    userInfoUserInfoCompanyXref.DeleteTrueFalse = true;
    }

    }
    else
    {
    userInfoUserInfoCompanyXref.ErrID = 1;
    userInfoUserInfoCompanyXref.ErrText = "userInfoUserInfoCompanyXrefID cannot be zero.";
    }
    }
    else
    {
    userInfoUserInfoCompanyXref = new UserInfoUserInfoCompanyXref(){
    ErrID = 1,
    ErrText = "UserInfoUserInfoCompanyXref cannot be null."
    };
    }

    }
    catch (Exception exception)
    {
    Errors(userInfoUserInfoCompanyXref);
    Log4ExceptionConnDb.Ex(exception);
    }
    finally
    {
    ConnectionDb.CloseConnection(connection);
    }
    }

    return userInfoUserInfoCompanyXref;
    }

    private void Errors(UserInfoUserInfoCompanyXref userInfoUserInfoCompanyXref)
    {
    userInfoUserInfoCompanyXref.ErrID = 1;
    userInfoUserInfoCompanyXref.ErrText = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
    }
    #endregion

    }
  

    }
  