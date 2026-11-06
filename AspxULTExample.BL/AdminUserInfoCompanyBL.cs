
    using System;
    using System.Collections.Generic;
    using AspxULTExample.Models;
    using AspxULTExample.Models.Interface;

    namespace AspxULTExample.BL
    {

    
    public partial class AdminUserInfoCompanyBL:IUserInfoCompanyBL
    {

    #region AdminUserInfoCompanyBL

    private readonly IUserInfoCompanyRepository _context;

    public AdminUserInfoCompanyBL(IUserInfoCompanyRepository context)
    {
    this._context = context;
    }

    public IEnumerable<UserInfoCompany>
    GetUserInfoCompanys()
    {
    return this._context.GetUserInfoCompanys();
    }

    public UserInfoCompany GetUserInfoCompanyById(int userInfoCompanyID)
    {
    return this._context.GetUserInfoCompanyById(userInfoCompanyID);
    }

    public bool InsertUserInfoCompany(UserInfoCompany userInfoCompany)
    {

    Dictionary<string, string> isVal = UserInfoCompanyIsValid(userInfoCompany);
    bool val = isVal.Count == 0;
    if(val)
    {
    this._context.InsertUserInfoCompany(userInfoCompany);
    }
    return val;
    }

    public bool UpdateUserInfoCompany(UserInfoCompany userInfoCompany)
    {
    Dictionary<string, string> isVal = UserInfoCompanyIsValid(userInfoCompany);
    bool val = isVal.Count == 0;

    if(val)
    {
    this._context.UpdateUserInfoCompany(userInfoCompany);
    }
    return val;
    }

    public bool DeleteUserInfoCompany(int userInfoCompanyID, UserInfoCompany userInfoCompany)
    {

    bool val = userInfoCompanyID != 0;

    if(val)
    {
    this._context.DeleteUserInfoCompany(userInfoCompanyID, userInfoCompany);
    }
    return val;
    }

    public Dictionary<string,string>UserInfoCompanyIsValid(UserInfoCompany userInfoCompany)
    {
    Dictionary<string,string> isVal = new Dictionary<string, string>();

    
    if (userInfoCompany != null){
    
    if (userInfoCompany.UserInfoCompanyID == 0)
    {
    isVal.Add("UserInfoCompanyID", "User Info Company ID cannot be zero.");
    }
  

    if (string.IsNullOrWhiteSpace(userInfoCompany.UserInfoCompanyEIN))
    {
    isVal.Add("UserInfoCompanyEIN", "User Info Company EIN cannot be null or empty or only have white space.");
    }
  

    if (string.IsNullOrWhiteSpace(userInfoCompany.UserInfoCompanyName))
    {
    isVal.Add("UserInfoCompanyName", "User Info Company Name cannot be null or empty or only have white space.");
    }
  

    if (string.IsNullOrWhiteSpace(userInfoCompany.UserInfoCompanyAddress1))
    {
    isVal.Add("UserInfoCompanyAddress1", "User Info Company Address1 cannot be null or empty or only have white space.");
    }
  

    if (string.IsNullOrWhiteSpace(userInfoCompany.UserInfoCompanyAddress2))
    {
    isVal.Add("UserInfoCompanyAddress2", "User Info Company Address2 cannot be null or empty or only have white space.");
    }
  

    if (string.IsNullOrWhiteSpace(userInfoCompany.UserInfoCompanyCityStateZip))
    {
    isVal.Add("UserInfoCompanyCityStateZip", "User Info Company City State Zip cannot be null or empty or only have white space.");
    }
  

    if (string.IsNullOrWhiteSpace(userInfoCompany.UserInfoCompanyTelephone))
    {
    isVal.Add("UserInfoCompanyTelephone", "User Info Company Telephone cannot be null or empty or only have white space.");
    }
  

    if (string.IsNullOrWhiteSpace(userInfoCompany.UserInfoCompanyEmailAddress))
    {
    isVal.Add("UserInfoCompanyEmailAddress", "User Info Company Email Address cannot be null or empty or only have white space.");
    }
  

    if (string.IsNullOrWhiteSpace(userInfoCompany.UserCompanyWebsiteAddress))
    {
    isVal.Add("UserCompanyWebsiteAddress", "User Company Website Address cannot be null or empty or only have white space.");
    }
  

    if (userInfoCompany.UserInfoCountriesID == 0)
    {
    isVal.Add("UserInfoCountriesID", "User Info Countries ID cannot be zero.");
    }
  


    } else
    {
    isVal.Add("userInfoCompany", "userInfoCompany cannot be null.");
    }
  

    return isVal;
    }

    #endregion

    }
  

    }
  