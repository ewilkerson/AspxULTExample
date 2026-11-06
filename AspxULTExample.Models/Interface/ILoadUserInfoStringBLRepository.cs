
    using System;
    using System.Collections.Generic;

    namespace AspxULTExample.Models.Interface
    {

    public interface ILoadUserInfoStringBL
    {

    #region ILoadUserInfoStringBL

    LoadUserInfo GetLoadUserInfoByString(string identityName);
    IEnumerable<UserInfoUserInfoCompanyXref> GetLoadUserInfoUserInfoCompanyXrefsById(int userInfoID);
    IEnumerable<LoadUserInfo> GetLoadUserInfoEmailAddressByCompanyID(int companyID);

    #endregion
    }

    public interface ILoadUserInfoStringRepository
    {

    #region ILoadUserInfoStringRepository

    LoadUserInfo GetLoadUserInfoByString(string identityName);
    IEnumerable<UserInfoUserInfoCompanyXref> GetLoadUserInfoUserInfoCompanyXrefsById(int userInfoID);
    IEnumerable<LoadUserInfo> GetLoadUserInfoEmailAddressByCompanyID(int companyID);

    #endregion
    }

    }
  