
    using System;
    using System.Collections.Generic;

    namespace AspxULTExample.Models.Interface
    {

    
    public interface IUserInfoAccessLevelRepository
    {

    #region IUserInfoAccessLevelRepository

    IEnumerable<UserInfoAccessLevel>GetUserInfoAccessLevels();

    UserInfoAccessLevel GetUserInfoAccessLevelById(int userInfoAccessLevelID);

    UserInfoAccessLevel InsertUserInfoAccessLevel(UserInfoAccessLevel userInfoAccessLevel);

    UserInfoAccessLevel UpdateUserInfoAccessLevel(UserInfoAccessLevel userInfoAccessLevel);

    UserInfoAccessLevel DeleteUserInfoAccessLevel(int userInfoAccessLevelID,UserInfoAccessLevel userInfoAccessLevel);

    #endregion
    }
  

    }
  