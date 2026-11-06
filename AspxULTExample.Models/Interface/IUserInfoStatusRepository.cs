
    using System;
    using System.Collections.Generic;

    namespace AspxULTExample.Models.Interface
    {

    
    public interface IUserInfoStatusRepository
    {

    #region IUserInfoStatusRepository

    IEnumerable<UserInfoStatus>GetUserInfoStatuss();

    UserInfoStatus GetUserInfoStatusById(int userInfoStatusID);

    UserInfoStatus InsertUserInfoStatus(UserInfoStatus userInfoStatus);

    UserInfoStatus UpdateUserInfoStatus(UserInfoStatus userInfoStatus);

    UserInfoStatus DeleteUserInfoStatus(int userInfoStatusID,UserInfoStatus userInfoStatus);

    #endregion
    }
  

    }
  