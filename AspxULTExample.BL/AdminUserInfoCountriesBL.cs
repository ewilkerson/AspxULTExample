
    using System;
    using System.Collections.Generic;
    using AspxULTExample.Models;
    using AspxULTExample.Models.Interface;

    namespace AspxULTExample.BL
    {

    
    public partial class AdminUserInfoCountriesBL:IUserInfoCountriesBL
    {

    #region AdminUserInfoCountriesBL

    private readonly IUserInfoCountriesRepository _context;

    public AdminUserInfoCountriesBL(IUserInfoCountriesRepository context)
    {
    this._context = context;
    }

    public IEnumerable<UserInfoCountries>
    GetUserInfoCountriess()
    {
    return this._context.GetUserInfoCountriess();
    }

    public UserInfoCountries GetUserInfoCountriesById(int userInfoCountriesID)
    {
    return this._context.GetUserInfoCountriesById(userInfoCountriesID);
    }

    public bool InsertUserInfoCountries(UserInfoCountries userInfoCountries)
    {

    Dictionary<string, string> isVal = UserInfoCountriesIsValid(userInfoCountries);
    bool val = isVal.Count == 0;
    if(val)
    {
    this._context.InsertUserInfoCountries(userInfoCountries);
    }
    return val;
    }

    public bool UpdateUserInfoCountries(UserInfoCountries userInfoCountries)
    {
    Dictionary<string, string> isVal = UserInfoCountriesIsValid(userInfoCountries);
    bool val = isVal.Count == 0;

    if(val)
    {
    this._context.UpdateUserInfoCountries(userInfoCountries);
    }
    return val;
    }

    public bool DeleteUserInfoCountries(int userInfoCountriesID, UserInfoCountries userInfoCountries)
    {

    bool val = userInfoCountriesID != 0;

    if(val)
    {
    this._context.DeleteUserInfoCountries(userInfoCountriesID, userInfoCountries);
    }
    return val;
    }

    public Dictionary<string,string>UserInfoCountriesIsValid(UserInfoCountries userInfoCountries)
    {
    Dictionary<string,string> isVal = new Dictionary<string, string>();

    
    if (userInfoCountries != null){
    
    if (userInfoCountries.UserInfoCountriesID == 0)
    {
    isVal.Add("UserInfoCountriesID", "User Info Countries ID cannot be zero.");
    }
  

    if (string.IsNullOrWhiteSpace(userInfoCountries.UserInfoCountriesName))
    {
    isVal.Add("UserInfoCountriesName", "User Info Countries Name cannot be null or empty or only have white space.");
    }
  


    } else
    {
    isVal.Add("userInfoCountries", "userInfoCountries cannot be null.");
    }
  

    return isVal;
    }

    #endregion

    }
  

    }
  