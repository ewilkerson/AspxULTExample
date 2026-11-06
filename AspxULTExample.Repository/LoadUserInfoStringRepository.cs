
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

    public partial class LoadUserInfoStringRepository : ILoadUserInfoStringRepository
    {

    #region LoadUserInfoStringRepository

    public LoadUserInfo GetLoadUserInfoByString(string userInfoUserIdentityName)
    {

    LoadUserInfo loadUserInfo = new LoadUserInfo();


    using (var connection = ConnectionDb.LiveConnection())
    {
    try
    {
    if (!string.IsNullOrWhiteSpace(userInfoUserIdentityName))
    {

    var p = new DynamicParameters();
    p.Add("@UserInfoUserIdentityName", userInfoUserIdentityName);

    using (var reader = connection.ExecuteReader(sql: "[dbo].[usp_GetLoadUserInfoByString]", param: p,
    commandType: CommandType.StoredProcedure))
    {
    if (reader.Read())
    {
    if (reader["UserInfoID"] != DBNull.Value)
    loadUserInfo.UserInfoID = Int32.Parse(reader["UserInfoID"].ToString());

    loadUserInfo.UserInfoUserIdentityName = reader["UserInfoUserIdentityName"].ToString();

    loadUserInfo.UserInfoUserName = reader["UserInfoUserName"].ToString();

    loadUserInfo.UserInfoFullName = reader["UserInfoFullName"].ToString();

    loadUserInfo.UserInfoEmailAddress = reader["UserInfoEmailAddress"].ToString();

    loadUserInfo.UserInfoJobTitle = reader["UserInfoJobTitle"].ToString();

    if (reader["UserInfoAccessLevelID"] != DBNull.Value)
    loadUserInfo.UserInfoAccessLevelID = Int32.Parse(reader["UserInfoAccessLevelID"].ToString());

    if (reader["UserInfoActiveYesNo"] != DBNull.Value)
    loadUserInfo.UserInfoActiveYesNo = bool.Parse(reader["UserInfoActiveYesNo"].ToString());

    loadUserInfo.UserInfoAccessLevelName = reader["UserInfoAccessLevelName"].ToString();

    }
    }
    }
    }
    catch (Exception exception)
    {
    Errors(loadUserInfo);
    Log4ExceptionConnDb.Ex(exception);
    }
    finally
    {
    ConnectionDb.CloseConnection(connection);
    }
    }

    return loadUserInfo;
    }

    public IEnumerable<UserInfoUserInfoCompanyXref> GetLoadUserInfoUserInfoCompanyXrefsById(int userInfoID)
    {
    List<UserInfoUserInfoCompanyXref> userInfoUserInfoCompanyXrefLists = new List<UserInfoUserInfoCompanyXref>();

    using (var connection = ConnectionDb.LiveConnection())
    {
    try
    {
    if (userInfoID != 0)
    {

    DynamicParameters parameters = new DynamicParameters();
    parameters.Add(name: "@UserInfoID", userInfoID);

    using (var reader = connection.ExecuteReader(sql: "[dbo].[usp_GetLoadUserInfoUserInfoCompanyXrefsById]", param: parameters, transaction: null, commandTimeout: null, CommandType.StoredProcedure))
    {

    while (reader.Read())
    {
    UserInfoUserInfoCompanyXref userInfoUserInfoCompanyXref = new UserInfoUserInfoCompanyXref();
    if (reader["UserInfoID"] != DBNull.Value)
    userInfoUserInfoCompanyXref.UserInfoID = int.Parse(reader["UserInfoID"].ToString());

    if (reader["UserInfoCompanyID"] != DBNull.Value)
    userInfoUserInfoCompanyXref.UserInfoCompanyID = int.Parse(reader["UserInfoCompanyID"].ToString());
    userInfoUserInfoCompanyXref.UserInfoCompanyName = reader["UserInfoCompanyName"].ToString();

    userInfoUserInfoCompanyXrefLists.Add(userInfoUserInfoCompanyXref);
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


    return userInfoUserInfoCompanyXrefLists;

    }


    public IEnumerable<LoadUserInfo> GetLoadUserInfoEmailAddressByCompanyID(int companyID)
    {

    List<LoadUserInfo> loadUserInfoEmailAddressLists = new List<LoadUserInfo>();

    using (var connection = ConnectionDb.LiveConnection())
    {
    try
    {
    if (companyID != 0)
    {

    var p = new DynamicParameters();
    p.Add("@CompanyID", companyID);

    using (var reader = connection.ExecuteReader(sql: "[dbo].[usp_GetLoadUserInfoEmailAddressByCompanyID]", param: p, commandType: CommandType.StoredProcedure))
    {

    while (reader.Read())
    {
    LoadUserInfo loadUserInfoEmailAddress = new LoadUserInfo();
    if (reader["UserInfoCompanyID"] != DBNull.Value)
    loadUserInfoEmailAddress.UserInfoCompanyID = int.Parse(reader["UserInfoCompanyID"].ToString());
    loadUserInfoEmailAddress.UserInfoFullName = reader["UserInfoFullName"].ToString();
    loadUserInfoEmailAddress.UserInfoEmailAddress = reader["UserInfoEmailAddress"].ToString();
    if (reader["UserInfoAccessLevelID"] != DBNull.Value)
    loadUserInfoEmailAddress.UserInfoAccessLevelID = int.Parse(reader["UserInfoAccessLevelID"].ToString());

    loadUserInfoEmailAddressLists.Add(loadUserInfoEmailAddress);
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

    return loadUserInfoEmailAddressLists;


    }

    private void Errors(LoadUserInfo loadUserInfo)
    {
    loadUserInfo.ErrID = 1;
    loadUserInfo.ErrText = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
    }


    #endregion

    }


    }
  