
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

    
    public partial class AdminUserInfoCountriesRepository : IUserInfoCountriesRepository
    {

    #region AdminUserInfoCountriesRepository

    public IEnumerable<UserInfoCountries> GetUserInfoCountriess()
    {
    List <UserInfoCountries> userInfoCountriesLists = new List<UserInfoCountries>();

    using (var connection = ConnectionDb.LiveConnection())
    {
    try
    {
    using (var reader = connection.ExecuteReader(sql: "[dbo].[usp_AdminGetUserInfoCountriess]"))
    {

    while (reader.Read())
    {
    UserInfoCountries userInfoCountries = new UserInfoCountries();
    			if(reader["UserInfoCountriesID"] != DBNull.Value)
				userInfoCountries.UserInfoCountriesID = int.Parse(reader["UserInfoCountriesID"].ToString());
			userInfoCountries.UserInfoCountriesName = reader["UserInfoCountriesName"].ToString();
			if(reader["UserInfoCountriesActiveYesNo"] != DBNull.Value)
				userInfoCountries.UserInfoCountriesActiveYesNo = bool.Parse(reader["UserInfoCountriesActiveYesNo"].ToString());

    userInfoCountriesLists.Add(userInfoCountries);
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

    return userInfoCountriesLists;

    }

    public UserInfoCountries GetUserInfoCountriesById(int userInfoCountriesID)
    {

    UserInfoCountries userInfoCountries = new UserInfoCountries();

    using (var connection = ConnectionDb.LiveConnection())
    {
    try
    {

    if (userInfoCountriesID != 0)
    {

    DynamicParameters parameters = new DynamicParameters();
    parameters.Add(name:"@UserInfoCountriesID", userInfoCountriesID);


    using (var reader = connection.ExecuteReader(sql: "[dbo].[usp_AdminGetUserInfoCountriesById]", param: parameters, transaction: null, commandTimeout: null, CommandType.StoredProcedure))
    {
    if (reader.Read())
    {
    			if(reader["UserInfoCountriesID"] != DBNull.Value)
				userInfoCountries.UserInfoCountriesID = int.Parse(reader["UserInfoCountriesID"].ToString());
			userInfoCountries.UserInfoCountriesName = reader["UserInfoCountriesName"].ToString();
			if(reader["UserInfoCountriesActiveYesNo"] != DBNull.Value)
				userInfoCountries.UserInfoCountriesActiveYesNo = bool.Parse(reader["UserInfoCountriesActiveYesNo"].ToString());

    }
    }
    }
    else
    {
    userInfoCountries.ErrID = 1;
    userInfoCountries.ErrText = "userInfoCountriesID cannot be zero.";
    }

    }
    catch (Exception exception)
    {
    Errors(userInfoCountries);
    Log4ExceptionConnDb.Ex(exception);
    }
    finally
    {
    ConnectionDb.CloseConnection(connection);
    }
    }

    return userInfoCountries;

    }

    public UserInfoCountries InsertUserInfoCountries(UserInfoCountries userInfoCountries)
    {

    using (var connection = ConnectionDb.LiveConnection())
    {
    try
    {

    if(userInfoCountries != null)
    {
    if(userInfoCountries.UserInfoCountriesID != 0)
    {

    DynamicParameters parameters = new DynamicParameters();
    parameters.Add(name:"@UserInfoCountriesID", dbType: DbType.Int32, direction: ParameterDirection.Output);
parameters.Add(name:"@UserInfoCountriesName", userInfoCountries.UserInfoCountriesName);
parameters.Add(name:"@UserInfoCountriesActiveYesNo", userInfoCountries.UserInfoCountriesActiveYesNo);

    parameters.Add(name: "@UpdateUserName", userInfoCountries.UpdateUserName);
    parameters.Add(name: "@UpdateFullName",userInfoCountries.UpdateFullName);
    parameters.Add(name: "@errID", dbType: DbType.Int32, direction: ParameterDirection.Output);
    parameters.Add(name: "@errText", dbType: DbType.String, direction: ParameterDirection.Output, size:2047);

    connection.Execute(sql: "[dbo].[usp_AdminInsertUserInfoCountriesById]", param: parameters, commandType: CommandType.StoredProcedure);

    if (parameters.Get<int?>(name: "@errID") != null)
    {
    int errID = parameters.Get<int>(name: "@errID");
    string errText = parameters.Get<string>(name: "@errText");
    userInfoCountries.ErrID = errID;
    userInfoCountries.ErrText = errText;

    }
    else
    {
    			int userInfoCountriesID = parameters.Get<int>("@UserInfoCountriesID");
userInfoCountries.UserInfoCountriesID = userInfoCountriesID;
    }

    }
    else
    {
    userInfoCountries.ErrID = 1;
    userInfoCountries.ErrText = "UserInfoCountriesID cannot be zero.";
    }

    }
    else
    {
    userInfoCountries = new UserInfoCountries(){
    ErrID = 1,
    ErrText = "UserInfoCountries cannot be null."
    };
    }

    }
    catch (Exception exception)
    {
    Errors(userInfoCountries);
    Log4ExceptionConnDb.Ex(exception);
    }
    finally
    {
    ConnectionDb.CloseConnection(connection);
    }
    }
    return userInfoCountries;
    }

    public UserInfoCountries UpdateUserInfoCountries(UserInfoCountries userInfoCountries)
    {

    using (var connection = ConnectionDb.LiveConnection())
    {
    try
    {

    if(userInfoCountries != null)
    {

    if(userInfoCountries.UserInfoCountriesID != 0)
    {

    DynamicParameters parameters = new DynamicParameters();
    parameters.Add(name:"@UserInfoCountriesID", userInfoCountries.UserInfoCountriesID);
parameters.Add(name:"@UserInfoCountriesName", userInfoCountries.UserInfoCountriesName);
parameters.Add(name:"@UserInfoCountriesActiveYesNo", userInfoCountries.UserInfoCountriesActiveYesNo);

    parameters.Add(name: "@UpdateUserName", userInfoCountries.UpdateUserName);
    parameters.Add(name: "@UpdateFullName",userInfoCountries.UpdateFullName);
    parameters.Add(name: "@errID", dbType: DbType.Int32, direction: ParameterDirection.Output);
    parameters.Add(name: "@errText", dbType: DbType.String, direction: ParameterDirection.Output, size:2047);

    connection.Execute(sql: "[dbo].[usp_AdminUpdateUserInfoCountriesById]", param: parameters, commandType: CommandType.StoredProcedure);

    if (parameters.Get<int?>(name: "@errID") != null)
    {
    int errID = parameters.Get<int>(name: "@errID");
    string errText = parameters.Get<string>(name: "@errText");
    userInfoCountries.ErrID = errID;
    userInfoCountries.ErrText = errText;

    }

    }
    else
    {
    userInfoCountries.ErrID = 1;
    userInfoCountries.ErrText = "UserInfoCountriesID cannot be zero.";
    }

    }
    else
    {
    userInfoCountries = new UserInfoCountries(){
    ErrID = 1,
    ErrText = "UserInfoCountries cannot be null."
    };
    }

    }
    catch (Exception exception)
    {
    Errors(userInfoCountries);
    Log4ExceptionConnDb.Ex(exception);
    }
    finally
    {
    ConnectionDb.CloseConnection(connection);
    }
    }

    return userInfoCountries;
    }

    public UserInfoCountries DeleteUserInfoCountries(int userInfoCountriesID,UserInfoCountries userInfoCountries)
    {

    using (var connection = ConnectionDb.LiveConnection())
    {
    try
    {

    if(userInfoCountries != null)
    {

    if(userInfoCountriesID != 0)
    {

    DynamicParameters parameters = new DynamicParameters();
    parameters.Add(name:"@UserInfoCountriesID", userInfoCountriesID);

    parameters.Add(name: "@UpdateUserName", userInfoCountries.UpdateUserName);
    parameters.Add(name: "@UpdateFullName",userInfoCountries.UpdateFullName);
    parameters.Add(name: "@errID", dbType: DbType.Int32, direction: ParameterDirection.Output);
    parameters.Add(name: "@errText", dbType: DbType.String, direction: ParameterDirection.Output, size:2047);

    connection.Execute(sql: "[dbo].[usp_AdminDeleteUserInfoCountriesById]", param: parameters, commandType: CommandType.StoredProcedure);

    if (parameters.Get<int?>(name: "@errID") != null)
    {
    int errID = parameters.Get<int>(name: "@errID");
    string errText = parameters.Get<string>(name: "@errText");
    userInfoCountries.ErrID = errID;
    userInfoCountries.ErrText = errText;
    }
    else
    {
    userInfoCountries.DeleteTrueFalse = true;
    }

    }
    else
    {
    userInfoCountries.ErrID = 1;
    userInfoCountries.ErrText = "userInfoCountriesID cannot be zero.";
    }
    }
    else
    {
    userInfoCountries = new UserInfoCountries(){
    ErrID = 1,
    ErrText = "UserInfoCountries cannot be null."
    };
    }

    }
    catch (Exception exception)
    {
    Errors(userInfoCountries);
    Log4ExceptionConnDb.Ex(exception);
    }
    finally
    {
    ConnectionDb.CloseConnection(connection);
    }
    }

    return userInfoCountries;
    }

    private void Errors(UserInfoCountries userInfoCountries)
    {
    userInfoCountries.ErrID = 1;
    userInfoCountries.ErrText = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
    }
    #endregion

    }
  

    }
  