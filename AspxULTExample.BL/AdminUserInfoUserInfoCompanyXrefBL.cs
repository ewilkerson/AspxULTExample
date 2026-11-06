
    using System;
    using System.Collections.Generic;
    using AspxULTExample.Models;
    using AspxULTExample.Models.Interface;

    namespace AspxULTExample.BL
    {

    
    public partial class AdminUserInfoUserInfoCompanyXrefBL:IUserInfoUserInfoCompanyXrefBL
    {

    #region AdminUserInfoUserInfoCompanyXrefBL

    private readonly IUserInfoUserInfoCompanyXrefRepository _context;

    public AdminUserInfoUserInfoCompanyXrefBL(IUserInfoUserInfoCompanyXrefRepository context)
    {
    this._context = context;
    }

    public IEnumerable<UserInfoUserInfoCompanyXref>
    GetUserInfoUserInfoCompanyXrefs()
    {
    return this._context.GetUserInfoUserInfoCompanyXrefs();
    }

    public UserInfoUserInfoCompanyXref GetUserInfoUserInfoCompanyXrefById(int userInfoUserInfoCompanyXrefID)
    {
    return this._context.GetUserInfoUserInfoCompanyXrefById(userInfoUserInfoCompanyXrefID);
    }

    public bool InsertUserInfoUserInfoCompanyXref(UserInfoUserInfoCompanyXref userInfoUserInfoCompanyXref)
    {

    Dictionary<string, string> isVal = UserInfoUserInfoCompanyXrefIsValid(userInfoUserInfoCompanyXref);
    bool val = isVal.Count == 0;
    if(val)
    {
    this._context.InsertUserInfoUserInfoCompanyXref(userInfoUserInfoCompanyXref);
    }
    return val;
    }

    public bool UpdateUserInfoUserInfoCompanyXref(UserInfoUserInfoCompanyXref userInfoUserInfoCompanyXref)
    {
    Dictionary<string, string> isVal = UserInfoUserInfoCompanyXrefIsValid(userInfoUserInfoCompanyXref);
    bool val = isVal.Count == 0;

    if(val)
    {
    this._context.UpdateUserInfoUserInfoCompanyXref(userInfoUserInfoCompanyXref);
    }
    return val;
    }

    public bool DeleteUserInfoUserInfoCompanyXref(int userInfoUserInfoCompanyXrefID, UserInfoUserInfoCompanyXref userInfoUserInfoCompanyXref)
    {

    bool val = userInfoUserInfoCompanyXrefID != 0;

    if(val)
    {
    this._context.DeleteUserInfoUserInfoCompanyXref(userInfoUserInfoCompanyXrefID, userInfoUserInfoCompanyXref);
    }
    return val;
    }

    public Dictionary<string,string>UserInfoUserInfoCompanyXrefIsValid(UserInfoUserInfoCompanyXref userInfoUserInfoCompanyXref)
    {
    Dictionary<string,string> isVal = new Dictionary<string, string>();

    
    if (userInfoUserInfoCompanyXref != null){
    
    if (userInfoUserInfoCompanyXref.UserInfoUserInfoCompanyXrefID == 0)
    {
    isVal.Add("UserInfoUserInfoCompanyXrefID", "User Info User Info Company Xref ID cannot be zero.");
    }
  

    if (userInfoUserInfoCompanyXref.UserInfoID == 0)
    {
    isVal.Add("UserInfoID", "User Info ID cannot be zero.");
    }
  

    if (userInfoUserInfoCompanyXref.UserInfoCompanyID == 0)
    {
    isVal.Add("UserInfoCompanyID", "User Info Company ID cannot be zero.");
    }
  



    } else
    {
    isVal.Add("userInfoUserInfoCompanyXref", "userInfoUserInfoCompanyXref cannot be null.");
    }
  

    return isVal;
    }

    #endregion

    }
  

    }
  