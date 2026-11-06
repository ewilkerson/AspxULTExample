
    using System;
    using System.Collections.Generic;
    using AspxULTExample.Models;
    using AspxULTExample.Models.Interface;

    namespace AspxULTExample.BL
    {

    
    public partial class AdminUserInfoAccessLevelBL:IUserInfoAccessLevelBL
    {

    #region AdminUserInfoAccessLevelBL

    private readonly IUserInfoAccessLevelRepository _context;

    public AdminUserInfoAccessLevelBL(IUserInfoAccessLevelRepository context)
    {
    this._context = context;
    }

    public IEnumerable<UserInfoAccessLevel>
    GetUserInfoAccessLevels()
    {
    return this._context.GetUserInfoAccessLevels();
    }

    public UserInfoAccessLevel GetUserInfoAccessLevelById(int userInfoAccessLevelID)
    {
    return this._context.GetUserInfoAccessLevelById(userInfoAccessLevelID);
    }

    public bool InsertUserInfoAccessLevel(UserInfoAccessLevel userInfoAccessLevel)
    {

    Dictionary<string, string> isVal = UserInfoAccessLevelIsValid(userInfoAccessLevel);
    bool val = isVal.Count == 0;
    if(val)
    {
    this._context.InsertUserInfoAccessLevel(userInfoAccessLevel);
    }
    return val;
    }

    public bool UpdateUserInfoAccessLevel(UserInfoAccessLevel userInfoAccessLevel)
    {
    Dictionary<string, string> isVal = UserInfoAccessLevelIsValid(userInfoAccessLevel);
    bool val = isVal.Count == 0;

    if(val)
    {
    this._context.UpdateUserInfoAccessLevel(userInfoAccessLevel);
    }
    return val;
    }

    public bool DeleteUserInfoAccessLevel(int userInfoAccessLevelID, UserInfoAccessLevel userInfoAccessLevel)
    {

    bool val = userInfoAccessLevelID != 0;

    if(val)
    {
    this._context.DeleteUserInfoAccessLevel(userInfoAccessLevelID, userInfoAccessLevel);
    }
    return val;
    }

    public Dictionary<string,string>UserInfoAccessLevelIsValid(UserInfoAccessLevel userInfoAccessLevel)
    {
    Dictionary<string,string> isVal = new Dictionary<string, string>();

    
    if (userInfoAccessLevel != null){
    
    if (userInfoAccessLevel.UserInfoAccessLevelID == 0)
    {
    isVal.Add("UserInfoAccessLevelID", "User Info Access Level ID cannot be zero.");
    }
  

    if (string.IsNullOrWhiteSpace(userInfoAccessLevel.UserInfoAccessLevelName))
    {
    isVal.Add("UserInfoAccessLevelName", "User Info Access Level Name cannot be null or empty or only have white space.");
    }
  

    if (userInfoAccessLevel.UserInfoAccessLevelNum == 0)
    {
    isVal.Add("UserInfoAccessLevelNum", "User Info Access Level Num cannot be zero.");
    }
  


    } else
    {
    isVal.Add("userInfoAccessLevel", "userInfoAccessLevel cannot be null.");
    }
  

    return isVal;
    }

    #endregion

    }
  

    }
  