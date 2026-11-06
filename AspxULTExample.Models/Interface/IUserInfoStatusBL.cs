
    using System;
    using System.Collections.Generic;

    namespace AspxULTExample.Models.Interface
    {

    
    public interface IUserInfoStatusBL
    {

    #region IUserInfoStatusBL

    IEnumerable<UserInfoStatus>GetUserInfoStatuss();

    UserInfoStatus GetUserInfoStatusById(int userInfoStatusID);

    bool InsertUserInfoStatus(UserInfoStatus userInfoStatus);

    bool UpdateUserInfoStatus(UserInfoStatus userInfoStatus);

    bool DeleteUserInfoStatus(int userInfoStatusID,UserInfoStatus userInfoStatus);

    Dictionary<string,string> UserInfoStatusIsValid(UserInfoStatus userInfoStatus);

    #endregion
    }
  

    }
  