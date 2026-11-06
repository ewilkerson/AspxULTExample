
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

    
    public partial class AdminUserInfoUserInfoAccessLevelXrefXmlRepository : SerializeDeserializeXmlRepository, IUserInfoUserInfoAccessLevelXrefRepository
    {

    #region AdminUserInfoUserInfoAccessLevelXrefXmlRepository

    private readonly string urlMapPath = HttpContext.Current.Server.MapPath("~");
    private string xmlUserInfoUserInfoAccessLevelXref;

    public AdminUserInfoUserInfoAccessLevelXrefXmlRepository()
    {
    string xmlFolder = urlMapPath + "\\Xml";
    xmlUserInfoUserInfoAccessLevelXref = xmlFolder + "\\UserInfoUserInfoAccessLevelXrefXml.xml";

    if (!Directory.Exists(xmlFolder))
    Directory.CreateDirectory(xmlFolder);

    if (!File.Exists(xmlUserInfoUserInfoAccessLevelXref))
    {
    File.WriteAllText(xmlUserInfoUserInfoAccessLevelXref, "<?xml version=\"1.0\" encoding=\"utf-8\"?><UserInfoUserInfoAccessLevelXrefXml xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" ><UserInfoUserInfoAccessLevelXrefLists></UserInfoUserInfoAccessLevelXrefLists></UserInfoUserInfoAccessLevelXrefXml>");
    }


    }

    public IEnumerable<UserInfoUserInfoAccessLevelXref> GetUserInfoUserInfoAccessLevelXrefs()
    {
    List<UserInfoUserInfoAccessLevelXref> userInfoUserInfoAccessLevelXrefLists = new List<UserInfoUserInfoAccessLevelXref>();

    try
    {
    UserInfoUserInfoAccessLevelXrefXml userInfoUserInfoAccessLevelXrefXml = XmlDeserialize<UserInfoUserInfoAccessLevelXrefXml>(xmlUserInfoUserInfoAccessLevelXref);
    userInfoUserInfoAccessLevelXrefLists = userInfoUserInfoAccessLevelXrefXml.UserInfoUserInfoAccessLevelXrefLists;
    userInfoUserInfoAccessLevelXrefLists.Sort((u1, u2) => u1.UserInfoUserInfoAccessLevelXrefID.CompareTo(u2.UserInfoUserInfoAccessLevelXrefID));
    }
    catch (Exception exception)
    {
    Log4ExceptionConnDb.ExXml(exception);
    }

    return userInfoUserInfoAccessLevelXrefLists;
    }

    public UserInfoUserInfoAccessLevelXref GetUserInfoUserInfoAccessLevelXrefById(int userInfoUserInfoAccessLevelXrefID)
    {
    UserInfoUserInfoAccessLevelXref userInfoUserInfoAccessLevelXref = new UserInfoUserInfoAccessLevelXref();

    try
    {

    if(userInfoUserInfoAccessLevelXrefID != 0)
    {

    List<UserInfoUserInfoAccessLevelXref> userInfoUserInfoAccessLevelXrefLists = new List<UserInfoUserInfoAccessLevelXref>();

    UserInfoUserInfoAccessLevelXrefXml userInfoUserInfoAccessLevelXrefXml = XmlDeserialize<UserInfoUserInfoAccessLevelXrefXml>(xmlUserInfoUserInfoAccessLevelXref);
    userInfoUserInfoAccessLevelXrefLists = userInfoUserInfoAccessLevelXrefXml.UserInfoUserInfoAccessLevelXrefLists.Where(a => a.UserInfoUserInfoAccessLevelXrefID == userInfoUserInfoAccessLevelXrefID).ToList();
    userInfoUserInfoAccessLevelXrefLists.Sort((u1, u2) => u1.UserInfoUserInfoAccessLevelXrefID.CompareTo(u2.UserInfoUserInfoAccessLevelXrefID));
    userInfoUserInfoAccessLevelXref = userInfoUserInfoAccessLevelXrefLists.FirstOrDefault();

    }
    else
    {
    userInfoUserInfoAccessLevelXref.ErrID = 1;
    userInfoUserInfoAccessLevelXref.ErrText = "userInfoUserInfoAccessLevelXrefID cannot be zero.";
    }

    }
    catch (Exception exception)
    {
    XmlErrors(userInfoUserInfoAccessLevelXref);
    Log4ExceptionConnDb.ExXml(exception);
    }

    return userInfoUserInfoAccessLevelXref;
    }

    public UserInfoUserInfoAccessLevelXref InsertUserInfoUserInfoAccessLevelXref(UserInfoUserInfoAccessLevelXref userInfoUserInfoAccessLevelXref)
    {

    try
    {
    if(userInfoUserInfoAccessLevelXref != null)
    {
    if(userInfoUserInfoAccessLevelXref.UserInfoUserInfoAccessLevelXrefID != 0)
    {

    UserInfoUserInfoAccessLevelXrefXml userInfoUserInfoAccessLevelXrefXml = XmlDeserialize<UserInfoUserInfoAccessLevelXrefXml>(xmlUserInfoUserInfoAccessLevelXref);

    if (userInfoUserInfoAccessLevelXrefXml.UserInfoUserInfoAccessLevelXrefLists == null)
    {
    userInfoUserInfoAccessLevelXrefXml.UserInfoUserInfoAccessLevelXrefLists = new List<UserInfoUserInfoAccessLevelXref>();
    }

    userInfoUserInfoAccessLevelXrefXml.UserInfoUserInfoAccessLevelXrefLists.Sort((u1, u2) => u1.UserInfoUserInfoAccessLevelXrefID.CompareTo(u2.UserInfoUserInfoAccessLevelXrefID));
    userInfoUserInfoAccessLevelXref.UserInfoUserInfoAccessLevelXrefID = userInfoUserInfoAccessLevelXrefXml.UserInfoUserInfoAccessLevelXrefLists.Count == 0 ? 1 : userInfoUserInfoAccessLevelXrefXml.UserInfoUserInfoAccessLevelXrefLists.Max(x => x.UserInfoUserInfoAccessLevelXrefID) + 1;
    userInfoUserInfoAccessLevelXrefXml.UserInfoUserInfoAccessLevelXrefLists.Add(userInfoUserInfoAccessLevelXref);
    XmlSerialize(userInfoUserInfoAccessLevelXrefXml, xmlUserInfoUserInfoAccessLevelXref);

    }
    else
    {
    userInfoUserInfoAccessLevelXref.ErrID = 1;
    userInfoUserInfoAccessLevelXref.ErrText = "UserInfoUserInfoAccessLevelXrefID cannot be zero.";
    }

    }
    else
    {
    userInfoUserInfoAccessLevelXref = new UserInfoUserInfoAccessLevelXref(){
    ErrID = 1,
    ErrText = "UserInfoUserInfoAccessLevelXref cannot be null."
    };
    }

    }
    catch (Exception exception)
    {
    XmlErrors(userInfoUserInfoAccessLevelXref);
    Log4ExceptionConnDb.ExXml(exception);
    }

    return userInfoUserInfoAccessLevelXref;
    }

    public UserInfoUserInfoAccessLevelXref UpdateUserInfoUserInfoAccessLevelXref(UserInfoUserInfoAccessLevelXref userInfoUserInfoAccessLevelXref)
    {

    try
    {
    if(userInfoUserInfoAccessLevelXref != null)
    {
    if(userInfoUserInfoAccessLevelXref.UserInfoUserInfoAccessLevelXrefID != 0)
    {

    UserInfoUserInfoAccessLevelXrefXml userInfoUserInfoAccessLevelXrefXml = XmlDeserialize<UserInfoUserInfoAccessLevelXrefXml>(xmlUserInfoUserInfoAccessLevelXref);

    if (userInfoUserInfoAccessLevelXrefXml.UserInfoUserInfoAccessLevelXrefLists == null)
    {
    userInfoUserInfoAccessLevelXrefXml.UserInfoUserInfoAccessLevelXrefLists = new List<UserInfoUserInfoAccessLevelXref>();
    }

    foreach (UserInfoUserInfoAccessLevelXref _userInfoUserInfoAccessLevelXref in userInfoUserInfoAccessLevelXrefXml.UserInfoUserInfoAccessLevelXrefLists)
    {
    if (_userInfoUserInfoAccessLevelXref.UserInfoUserInfoAccessLevelXrefID == userInfoUserInfoAccessLevelXref.UserInfoUserInfoAccessLevelXrefID)
    {
    _userInfoUserInfoAccessLevelXref.UserInfoID = userInfoUserInfoAccessLevelXref.UserInfoID;
_userInfoUserInfoAccessLevelXref.UserInfoAccessLevelID = userInfoUserInfoAccessLevelXref.UserInfoAccessLevelID;
_userInfoUserInfoAccessLevelXref.UserInfoUserInfoAccessLevelXrefActiveYesNo = userInfoUserInfoAccessLevelXref.UserInfoUserInfoAccessLevelXrefActiveYesNo;

    _userInfoUserInfoAccessLevelXref.UpdateUserName = userInfoUserInfoAccessLevelXref.UpdateUserName;
    _userInfoUserInfoAccessLevelXref.UpdateFullName = userInfoUserInfoAccessLevelXref.UpdateFullName;
    _userInfoUserInfoAccessLevelXref.UpdateDate = userInfoUserInfoAccessLevelXref.UpdateDate;
    XmlSerialize(userInfoUserInfoAccessLevelXrefXml, xmlUserInfoUserInfoAccessLevelXref);
    break;
    }
    }

    }
    else
    {
    userInfoUserInfoAccessLevelXref.ErrID = 1;
    userInfoUserInfoAccessLevelXref.ErrText = "UserInfoUserInfoAccessLevelXrefID cannot be zero.";
    }

    }
    else
    {
    userInfoUserInfoAccessLevelXref = new UserInfoUserInfoAccessLevelXref(){
    ErrID = 1,
    ErrText = "UserInfoUserInfoAccessLevelXref cannot be null."
    };
    }


    }
    catch (Exception exception)
    {
    XmlErrors(userInfoUserInfoAccessLevelXref);
    Log4ExceptionConnDb.ExXml(exception);
    }

    return userInfoUserInfoAccessLevelXref;
    }

    public UserInfoUserInfoAccessLevelXref DeleteUserInfoUserInfoAccessLevelXref(int userInfoUserInfoAccessLevelXrefID, UserInfoUserInfoAccessLevelXref userInfoUserInfoAccessLevelXref)
    {

    try
    {

    if(userInfoUserInfoAccessLevelXref != null)
    {
    if(userInfoUserInfoAccessLevelXrefID != 0)
    {

    UserInfoUserInfoAccessLevelXrefXml userInfoUserInfoAccessLevelXrefXml = XmlDeserialize<UserInfoUserInfoAccessLevelXrefXml>(xmlUserInfoUserInfoAccessLevelXref);

    if (userInfoUserInfoAccessLevelXrefXml.UserInfoUserInfoAccessLevelXrefLists == null)
    {
    userInfoUserInfoAccessLevelXrefXml.UserInfoUserInfoAccessLevelXrefLists = new List<UserInfoUserInfoAccessLevelXref>();
    }

    userInfoUserInfoAccessLevelXrefXml.UserInfoUserInfoAccessLevelXrefLists.RemoveAll(x => x.UserInfoUserInfoAccessLevelXrefID == userInfoUserInfoAccessLevelXrefID);
    XmlSerialize(userInfoUserInfoAccessLevelXrefXml, xmlUserInfoUserInfoAccessLevelXref);

    userInfoUserInfoAccessLevelXref.DeleteTrueFalse = true;

    }
    else
    {
    userInfoUserInfoAccessLevelXref.ErrID = 1;
    userInfoUserInfoAccessLevelXref.ErrText = "userInfoUserInfoAccessLevelXrefID cannot be zero.";
    }
    }
    else
    {
    userInfoUserInfoAccessLevelXref = new UserInfoUserInfoAccessLevelXref(){
    ErrID = 1,
    ErrText = "UserInfoUserInfoAccessLevelXref cannot be null."
    };
    }

    }
    catch (Exception exception)
    {
    XmlErrors(userInfoUserInfoAccessLevelXref);
    Log4ExceptionConnDb.ExXml(exception);
    }

    return userInfoUserInfoAccessLevelXref;
    }

    private void XmlErrors(UserInfoUserInfoAccessLevelXref userInfoUserInfoAccessLevelXref)
    {
    userInfoUserInfoAccessLevelXref.ErrID = 1;
    userInfoUserInfoAccessLevelXref.ErrText = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
    }
    #endregion
    }
  

    }
  