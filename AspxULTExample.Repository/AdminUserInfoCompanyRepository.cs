
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

    
    public partial class AdminUserInfoCompanyRepository : IUserInfoCompanyRepository
    {

    #region AdminUserInfoCompanyRepository

    public IEnumerable<UserInfoCompany> GetUserInfoCompanys()
    {
    List <UserInfoCompany> userInfoCompanyLists = new List<UserInfoCompany>();

    using (var connection = ConnectionDb.LiveConnection())
    {
    try
    {
    using (var reader = connection.ExecuteReader(sql: "[dbo].[usp_AdminGetUserInfoCompanys]"))
    {

    while (reader.Read())
    {
    UserInfoCompany userInfoCompany = new UserInfoCompany();
    			if(reader["UserInfoCompanyID"] != DBNull.Value)
				userInfoCompany.UserInfoCompanyID = int.Parse(reader["UserInfoCompanyID"].ToString());
			userInfoCompany.UserInfoCompanyEIN = reader["UserInfoCompanyEIN"].ToString();
			userInfoCompany.UserInfoCompanyName = reader["UserInfoCompanyName"].ToString();
			userInfoCompany.UserInfoCompanyAddress1 = reader["UserInfoCompanyAddress1"].ToString();
			userInfoCompany.UserInfoCompanyAddress2 = reader["UserInfoCompanyAddress2"].ToString();
			userInfoCompany.UserInfoCompanyCityStateZip = reader["UserInfoCompanyCityStateZip"].ToString();
			userInfoCompany.UserInfoCompanyTelephone = reader["UserInfoCompanyTelephone"].ToString();
			userInfoCompany.UserInfoCompanyEmailAddress = reader["UserInfoCompanyEmailAddress"].ToString();
			userInfoCompany.UserCompanyWebsiteAddress = reader["UserCompanyWebsiteAddress"].ToString();
			if(reader["UserInfoCountriesID"] != DBNull.Value)
				userInfoCompany.UserInfoCountriesID = int.Parse(reader["UserInfoCountriesID"].ToString());
			if(reader["UserInfoCompanyActiveYesNo"] != DBNull.Value)
				userInfoCompany.UserInfoCompanyActiveYesNo = bool.Parse(reader["UserInfoCompanyActiveYesNo"].ToString());

    userInfoCompanyLists.Add(userInfoCompany);
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

    return userInfoCompanyLists;

    }

    public UserInfoCompany GetUserInfoCompanyById(int userInfoCompanyID)
    {

    UserInfoCompany userInfoCompany = new UserInfoCompany();

    using (var connection = ConnectionDb.LiveConnection())
    {
    try
    {

    if (userInfoCompanyID != 0)
    {

    DynamicParameters parameters = new DynamicParameters();
    parameters.Add(name:"@UserInfoCompanyID", userInfoCompanyID);


    using (var reader = connection.ExecuteReader(sql: "[dbo].[usp_AdminGetUserInfoCompanyById]", param: parameters, transaction: null, commandTimeout: null, CommandType.StoredProcedure))
    {
    if (reader.Read())
    {
    			if(reader["UserInfoCompanyID"] != DBNull.Value)
				userInfoCompany.UserInfoCompanyID = int.Parse(reader["UserInfoCompanyID"].ToString());
			userInfoCompany.UserInfoCompanyEIN = reader["UserInfoCompanyEIN"].ToString();
			userInfoCompany.UserInfoCompanyName = reader["UserInfoCompanyName"].ToString();
			userInfoCompany.UserInfoCompanyAddress1 = reader["UserInfoCompanyAddress1"].ToString();
			userInfoCompany.UserInfoCompanyAddress2 = reader["UserInfoCompanyAddress2"].ToString();
			userInfoCompany.UserInfoCompanyCityStateZip = reader["UserInfoCompanyCityStateZip"].ToString();
			userInfoCompany.UserInfoCompanyTelephone = reader["UserInfoCompanyTelephone"].ToString();
			userInfoCompany.UserInfoCompanyEmailAddress = reader["UserInfoCompanyEmailAddress"].ToString();
			userInfoCompany.UserCompanyWebsiteAddress = reader["UserCompanyWebsiteAddress"].ToString();
			if(reader["UserInfoCountriesID"] != DBNull.Value)
				userInfoCompany.UserInfoCountriesID = int.Parse(reader["UserInfoCountriesID"].ToString());
			if(reader["UserInfoCompanyActiveYesNo"] != DBNull.Value)
				userInfoCompany.UserInfoCompanyActiveYesNo = bool.Parse(reader["UserInfoCompanyActiveYesNo"].ToString());

    }
    }
    }
    else
    {
    userInfoCompany.ErrID = 1;
    userInfoCompany.ErrText = "userInfoCompanyID cannot be zero.";
    }

    }
    catch (Exception exception)
    {
    Errors(userInfoCompany);
    Log4ExceptionConnDb.Ex(exception);
    }
    finally
    {
    ConnectionDb.CloseConnection(connection);
    }
    }

    return userInfoCompany;

    }

    public UserInfoCompany InsertUserInfoCompany(UserInfoCompany userInfoCompany)
    {

    using (var connection = ConnectionDb.LiveConnection())
    {
    try
    {

    if(userInfoCompany != null)
    {
    if(userInfoCompany.UserInfoCompanyID != 0)
    {

    DynamicParameters parameters = new DynamicParameters();
    parameters.Add(name:"@UserInfoCompanyID", dbType: DbType.Int32, direction: ParameterDirection.Output);
parameters.Add(name:"@UserInfoCompanyEIN", userInfoCompany.UserInfoCompanyEIN);
parameters.Add(name:"@UserInfoCompanyName", userInfoCompany.UserInfoCompanyName);
parameters.Add(name:"@UserInfoCompanyAddress1", userInfoCompany.UserInfoCompanyAddress1);
parameters.Add(name:"@UserInfoCompanyAddress2", userInfoCompany.UserInfoCompanyAddress2);
parameters.Add(name:"@UserInfoCompanyCityStateZip", userInfoCompany.UserInfoCompanyCityStateZip);
parameters.Add(name:"@UserInfoCompanyTelephone", userInfoCompany.UserInfoCompanyTelephone);
parameters.Add(name:"@UserInfoCompanyEmailAddress", userInfoCompany.UserInfoCompanyEmailAddress);
parameters.Add(name:"@UserCompanyWebsiteAddress", userInfoCompany.UserCompanyWebsiteAddress);
parameters.Add(name:"@UserInfoCountriesID", userInfoCompany.UserInfoCountriesID);
parameters.Add(name:"@UserInfoCompanyActiveYesNo", userInfoCompany.UserInfoCompanyActiveYesNo);

    parameters.Add(name: "@UpdateUserName", userInfoCompany.UpdateUserName);
    parameters.Add(name: "@UpdateFullName",userInfoCompany.UpdateFullName);
    parameters.Add(name: "@errID", dbType: DbType.Int32, direction: ParameterDirection.Output);
    parameters.Add(name: "@errText", dbType: DbType.String, direction: ParameterDirection.Output, size:2047);

    connection.Execute(sql: "[dbo].[usp_AdminInsertUserInfoCompanyById]", param: parameters, commandType: CommandType.StoredProcedure);

    if (parameters.Get<int?>(name: "@errID") != null)
    {
    int errID = parameters.Get<int>(name: "@errID");
    string errText = parameters.Get<string>(name: "@errText");
    userInfoCompany.ErrID = errID;
    userInfoCompany.ErrText = errText;

    }
    else
    {
    			int userInfoCompanyID = parameters.Get<int>("@UserInfoCompanyID");
userInfoCompany.UserInfoCompanyID = userInfoCompanyID;
    }

    }
    else
    {
    userInfoCompany.ErrID = 1;
    userInfoCompany.ErrText = "UserInfoCompanyID cannot be zero.";
    }

    }
    else
    {
    userInfoCompany = new UserInfoCompany(){
    ErrID = 1,
    ErrText = "UserInfoCompany cannot be null."
    };
    }

    }
    catch (Exception exception)
    {
    Errors(userInfoCompany);
    Log4ExceptionConnDb.Ex(exception);
    }
    finally
    {
    ConnectionDb.CloseConnection(connection);
    }
    }
    return userInfoCompany;
    }

    public UserInfoCompany UpdateUserInfoCompany(UserInfoCompany userInfoCompany)
    {

    using (var connection = ConnectionDb.LiveConnection())
    {
    try
    {

    if(userInfoCompany != null)
    {

    if(userInfoCompany.UserInfoCompanyID != 0)
    {

    DynamicParameters parameters = new DynamicParameters();
    parameters.Add(name:"@UserInfoCompanyID", userInfoCompany.UserInfoCompanyID);
parameters.Add(name:"@UserInfoCompanyEIN", userInfoCompany.UserInfoCompanyEIN);
parameters.Add(name:"@UserInfoCompanyName", userInfoCompany.UserInfoCompanyName);
parameters.Add(name:"@UserInfoCompanyAddress1", userInfoCompany.UserInfoCompanyAddress1);
parameters.Add(name:"@UserInfoCompanyAddress2", userInfoCompany.UserInfoCompanyAddress2);
parameters.Add(name:"@UserInfoCompanyCityStateZip", userInfoCompany.UserInfoCompanyCityStateZip);
parameters.Add(name:"@UserInfoCompanyTelephone", userInfoCompany.UserInfoCompanyTelephone);
parameters.Add(name:"@UserInfoCompanyEmailAddress", userInfoCompany.UserInfoCompanyEmailAddress);
parameters.Add(name:"@UserCompanyWebsiteAddress", userInfoCompany.UserCompanyWebsiteAddress);
parameters.Add(name:"@UserInfoCountriesID", userInfoCompany.UserInfoCountriesID);
parameters.Add(name:"@UserInfoCompanyActiveYesNo", userInfoCompany.UserInfoCompanyActiveYesNo);

    parameters.Add(name: "@UpdateUserName", userInfoCompany.UpdateUserName);
    parameters.Add(name: "@UpdateFullName",userInfoCompany.UpdateFullName);
    parameters.Add(name: "@errID", dbType: DbType.Int32, direction: ParameterDirection.Output);
    parameters.Add(name: "@errText", dbType: DbType.String, direction: ParameterDirection.Output, size:2047);

    connection.Execute(sql: "[dbo].[usp_AdminUpdateUserInfoCompanyById]", param: parameters, commandType: CommandType.StoredProcedure);

    if (parameters.Get<int?>(name: "@errID") != null)
    {
    int errID = parameters.Get<int>(name: "@errID");
    string errText = parameters.Get<string>(name: "@errText");
    userInfoCompany.ErrID = errID;
    userInfoCompany.ErrText = errText;

    }

    }
    else
    {
    userInfoCompany.ErrID = 1;
    userInfoCompany.ErrText = "UserInfoCompanyID cannot be zero.";
    }

    }
    else
    {
    userInfoCompany = new UserInfoCompany(){
    ErrID = 1,
    ErrText = "UserInfoCompany cannot be null."
    };
    }

    }
    catch (Exception exception)
    {
    Errors(userInfoCompany);
    Log4ExceptionConnDb.Ex(exception);
    }
    finally
    {
    ConnectionDb.CloseConnection(connection);
    }
    }

    return userInfoCompany;
    }

    public UserInfoCompany DeleteUserInfoCompany(int userInfoCompanyID,UserInfoCompany userInfoCompany)
    {

    using (var connection = ConnectionDb.LiveConnection())
    {
    try
    {

    if(userInfoCompany != null)
    {

    if(userInfoCompanyID != 0)
    {

    DynamicParameters parameters = new DynamicParameters();
    parameters.Add(name:"@UserInfoCompanyID", userInfoCompanyID);

    parameters.Add(name: "@UpdateUserName", userInfoCompany.UpdateUserName);
    parameters.Add(name: "@UpdateFullName",userInfoCompany.UpdateFullName);
    parameters.Add(name: "@errID", dbType: DbType.Int32, direction: ParameterDirection.Output);
    parameters.Add(name: "@errText", dbType: DbType.String, direction: ParameterDirection.Output, size:2047);

    connection.Execute(sql: "[dbo].[usp_AdminDeleteUserInfoCompanyById]", param: parameters, commandType: CommandType.StoredProcedure);

    if (parameters.Get<int?>(name: "@errID") != null)
    {
    int errID = parameters.Get<int>(name: "@errID");
    string errText = parameters.Get<string>(name: "@errText");
    userInfoCompany.ErrID = errID;
    userInfoCompany.ErrText = errText;
    }
    else
    {
    userInfoCompany.DeleteTrueFalse = true;
    }

    }
    else
    {
    userInfoCompany.ErrID = 1;
    userInfoCompany.ErrText = "userInfoCompanyID cannot be zero.";
    }
    }
    else
    {
    userInfoCompany = new UserInfoCompany(){
    ErrID = 1,
    ErrText = "UserInfoCompany cannot be null."
    };
    }

    }
    catch (Exception exception)
    {
    Errors(userInfoCompany);
    Log4ExceptionConnDb.Ex(exception);
    }
    finally
    {
    ConnectionDb.CloseConnection(connection);
    }
    }

    return userInfoCompany;
    }

    private void Errors(UserInfoCompany userInfoCompany)
    {
    userInfoCompany.ErrID = 1;
    userInfoCompany.ErrText = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
    }
    #endregion

    }
  

    }
  