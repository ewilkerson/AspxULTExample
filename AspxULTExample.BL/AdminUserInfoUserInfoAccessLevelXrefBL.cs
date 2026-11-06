
    using System;
    using System.Collections.Generic;
    using AspxULTExample.Models;
    using AspxULTExample.Models.Interface;

    namespace AspxULTExample.BL
    {

    
    public partial class AdminUserInfoUserInfoAccessLevelXrefBL:IUserInfoUserInfoAccessLevelXrefBL
    {

    #region AdminUserInfoUserInfoAccessLevelXrefBL

    private readonly IUserInfoUserInfoAccessLevelXrefRepository _context;

    public AdminUserInfoUserInfoAccessLevelXrefBL(IUserInfoUserInfoAccessLevelXrefRepository context)
    {
    this._context = context;
    }

    public IEnumerable<UserInfoUserInfoAccessLevelXref>
    GetUserInfoUserInfoAccessLevelXrefs()
    {
    return this._context.GetUserInfoUserInfoAccessLevelXrefs();
    }

    public UserInfoUserInfoAccessLevelXref GetUserInfoUserInfoAccessLevelXrefById(int userInfoUserInfoAccessLevelXrefID)
    {
    return this._context.GetUserInfoUserInfoAccessLevelXrefById(userInfoUserInfoAccessLevelXrefID);
    }

    public bool InsertUserInfoUserInfoAccessLevelXref(UserInfoUserInfoAccessLevelXref userInfoUserInfoAccessLevelXref)
    {

    Dictionary<string, string> isVal = UserInfoUserInfoAccessLevelXrefIsValid(userInfoUserInfoAccessLevelXref);
    bool val = isVal.Count == 0;
    if(val)
    {
    this._context.InsertUserInfoUserInfoAccessLevelXref(userInfoUserInfoAccessLevelXref);
    }
    return val;
    }

    public bool UpdateUserInfoUserInfoAccessLevelXref(UserInfoUserInfoAccessLevelXref userInfoUserInfoAccessLevelXref)
    {
    Dictionary<string, string> isVal = UserInfoUserInfoAccessLevelXrefIsValid(userInfoUserInfoAccessLevelXref);
    bool val = isVal.Count == 0;

    if(val)
    {
    this._context.UpdateUserInfoUserInfoAccessLevelXref(userInfoUserInfoAccessLevelXref);
    }
    return val;
    }

    public bool DeleteUserInfoUserInfoAccessLevelXref(int userInfoUserInfoAccessLevelXrefID, UserInfoUserInfoAccessLevelXref userInfoUserInfoAccessLevelXref)
    {

    bool val = userInfoUserInfoAccessLevelXrefID != 0;

    if(val)
    {
    this._context.DeleteUserInfoUserInfoAccessLevelXref(userInfoUserInfoAccessLevelXrefID, userInfoUserInfoAccessLevelXref);
    }
    return val;
    }

    public Dictionary<string,string>UserInfoUserInfoAccessLevelXrefIsValid(UserInfoUserInfoAccessLevelXref userInfoUserInfoAccessLevelXref)
    {
    Dictionary<string,string> isVal = new Dictionary<string, string>();

    
    if (userInfoUserInfoAccessLevelXref != null){
    
    if (userInfoUserInfoAccessLevelXref.UserInfoUserInfoAccessLevelXrefID == 0)
    {
    isVal.Add("UserInfoUserInfoAccessLevelXrefID", "User Info User Info Access Level Xref ID cannot be zero.");
    }
  

    if (userInfoUserInfoAccessLevelXref.UserInfoID == 0)
    {
    isVal.Add("UserInfoID", "User Info ID cannot be zero.");
    }
  

    if (userInfoUserInfoAccessLevelXref.UserInfoAccessLevelID == 0)
    {
    isVal.Add("UserInfoAccessLevelID", "User Info Access Level ID cannot be zero.");
    }
  


    } else
    {
    isVal.Add("userInfoUserInfoAccessLevelXref", "userInfoUserInfoAccessLevelXref cannot be null.");
    }
  

    return isVal;
    }

    #endregion

    }
  

    }
  