
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

    
    public partial class AdminUserInfoUserInfoCompanyXrefXmlRepository : SerializeDeserializeXmlRepository, IUserInfoUserInfoCompanyXrefRepository
    {

    #region AdminUserInfoUserInfoCompanyXrefXmlRepository

    private readonly string urlMapPath = HttpContext.Current.Server.MapPath("~");
    private string xmlUserInfoUserInfoCompanyXref;

    public AdminUserInfoUserInfoCompanyXrefXmlRepository()
    {
    string xmlFolder = urlMapPath + "\\Xml";
    xmlUserInfoUserInfoCompanyXref = xmlFolder + "\\UserInfoUserInfoCompanyXrefXml.xml";

    if (!Directory.Exists(xmlFolder))
    Directory.CreateDirectory(xmlFolder);

    if (!File.Exists(xmlUserInfoUserInfoCompanyXref))
    {
    File.WriteAllText(xmlUserInfoUserInfoCompanyXref, "<?xml version=\"1.0\" encoding=\"utf-8\"?><UserInfoUserInfoCompanyXrefXml xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" ><UserInfoUserInfoCompanyXrefLists></UserInfoUserInfoCompanyXrefLists></UserInfoUserInfoCompanyXrefXml>");
    }


    }

    public IEnumerable<UserInfoUserInfoCompanyXref> GetUserInfoUserInfoCompanyXrefs()
    {
    List<UserInfoUserInfoCompanyXref> userInfoUserInfoCompanyXrefLists = new List<UserInfoUserInfoCompanyXref>();

    try
    {
    UserInfoUserInfoCompanyXrefXml userInfoUserInfoCompanyXrefXml = XmlDeserialize<UserInfoUserInfoCompanyXrefXml>(xmlUserInfoUserInfoCompanyXref);
    userInfoUserInfoCompanyXrefLists = userInfoUserInfoCompanyXrefXml.UserInfoUserInfoCompanyXrefLists;
    userInfoUserInfoCompanyXrefLists.Sort((u1, u2) => u1.UserInfoUserInfoCompanyXrefID.CompareTo(u2.UserInfoUserInfoCompanyXrefID));
    }
    catch (Exception exception)
    {
    Log4ExceptionConnDb.ExXml(exception);
    }

    return userInfoUserInfoCompanyXrefLists;
    }

    public UserInfoUserInfoCompanyXref GetUserInfoUserInfoCompanyXrefById(int userInfoUserInfoCompanyXrefID)
    {
    UserInfoUserInfoCompanyXref userInfoUserInfoCompanyXref = new UserInfoUserInfoCompanyXref();

    try
    {

    if(userInfoUserInfoCompanyXrefID != 0)
    {

    List<UserInfoUserInfoCompanyXref> userInfoUserInfoCompanyXrefLists = new List<UserInfoUserInfoCompanyXref>();

    UserInfoUserInfoCompanyXrefXml userInfoUserInfoCompanyXrefXml = XmlDeserialize<UserInfoUserInfoCompanyXrefXml>(xmlUserInfoUserInfoCompanyXref);
    userInfoUserInfoCompanyXrefLists = userInfoUserInfoCompanyXrefXml.UserInfoUserInfoCompanyXrefLists.Where(a => a.UserInfoUserInfoCompanyXrefID == userInfoUserInfoCompanyXrefID).ToList();
    userInfoUserInfoCompanyXrefLists.Sort((u1, u2) => u1.UserInfoUserInfoCompanyXrefID.CompareTo(u2.UserInfoUserInfoCompanyXrefID));
    userInfoUserInfoCompanyXref = userInfoUserInfoCompanyXrefLists.FirstOrDefault();

    }
    else
    {
    userInfoUserInfoCompanyXref.ErrID = 1;
    userInfoUserInfoCompanyXref.ErrText = "userInfoUserInfoCompanyXrefID cannot be zero.";
    }

    }
    catch (Exception exception)
    {
    XmlErrors(userInfoUserInfoCompanyXref);
    Log4ExceptionConnDb.ExXml(exception);
    }

    return userInfoUserInfoCompanyXref;
    }

    public UserInfoUserInfoCompanyXref InsertUserInfoUserInfoCompanyXref(UserInfoUserInfoCompanyXref userInfoUserInfoCompanyXref)
    {

    try
    {
    if(userInfoUserInfoCompanyXref != null)
    {
    if(userInfoUserInfoCompanyXref.UserInfoUserInfoCompanyXrefID != 0)
    {

    UserInfoUserInfoCompanyXrefXml userInfoUserInfoCompanyXrefXml = XmlDeserialize<UserInfoUserInfoCompanyXrefXml>(xmlUserInfoUserInfoCompanyXref);

    if (userInfoUserInfoCompanyXrefXml.UserInfoUserInfoCompanyXrefLists == null)
    {
    userInfoUserInfoCompanyXrefXml.UserInfoUserInfoCompanyXrefLists = new List<UserInfoUserInfoCompanyXref>();
    }

    userInfoUserInfoCompanyXrefXml.UserInfoUserInfoCompanyXrefLists.Sort((u1, u2) => u1.UserInfoUserInfoCompanyXrefID.CompareTo(u2.UserInfoUserInfoCompanyXrefID));
    userInfoUserInfoCompanyXref.UserInfoUserInfoCompanyXrefID = userInfoUserInfoCompanyXrefXml.UserInfoUserInfoCompanyXrefLists.Count == 0 ? 1 : userInfoUserInfoCompanyXrefXml.UserInfoUserInfoCompanyXrefLists.Max(x => x.UserInfoUserInfoCompanyXrefID) + 1;
    userInfoUserInfoCompanyXrefXml.UserInfoUserInfoCompanyXrefLists.Add(userInfoUserInfoCompanyXref);
    XmlSerialize(userInfoUserInfoCompanyXrefXml, xmlUserInfoUserInfoCompanyXref);

    }
    else
    {
    userInfoUserInfoCompanyXref.ErrID = 1;
    userInfoUserInfoCompanyXref.ErrText = "UserInfoUserInfoCompanyXrefID cannot be zero.";
    }

    }
    else
    {
    userInfoUserInfoCompanyXref = new UserInfoUserInfoCompanyXref(){
    ErrID = 1,
    ErrText = "UserInfoUserInfoCompanyXref cannot be null."
    };
    }

    }
    catch (Exception exception)
    {
    XmlErrors(userInfoUserInfoCompanyXref);
    Log4ExceptionConnDb.ExXml(exception);
    }

    return userInfoUserInfoCompanyXref;
    }

    public UserInfoUserInfoCompanyXref UpdateUserInfoUserInfoCompanyXref(UserInfoUserInfoCompanyXref userInfoUserInfoCompanyXref)
    {

    try
    {
    if(userInfoUserInfoCompanyXref != null)
    {
    if(userInfoUserInfoCompanyXref.UserInfoUserInfoCompanyXrefID != 0)
    {

    UserInfoUserInfoCompanyXrefXml userInfoUserInfoCompanyXrefXml = XmlDeserialize<UserInfoUserInfoCompanyXrefXml>(xmlUserInfoUserInfoCompanyXref);

    if (userInfoUserInfoCompanyXrefXml.UserInfoUserInfoCompanyXrefLists == null)
    {
    userInfoUserInfoCompanyXrefXml.UserInfoUserInfoCompanyXrefLists = new List<UserInfoUserInfoCompanyXref>();
    }

    foreach (UserInfoUserInfoCompanyXref _userInfoUserInfoCompanyXref in userInfoUserInfoCompanyXrefXml.UserInfoUserInfoCompanyXrefLists)
    {
    if (_userInfoUserInfoCompanyXref.UserInfoUserInfoCompanyXrefID == userInfoUserInfoCompanyXref.UserInfoUserInfoCompanyXrefID)
    {
    _userInfoUserInfoCompanyXref.UserInfoID = userInfoUserInfoCompanyXref.UserInfoID;
_userInfoUserInfoCompanyXref.UserInfoCompanyID = userInfoUserInfoCompanyXref.UserInfoCompanyID;
_userInfoUserInfoCompanyXref.UserInfoUserInfoCompanyXrefEmailAddressActiveYesNo = userInfoUserInfoCompanyXref.UserInfoUserInfoCompanyXrefEmailAddressActiveYesNo;
_userInfoUserInfoCompanyXref.UserInfoUserInfoCompanyXrefActiveYesNo = userInfoUserInfoCompanyXref.UserInfoUserInfoCompanyXrefActiveYesNo;

    _userInfoUserInfoCompanyXref.UpdateUserName = userInfoUserInfoCompanyXref.UpdateUserName;
    _userInfoUserInfoCompanyXref.UpdateFullName = userInfoUserInfoCompanyXref.UpdateFullName;
    _userInfoUserInfoCompanyXref.UpdateDate = userInfoUserInfoCompanyXref.UpdateDate;
    XmlSerialize(userInfoUserInfoCompanyXrefXml, xmlUserInfoUserInfoCompanyXref);
    break;
    }
    }

    }
    else
    {
    userInfoUserInfoCompanyXref.ErrID = 1;
    userInfoUserInfoCompanyXref.ErrText = "UserInfoUserInfoCompanyXrefID cannot be zero.";
    }

    }
    else
    {
    userInfoUserInfoCompanyXref = new UserInfoUserInfoCompanyXref(){
    ErrID = 1,
    ErrText = "UserInfoUserInfoCompanyXref cannot be null."
    };
    }


    }
    catch (Exception exception)
    {
    XmlErrors(userInfoUserInfoCompanyXref);
    Log4ExceptionConnDb.ExXml(exception);
    }

    return userInfoUserInfoCompanyXref;
    }

    public UserInfoUserInfoCompanyXref DeleteUserInfoUserInfoCompanyXref(int userInfoUserInfoCompanyXrefID, UserInfoUserInfoCompanyXref userInfoUserInfoCompanyXref)
    {

    try
    {

    if(userInfoUserInfoCompanyXref != null)
    {
    if(userInfoUserInfoCompanyXrefID != 0)
    {

    UserInfoUserInfoCompanyXrefXml userInfoUserInfoCompanyXrefXml = XmlDeserialize<UserInfoUserInfoCompanyXrefXml>(xmlUserInfoUserInfoCompanyXref);

    if (userInfoUserInfoCompanyXrefXml.UserInfoUserInfoCompanyXrefLists == null)
    {
    userInfoUserInfoCompanyXrefXml.UserInfoUserInfoCompanyXrefLists = new List<UserInfoUserInfoCompanyXref>();
    }

    userInfoUserInfoCompanyXrefXml.UserInfoUserInfoCompanyXrefLists.RemoveAll(x => x.UserInfoUserInfoCompanyXrefID == userInfoUserInfoCompanyXrefID);
    XmlSerialize(userInfoUserInfoCompanyXrefXml, xmlUserInfoUserInfoCompanyXref);

    userInfoUserInfoCompanyXref.DeleteTrueFalse = true;

    }
    else
    {
    userInfoUserInfoCompanyXref.ErrID = 1;
    userInfoUserInfoCompanyXref.ErrText = "userInfoUserInfoCompanyXrefID cannot be zero.";
    }
    }
    else
    {
    userInfoUserInfoCompanyXref = new UserInfoUserInfoCompanyXref(){
    ErrID = 1,
    ErrText = "UserInfoUserInfoCompanyXref cannot be null."
    };
    }

    }
    catch (Exception exception)
    {
    XmlErrors(userInfoUserInfoCompanyXref);
    Log4ExceptionConnDb.ExXml(exception);
    }

    return userInfoUserInfoCompanyXref;
    }

    private void XmlErrors(UserInfoUserInfoCompanyXref userInfoUserInfoCompanyXref)
    {
    userInfoUserInfoCompanyXref.ErrID = 1;
    userInfoUserInfoCompanyXref.ErrText = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
    }
    #endregion
    }
  

    }
  