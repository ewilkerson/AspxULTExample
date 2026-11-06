
    using System;
    using System.Collections.Generic;
    using AspxULTExample.Models;
    using AspxULTExample.Models.Interface;

    namespace AspxULTExample.BL
    {

    
    public partial class AdminUserInfoBL:IUserInfoBL
    {

    #region AdminUserInfoBL

    private readonly IUserInfoRepository _context;

    public AdminUserInfoBL(IUserInfoRepository context)
    {
    this._context = context;
    }

    public IEnumerable<UserInfo>
    GetUserInfos()
    {
    return this._context.GetUserInfos();
    }

    public UserInfo GetUserInfoById(int userInfoID)
    {
    return this._context.GetUserInfoById(userInfoID);
    }

    public bool InsertUserInfo(UserInfo userInfo)
    {

    Dictionary<string, string> isVal = UserInfoIsValid(userInfo);
    bool val = isVal.Count == 0;
    if(val)
    {
    this._context.InsertUserInfo(userInfo);
    }
    return val;
    }

    public bool UpdateUserInfo(UserInfo userInfo)
    {
    Dictionary<string, string> isVal = UserInfoIsValid(userInfo);
    bool val = isVal.Count == 0;

    if(val)
    {
    this._context.UpdateUserInfo(userInfo);
    }
    return val;
    }

    public bool DeleteUserInfo(int userInfoID, UserInfo userInfo)
    {

    bool val = userInfoID != 0;

    if(val)
    {
    this._context.DeleteUserInfo(userInfoID, userInfo);
    }
    return val;
    }

    public Dictionary<string,string>UserInfoIsValid(UserInfo userInfo)
    {
    Dictionary<string,string> isVal = new Dictionary<string, string>();

    
    if (userInfo != null){
    
    if (userInfo.UserInfoID == 0)
    {
    isVal.Add("UserInfoID", "User Info ID cannot be zero.");
    }
  

    if (string.IsNullOrWhiteSpace(userInfo.UserInfoUserIdentityName))
    {
    isVal.Add("UserInfoUserIdentityName", "User Info User Identity Name cannot be null or empty or only have white space.");
    }
  

    if (string.IsNullOrWhiteSpace(userInfo.UserInfoUserName))
    {
    isVal.Add("UserInfoUserName", "User Info User Name cannot be null or empty or only have white space.");
    }
  

    if (string.IsNullOrWhiteSpace(userInfo.UserInfoFullName))
    {
    isVal.Add("UserInfoFullName", "User Info Full Name cannot be null or empty or only have white space.");
    }
  

    if (string.IsNullOrWhiteSpace(userInfo.UserInfoEmailAddress))
    {
    isVal.Add("UserInfoEmailAddress", "User Info Email Address cannot be null or empty or only have white space.");
    }
  

    if (string.IsNullOrWhiteSpace(userInfo.UserInfoJobTitle))
    {
    isVal.Add("UserInfoJobTitle", "User Info Job Title cannot be null or empty or only have white space.");
    }
  


    } else
    {
    isVal.Add("userInfo", "userInfo cannot be null.");
    }
  

    return isVal;
    }

    #endregion

    }
  

    }
  