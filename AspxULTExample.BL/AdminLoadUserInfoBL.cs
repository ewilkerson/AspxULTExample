
    using System;
    using System.Collections.Generic;
    using AspxULTExample.Models;
    using AspxULTExample.Models.Interface;

    namespace AspxULTExample.BL
    {

    
    public partial class AdminLoadUserInfoBL:ILoadUserInfoBL
    {

    #region AdminLoadUserInfoBL

    private readonly ILoadUserInfoRepository _context;

    public AdminLoadUserInfoBL(ILoadUserInfoRepository context)
    {
    this._context = context;
    }

    public IEnumerable<LoadUserInfo>
    GetLoadUserInfos()
    {
    return this._context.GetLoadUserInfos();
    }

    public LoadUserInfo GetLoadUserInfoById(int userInfoID)
    {
    return this._context.GetLoadUserInfoById(userInfoID);
    }

    public bool InsertLoadUserInfo(LoadUserInfo loadUserInfo)
    {

    Dictionary<string, string> isVal = LoadUserInfoIsValid(loadUserInfo);
    bool val = isVal.Count == 0;
    if(val)
    {
    this._context.InsertLoadUserInfo(loadUserInfo);
    }
    return val;
    }

    public bool UpdateLoadUserInfo(LoadUserInfo loadUserInfo)
    {
    Dictionary<string, string> isVal = LoadUserInfoIsValid(loadUserInfo);
    bool val = isVal.Count == 0;

    if(val)
    {
    this._context.UpdateLoadUserInfo(loadUserInfo);
    }
    return val;
    }

    public bool DeleteLoadUserInfo(int userInfoID, LoadUserInfo loadUserInfo)
    {

    bool val = userInfoID != 0;

    if(val)
    {
    this._context.DeleteLoadUserInfo(userInfoID, loadUserInfo);
    }
    return val;
    }

    public Dictionary<string,string>LoadUserInfoIsValid(LoadUserInfo loadUserInfo)
    {
    Dictionary<string,string> isVal = new Dictionary<string, string>();

    
    if (loadUserInfo != null){
    
    if (loadUserInfo.UserInfoID == 0)
    {
    isVal.Add("UserInfoID", "User Info ID cannot be zero.");
    }
  

    if (string.IsNullOrWhiteSpace(loadUserInfo.UserInfoUserIdentityName))
    {
    isVal.Add("UserInfoUserIdentityName", "User Info User Identity Name cannot be null or empty or only have white space.");
    }
  

    if (string.IsNullOrWhiteSpace(loadUserInfo.UserInfoUserName))
    {
    isVal.Add("UserInfoUserName", "User Info User Name cannot be null or empty or only have white space.");
    }
  

    if (string.IsNullOrWhiteSpace(loadUserInfo.UserInfoFullName))
    {
    isVal.Add("UserInfoFullName", "User Info Full Name cannot be null or empty or only have white space.");
    }
  

    if (string.IsNullOrWhiteSpace(loadUserInfo.UserInfoEmailAddress))
    {
    isVal.Add("UserInfoEmailAddress", "User Info Email Address cannot be null or empty or only have white space.");
    }
  

    if (string.IsNullOrWhiteSpace(loadUserInfo.UserInfoJobTitle))
    {
    isVal.Add("UserInfoJobTitle", "User Info Job Title cannot be null or empty or only have white space.");
    }
  


    if (loadUserInfo.UserInfoAccessLevelID == 0)
    {
    isVal.Add("UserInfoAccessLevelID", "User Info Access Level ID cannot be zero.");
    }
  

    } else
    {
    isVal.Add("loadUserInfo", "loadUserInfo cannot be null.");
    }
  

    return isVal;
    }

    #endregion

    }
  

    }
  