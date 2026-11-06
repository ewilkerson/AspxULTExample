
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


    public partial class AdminLoadUserInfoRepository : ILoadUserInfoRepository
    {

        #region AdminLoadUserInfoRepository

        public IEnumerable<LoadUserInfo> GetLoadUserInfos()
        {
            List<LoadUserInfo> loadUserInfoLists = new List<LoadUserInfo>();

            using (var connection = ConnectionDb.LiveConnection())
            {
                try
                {
                    using (var reader = connection.ExecuteReader(sql: "[dbo].[usp_AdminGetLoadUserInfos]"))
                    {

                        while (reader.Read())
                        {
                            LoadUserInfo loadUserInfo = new LoadUserInfo();
                            if (reader["UserInfoID"] != DBNull.Value)
                                loadUserInfo.UserInfoID = int.Parse(reader["UserInfoID"].ToString());
                            loadUserInfo.UserInfoUserIdentityName = reader["UserInfoUserIdentityName"].ToString();
                            loadUserInfo.UserInfoUserName = reader["UserInfoUserName"].ToString();
                            loadUserInfo.UserInfoFullName = reader["UserInfoFullName"].ToString();
                            loadUserInfo.UserInfoEmailAddress = reader["UserInfoEmailAddress"].ToString();
                            loadUserInfo.UserInfoJobTitle = reader["UserInfoJobTitle"].ToString();
                            if (reader["UserInfoActiveYesNo"] != DBNull.Value)
                                loadUserInfo.UserInfoActiveYesNo = bool.Parse(reader["UserInfoActiveYesNo"].ToString());
                            if (reader["UserInfoAccessLevelID"] != DBNull.Value)
                                loadUserInfo.UserInfoAccessLevelID = int.Parse(reader["UserInfoAccessLevelID"].ToString());
                            loadUserInfo.UserInfoAccessLevelName = reader["UserInfoAccessLevelName"].ToString();
                            loadUserInfoLists.Add(loadUserInfo);
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

            return loadUserInfoLists;

        }

        public LoadUserInfo GetLoadUserInfoById(int userInfoID)
        {

            LoadUserInfo loadUserInfo = new LoadUserInfo();

            using (var connection = ConnectionDb.LiveConnection())
            {
                try
                {

                    if (userInfoID != 0)
                    {

                        DynamicParameters parameters = new DynamicParameters();
                        parameters.Add(name: "@UserInfoID", userInfoID);


                        using (var reader = connection.ExecuteReader(sql: "[dbo].[usp_AdminGetLoadUserInfoById]", param: parameters, transaction: null, commandTimeout: null, CommandType.StoredProcedure))
                        {
                            if (reader.Read())
                            {
                                if (reader["UserInfoID"] != DBNull.Value)
                                    loadUserInfo.UserInfoID = int.Parse(reader["UserInfoID"].ToString());
                                loadUserInfo.UserInfoUserIdentityName = reader["UserInfoUserIdentityName"].ToString();
                                loadUserInfo.UserInfoUserName = reader["UserInfoUserName"].ToString();
                                loadUserInfo.UserInfoFullName = reader["UserInfoFullName"].ToString();
                                loadUserInfo.UserInfoEmailAddress = reader["UserInfoEmailAddress"].ToString();
                                loadUserInfo.UserInfoJobTitle = reader["UserInfoJobTitle"].ToString();
                                if (reader["UserInfoActiveYesNo"] != DBNull.Value)
                                    loadUserInfo.UserInfoActiveYesNo = bool.Parse(reader["UserInfoActiveYesNo"].ToString());
                                if (reader["UserInfoAccessLevelID"] != DBNull.Value)
                                    loadUserInfo.UserInfoAccessLevelID = int.Parse(reader["UserInfoAccessLevelID"].ToString());
                                loadUserInfo.UserInfoAccessLevelName = reader["UserInfoAccessLevelName"].ToString();
                            }
                        }
                    }
                    else
                    {
                        loadUserInfo.ErrID = 1;
                        loadUserInfo.ErrText = "userInfoID cannot be zero.";
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

        public LoadUserInfo InsertLoadUserInfo(LoadUserInfo loadUserInfo)
        {

            using (var connection = ConnectionDb.LiveConnection())
            {
                try
                {

                    if (loadUserInfo != null)
                    {
                        if (loadUserInfo.UserInfoID != 0)
                        {

                            DynamicParameters parameters = new DynamicParameters();
                            parameters.Add(name: "@UserInfoID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                            parameters.Add(name: "@UserInfoUserIdentityName", loadUserInfo.UserInfoUserIdentityName);
                            parameters.Add(name: "@UserInfoUserName", loadUserInfo.UserInfoUserName);
                            parameters.Add(name: "@UserInfoFullName", loadUserInfo.UserInfoFullName);
                            parameters.Add(name: "@UserInfoEmailAddress", loadUserInfo.UserInfoEmailAddress);
                            parameters.Add(name: "@UserInfoJobTitle", loadUserInfo.UserInfoJobTitle);
                            parameters.Add(name: "@UserInfoActiveYesNo", loadUserInfo.UserInfoActiveYesNo);
                            parameters.Add(name: "@UserInfoAccessLevelID", loadUserInfo.UserInfoAccessLevelID);

                            parameters.Add(name: "@UpdateUserName", loadUserInfo.UpdateUserName);
                            parameters.Add(name: "@UpdateFullName", loadUserInfo.UpdateFullName);
                            parameters.Add(name: "@errID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                            parameters.Add(name: "@errText", dbType: DbType.String, direction: ParameterDirection.Output, size: 2047);

                            connection.Execute(sql: "[dbo].[usp_AdminInsertLoadUserInfoById]", param: parameters, commandType: CommandType.StoredProcedure);

                            if (parameters.Get<int?>(name: "@errID") != null)
                            {
                                int errID = parameters.Get<int>(name: "@errID");
                                string errText = parameters.Get<string>(name: "@errText");
                                loadUserInfo.ErrID = errID;
                                loadUserInfo.ErrText = errText;

                            }
                            else
                            {
                                int userInfoID = parameters.Get<int>("@UserInfoID");
                                loadUserInfo.UserInfoID = userInfoID;
                            }

                        }
                        else
                        {
                            loadUserInfo.ErrID = 1;
                            loadUserInfo.ErrText = "UserInfoID cannot be zero.";
                        }

                    }
                    else
                    {
                        loadUserInfo = new LoadUserInfo()
                        {
                            ErrID = 1,
                            ErrText = "LoadUserInfo cannot be null."
                        };
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

        public LoadUserInfo UpdateLoadUserInfo(LoadUserInfo loadUserInfo)
        {

            using (var connection = ConnectionDb.LiveConnection())
            {
                try
                {

                    if (loadUserInfo != null)
                    {

                        if (loadUserInfo.UserInfoID != 0)
                        {

                            DynamicParameters parameters = new DynamicParameters();
                            parameters.Add(name: "@UserInfoID", loadUserInfo.UserInfoID);
                            parameters.Add(name: "@UserInfoUserIdentityName", loadUserInfo.UserInfoUserIdentityName);
                            parameters.Add(name: "@UserInfoUserName", loadUserInfo.UserInfoUserName);
                            parameters.Add(name: "@UserInfoFullName", loadUserInfo.UserInfoFullName);
                            parameters.Add(name: "@UserInfoEmailAddress", loadUserInfo.UserInfoEmailAddress);
                            parameters.Add(name: "@UserInfoJobTitle", loadUserInfo.UserInfoJobTitle);
                            parameters.Add(name: "@UserInfoActiveYesNo", loadUserInfo.UserInfoActiveYesNo);
                            parameters.Add(name: "@UserInfoAccessLevelID", loadUserInfo.UserInfoAccessLevelID);

                            parameters.Add(name: "@UpdateUserName", loadUserInfo.UpdateUserName);
                            parameters.Add(name: "@UpdateFullName", loadUserInfo.UpdateFullName);
                            parameters.Add(name: "@errID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                            parameters.Add(name: "@errText", dbType: DbType.String, direction: ParameterDirection.Output, size: 2047);

                            connection.Execute(sql: "[dbo].[usp_AdminUpdateLoadUserInfoById]", param: parameters, commandType: CommandType.StoredProcedure);

                            if (parameters.Get<int?>(name: "@errID") != null)
                            {
                                int errID = parameters.Get<int>(name: "@errID");
                                string errText = parameters.Get<string>(name: "@errText");
                                loadUserInfo.ErrID = errID;
                                loadUserInfo.ErrText = errText;

                            }

                        }
                        else
                        {
                            loadUserInfo.ErrID = 1;
                            loadUserInfo.ErrText = "UserInfoID cannot be zero.";
                        }

                    }
                    else
                    {
                        loadUserInfo = new LoadUserInfo()
                        {
                            ErrID = 1,
                            ErrText = "LoadUserInfo cannot be null."
                        };
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

        public LoadUserInfo DeleteLoadUserInfo(int userInfoID, LoadUserInfo loadUserInfo)
        {

            using (var connection = ConnectionDb.LiveConnection())
            {
                try
                {

                    if (loadUserInfo != null)
                    {

                        if (userInfoID != 0)
                        {

                            DynamicParameters parameters = new DynamicParameters();
                            parameters.Add(name: "@UserInfoID", userInfoID);

                            parameters.Add(name: "@UpdateUserName", loadUserInfo.UpdateUserName);
                            parameters.Add(name: "@UpdateFullName", loadUserInfo.UpdateFullName);
                            parameters.Add(name: "@errID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                            parameters.Add(name: "@errText", dbType: DbType.String, direction: ParameterDirection.Output, size: 2047);

                            connection.Execute(sql: "[dbo].[usp_AdminDeleteLoadUserInfoById]", param: parameters, commandType: CommandType.StoredProcedure);

                            if (parameters.Get<int?>(name: "@errID") != null)
                            {
                                int errID = parameters.Get<int>(name: "@errID");
                                string errText = parameters.Get<string>(name: "@errText");
                                loadUserInfo.ErrID = errID;
                                loadUserInfo.ErrText = errText;
                            }
                            else
                            {
                                loadUserInfo.DeleteTrueFalse = true;
                            }

                        }
                        else
                        {
                            loadUserInfo.ErrID = 1;
                            loadUserInfo.ErrText = "userInfoID cannot be zero.";
                        }
                    }
                    else
                    {
                        loadUserInfo = new LoadUserInfo()
                        {
                            ErrID = 1,
                            ErrText = "LoadUserInfo cannot be null."
                        };
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

        private void Errors(LoadUserInfo loadUserInfo)
        {
            loadUserInfo.ErrID = 1;
            loadUserInfo.ErrText = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
        }
        #endregion

    }


}
