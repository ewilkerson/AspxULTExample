
    using System;
    using System.Collections.Generic;
    using AspxULTExample.Models;
    using AspxULTExample.Models.Interface;

    namespace AspxULTExample.BL
    {
    public partial class LoadUserInfoStringBL:ILoadUserInfoStringBL
    {

    #region LoadUserInfoStringBL

    public readonly ILoadUserInfoStringRepository _context;

    public LoadUserInfoStringBL(ILoadUserInfoStringRepository context)
    {
    this._context = context;
    }

    public LoadUserInfo GetLoadUserInfoByString(string userInfoUserName)
    {
    return _context.GetLoadUserInfoByString(userInfoUserName);
    }

    public IEnumerable<UserInfoUserInfoCompanyXref> GetLoadUserInfoUserInfoCompanyXrefsById(int userInfoID)
    {
    return _context.GetLoadUserInfoUserInfoCompanyXrefsById(userInfoID);
    }

    public IEnumerable<LoadUserInfo> GetLoadUserInfoEmailAddressByCompanyID(int companyID)
    {
    return _context.GetLoadUserInfoEmailAddressByCompanyID(companyID);
    }

    #endregion

    }

    }
  