
    using System;
    using System.Collections.Generic;

    namespace AspxULTExample.Models.Interface
    {

    
    public interface ILoadUserInfoRepository
    {

    #region ILoadUserInfoRepository

    IEnumerable<LoadUserInfo>GetLoadUserInfos();

    LoadUserInfo GetLoadUserInfoById(int userInfoID);

    LoadUserInfo InsertLoadUserInfo(LoadUserInfo loadUserInfo);

    LoadUserInfo UpdateLoadUserInfo(LoadUserInfo loadUserInfo);

    LoadUserInfo DeleteLoadUserInfo(int userInfoID,LoadUserInfo loadUserInfo);

    #endregion
    }
  

    }
  