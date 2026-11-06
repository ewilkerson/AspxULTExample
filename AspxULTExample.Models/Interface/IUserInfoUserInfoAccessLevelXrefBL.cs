
    using System;
    using System.Collections.Generic;

    namespace AspxULTExample.Models.Interface
    {

    
    public interface IUserInfoUserInfoAccessLevelXrefBL
    {

    #region IUserInfoUserInfoAccessLevelXrefBL

    IEnumerable<UserInfoUserInfoAccessLevelXref>GetUserInfoUserInfoAccessLevelXrefs();

    UserInfoUserInfoAccessLevelXref GetUserInfoUserInfoAccessLevelXrefById(int userInfoUserInfoAccessLevelXrefID);

    bool InsertUserInfoUserInfoAccessLevelXref(UserInfoUserInfoAccessLevelXref userInfoUserInfoAccessLevelXref);

    bool UpdateUserInfoUserInfoAccessLevelXref(UserInfoUserInfoAccessLevelXref userInfoUserInfoAccessLevelXref);

    bool DeleteUserInfoUserInfoAccessLevelXref(int userInfoUserInfoAccessLevelXrefID,UserInfoUserInfoAccessLevelXref userInfoUserInfoAccessLevelXref);

    Dictionary<string,string> UserInfoUserInfoAccessLevelXrefIsValid(UserInfoUserInfoAccessLevelXref userInfoUserInfoAccessLevelXref);

    #endregion
    }
  

    }
  