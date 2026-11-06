
    using System;
    using System.Collections.Generic;

    namespace AspxULTExample.Models.Interface
    {

    
    public interface IUserInfoCountriesRepository
    {

    #region IUserInfoCountriesRepository

    IEnumerable<UserInfoCountries>GetUserInfoCountriess();

    UserInfoCountries GetUserInfoCountriesById(int userInfoCountriesID);

    UserInfoCountries InsertUserInfoCountries(UserInfoCountries userInfoCountries);

    UserInfoCountries UpdateUserInfoCountries(UserInfoCountries userInfoCountries);

    UserInfoCountries DeleteUserInfoCountries(int userInfoCountriesID,UserInfoCountries userInfoCountries);

    #endregion
    }
  

    }
  