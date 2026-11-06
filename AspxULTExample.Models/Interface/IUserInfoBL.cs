
    using System;
    using System.Collections.Generic;

    namespace AspxULTExample.Models.Interface
    {

    
    public interface IUserInfoBL
    {

    #region IUserInfoBL

    IEnumerable<UserInfo>GetUserInfos();

    UserInfo GetUserInfoById(int userInfoID);

    bool InsertUserInfo(UserInfo userInfo);

    bool UpdateUserInfo(UserInfo userInfo);

    bool DeleteUserInfo(int userInfoID,UserInfo userInfo);

    Dictionary<string,string> UserInfoIsValid(UserInfo userInfo);

    #endregion
    }
  

    }
  