
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

    
    public partial class AdminUserInfoXmlRepository : SerializeDeserializeXmlRepository, IUserInfoRepository
    {

    #region AdminUserInfoXmlRepository

    private readonly string urlMapPath = HttpContext.Current.Server.MapPath("~");
    private string xmlUserInfo;

    public AdminUserInfoXmlRepository()
    {
    string xmlFolder = urlMapPath + "\\Xml";
    xmlUserInfo = xmlFolder + "\\UserInfoXml.xml";

    if (!Directory.Exists(xmlFolder))
    Directory.CreateDirectory(xmlFolder);

    if (!File.Exists(xmlUserInfo))
    {
    File.WriteAllText(xmlUserInfo, "<?xml version=\"1.0\" encoding=\"utf-8\"?><UserInfoXml xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" ><UserInfoLists></UserInfoLists></UserInfoXml>");
    }


    }

    public IEnumerable<UserInfo> GetUserInfos()
    {
    List<UserInfo> userInfoLists = new List<UserInfo>();

    try
    {
    UserInfoXml userInfoXml = XmlDeserialize<UserInfoXml>(xmlUserInfo);
    userInfoLists = userInfoXml.UserInfoLists;
    userInfoLists.Sort((u1, u2) => u1.UserInfoID.CompareTo(u2.UserInfoID));
    }
    catch (Exception exception)
    {
    Log4ExceptionConnDb.ExXml(exception);
    }

    return userInfoLists;
    }

    public UserInfo GetUserInfoById(int userInfoID)
    {
    UserInfo userInfo = new UserInfo();

    try
    {

    if(userInfoID != 0)
    {

    List<UserInfo> userInfoLists = new List<UserInfo>();

    UserInfoXml userInfoXml = XmlDeserialize<UserInfoXml>(xmlUserInfo);
    userInfoLists = userInfoXml.UserInfoLists.Where(a => a.UserInfoID == userInfoID).ToList();
    userInfoLists.Sort((u1, u2) => u1.UserInfoID.CompareTo(u2.UserInfoID));
    userInfo = userInfoLists.FirstOrDefault();

    }
    else
    {
    userInfo.ErrID = 1;
    userInfo.ErrText = "userInfoID cannot be zero.";
    }

    }
    catch (Exception exception)
    {
    XmlErrors(userInfo);
    Log4ExceptionConnDb.ExXml(exception);
    }

    return userInfo;
    }

    public UserInfo InsertUserInfo(UserInfo userInfo)
    {

    try
    {
    if(userInfo != null)
    {
    if(userInfo.UserInfoID != 0)
    {

    UserInfoXml userInfoXml = XmlDeserialize<UserInfoXml>(xmlUserInfo);

    if (userInfoXml.UserInfoLists == null)
    {
    userInfoXml.UserInfoLists = new List<UserInfo>();
    }

    userInfoXml.UserInfoLists.Sort((u1, u2) => u1.UserInfoID.CompareTo(u2.UserInfoID));
    userInfo.UserInfoID = userInfoXml.UserInfoLists.Count == 0 ? 1 : userInfoXml.UserInfoLists.Max(x => x.UserInfoID) + 1;
    userInfoXml.UserInfoLists.Add(userInfo);
    XmlSerialize(userInfoXml, xmlUserInfo);

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
    XmlErrors(userInfo);
    Log4ExceptionConnDb.ExXml(exception);
    }

    return userInfo;
    }

    public UserInfo UpdateUserInfo(UserInfo userInfo)
    {

    try
    {
    if(userInfo != null)
    {
    if(userInfo.UserInfoID != 0)
    {

    UserInfoXml userInfoXml = XmlDeserialize<UserInfoXml>(xmlUserInfo);

    if (userInfoXml.UserInfoLists == null)
    {
    userInfoXml.UserInfoLists = new List<UserInfo>();
    }

    foreach (UserInfo _userInfo in userInfoXml.UserInfoLists)
    {
    if (_userInfo.UserInfoID == userInfo.UserInfoID)
    {
    _userInfo.UserInfoUserIdentityName = userInfo.UserInfoUserIdentityName;
_userInfo.UserInfoUserName = userInfo.UserInfoUserName;
_userInfo.UserInfoFullName = userInfo.UserInfoFullName;
_userInfo.UserInfoEmailAddress = userInfo.UserInfoEmailAddress;
_userInfo.UserInfoJobTitle = userInfo.UserInfoJobTitle;
_userInfo.UserInfoActiveYesNo = userInfo.UserInfoActiveYesNo;

    _userInfo.UpdateUserName = userInfo.UpdateUserName;
    _userInfo.UpdateFullName = userInfo.UpdateFullName;
    _userInfo.UpdateDate = userInfo.UpdateDate;
    XmlSerialize(userInfoXml, xmlUserInfo);
    break;
    }
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
    XmlErrors(userInfo);
    Log4ExceptionConnDb.ExXml(exception);
    }

    return userInfo;
    }

    public UserInfo DeleteUserInfo(int userInfoID, UserInfo userInfo)
    {

    try
    {

    if(userInfo != null)
    {
    if(userInfoID != 0)
    {

    UserInfoXml userInfoXml = XmlDeserialize<UserInfoXml>(xmlUserInfo);

    if (userInfoXml.UserInfoLists == null)
    {
    userInfoXml.UserInfoLists = new List<UserInfo>();
    }

    userInfoXml.UserInfoLists.RemoveAll(x => x.UserInfoID == userInfoID);
    XmlSerialize(userInfoXml, xmlUserInfo);

    userInfo.DeleteTrueFalse = true;

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
    XmlErrors(userInfo);
    Log4ExceptionConnDb.ExXml(exception);
    }

    return userInfo;
    }

    private void XmlErrors(UserInfo userInfo)
    {
    userInfo.ErrID = 1;
    userInfo.ErrText = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
    }
    #endregion
    }
  

    }
  