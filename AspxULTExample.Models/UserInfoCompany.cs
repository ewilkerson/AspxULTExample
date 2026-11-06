
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    namespace AspxULTExample.Models
    {
    public partial class UserInfoCompany : BaseObject
    {
    #region Properties
    private int _userInfoCompanyID;
/// <summary>
///UserInfoCompanyID
/// </summary>
[ScaffoldColumn(false)]
[DisplayName("User Info Company ID")]

public int UserInfoCompanyID {
get {return _userInfoCompanyID;}
set{ _userInfoCompanyID = value;}
}

private string _userInfoCompanyEIN;
/// <summary>
///UserInfoCompanyEIN
/// </summary>
[Required(ErrorMessage = "This User Info Company EIN is required.")]
[DisplayName("User Info Company EIN")]
[DataType(DataType.Text)]
[StringLength(50, MinimumLength = 1, ErrorMessage="User Info Company EIN cannot be null or empty or only have white space or 50 characters maximum.")]
public string UserInfoCompanyEIN {
get {return _userInfoCompanyEIN;}
set{ _userInfoCompanyEIN = value;}
}

private string _userInfoCompanyName;
/// <summary>
///UserInfoCompanyName
/// </summary>
[Required(ErrorMessage = "This User Info Company Name is required.")]
[DisplayName("User Info Company Name")]
[DataType(DataType.MultilineText)]
[StringLength(200, MinimumLength = 1, ErrorMessage="User Info Company Name cannot be null or empty or only have white space or 200 characters maximum.")]
public string UserInfoCompanyName {
get {return _userInfoCompanyName;}
set{ _userInfoCompanyName = value;}
}

private string _userInfoCompanyAddress1;
/// <summary>
///UserInfoCompanyAddress1
/// </summary>
[Required(ErrorMessage = "This User Info Company Address1 is required.")]
[DisplayName("User Info Company Address1")]
[DataType(DataType.Text)]
[StringLength(60, MinimumLength = 1, ErrorMessage="User Info Company Address1 cannot be null or empty or only have white space or 60 characters maximum.")]
public string UserInfoCompanyAddress1 {
get {return _userInfoCompanyAddress1;}
set{ _userInfoCompanyAddress1 = value;}
}

private string _userInfoCompanyAddress2;
/// <summary>
///UserInfoCompanyAddress2
/// </summary>
[Required(ErrorMessage = "This User Info Company Address2 is required.")]
[DisplayName("User Info Company Address2")]
[DataType(DataType.Text)]
[StringLength(60, MinimumLength = 1, ErrorMessage="User Info Company Address2 cannot be null or empty or only have white space or 60 characters maximum.")]
public string UserInfoCompanyAddress2 {
get {return _userInfoCompanyAddress2;}
set{ _userInfoCompanyAddress2 = value;}
}

private string _userInfoCompanyCityStateZip;
/// <summary>
///UserInfoCompanyCityStateZip
/// </summary>
[Required(ErrorMessage = "This User Info Company City State Zip is required.")]
[DisplayName("User Info Company City State Zip")]
[DataType(DataType.Text)]
[StringLength(60, MinimumLength = 1, ErrorMessage="User Info Company City State Zip cannot be null or empty or only have white space or 60 characters maximum.")]
public string UserInfoCompanyCityStateZip {
get {return _userInfoCompanyCityStateZip;}
set{ _userInfoCompanyCityStateZip = value;}
}

private string _userInfoCompanyTelephone;
/// <summary>
///UserInfoCompanyTelephone
/// </summary>
[Required(ErrorMessage = "This User Info Company Telephone is required.")]
[DisplayName("User Info Company Telephone")]
[DataType(DataType.Text)]
[StringLength(50, MinimumLength = 1, ErrorMessage="User Info Company Telephone cannot be null or empty or only have white space or 50 characters maximum.")]
public string UserInfoCompanyTelephone {
get {return _userInfoCompanyTelephone;}
set{ _userInfoCompanyTelephone = value;}
}

private string _userInfoCompanyEmailAddress;
/// <summary>
///UserInfoCompanyEmailAddress
/// </summary>
[Required(ErrorMessage = "This User Info Company Email Address is required.")]
[DisplayName("User Info Company Email Address")]
[DataType(DataType.EmailAddress)]
[EmailAddress]
[RegularExpression(@"^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{{|}}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$", ErrorMessage="User Info Company Email Address cannot be 50 characters maximum.")]
[StringLength(50, MinimumLength = 1, ErrorMessage="User Info Company Email Address cannot be null or empty or only have white space or 50 characters maximum.")]
public string UserInfoCompanyEmailAddress {
get {return _userInfoCompanyEmailAddress;}
set{ _userInfoCompanyEmailAddress = value;}
}

private string _userCompanyWebsiteAddress;
/// <summary>
///UserCompanyWebsiteAddress
/// </summary>
[Required(ErrorMessage = "This User Company Website Address is required.")]
[DisplayName("User Company Website Address")]
[DataType(DataType.Url)]
[Url]
[RegularExpression(@"^(http|ftp|https)://[\w-]+(\.[\w-]+)+([\w.,@?^=%&:/~+#-]*[\w@?^=%&/~+#-])?$", ErrorMessage="User Company Website Address cannot be 50 characters maximum.")]
[StringLength(50, MinimumLength = 1, ErrorMessage="User Company Website Address cannot be null or empty or only have white space or 50 characters maximum.")]
public string UserCompanyWebsiteAddress {
get {return _userCompanyWebsiteAddress;}
set{ _userCompanyWebsiteAddress = value;}
}

private int _userInfoCountriesID;
/// <summary>
///UserInfoCountriesID
/// </summary>
[Required(ErrorMessage = "This User Info Countries ID is required.")]
[DisplayName("User Info Countries ID")]
[Range(0, int.MaxValue, ErrorMessage="User Info Countries ID cannot be negative.")]
[DisplayFormat(DataFormatString = "{0:d}")]
public int UserInfoCountriesID {
get {return _userInfoCountriesID;}
set{ _userInfoCountriesID = value;}
}

private bool _userInfoCompanyActiveYesNo;
/// <summary>
///UserInfoCompanyActiveYesNo
/// </summary>
[Required(ErrorMessage = "This User Info Company Active Yes No is required.")]
[DisplayName("User Info Company Active Yes No")]

public bool UserInfoCompanyActiveYesNo {
get {return _userInfoCompanyActiveYesNo;}
set{ _userInfoCompanyActiveYesNo = value;}
}


    #endregion

    #region Constants
    
    #endregion

    #region Instance Methods
    public UserInfoCompany():base()
    {
    _userInfoCompanyID = 0;
_userInfoCompanyEIN = string.Empty;
_userInfoCompanyName = string.Empty;
_userInfoCompanyAddress1 = string.Empty;
_userInfoCompanyAddress2 = string.Empty;
_userInfoCompanyCityStateZip = string.Empty;
_userInfoCompanyTelephone = string.Empty;
_userInfoCompanyEmailAddress = string.Empty;
_userCompanyWebsiteAddress = string.Empty;
_userInfoCountriesID = 0;
_userInfoCompanyActiveYesNo = false;

    }
    #endregion

    }
    }
  