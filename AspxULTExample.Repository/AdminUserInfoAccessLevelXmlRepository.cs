
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


    public partial class AdminUserInfoAccessLevelXmlRepository : SerializeDeserializeXmlRepository, IUserInfoAccessLevelRepository
    {

        #region AdminUserInfoAccessLevelXmlRepository

        private readonly string urlMapPath = HttpContext.Current.Server.MapPath("~");
        private string xmlUserInfoAccessLevel;

        public AdminUserInfoAccessLevelXmlRepository()
        {
            string xmlFolder = urlMapPath + "\\Xml";
            xmlUserInfoAccessLevel = xmlFolder + "\\UserInfoAccessLevelXml.xml";

            if (!Directory.Exists(xmlFolder))
                Directory.CreateDirectory(xmlFolder);

            if (!File.Exists(xmlUserInfoAccessLevel))
            {
                File.WriteAllText(xmlUserInfoAccessLevel, "<?xml version=\"1.0\" encoding=\"utf-8\"?><UserInfoAccessLevelXml xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" ><UserInfoAccessLevelLists></UserInfoAccessLevelLists></UserInfoAccessLevelXml>");
            }


        }

        public IEnumerable<UserInfoAccessLevel> GetUserInfoAccessLevels()
        {
            List<UserInfoAccessLevel> userInfoAccessLevelLists = new List<UserInfoAccessLevel>();

            try
            {
                UserInfoAccessLevelXml userInfoAccessLevelXml = XmlDeserialize<UserInfoAccessLevelXml>(xmlUserInfoAccessLevel);
                userInfoAccessLevelLists = userInfoAccessLevelXml.UserInfoAccessLevelLists;
                userInfoAccessLevelLists.Sort((u1, u2) => u2.UserInfoAccessLevelID.CompareTo(u1.UserInfoAccessLevelID));
            }
            catch (Exception exception)
            {
                Log4ExceptionConnDb.ExXml(exception);
            }

            return userInfoAccessLevelLists;
        }

        public UserInfoAccessLevel GetUserInfoAccessLevelById(int userInfoAccessLevelID)
        {
            UserInfoAccessLevel userInfoAccessLevel = new UserInfoAccessLevel();

            try
            {

                if (userInfoAccessLevelID != 0)
                {

                    List<UserInfoAccessLevel> userInfoAccessLevelLists = new List<UserInfoAccessLevel>();

                    UserInfoAccessLevelXml userInfoAccessLevelXml = XmlDeserialize<UserInfoAccessLevelXml>(xmlUserInfoAccessLevel);
                    userInfoAccessLevelLists = userInfoAccessLevelXml.UserInfoAccessLevelLists.Where(a => a.UserInfoAccessLevelID == userInfoAccessLevelID).ToList();
                    userInfoAccessLevelLists.Sort((u1, u2) => u2.UserInfoAccessLevelID.CompareTo(u1.UserInfoAccessLevelID));
                    userInfoAccessLevel = userInfoAccessLevelLists.FirstOrDefault();

                }
                else
                {
                    userInfoAccessLevel.ErrID = 1;
                    userInfoAccessLevel.ErrText = "userInfoAccessLevelID cannot be zero.";
                }

            }
            catch (Exception exception)
            {
                XmlErrors(userInfoAccessLevel);
                Log4ExceptionConnDb.ExXml(exception);
            }

            return userInfoAccessLevel;
        }

        public UserInfoAccessLevel InsertUserInfoAccessLevel(UserInfoAccessLevel userInfoAccessLevel)
        {

            try
            {
                if (userInfoAccessLevel != null)
                {
                    if (userInfoAccessLevel.UserInfoAccessLevelID != 0)
                    {

                        UserInfoAccessLevelXml userInfoAccessLevelXml = XmlDeserialize<UserInfoAccessLevelXml>(xmlUserInfoAccessLevel);

                        if (userInfoAccessLevelXml.UserInfoAccessLevelLists == null)
                        {
                            userInfoAccessLevelXml.UserInfoAccessLevelLists = new List<UserInfoAccessLevel>();
                        }

                        userInfoAccessLevelXml.UserInfoAccessLevelLists.Sort((u1, u2) => u1.UserInfoAccessLevelID.CompareTo(u2.UserInfoAccessLevelID));
                        userInfoAccessLevel.UserInfoAccessLevelID = userInfoAccessLevelXml.UserInfoAccessLevelLists.Count == 0 ? 1 : userInfoAccessLevelXml.UserInfoAccessLevelLists.Max(x => x.UserInfoAccessLevelID) + 1;
                        userInfoAccessLevelXml.UserInfoAccessLevelLists.Add(userInfoAccessLevel);
                        XmlSerialize(userInfoAccessLevelXml, xmlUserInfoAccessLevel);

                    }
                    else
                    {
                        userInfoAccessLevel.ErrID = 1;
                        userInfoAccessLevel.ErrText = "UserInfoAccessLevelID cannot be zero.";
                    }

                }
                else
                {
                    userInfoAccessLevel = new UserInfoAccessLevel()
                    {
                        ErrID = 1,
                        ErrText = "UserInfoAccessLevel cannot be null."
                    };
                }

            }
            catch (Exception exception)
            {
                XmlErrors(userInfoAccessLevel);
                Log4ExceptionConnDb.ExXml(exception);
            }

            return userInfoAccessLevel;
        }

        public UserInfoAccessLevel UpdateUserInfoAccessLevel(UserInfoAccessLevel userInfoAccessLevel)
        {

            try
            {
                if (userInfoAccessLevel != null)
                {
                    if (userInfoAccessLevel.UserInfoAccessLevelID != 0)
                    {

                        UserInfoAccessLevelXml userInfoAccessLevelXml = XmlDeserialize<UserInfoAccessLevelXml>(xmlUserInfoAccessLevel);

                        if (userInfoAccessLevelXml.UserInfoAccessLevelLists == null)
                        {
                            userInfoAccessLevelXml.UserInfoAccessLevelLists = new List<UserInfoAccessLevel>();
                        }

                        foreach (UserInfoAccessLevel _userInfoAccessLevel in userInfoAccessLevelXml.UserInfoAccessLevelLists)
                        {
                            if (_userInfoAccessLevel.UserInfoAccessLevelID == userInfoAccessLevel.UserInfoAccessLevelID)
                            {
                                _userInfoAccessLevel.UserInfoAccessLevelName = userInfoAccessLevel.UserInfoAccessLevelName;
                                _userInfoAccessLevel.UserInfoAccessLevelNum = userInfoAccessLevel.UserInfoAccessLevelNum;
                                _userInfoAccessLevel.UserInfoAccessLevelActiveYesNo = userInfoAccessLevel.UserInfoAccessLevelActiveYesNo;

                                _userInfoAccessLevel.UpdateUserName = userInfoAccessLevel.UpdateUserName;
                                _userInfoAccessLevel.UpdateFullName = userInfoAccessLevel.UpdateFullName;
                                _userInfoAccessLevel.UpdateDate = userInfoAccessLevel.UpdateDate;
                                XmlSerialize(userInfoAccessLevelXml, xmlUserInfoAccessLevel);
                                break;
                            }
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
                    userInfoAccessLevel = new UserInfoAccessLevel()
                    {
                        ErrID = 1,
                        ErrText = "UserInfoAccessLevel cannot be null."
                    };
                }


            }
            catch (Exception exception)
            {
                XmlErrors(userInfoAccessLevel);
                Log4ExceptionConnDb.ExXml(exception);
            }

            return userInfoAccessLevel;
        }

        public UserInfoAccessLevel DeleteUserInfoAccessLevel(int userInfoAccessLevelID, UserInfoAccessLevel userInfoAccessLevel)
        {

            try
            {

                if (userInfoAccessLevel != null)
                {
                    if (userInfoAccessLevelID != 0)
                    {

                        UserInfoAccessLevelXml userInfoAccessLevelXml = XmlDeserialize<UserInfoAccessLevelXml>(xmlUserInfoAccessLevel);

                        if (userInfoAccessLevelXml.UserInfoAccessLevelLists == null)
                        {
                            userInfoAccessLevelXml.UserInfoAccessLevelLists = new List<UserInfoAccessLevel>();
                        }

                        userInfoAccessLevelXml.UserInfoAccessLevelLists.RemoveAll(x => x.UserInfoAccessLevelID == userInfoAccessLevelID);
                        XmlSerialize(userInfoAccessLevelXml, xmlUserInfoAccessLevel);

                        userInfoAccessLevel.DeleteTrueFalse = true;

                    }
                    else
                    {
                        userInfoAccessLevel.ErrID = 1;
                        userInfoAccessLevel.ErrText = "userInfoAccessLevelID cannot be zero.";
                    }
                }
                else
                {
                    userInfoAccessLevel = new UserInfoAccessLevel()
                    {
                        ErrID = 1,
                        ErrText = "UserInfoAccessLevel cannot be null."
                    };
                }

            }
            catch (Exception exception)
            {
                XmlErrors(userInfoAccessLevel);
                Log4ExceptionConnDb.ExXml(exception);
            }

            return userInfoAccessLevel;
        }

        private void XmlErrors(UserInfoAccessLevel userInfoAccessLevel)
        {
            userInfoAccessLevel.ErrID = 1;
            userInfoAccessLevel.ErrText = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
        }
        #endregion
    }


}
