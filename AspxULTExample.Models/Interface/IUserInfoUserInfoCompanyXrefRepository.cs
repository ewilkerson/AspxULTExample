
    using System;
    using System.Collections.Generic;

    namespace AspxULTExample.Models.Interface
    {

    
    public interface IUserInfoUserInfoCompanyXrefRepository
    {

    #region IUserInfoUserInfoCompanyXrefRepository

    IEnumerable<UserInfoUserInfoCompanyXref>GetUserInfoUserInfoCompanyXrefs();

    UserInfoUserInfoCompanyXref GetUserInfoUserInfoCompanyXrefById(int userInfoUserInfoCompanyXrefID);

    UserInfoUserInfoCompanyXref InsertUserInfoUserInfoCompanyXref(UserInfoUserInfoCompanyXref userInfoUserInfoCompanyXref);

    UserInfoUserInfoCompanyXref UpdateUserInfoUserInfoCompanyXref(UserInfoUserInfoCompanyXref userInfoUserInfoCompanyXref);

    UserInfoUserInfoCompanyXref DeleteUserInfoUserInfoCompanyXref(int userInfoUserInfoCompanyXrefID,UserInfoUserInfoCompanyXref userInfoUserInfoCompanyXref);

    #endregion
    }
  

    }
  