
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Linq;
using AspxULTExample.Models;
using AspxULTExample.Models.Interface;

namespace AspxULTExample.Repository
{
    public partial class AdminLoadUserInfoXmlRepository : SerializeDeserializeXmlRepository, ILoadUserInfoRepository
    {

        #region AdminLoadUserInfoXmlRepository

        private readonly string urlMapPath = HttpContext.Current.Server.MapPath("~");
        private string xmlUserInfo;
        private string xmlUserInfoAccessLevel;
        private string xmlUserInfoUserInfoAccessLevelXref;

        public AdminLoadUserInfoXmlRepository()
        {
            string xmlFolder = urlMapPath + "\\Xml";

            xmlUserInfo = xmlFolder + "\\UserInfoXml.xml";

            if (!Directory.Exists(xmlFolder))
                Directory.CreateDirectory(xmlFolder);

            if (!File.Exists(xmlUserInfo))
            {
                File.WriteAllText(xmlUserInfo, "<?xml version=\"1.0\" encoding=\"utf-8\"?><UserInfoXml xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" ><UserInfoLists></UserInfoLists></UserInfoXml>");
            }

            xmlUserInfoAccessLevel = xmlFolder + "\\UserInfoAccessLevelXml.xml";

            if (!Directory.Exists(xmlFolder))
                Directory.CreateDirectory(xmlFolder);

            if (!File.Exists(xmlUserInfoAccessLevel))
            {
                File.WriteAllText(xmlUserInfoAccessLevel, "<?xml version=\"1.0\" encoding=\"utf-8\"?><UserInfoAccessLevelXml xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" ><UserInfoAccessLevelLists></UserInfoAccessLevelLists></UserInfoAccessLevelXml>");
            }


            xmlUserInfoUserInfoAccessLevelXref = xmlFolder + "\\UserInfoUserInfoAccessLevelXrefXml.xml";

            if (!Directory.Exists(xmlFolder))
                Directory.CreateDirectory(xmlFolder);

            if (!File.Exists(xmlUserInfoUserInfoAccessLevelXref))
            {
                File.WriteAllText(xmlUserInfoUserInfoAccessLevelXref, "<?xml version=\"1.0\" encoding=\"utf-8\"?><UserInfoUserInfoAccessLevelXrefXml xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" ><UserInfoUserInfoAccessLevelXrefLists></UserInfoUserInfoAccessLevelXrefLists></UserInfoUserInfoAccessLevelXrefXml>");
            }


        }

        public IEnumerable<LoadUserInfo> GetLoadUserInfos()
        {
            List<LoadUserInfo> loadUserInfoLists = new List<LoadUserInfo>();

            try
            {
                List<UserInfo> userInfoLists = new List<UserInfo>();
                List<UserInfoAccessLevel> userInfoAccessLevelLists = new List<UserInfoAccessLevel>();
                List<UserInfoUserInfoAccessLevelXref> userInfoUserInfoAccessLevelXrefLists = new List<UserInfoUserInfoAccessLevelXref>();

                UserInfoXml userInfoXml = XmlDeserialize<UserInfoXml>(xmlUserInfo);
                userInfoLists = userInfoXml.UserInfoLists.ToList();

                UserInfoAccessLevelXml userInfoAccessLevelXml = XmlDeserialize<UserInfoAccessLevelXml>(xmlUserInfoAccessLevel);
                userInfoAccessLevelLists = userInfoAccessLevelXml.UserInfoAccessLevelLists.ToList();

                UserInfoUserInfoAccessLevelXrefXml userInfoUserInfoAccessLevelXrefXml = XmlDeserialize<UserInfoUserInfoAccessLevelXrefXml>(xmlUserInfoUserInfoAccessLevelXref);
                userInfoUserInfoAccessLevelXrefLists = userInfoUserInfoAccessLevelXrefXml.UserInfoUserInfoAccessLevelXrefLists.ToList();

                var loadUInfoLists =
                (from UUALX in userInfoUserInfoAccessLevelXrefLists
                 join U in userInfoLists on UUALX.UserInfoID equals U.UserInfoID
                 join UAL in userInfoAccessLevelLists on UUALX.UserInfoAccessLevelID equals UAL.UserInfoAccessLevelID
                 orderby U.UserInfoID
                 select new LoadUserInfo
                 {
                     UserInfoID = U.UserInfoID,
                     UserInfoUserIdentityName = U.UserInfoUserIdentityName,
                     UserInfoUserName = U.UserInfoUserName,
                     UserInfoFullName = U.UserInfoFullName,
                     UserInfoEmailAddress = U.UserInfoEmailAddress,
                     UserInfoJobTitle = U.UserInfoJobTitle,
                     UserInfoActiveYesNo = U.UserInfoActiveYesNo,
                     CreateUserName = U.CreateUserName,
                     CreateFullName = U.CreateFullName,
                     CreateDate = U.CreateDate,
                     UpdateUserName = U.UpdateUserName,
                     UpdateFullName = U.UpdateFullName,
                     UpdateDate = U.UpdateDate,
                     UserInfoAccessLevelID = UAL.UserInfoAccessLevelID,
                     UserInfoAccessLevelName = UAL.UserInfoAccessLevelName
                 });

                loadUserInfoLists = loadUInfoLists.ToList();
            }
            catch (Exception exception)
            {
                Log4ExceptionConnDb.ExXml(exception);
            }

            return loadUserInfoLists;
        }

        public LoadUserInfo GetLoadUserInfoById(int userInfoID)
        {
            LoadUserInfo loadUserInfo = new LoadUserInfo();

            try
            {
                if (userInfoID != 0)
                {

                    List<UserInfo> userInfoLists = new List<UserInfo>();
                    List<UserInfoAccessLevel> userInfoAccessLevelLists = new List<UserInfoAccessLevel>();
                    List<UserInfoUserInfoAccessLevelXref> userInfoUserInfoAccessLevelXrefLists = new List<UserInfoUserInfoAccessLevelXref>();

                    UserInfoXml userInfoXml = XmlDeserialize<UserInfoXml>(xmlUserInfo);
                    userInfoLists = userInfoXml.UserInfoLists.ToList();

                    UserInfoAccessLevelXml userInfoAccessLevelXml = XmlDeserialize<UserInfoAccessLevelXml>(xmlUserInfoAccessLevel);
                    userInfoAccessLevelLists = userInfoAccessLevelXml.UserInfoAccessLevelLists.ToList();

                    UserInfoUserInfoAccessLevelXrefXml userInfoUserInfoAccessLevelXrefXml = XmlDeserialize<UserInfoUserInfoAccessLevelXrefXml>(xmlUserInfoUserInfoAccessLevelXref);
                    userInfoUserInfoAccessLevelXrefLists = userInfoUserInfoAccessLevelXrefXml.UserInfoUserInfoAccessLevelXrefLists.ToList();

                    var loadUInfoLists =
                    (from UUALX in userInfoUserInfoAccessLevelXrefLists
                     join U in userInfoLists on UUALX.UserInfoID equals U.UserInfoID
                     join UAL in userInfoAccessLevelLists on UUALX.UserInfoAccessLevelID equals UAL.UserInfoAccessLevelID
                     where U.UserInfoID == userInfoID
                     orderby U.UserInfoID
                     select new LoadUserInfo
                     {
                         UserInfoID = U.UserInfoID,
                         UserInfoUserIdentityName = U.UserInfoUserIdentityName,
                         UserInfoUserName = U.UserInfoUserName,
                         UserInfoFullName = U.UserInfoFullName,
                         UserInfoEmailAddress = U.UserInfoEmailAddress,
                         UserInfoJobTitle = U.UserInfoJobTitle,
                         UserInfoActiveYesNo = U.UserInfoActiveYesNo,
                         CreateUserName = U.CreateUserName,
                         CreateFullName = U.CreateFullName,
                         CreateDate = U.CreateDate,
                         UpdateUserName = U.UpdateUserName,
                         UpdateFullName = U.UpdateFullName,
                         UpdateDate = U.UpdateDate,
                         UserInfoAccessLevelID = UAL.UserInfoAccessLevelID,
                         UserInfoAccessLevelName = UAL.UserInfoAccessLevelName
                     });

                    loadUserInfo = loadUInfoLists.FirstOrDefault();

                }
                else
                {
                    loadUserInfo.ErrID = 1;
                    loadUserInfo.ErrText = "userInfoID cannot be zero.";
                }

            }
            catch (Exception exception)
            {
                XmlErrors(loadUserInfo);
                Log4ExceptionConnDb.ExXml(exception);
            }

            return loadUserInfo;
        }

        public LoadUserInfo InsertLoadUserInfo(LoadUserInfo loadUserInfo)
        {

            try
            {
                if (loadUserInfo != null)
                {
                    if (loadUserInfo.UserInfoID != 0)
                    {

                        UserInfoXml userInfoXml = XmlDeserialize<UserInfoXml>(xmlUserInfo);

                        if (userInfoXml.UserInfoLists == null)
                        {
                            userInfoXml.UserInfoLists = new List<UserInfo>();
                        }

                        UserInfo userInfo = new UserInfo();

                        userInfo.UserInfoUserIdentityName = loadUserInfo.UserInfoUserIdentityName;
                        userInfo.UserInfoUserName = loadUserInfo.UserInfoUserName;
                        userInfo.UserInfoFullName = loadUserInfo.UserInfoFullName;
                        userInfo.UserInfoEmailAddress = loadUserInfo.UserInfoEmailAddress;
                        userInfo.UserInfoJobTitle = loadUserInfo.UserInfoJobTitle;
                        userInfo.UserInfoActiveYesNo = loadUserInfo.UserInfoActiveYesNo;
                        userInfo.CreateUserName = loadUserInfo.CreateUserName;
                        userInfo.CreateFullName = loadUserInfo.CreateFullName;
                        userInfo.CreateDate = loadUserInfo.CreateDate;
                        userInfo.UpdateUserName = loadUserInfo.UpdateUserName;
                        userInfo.UpdateFullName = loadUserInfo.UpdateFullName;
                        userInfo.UpdateDate = loadUserInfo.UpdateDate;

                        userInfoXml.UserInfoLists.Sort((u1, u2) => u1.UserInfoID.CompareTo(u2.UserInfoID));
                        userInfo.UserInfoID = userInfoXml.UserInfoLists.Count == 0 ? 1 : userInfoXml.UserInfoLists.Max(x => x.UserInfoID) + 1;
                        userInfoXml.UserInfoLists.Add(userInfo);
                        XmlSerialize(userInfoXml, xmlUserInfo);

                        loadUserInfo.UserInfoID = userInfo.UserInfoID;

                        UserInfoUserInfoAccessLevelXrefXml userInfoUserInfoAccessLevelXrefXml = XmlDeserialize<UserInfoUserInfoAccessLevelXrefXml>(xmlUserInfoUserInfoAccessLevelXref);

                        if (userInfoUserInfoAccessLevelXrefXml.UserInfoUserInfoAccessLevelXrefLists == null)
                        {
                            userInfoUserInfoAccessLevelXrefXml.UserInfoUserInfoAccessLevelXrefLists = new List<UserInfoUserInfoAccessLevelXref>();
                        }

                        UserInfoUserInfoAccessLevelXref userInfoUserInfoAccessLevelXref = new UserInfoUserInfoAccessLevelXref();
                        userInfoUserInfoAccessLevelXref.UserInfoID = userInfo.UserInfoID;
                        userInfoUserInfoAccessLevelXref.UserInfoAccessLevelID = loadUserInfo.UserInfoAccessLevelID;
                        userInfoUserInfoAccessLevelXref.CreateUserName = loadUserInfo.CreateUserName;
                        userInfoUserInfoAccessLevelXref.CreateFullName = loadUserInfo.CreateFullName;
                        userInfoUserInfoAccessLevelXref.CreateDate = loadUserInfo.CreateDate;
                        userInfoUserInfoAccessLevelXref.UpdateUserName = loadUserInfo.UpdateUserName;
                        userInfoUserInfoAccessLevelXref.UpdateFullName = loadUserInfo.UpdateFullName;
                        userInfoUserInfoAccessLevelXref.UpdateDate = loadUserInfo.UpdateDate;

                        userInfoUserInfoAccessLevelXrefXml.UserInfoUserInfoAccessLevelXrefLists.Sort((u1, u2) => u1.UserInfoUserInfoAccessLevelXrefID.CompareTo(u2.UserInfoUserInfoAccessLevelXrefID));
                        userInfoUserInfoAccessLevelXref.UserInfoUserInfoAccessLevelXrefID = userInfoUserInfoAccessLevelXrefXml.UserInfoUserInfoAccessLevelXrefLists.Count == 0 ? 1 : userInfoUserInfoAccessLevelXrefXml.UserInfoUserInfoAccessLevelXrefLists.Max(x => x.UserInfoUserInfoAccessLevelXrefID) + 1;
                        userInfoUserInfoAccessLevelXrefXml.UserInfoUserInfoAccessLevelXrefLists.Add(userInfoUserInfoAccessLevelXref);
                        XmlSerialize(userInfoUserInfoAccessLevelXrefXml, xmlUserInfoUserInfoAccessLevelXref);

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
                XmlErrors(loadUserInfo);
                Log4ExceptionConnDb.ExXml(exception);
            }

            return loadUserInfo;
        }

        public LoadUserInfo UpdateLoadUserInfo(LoadUserInfo loadUserInfo)
        {

            try
            {

                if (loadUserInfo != null)
                {
                    if (loadUserInfo.UserInfoID != 0)
                    {

                        UserInfoXml userInfoXml = XmlDeserialize<UserInfoXml>(xmlUserInfo);

                        if (userInfoXml.UserInfoLists == null)
                        {
                            userInfoXml.UserInfoLists = new List<UserInfo>();
                        }

                        foreach (var userInfo in userInfoXml.UserInfoLists)
                        {
                            if (userInfo.UserInfoID == loadUserInfo.UserInfoID)
                            {
                                userInfo.UserInfoUserIdentityName = loadUserInfo.UserInfoUserIdentityName;
                                userInfo.UserInfoUserName = loadUserInfo.UserInfoUserName;
                                userInfo.UserInfoFullName = loadUserInfo.UserInfoFullName;
                                userInfo.UserInfoEmailAddress = loadUserInfo.UserInfoEmailAddress;
                                userInfo.UserInfoJobTitle = loadUserInfo.UserInfoJobTitle;
                                userInfo.UserInfoActiveYesNo = loadUserInfo.UserInfoActiveYesNo;
                                userInfo.UpdateUserName = loadUserInfo.UpdateUserName;
                                userInfo.UpdateFullName = loadUserInfo.UpdateFullName;
                                userInfo.UpdateDate = loadUserInfo.UpdateDate;

                                XmlSerialize(userInfoXml, xmlUserInfo);
                                break;
                            }
                        }

                        UserInfoUserInfoAccessLevelXrefXml userInfoUserInfoAccessLevelXrefXml = XmlDeserialize<UserInfoUserInfoAccessLevelXrefXml>(xmlUserInfoUserInfoAccessLevelXref);

                        if (userInfoUserInfoAccessLevelXrefXml.UserInfoUserInfoAccessLevelXrefLists == null)
                        {
                            userInfoUserInfoAccessLevelXrefXml.UserInfoUserInfoAccessLevelXrefLists = new List<UserInfoUserInfoAccessLevelXref>();
                        }

                        foreach (var userInfoUserInfoAccessLevelXref in userInfoUserInfoAccessLevelXrefXml.UserInfoUserInfoAccessLevelXrefLists)
                        {
                            if (userInfoUserInfoAccessLevelXref.UserInfoID == loadUserInfo.UserInfoID)
                            {
                                userInfoUserInfoAccessLevelXref.UserInfoAccessLevelID = loadUserInfo.UserInfoAccessLevelID;
                                userInfoUserInfoAccessLevelXref.UpdateUserName = loadUserInfo.UpdateUserName;
                                userInfoUserInfoAccessLevelXref.UpdateFullName = loadUserInfo.UpdateFullName;
                                userInfoUserInfoAccessLevelXref.UpdateDate = loadUserInfo.UpdateDate;

                                XmlSerialize(userInfoUserInfoAccessLevelXrefXml, xmlUserInfoUserInfoAccessLevelXref);
                            }
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
                XmlErrors(loadUserInfo);
                Log4ExceptionConnDb.ExXml(exception);
            }


            return loadUserInfo;
        }

        public LoadUserInfo DeleteLoadUserInfo(int userInfoID, LoadUserInfo loadUserInfo)
        {

            try
            {

                if (loadUserInfo != null)
                {
                    if (userInfoID != 0)
                    {

                        UserInfoUserInfoAccessLevelXrefXml userInfoUserInfoAccessLevelXrefXml = XmlDeserialize<UserInfoUserInfoAccessLevelXrefXml>(xmlUserInfoUserInfoAccessLevelXref);

                        if (userInfoUserInfoAccessLevelXrefXml.UserInfoUserInfoAccessLevelXrefLists == null)
                        {
                            userInfoUserInfoAccessLevelXrefXml.UserInfoUserInfoAccessLevelXrefLists = new List<UserInfoUserInfoAccessLevelXref>();
                        }

                        userInfoUserInfoAccessLevelXrefXml.UserInfoUserInfoAccessLevelXrefLists.RemoveAll(x => x.UserInfoID == userInfoID);
                        XmlSerialize(userInfoUserInfoAccessLevelXrefXml, xmlUserInfoUserInfoAccessLevelXref);


                        UserInfoXml userInfoXml = XmlDeserialize<UserInfoXml>(xmlUserInfo);

                        if (userInfoXml.UserInfoLists == null)
                        {
                            userInfoXml.UserInfoLists = new List<UserInfo>();
                        }

                        userInfoXml.UserInfoLists.RemoveAll(x => x.UserInfoID == userInfoID);
                        XmlSerialize(userInfoXml, xmlUserInfo);


                        loadUserInfo.DeleteTrueFalse = true;

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
                XmlErrors(loadUserInfo);
                Log4ExceptionConnDb.ExXml(exception);
            }

            return loadUserInfo;
        }

        private void XmlErrors(LoadUserInfo loadUserInfo)
        {
            loadUserInfo.ErrID = 1;
            loadUserInfo.ErrText = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
        }
        #endregion
    }
}
