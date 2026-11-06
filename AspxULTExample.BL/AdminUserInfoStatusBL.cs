
    using System;
    using System.Collections.Generic;
    using AspxULTExample.Models;
    using AspxULTExample.Models.Interface;

    namespace AspxULTExample.BL
    {

    
    public partial class AdminUserInfoStatusBL:IUserInfoStatusBL
    {

    #region AdminUserInfoStatusBL

    private readonly IUserInfoStatusRepository _context;

    public AdminUserInfoStatusBL(IUserInfoStatusRepository context)
    {
    this._context = context;
    }

    public IEnumerable<UserInfoStatus>
    GetUserInfoStatuss()
    {
    return this._context.GetUserInfoStatuss();
    }

    public UserInfoStatus GetUserInfoStatusById(int userInfoStatusID)
    {
    return this._context.GetUserInfoStatusById(userInfoStatusID);
    }

    public bool InsertUserInfoStatus(UserInfoStatus userInfoStatus)
    {

    Dictionary<string, string> isVal = UserInfoStatusIsValid(userInfoStatus);
    bool val = isVal.Count == 0;
    if(val)
    {
    this._context.InsertUserInfoStatus(userInfoStatus);
    }
    return val;
    }

    public bool UpdateUserInfoStatus(UserInfoStatus userInfoStatus)
    {
    Dictionary<string, string> isVal = UserInfoStatusIsValid(userInfoStatus);
    bool val = isVal.Count == 0;

    if(val)
    {
    this._context.UpdateUserInfoStatus(userInfoStatus);
    }
    return val;
    }

    public bool DeleteUserInfoStatus(int userInfoStatusID, UserInfoStatus userInfoStatus)
    {

    bool val = userInfoStatusID != 0;

    if(val)
    {
    this._context.DeleteUserInfoStatus(userInfoStatusID, userInfoStatus);
    }
    return val;
    }

    public Dictionary<string,string>UserInfoStatusIsValid(UserInfoStatus userInfoStatus)
    {
    Dictionary<string,string> isVal = new Dictionary<string, string>();

    
    if (userInfoStatus != null){
    
    if (userInfoStatus.UserInfoStatusID == 0)
    {
    isVal.Add("UserInfoStatusID", "User Info Status ID cannot be zero.");
    }
  

    if (string.IsNullOrWhiteSpace(userInfoStatus.UserInfoStatusName))
    {
    isVal.Add("UserInfoStatusName", "User Info Status Name cannot be null or empty or only have white space.");
    }
  


    } else
    {
    isVal.Add("userInfoStatus", "userInfoStatus cannot be null.");
    }
  

    return isVal;
    }

    #endregion

    }
  

    }
  