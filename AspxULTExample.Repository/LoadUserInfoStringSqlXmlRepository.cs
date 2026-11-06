
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

    public enum LoadUserInfoSqlXmlEnum
    {
    Sql,
    Xml
    }

    public partial class LoadUserInfoStringSqlXmlRepository : ILoadUserInfoStringRepository
    {

    #region LoadUserInfoStringSqlXmlRepository

    private string LoadUserInfoUserName(string userInfoUserName)
    {
    string userName = string.Empty;

    if (!string.IsNullOrWhiteSpace(userInfoUserName))
    {
    string[] parts = userInfoUserName.Split('\\');
    userName = parts.Length == 1 ? parts[0].Trim() : parts[1].Trim();
    }

    return userName;
    }

    public LoadUserInfo GetLoadUserInfoByString(string userInfoUserName)
    {
    LoadUserInfo loadUserInfo = new LoadUserInfo();

    if (!string.IsNullOrWhiteSpace(userInfoUserName))
    {
    string userInfoUserIdentityName = LoadUserInfoUserName(userInfoUserName);

    LoadUserInfoSqlXmlEnum loadUserInfoSqlXmlEnum = LoadUserInfoSqlXmlEnum.Xml;
    if (loadUserInfoSqlXmlEnum == LoadUserInfoSqlXmlEnum.Sql)
    {
    LoadUserInfoStringRepository adminLoadUserInfoStringRepository = new LoadUserInfoStringRepository();
    loadUserInfo = adminLoadUserInfoStringRepository.GetLoadUserInfoByString(userInfoUserIdentityName);
    }
    else if (loadUserInfoSqlXmlEnum == LoadUserInfoSqlXmlEnum.Xml)
    {
    LoadUserInfoXmlStringRepository loadUserInfoXmlStringRepository = new LoadUserInfoXmlStringRepository();
    loadUserInfo = loadUserInfoXmlStringRepository.GetLoadUserInfoByString(userInfoUserIdentityName);
    }

    }

    return loadUserInfo;
    }

    public IEnumerable<UserInfoUserInfoCompanyXref> GetLoadUserInfoUserInfoCompanyXrefsById(int userInfoID)
    {
    IEnumerable<UserInfoUserInfoCompanyXref> userInfoUserInfoCompanyXrefLists = new List<UserInfoUserInfoCompanyXref>();

    if (userInfoID != 0)
    {
    LoadUserInfoSqlXmlEnum loadUserInfoSqlXmlEnum = LoadUserInfoSqlXmlEnum.Xml;
    if (loadUserInfoSqlXmlEnum == LoadUserInfoSqlXmlEnum.Sql)
    {
    LoadUserInfoStringRepository loadUserInfoStringRepository = new LoadUserInfoStringRepository();
    userInfoUserInfoCompanyXrefLists = loadUserInfoStringRepository.GetLoadUserInfoUserInfoCompanyXrefsById(userInfoID);
    }
    else if (loadUserInfoSqlXmlEnum == LoadUserInfoSqlXmlEnum.Xml)
    {
    LoadUserInfoXmlStringRepository loadUserInfoXmlStringRepository = new LoadUserInfoXmlStringRepository();
    userInfoUserInfoCompanyXrefLists = loadUserInfoXmlStringRepository.GetLoadUserInfoUserInfoCompanyXrefsById(userInfoID);
    }

    }

    return userInfoUserInfoCompanyXrefLists;

    }


    public IEnumerable<LoadUserInfo> GetLoadUserInfoEmailAddressByCompanyID(int companyID)
    {

    IEnumerable<LoadUserInfo> loadUserInfoEmailAddressLists = new List<LoadUserInfo>();

    if (companyID != 0)
    {

    LoadUserInfoSqlXmlEnum loadUserInfoSqlXmlEnum = LoadUserInfoSqlXmlEnum.Xml;
    if (loadUserInfoSqlXmlEnum == LoadUserInfoSqlXmlEnum.Sql)
    {
    LoadUserInfoStringRepository loadUserInfoStringRepository = new LoadUserInfoStringRepository();
    loadUserInfoEmailAddressLists = loadUserInfoStringRepository.GetLoadUserInfoEmailAddressByCompanyID(companyID);
    }
    else if (loadUserInfoSqlXmlEnum == LoadUserInfoSqlXmlEnum.Xml)
    {
    LoadUserInfoXmlStringRepository loadUserInfoXmlStringRepository = new LoadUserInfoXmlStringRepository();
    loadUserInfoEmailAddressLists = loadUserInfoXmlStringRepository.GetLoadUserInfoEmailAddressByCompanyID(companyID);
    }

    }
    return loadUserInfoEmailAddressLists;


    }


    #endregion

    }

    }

  