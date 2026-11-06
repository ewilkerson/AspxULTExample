
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

    
    public partial class AdminUserInfoCountriesXmlRepository : SerializeDeserializeXmlRepository, IUserInfoCountriesRepository
    {

    #region AdminUserInfoCountriesXmlRepository

    private readonly string urlMapPath = HttpContext.Current.Server.MapPath("~");
    private string xmlUserInfoCountries;

    public AdminUserInfoCountriesXmlRepository()
    {
    string xmlFolder = urlMapPath + "\\Xml";
    xmlUserInfoCountries = xmlFolder + "\\UserInfoCountriesXml.xml";

    if (!Directory.Exists(xmlFolder))
    Directory.CreateDirectory(xmlFolder);

    if (!File.Exists(xmlUserInfoCountries))
    {
    File.WriteAllText(xmlUserInfoCountries, "<?xml version=\"1.0\" encoding=\"utf-8\"?><UserInfoCountriesXml xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" ><UserInfoCountriesLists></UserInfoCountriesLists></UserInfoCountriesXml>");
    }


    }

    public IEnumerable<UserInfoCountries> GetUserInfoCountriess()
    {
    List<UserInfoCountries> userInfoCountriesLists = new List<UserInfoCountries>();

    try
    {
    UserInfoCountriesXml userInfoCountriesXml = XmlDeserialize<UserInfoCountriesXml>(xmlUserInfoCountries);
    userInfoCountriesLists = userInfoCountriesXml.UserInfoCountriesLists;
    userInfoCountriesLists.Sort((u1, u2) => u1.UserInfoCountriesID.CompareTo(u2.UserInfoCountriesID));
    }
    catch (Exception exception)
    {
    Log4ExceptionConnDb.ExXml(exception);
    }

    return userInfoCountriesLists;
    }

    public UserInfoCountries GetUserInfoCountriesById(int userInfoCountriesID)
    {
    UserInfoCountries userInfoCountries = new UserInfoCountries();

    try
    {

    if(userInfoCountriesID != 0)
    {

    List<UserInfoCountries> userInfoCountriesLists = new List<UserInfoCountries>();

    UserInfoCountriesXml userInfoCountriesXml = XmlDeserialize<UserInfoCountriesXml>(xmlUserInfoCountries);
    userInfoCountriesLists = userInfoCountriesXml.UserInfoCountriesLists.Where(a => a.UserInfoCountriesID == userInfoCountriesID).ToList();
    userInfoCountriesLists.Sort((u1, u2) => u1.UserInfoCountriesID.CompareTo(u2.UserInfoCountriesID));
    userInfoCountries = userInfoCountriesLists.FirstOrDefault();

    }
    else
    {
    userInfoCountries.ErrID = 1;
    userInfoCountries.ErrText = "userInfoCountriesID cannot be zero.";
    }

    }
    catch (Exception exception)
    {
    XmlErrors(userInfoCountries);
    Log4ExceptionConnDb.ExXml(exception);
    }

    return userInfoCountries;
    }

    public UserInfoCountries InsertUserInfoCountries(UserInfoCountries userInfoCountries)
    {

    try
    {
    if(userInfoCountries != null)
    {
    if(userInfoCountries.UserInfoCountriesID != 0)
    {

    UserInfoCountriesXml userInfoCountriesXml = XmlDeserialize<UserInfoCountriesXml>(xmlUserInfoCountries);

    if (userInfoCountriesXml.UserInfoCountriesLists == null)
    {
    userInfoCountriesXml.UserInfoCountriesLists = new List<UserInfoCountries>();
    }

    userInfoCountriesXml.UserInfoCountriesLists.Sort((u1, u2) => u1.UserInfoCountriesID.CompareTo(u2.UserInfoCountriesID));
    userInfoCountries.UserInfoCountriesID = userInfoCountriesXml.UserInfoCountriesLists.Count == 0 ? 1 : userInfoCountriesXml.UserInfoCountriesLists.Max(x => x.UserInfoCountriesID) + 1;
    userInfoCountriesXml.UserInfoCountriesLists.Add(userInfoCountries);
    XmlSerialize(userInfoCountriesXml, xmlUserInfoCountries);

    }
    else
    {
    userInfoCountries.ErrID = 1;
    userInfoCountries.ErrText = "UserInfoCountriesID cannot be zero.";
    }

    }
    else
    {
    userInfoCountries = new UserInfoCountries(){
    ErrID = 1,
    ErrText = "UserInfoCountries cannot be null."
    };
    }

    }
    catch (Exception exception)
    {
    XmlErrors(userInfoCountries);
    Log4ExceptionConnDb.ExXml(exception);
    }

    return userInfoCountries;
    }

    public UserInfoCountries UpdateUserInfoCountries(UserInfoCountries userInfoCountries)
    {

    try
    {
    if(userInfoCountries != null)
    {
    if(userInfoCountries.UserInfoCountriesID != 0)
    {

    UserInfoCountriesXml userInfoCountriesXml = XmlDeserialize<UserInfoCountriesXml>(xmlUserInfoCountries);

    if (userInfoCountriesXml.UserInfoCountriesLists == null)
    {
    userInfoCountriesXml.UserInfoCountriesLists = new List<UserInfoCountries>();
    }

    foreach (UserInfoCountries _userInfoCountries in userInfoCountriesXml.UserInfoCountriesLists)
    {
    if (_userInfoCountries.UserInfoCountriesID == userInfoCountries.UserInfoCountriesID)
    {
    _userInfoCountries.UserInfoCountriesName = userInfoCountries.UserInfoCountriesName;
_userInfoCountries.UserInfoCountriesActiveYesNo = userInfoCountries.UserInfoCountriesActiveYesNo;

    _userInfoCountries.UpdateUserName = userInfoCountries.UpdateUserName;
    _userInfoCountries.UpdateFullName = userInfoCountries.UpdateFullName;
    _userInfoCountries.UpdateDate = userInfoCountries.UpdateDate;
    XmlSerialize(userInfoCountriesXml, xmlUserInfoCountries);
    break;
    }
    }

    }
    else
    {
    userInfoCountries.ErrID = 1;
    userInfoCountries.ErrText = "UserInfoCountriesID cannot be zero.";
    }

    }
    else
    {
    userInfoCountries = new UserInfoCountries(){
    ErrID = 1,
    ErrText = "UserInfoCountries cannot be null."
    };
    }


    }
    catch (Exception exception)
    {
    XmlErrors(userInfoCountries);
    Log4ExceptionConnDb.ExXml(exception);
    }

    return userInfoCountries;
    }

    public UserInfoCountries DeleteUserInfoCountries(int userInfoCountriesID, UserInfoCountries userInfoCountries)
    {

    try
    {

    if(userInfoCountries != null)
    {
    if(userInfoCountriesID != 0)
    {

    UserInfoCountriesXml userInfoCountriesXml = XmlDeserialize<UserInfoCountriesXml>(xmlUserInfoCountries);

    if (userInfoCountriesXml.UserInfoCountriesLists == null)
    {
    userInfoCountriesXml.UserInfoCountriesLists = new List<UserInfoCountries>();
    }

    userInfoCountriesXml.UserInfoCountriesLists.RemoveAll(x => x.UserInfoCountriesID == userInfoCountriesID);
    XmlSerialize(userInfoCountriesXml, xmlUserInfoCountries);

    userInfoCountries.DeleteTrueFalse = true;

    }
    else
    {
    userInfoCountries.ErrID = 1;
    userInfoCountries.ErrText = "userInfoCountriesID cannot be zero.";
    }
    }
    else
    {
    userInfoCountries = new UserInfoCountries(){
    ErrID = 1,
    ErrText = "UserInfoCountries cannot be null."
    };
    }

    }
    catch (Exception exception)
    {
    XmlErrors(userInfoCountries);
    Log4ExceptionConnDb.ExXml(exception);
    }

    return userInfoCountries;
    }

    private void XmlErrors(UserInfoCountries userInfoCountries)
    {
    userInfoCountries.ErrID = 1;
    userInfoCountries.ErrText = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
    }
    #endregion
    }
  

    }
  