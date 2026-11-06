
    using System;
    using System.Collections.Generic;

    namespace AspxULTExample.Models.Interface
    {

    
    public interface IUserInfoRepository
    {

    #region IUserInfoRepository

    IEnumerable<UserInfo>GetUserInfos();

    UserInfo GetUserInfoById(int userInfoID);

    UserInfo InsertUserInfo(UserInfo userInfo);

    UserInfo UpdateUserInfo(UserInfo userInfo);

    UserInfo DeleteUserInfo(int userInfoID,UserInfo userInfo);

    #endregion
    }
  

    }
  