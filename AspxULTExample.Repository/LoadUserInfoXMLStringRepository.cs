
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


    public partial class LoadUserInfoXmlStringRepository : SerializeDeserializeXmlRepository, ILoadUserInfoStringRepository
    {

        #region LoadUserInfoXmlStringRepository

        private readonly string urlMapPath = HttpContext.Current.Server.MapPath("~");
        private string xmlUserInfo;
        private string xmlUserInfoAccessLevel;
        private string xmlUserInfoUserInfoAccessLevelXref;
        private string xmlUserInfoCompany;
        private string xmlUserInfoUserInfoCompanyXref;

        public LoadUserInfoXmlStringRepository()
        {
            string xmlFolder = urlMapPath + "\\Xml";

            if (!Directory.Exists(xmlFolder))
                Directory.CreateDirectory(xmlFolder);

            xmlUserInfo = xmlFolder + "\\UserInfoXml.xml";
            if (!System.IO.File.Exists(xmlUserInfo))
            {
                System.IO.File.WriteAllText(xmlUserInfo, "<?xml version=\"1.0\" encoding=\"utf-8\"?><UserInfoXml xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" ><UserInfoLists></UserInfoLists></UserInfoXml>");
            }

            xmlUserInfoAccessLevel = xmlFolder + "\\UserInfoAccessLevelXml.xml";
            if (!System.IO.File.Exists(xmlUserInfoAccessLevel))
            {
                System.IO.File.WriteAllText(xmlUserInfoAccessLevel, "<?xml version=\"1.0\" encoding=\"utf-8\"?><UserInfoAccessLevelXml xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" ><UserInfoAccessLevelLists></UserInfoAccessLevelLists></UserInfoAccessLevelXml>");
            }

            xmlUserInfoUserInfoAccessLevelXref = xmlFolder + "\\UserInfoUserInfoAccessLevelXrefXml.xml";
            if (!System.IO.File.Exists(xmlUserInfoUserInfoAccessLevelXref))
            {
                System.IO.File.WriteAllText(xmlUserInfoUserInfoAccessLevelXref, "<?xml version=\"1.0\" encoding=\"utf-8\"?><UserInfoUserInfoAccessLevelXrefXml xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" ><UserInfoUserInfoAccessLevelXrefLists></UserInfoUserInfoAccessLevelXrefLists></UserInfoUserInfoAccessLevelXrefXml>");
            }

            xmlUserInfoCompany = xmlFolder + "\\UserInfoCompanyXml.xml";
            if (!System.IO.File.Exists(xmlUserInfoCompany))
            {
                System.IO.File.WriteAllText(xmlUserInfoCompany, "<?xml version=\"1.0\" encoding=\"utf-8\"?><UserInfoCompanyXml xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" ><UserInfoCompanyLists></UserInfoCompanyLists></UserInfoCompanyXml>");
            }

            xmlUserInfoUserInfoCompanyXref = xmlFolder + "\\UserInfoUserInfoCompanyXrefXml.xml";
            if (!System.IO.File.Exists(xmlUserInfoUserInfoCompanyXref))
            {
                System.IO.File.WriteAllText(xmlUserInfoUserInfoCompanyXref, "<?xml version=\"1.0\" encoding=\"utf-8\"?><UserInfoUserInfoCompanyXrefXml xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" ><UserInfoUserInfoCompanyXrefLists></UserInfoUserInfoCompanyXrefLists></UserInfoUserInfoCompanyXrefXml>");
            }
        }

        public LoadUserInfo GetLoadUserInfoByString(string userInfoUserIdentityName)
        {

            LoadUserInfo loadUserInfo = new LoadUserInfo();

            try
            {
                if (!string.IsNullOrWhiteSpace(userInfoUserIdentityName))
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

                    var loadUserInfoLists =
                    (from UUALX in userInfoUserInfoAccessLevelXrefLists
                     join U in userInfoLists on UUALX.UserInfoID equals U.UserInfoID
                     join UAL in userInfoAccessLevelLists on UUALX.UserInfoAccessLevelID equals UAL.UserInfoAccessLevelID
                     where U.UserInfoActiveYesNo && U.UserInfoUserIdentityName == userInfoUserIdentityName
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

                    loadUserInfo = loadUserInfoLists.FirstOrDefault();

                }
            }
            catch (Exception exception)
            {
                XmlErrors(loadUserInfo);
                Log4ExceptionConnDb.ExXml(exception);
            }

            return loadUserInfo;

        }

        public IEnumerable<UserInfoUserInfoCompanyXref> GetLoadUserInfoUserInfoCompanyXrefsById(int userInfoID)
        {
            List<UserInfoUserInfoCompanyXref> userInfoUserInfoCompanyXrefLists = new List<UserInfoUserInfoCompanyXref>();

            try
            {
                if (userInfoID != 0)
                {

                    List<UserInfoCompany> userInfoCompanyLists = new List<UserInfoCompany>();
                    List<UserInfoUserInfoCompanyXref> userInfoUCXLists = new List<UserInfoUserInfoCompanyXref>();

                    UserInfoCompanyXml userInfoCompanyXml = XmlDeserialize<UserInfoCompanyXml>(xmlUserInfoCompany);
                    userInfoCompanyLists = userInfoCompanyXml.UserInfoCompanyLists.ToList();

                    UserInfoUserInfoCompanyXrefXml userInfoUserInfoCompanyXrefXml = XmlDeserialize<UserInfoUserInfoCompanyXrefXml>(xmlUserInfoUserInfoCompanyXref);
                    userInfoUCXLists = userInfoUserInfoCompanyXrefXml.UserInfoUserInfoCompanyXrefLists.ToList();

                    var loadUUCXLists =
                    (from UUC in userInfoUCXLists
                     join UC in userInfoCompanyLists on UUC.UserInfoCompanyID equals UC.UserInfoCompanyID
                     where UUC.UserInfoID == userInfoID && UUC.UserInfoUserInfoCompanyXrefActiveYesNo
                     orderby UC.UserInfoCompanyID
                     select new UserInfoUserInfoCompanyXref()
                     {
                         UserInfoID = UUC.UserInfoID,
                         UserInfoCompanyID = UUC.UserInfoCompanyID,
                         UserInfoCompanyName = UC.UserInfoCompanyName
                     });

                    userInfoUserInfoCompanyXrefLists = loadUUCXLists.ToList();
                }
            }
            catch (Exception exception)
            {
                Log4ExceptionConnDb.ExXml(exception);
            }


            return userInfoUserInfoCompanyXrefLists;

        }

        public IEnumerable<LoadUserInfo> GetLoadUserInfoEmailAddressByCompanyID(int companyID)
        {

            List<LoadUserInfo> loadUserInfoEmailAddressLists = new List<LoadUserInfo>();

            try
            {
                if (companyID != 0)
                {

                    List<UserInfo> userInfoLists = new List<UserInfo>();
                    List<UserInfoUserInfoAccessLevelXref> userInfoUserInfoAccessLevelXrefLists = new List<UserInfoUserInfoAccessLevelXref>();
                    List<UserInfoUserInfoCompanyXref> userInfoUserInfoCompanyXrefLists = new List<UserInfoUserInfoCompanyXref>();

                    UserInfoXml userInfoXml = XmlDeserialize<UserInfoXml>(xmlUserInfo);
                    userInfoLists = userInfoXml.UserInfoLists.ToList();

                    UserInfoUserInfoAccessLevelXrefXml userInfoUserInfoAccessLevelXrefXml = XmlDeserialize<UserInfoUserInfoAccessLevelXrefXml>(xmlUserInfoUserInfoAccessLevelXref);
                    userInfoUserInfoAccessLevelXrefLists = userInfoUserInfoAccessLevelXrefXml.UserInfoUserInfoAccessLevelXrefLists.ToList();

                    UserInfoUserInfoCompanyXrefXml userInfoUserInfoCompanyXrefXml = XmlDeserialize<UserInfoUserInfoCompanyXrefXml>(xmlUserInfoUserInfoCompanyXref);
                    userInfoUserInfoCompanyXrefLists = userInfoUserInfoCompanyXrefXml.UserInfoUserInfoCompanyXrefLists.ToList();

                    var loadUserInfoLists =
                    (from UUC in userInfoUserInfoCompanyXrefLists
                     join U in userInfoLists on UUC.UserInfoID equals U.UserInfoID
                     join UUALX in userInfoUserInfoAccessLevelXrefLists on U.UserInfoID equals UUALX.UserInfoID
                     where UUC.UserInfoCompanyID == companyID && UUC.UserInfoUserInfoCompanyXrefActiveYesNo && UUC.UserInfoUserInfoCompanyXrefEmailAddressActiveYesNo && U.UserInfoActiveYesNo
                     orderby U.UserInfoID, UUC.UserInfoCompanyName
                     select new LoadUserInfo
                     {
                         UserInfoCompanyID = UUC.UserInfoCompanyID,
                         UserInfoFullName = U.UserInfoFullName,
                         UserInfoEmailAddress = U.UserInfoEmailAddress,
                         UserInfoAccessLevelID = UUALX.UserInfoAccessLevelID,
                     });

                    loadUserInfoEmailAddressLists = loadUserInfoLists.ToList();
                }
            }
            catch (Exception exception)
            {
                Log4ExceptionConnDb.ExXml(exception);
            }

            return loadUserInfoEmailAddressLists;


        }

        private void XmlErrors(LoadUserInfo loadUserInfo)
        {
            loadUserInfo.ErrID = 1;
            loadUserInfo.ErrText = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
        }

        #endregion

    }


}
