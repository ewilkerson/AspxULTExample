
    using System;
    using System.Collections.Generic;

    namespace AspxULTExample.Models.Interface
    {

    
    public interface IUserInfoUserInfoCompanyXrefBL
    {

    #region IUserInfoUserInfoCompanyXrefBL

    IEnumerable<UserInfoUserInfoCompanyXref>GetUserInfoUserInfoCompanyXrefs();

    UserInfoUserInfoCompanyXref GetUserInfoUserInfoCompanyXrefById(int userInfoUserInfoCompanyXrefID);

    bool InsertUserInfoUserInfoCompanyXref(UserInfoUserInfoCompanyXref userInfoUserInfoCompanyXref);

    bool UpdateUserInfoUserInfoCompanyXref(UserInfoUserInfoCompanyXref userInfoUserInfoCompanyXref);

    bool DeleteUserInfoUserInfoCompanyXref(int userInfoUserInfoCompanyXrefID,UserInfoUserInfoCompanyXref userInfoUserInfoCompanyXref);

    Dictionary<string,string> UserInfoUserInfoCompanyXrefIsValid(UserInfoUserInfoCompanyXref userInfoUserInfoCompanyXref);

    #endregion
    }
  

    }
  