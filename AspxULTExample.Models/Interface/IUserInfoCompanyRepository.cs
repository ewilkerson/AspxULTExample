
    using System;
    using System.Collections.Generic;

    namespace AspxULTExample.Models.Interface
    {

    
    public interface IUserInfoCompanyRepository
    {

    #region IUserInfoCompanyRepository

    IEnumerable<UserInfoCompany>GetUserInfoCompanys();

    UserInfoCompany GetUserInfoCompanyById(int userInfoCompanyID);

    UserInfoCompany InsertUserInfoCompany(UserInfoCompany userInfoCompany);

    UserInfoCompany UpdateUserInfoCompany(UserInfoCompany userInfoCompany);

    UserInfoCompany DeleteUserInfoCompany(int userInfoCompanyID,UserInfoCompany userInfoCompany);

    #endregion
    }
  

    }
  