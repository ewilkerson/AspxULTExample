
    using System;
    using System.Collections.Generic;

    namespace AspxULTExample.Models.Interface
    {

    
    public interface IUserInfoUserInfoAccessLevelXrefRepository
    {

    #region IUserInfoUserInfoAccessLevelXrefRepository

    IEnumerable<UserInfoUserInfoAccessLevelXref>GetUserInfoUserInfoAccessLevelXrefs();

    UserInfoUserInfoAccessLevelXref GetUserInfoUserInfoAccessLevelXrefById(int userInfoUserInfoAccessLevelXrefID);

    UserInfoUserInfoAccessLevelXref InsertUserInfoUserInfoAccessLevelXref(UserInfoUserInfoAccessLevelXref userInfoUserInfoAccessLevelXref);

    UserInfoUserInfoAccessLevelXref UpdateUserInfoUserInfoAccessLevelXref(UserInfoUserInfoAccessLevelXref userInfoUserInfoAccessLevelXref);

    UserInfoUserInfoAccessLevelXref DeleteUserInfoUserInfoAccessLevelXref(int userInfoUserInfoAccessLevelXrefID,UserInfoUserInfoAccessLevelXref userInfoUserInfoAccessLevelXref);

    #endregion
    }
  

    }
  