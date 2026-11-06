
    using System;
    using System.Collections.Generic;

    namespace AspxULTExample.Models.Interface
    {

    
    public interface IUserInfoCountriesBL
    {

    #region IUserInfoCountriesBL

    IEnumerable<UserInfoCountries>GetUserInfoCountriess();

    UserInfoCountries GetUserInfoCountriesById(int userInfoCountriesID);

    bool InsertUserInfoCountries(UserInfoCountries userInfoCountries);

    bool UpdateUserInfoCountries(UserInfoCountries userInfoCountries);

    bool DeleteUserInfoCountries(int userInfoCountriesID,UserInfoCountries userInfoCountries);

    Dictionary<string,string> UserInfoCountriesIsValid(UserInfoCountries userInfoCountries);

    #endregion
    }
  

    }
  