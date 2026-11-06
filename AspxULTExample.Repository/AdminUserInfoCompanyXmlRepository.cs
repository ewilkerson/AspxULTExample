
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

    
    public partial class AdminUserInfoCompanyXmlRepository : SerializeDeserializeXmlRepository, IUserInfoCompanyRepository
    {

    #region AdminUserInfoCompanyXmlRepository

    private readonly string urlMapPath = HttpContext.Current.Server.MapPath("~");
    private string xmlUserInfoCompany;

    public AdminUserInfoCompanyXmlRepository()
    {
    string xmlFolder = urlMapPath + "\\Xml";
    xmlUserInfoCompany = xmlFolder + "\\UserInfoCompanyXml.xml";

    if (!Directory.Exists(xmlFolder))
    Directory.CreateDirectory(xmlFolder);

    if (!File.Exists(xmlUserInfoCompany))
    {
    File.WriteAllText(xmlUserInfoCompany, "<?xml version=\"1.0\" encoding=\"utf-8\"?><UserInfoCompanyXml xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" ><UserInfoCompanyLists></UserInfoCompanyLists></UserInfoCompanyXml>");
    }


    }

    public IEnumerable<UserInfoCompany> GetUserInfoCompanys()
    {
    List<UserInfoCompany> userInfoCompanyLists = new List<UserInfoCompany>();

    try
    {
    UserInfoCompanyXml userInfoCompanyXml = XmlDeserialize<UserInfoCompanyXml>(xmlUserInfoCompany);
    userInfoCompanyLists = userInfoCompanyXml.UserInfoCompanyLists;
    userInfoCompanyLists.Sort((u1, u2) => u1.UserInfoCompanyID.CompareTo(u2.UserInfoCompanyID));
    }
    catch (Exception exception)
    {
    Log4ExceptionConnDb.ExXml(exception);
    }

    return userInfoCompanyLists;
    }

    public UserInfoCompany GetUserInfoCompanyById(int userInfoCompanyID)
    {
    UserInfoCompany userInfoCompany = new UserInfoCompany();

    try
    {

    if(userInfoCompanyID != 0)
    {

    List<UserInfoCompany> userInfoCompanyLists = new List<UserInfoCompany>();

    UserInfoCompanyXml userInfoCompanyXml = XmlDeserialize<UserInfoCompanyXml>(xmlUserInfoCompany);
    userInfoCompanyLists = userInfoCompanyXml.UserInfoCompanyLists.Where(a => a.UserInfoCompanyID == userInfoCompanyID).ToList();
    userInfoCompanyLists.Sort((u1, u2) => u1.UserInfoCompanyID.CompareTo(u2.UserInfoCompanyID));
    userInfoCompany = userInfoCompanyLists.FirstOrDefault();

    }
    else
    {
    userInfoCompany.ErrID = 1;
    userInfoCompany.ErrText = "userInfoCompanyID cannot be zero.";
    }

    }
    catch (Exception exception)
    {
    XmlErrors(userInfoCompany);
    Log4ExceptionConnDb.ExXml(exception);
    }

    return userInfoCompany;
    }

    public UserInfoCompany InsertUserInfoCompany(UserInfoCompany userInfoCompany)
    {

    try
    {
    if(userInfoCompany != null)
    {
    if(userInfoCompany.UserInfoCompanyID != 0)
    {

    UserInfoCompanyXml userInfoCompanyXml = XmlDeserialize<UserInfoCompanyXml>(xmlUserInfoCompany);

    if (userInfoCompanyXml.UserInfoCompanyLists == null)
    {
    userInfoCompanyXml.UserInfoCompanyLists = new List<UserInfoCompany>();
    }

    userInfoCompanyXml.UserInfoCompanyLists.Sort((u1, u2) => u1.UserInfoCompanyID.CompareTo(u2.UserInfoCompanyID));
    userInfoCompany.UserInfoCompanyID = userInfoCompanyXml.UserInfoCompanyLists.Count == 0 ? 1 : userInfoCompanyXml.UserInfoCompanyLists.Max(x => x.UserInfoCompanyID) + 1;
    userInfoCompanyXml.UserInfoCompanyLists.Add(userInfoCompany);
    XmlSerialize(userInfoCompanyXml, xmlUserInfoCompany);

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
    XmlErrors(userInfoCompany);
    Log4ExceptionConnDb.ExXml(exception);
    }

    return userInfoCompany;
    }

    public UserInfoCompany UpdateUserInfoCompany(UserInfoCompany userInfoCompany)
    {

    try
    {
    if(userInfoCompany != null)
    {
    if(userInfoCompany.UserInfoCompanyID != 0)
    {

    UserInfoCompanyXml userInfoCompanyXml = XmlDeserialize<UserInfoCompanyXml>(xmlUserInfoCompany);

    if (userInfoCompanyXml.UserInfoCompanyLists == null)
    {
    userInfoCompanyXml.UserInfoCompanyLists = new List<UserInfoCompany>();
    }

    foreach (UserInfoCompany _userInfoCompany in userInfoCompanyXml.UserInfoCompanyLists)
    {
    if (_userInfoCompany.UserInfoCompanyID == userInfoCompany.UserInfoCompanyID)
    {
    _userInfoCompany.UserInfoCompanyEIN = userInfoCompany.UserInfoCompanyEIN;
_userInfoCompany.UserInfoCompanyName = userInfoCompany.UserInfoCompanyName;
_userInfoCompany.UserInfoCompanyAddress1 = userInfoCompany.UserInfoCompanyAddress1;
_userInfoCompany.UserInfoCompanyAddress2 = userInfoCompany.UserInfoCompanyAddress2;
_userInfoCompany.UserInfoCompanyCityStateZip = userInfoCompany.UserInfoCompanyCityStateZip;
_userInfoCompany.UserInfoCompanyTelephone = userInfoCompany.UserInfoCompanyTelephone;
_userInfoCompany.UserInfoCompanyEmailAddress = userInfoCompany.UserInfoCompanyEmailAddress;
_userInfoCompany.UserCompanyWebsiteAddress = userInfoCompany.UserCompanyWebsiteAddress;
_userInfoCompany.UserInfoCountriesID = userInfoCompany.UserInfoCountriesID;
_userInfoCompany.UserInfoCompanyActiveYesNo = userInfoCompany.UserInfoCompanyActiveYesNo;

    _userInfoCompany.UpdateUserName = userInfoCompany.UpdateUserName;
    _userInfoCompany.UpdateFullName = userInfoCompany.UpdateFullName;
    _userInfoCompany.UpdateDate = userInfoCompany.UpdateDate;
    XmlSerialize(userInfoCompanyXml, xmlUserInfoCompany);
    break;
    }
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
    XmlErrors(userInfoCompany);
    Log4ExceptionConnDb.ExXml(exception);
    }

    return userInfoCompany;
    }

    public UserInfoCompany DeleteUserInfoCompany(int userInfoCompanyID, UserInfoCompany userInfoCompany)
    {

    try
    {

    if(userInfoCompany != null)
    {
    if(userInfoCompanyID != 0)
    {

    UserInfoCompanyXml userInfoCompanyXml = XmlDeserialize<UserInfoCompanyXml>(xmlUserInfoCompany);

    if (userInfoCompanyXml.UserInfoCompanyLists == null)
    {
    userInfoCompanyXml.UserInfoCompanyLists = new List<UserInfoCompany>();
    }

    userInfoCompanyXml.UserInfoCompanyLists.RemoveAll(x => x.UserInfoCompanyID == userInfoCompanyID);
    XmlSerialize(userInfoCompanyXml, xmlUserInfoCompany);

    userInfoCompany.DeleteTrueFalse = true;

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
    XmlErrors(userInfoCompany);
    Log4ExceptionConnDb.ExXml(exception);
    }

    return userInfoCompany;
    }

    private void XmlErrors(UserInfoCompany userInfoCompany)
    {
    userInfoCompany.ErrID = 1;
    userInfoCompany.ErrText = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
    }
    #endregion
    }
  

    }
  