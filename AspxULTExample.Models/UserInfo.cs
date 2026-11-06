
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    namespace AspxULTExample.Models
    {
    public partial class UserInfo : BaseObject
    {
    #region Properties
    private int _userInfoID;
/// <summary>
///UserInfoID
/// </summary>
[ScaffoldColumn(false)]
[DisplayName("User Info ID")]

public int UserInfoID {
get {return _userInfoID;}
set{ _userInfoID = value;}
}

private string _userInfoUserIdentityName;
/// <summary>
///UserInfoUserIdentityName
/// </summary>
[Required(ErrorMessage = "This User Info User Identity Name is required.")]
[DisplayName("User Info User Identity Name")]
[DataType(DataType.Text)]
[StringLength(50, MinimumLength = 1, ErrorMessage="User Info User Identity Name cannot be null or empty or only have white space or 50 characters maximum.")]
public string UserInfoUserIdentityName {
get {return _userInfoUserIdentityName;}
set{ _userInfoUserIdentityName = value;}
}

private string _userInfoUserName;
/// <summary>
///UserInfoUserName
/// </summary>
[Required(ErrorMessage = "This User Info User Name is required.")]
[DisplayName("User Info User Name")]
[DataType(DataType.Text)]
[StringLength(50, MinimumLength = 1, ErrorMessage="User Info User Name cannot be null or empty or only have white space or 50 characters maximum.")]
public string UserInfoUserName {
get {return _userInfoUserName;}
set{ _userInfoUserName = value;}
}

private string _userInfoFullName;
/// <summary>
///UserInfoFullName
/// </summary>
[Required(ErrorMessage = "This User Info Full Name is required.")]
[DisplayName("User Info Full Name")]
[DataType(DataType.Text)]
[StringLength(50, MinimumLength = 1, ErrorMessage="User Info Full Name cannot be null or empty or only have white space or 50 characters maximum.")]
public string UserInfoFullName {
get {return _userInfoFullName;}
set{ _userInfoFullName = value;}
}

private string _userInfoEmailAddress;
/// <summary>
///UserInfoEmailAddress
/// </summary>
[Required(ErrorMessage = "This User Info Email Address is required.")]
[DisplayName("User Info Email Address")]
[DataType(DataType.EmailAddress)]
[EmailAddress]
[RegularExpression(@"^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{{|}}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$", ErrorMessage="User Info Email Address cannot be 50 characters maximum.")]
[StringLength(50, MinimumLength = 1, ErrorMessage="User Info Email Address cannot be null or empty or only have white space or 50 characters maximum.")]
public string UserInfoEmailAddress {
get {return _userInfoEmailAddress;}
set{ _userInfoEmailAddress = value;}
}

private string _userInfoJobTitle;
/// <summary>
///UserInfoJobTitle
/// </summary>
[Required(ErrorMessage = "This User Info Job Title is required.")]
[DisplayName("User Info Job Title")]
[DataType(DataType.Text)]
[StringLength(50, MinimumLength = 1, ErrorMessage="User Info Job Title cannot be null or empty or only have white space or 50 characters maximum.")]
public string UserInfoJobTitle {
get {return _userInfoJobTitle;}
set{ _userInfoJobTitle = value;}
}

private bool _userInfoActiveYesNo;
/// <summary>
///UserInfoActiveYesNo
/// </summary>
[Required(ErrorMessage = "This User Info Active Yes No is required.")]
[DisplayName("User Info Active Yes No")]

public bool UserInfoActiveYesNo {
get {return _userInfoActiveYesNo;}
set{ _userInfoActiveYesNo = value;}
}


    #endregion

    #region Constants
    
    #endregion

    #region Instance Methods
    public UserInfo():base()
    {
    _userInfoID = 0;
_userInfoUserIdentityName = string.Empty;
_userInfoUserName = string.Empty;
_userInfoFullName = string.Empty;
_userInfoEmailAddress = string.Empty;
_userInfoJobTitle = string.Empty;
_userInfoActiveYesNo = false;

    }
    #endregion

    }
    }
  