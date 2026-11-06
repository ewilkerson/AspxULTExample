
    using System;
    using System.Collections.Generic;

    namespace AspxULTExample.Models.Interface
    {

    
    public interface IUserInfoAccessLevelBL
    {

    #region IUserInfoAccessLevelBL

    IEnumerable<UserInfoAccessLevel>GetUserInfoAccessLevels();

    UserInfoAccessLevel GetUserInfoAccessLevelById(int userInfoAccessLevelID);

    bool InsertUserInfoAccessLevel(UserInfoAccessLevel userInfoAccessLevel);

    bool UpdateUserInfoAccessLevel(UserInfoAccessLevel userInfoAccessLevel);

    bool DeleteUserInfoAccessLevel(int userInfoAccessLevelID,UserInfoAccessLevel userInfoAccessLevel);

    Dictionary<string,string> UserInfoAccessLevelIsValid(UserInfoAccessLevel userInfoAccessLevel);

    #endregion
    }
  

    }
  