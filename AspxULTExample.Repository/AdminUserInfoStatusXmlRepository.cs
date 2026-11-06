
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

    
    public partial class AdminUserInfoStatusXmlRepository : SerializeDeserializeXmlRepository, IUserInfoStatusRepository
    {

    #region AdminUserInfoStatusXmlRepository

    private readonly string urlMapPath = HttpContext.Current.Server.MapPath("~");
    private string xmlUserInfoStatus;

    public AdminUserInfoStatusXmlRepository()
    {
    string xmlFolder = urlMapPath + "\\Xml";
    xmlUserInfoStatus = xmlFolder + "\\UserInfoStatusXml.xml";

    if (!Directory.Exists(xmlFolder))
    Directory.CreateDirectory(xmlFolder);

    if (!File.Exists(xmlUserInfoStatus))
    {
    File.WriteAllText(xmlUserInfoStatus, "<?xml version=\"1.0\" encoding=\"utf-8\"?><UserInfoStatusXml xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" ><UserInfoStatusLists></UserInfoStatusLists></UserInfoStatusXml>");
    }


    }

    public IEnumerable<UserInfoStatus> GetUserInfoStatuss()
    {
    List<UserInfoStatus> userInfoStatusLists = new List<UserInfoStatus>();

    try
    {
    UserInfoStatusXml userInfoStatusXml = XmlDeserialize<UserInfoStatusXml>(xmlUserInfoStatus);
    userInfoStatusLists = userInfoStatusXml.UserInfoStatusLists;
    userInfoStatusLists.Sort((u1, u2) => u1.UserInfoStatusID.CompareTo(u2.UserInfoStatusID));
    }
    catch (Exception exception)
    {
    Log4ExceptionConnDb.ExXml(exception);
    }

    return userInfoStatusLists;
    }

    public UserInfoStatus GetUserInfoStatusById(int userInfoStatusID)
    {
    UserInfoStatus userInfoStatus = new UserInfoStatus();

    try
    {

    if(userInfoStatusID != 0)
    {

    List<UserInfoStatus> userInfoStatusLists = new List<UserInfoStatus>();

    UserInfoStatusXml userInfoStatusXml = XmlDeserialize<UserInfoStatusXml>(xmlUserInfoStatus);
    userInfoStatusLists = userInfoStatusXml.UserInfoStatusLists.Where(a => a.UserInfoStatusID == userInfoStatusID).ToList();
    userInfoStatusLists.Sort((u1, u2) => u1.UserInfoStatusID.CompareTo(u2.UserInfoStatusID));
    userInfoStatus = userInfoStatusLists.FirstOrDefault();

    }
    else
    {
    userInfoStatus.ErrID = 1;
    userInfoStatus.ErrText = "userInfoStatusID cannot be zero.";
    }

    }
    catch (Exception exception)
    {
    XmlErrors(userInfoStatus);
    Log4ExceptionConnDb.ExXml(exception);
    }

    return userInfoStatus;
    }

    public UserInfoStatus InsertUserInfoStatus(UserInfoStatus userInfoStatus)
    {

    try
    {
    if(userInfoStatus != null)
    {
    if(userInfoStatus.UserInfoStatusID != 0)
    {

    UserInfoStatusXml userInfoStatusXml = XmlDeserialize<UserInfoStatusXml>(xmlUserInfoStatus);

    if (userInfoStatusXml.UserInfoStatusLists == null)
    {
    userInfoStatusXml.UserInfoStatusLists = new List<UserInfoStatus>();
    }

    userInfoStatusXml.UserInfoStatusLists.Sort((u1, u2) => u1.UserInfoStatusID.CompareTo(u2.UserInfoStatusID));
    userInfoStatus.UserInfoStatusID = userInfoStatusXml.UserInfoStatusLists.Count == 0 ? 1 : userInfoStatusXml.UserInfoStatusLists.Max(x => x.UserInfoStatusID) + 1;
    userInfoStatusXml.UserInfoStatusLists.Add(userInfoStatus);
    XmlSerialize(userInfoStatusXml, xmlUserInfoStatus);

    }
    else
    {
    userInfoStatus.ErrID = 1;
    userInfoStatus.ErrText = "UserInfoStatusID cannot be zero.";
    }

    }
    else
    {
    userInfoStatus = new UserInfoStatus(){
    ErrID = 1,
    ErrText = "UserInfoStatus cannot be null."
    };
    }

    }
    catch (Exception exception)
    {
    XmlErrors(userInfoStatus);
    Log4ExceptionConnDb.ExXml(exception);
    }

    return userInfoStatus;
    }

    public UserInfoStatus UpdateUserInfoStatus(UserInfoStatus userInfoStatus)
    {

    try
    {
    if(userInfoStatus != null)
    {
    if(userInfoStatus.UserInfoStatusID != 0)
    {

    UserInfoStatusXml userInfoStatusXml = XmlDeserialize<UserInfoStatusXml>(xmlUserInfoStatus);

    if (userInfoStatusXml.UserInfoStatusLists == null)
    {
    userInfoStatusXml.UserInfoStatusLists = new List<UserInfoStatus>();
    }

    foreach (UserInfoStatus _userInfoStatus in userInfoStatusXml.UserInfoStatusLists)
    {
    if (_userInfoStatus.UserInfoStatusID == userInfoStatus.UserInfoStatusID)
    {
    _userInfoStatus.UserInfoStatusName = userInfoStatus.UserInfoStatusName;
_userInfoStatus.UserInfoStatusActiveYesNo = userInfoStatus.UserInfoStatusActiveYesNo;

    _userInfoStatus.UpdateUserName = userInfoStatus.UpdateUserName;
    _userInfoStatus.UpdateFullName = userInfoStatus.UpdateFullName;
    _userInfoStatus.UpdateDate = userInfoStatus.UpdateDate;
    XmlSerialize(userInfoStatusXml, xmlUserInfoStatus);
    break;
    }
    }

    }
    else
    {
    userInfoStatus.ErrID = 1;
    userInfoStatus.ErrText = "UserInfoStatusID cannot be zero.";
    }

    }
    else
    {
    userInfoStatus = new UserInfoStatus(){
    ErrID = 1,
    ErrText = "UserInfoStatus cannot be null."
    };
    }


    }
    catch (Exception exception)
    {
    XmlErrors(userInfoStatus);
    Log4ExceptionConnDb.ExXml(exception);
    }

    return userInfoStatus;
    }

    public UserInfoStatus DeleteUserInfoStatus(int userInfoStatusID, UserInfoStatus userInfoStatus)
    {

    try
    {

    if(userInfoStatus != null)
    {
    if(userInfoStatusID != 0)
    {

    UserInfoStatusXml userInfoStatusXml = XmlDeserialize<UserInfoStatusXml>(xmlUserInfoStatus);

    if (userInfoStatusXml.UserInfoStatusLists == null)
    {
    userInfoStatusXml.UserInfoStatusLists = new List<UserInfoStatus>();
    }

    userInfoStatusXml.UserInfoStatusLists.RemoveAll(x => x.UserInfoStatusID == userInfoStatusID);
    XmlSerialize(userInfoStatusXml, xmlUserInfoStatus);

    userInfoStatus.DeleteTrueFalse = true;

    }
    else
    {
    userInfoStatus.ErrID = 1;
    userInfoStatus.ErrText = "userInfoStatusID cannot be zero.";
    }
    }
    else
    {
    userInfoStatus = new UserInfoStatus(){
    ErrID = 1,
    ErrText = "UserInfoStatus cannot be null."
    };
    }

    }
    catch (Exception exception)
    {
    XmlErrors(userInfoStatus);
    Log4ExceptionConnDb.ExXml(exception);
    }

    return userInfoStatus;
    }

    private void XmlErrors(UserInfoStatus userInfoStatus)
    {
    userInfoStatus.ErrID = 1;
    userInfoStatus.ErrText = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
    }
    #endregion
    }
  

    }
  