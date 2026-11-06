
    using System;
    using System.Collections.Generic;

    namespace AspxULTExample.Models.Interface
    {

    
    public interface ILoadUserInfoBL
    {

    #region ILoadUserInfoBL

    IEnumerable<LoadUserInfo>GetLoadUserInfos();

    LoadUserInfo GetLoadUserInfoById(int userInfoID);

    bool InsertLoadUserInfo(LoadUserInfo loadUserInfo);

    bool UpdateLoadUserInfo(LoadUserInfo loadUserInfo);

    bool DeleteLoadUserInfo(int userInfoID,LoadUserInfo loadUserInfo);

    Dictionary<string,string> LoadUserInfoIsValid(LoadUserInfo loadUserInfo);

    #endregion
    }
  

    }
  