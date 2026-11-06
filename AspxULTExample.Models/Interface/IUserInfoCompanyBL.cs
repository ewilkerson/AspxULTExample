
    using System;
    using System.Collections.Generic;

    namespace AspxULTExample.Models.Interface
    {

    
    public interface IUserInfoCompanyBL
    {

    #region IUserInfoCompanyBL

    IEnumerable<UserInfoCompany>GetUserInfoCompanys();

    UserInfoCompany GetUserInfoCompanyById(int userInfoCompanyID);

    bool InsertUserInfoCompany(UserInfoCompany userInfoCompany);

    bool UpdateUserInfoCompany(UserInfoCompany userInfoCompany);

    bool DeleteUserInfoCompany(int userInfoCompanyID,UserInfoCompany userInfoCompany);

    Dictionary<string,string> UserInfoCompanyIsValid(UserInfoCompany userInfoCompany);

    #endregion
    }
  

    }
  