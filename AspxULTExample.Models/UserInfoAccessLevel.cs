
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    namespace AspxULTExample.Models
    {
    public partial class UserInfoAccessLevel : BaseObject
    {
    #region Properties
    private int _userInfoAccessLevelID;
/// <summary>
///UserInfoAccessLevelID
/// </summary>
[ScaffoldColumn(false)]
[DisplayName("User Info Access Level ID")]

public int UserInfoAccessLevelID {
get {return _userInfoAccessLevelID;}
set{ _userInfoAccessLevelID = value;}
}

private string _userInfoAccessLevelName;
/// <summary>
///UserInfoAccessLevelName
/// </summary>
[Required(ErrorMessage = "This User Info Access Level Name is required.")]
[DisplayName("User Info Access Level Name")]
[DataType(DataType.Text)]
[StringLength(50, MinimumLength = 1, ErrorMessage="User Info Access Level Name cannot be null or empty or only have white space or 50 characters maximum.")]
public string UserInfoAccessLevelName {
get {return _userInfoAccessLevelName;}
set{ _userInfoAccessLevelName = value;}
}

private int _userInfoAccessLevelNum;
/// <summary>
///UserInfoAccessLevelNum
/// </summary>
[Required(ErrorMessage = "This User Info Access Level Num is required.")]
[DisplayName("User Info Access Level Num")]
[Range(1, int.MaxValue, ErrorMessage="User Info Access Level Num cannot be zero.")]
[DisplayFormat(DataFormatString = "{0:d}")]
public int UserInfoAccessLevelNum {
get {return _userInfoAccessLevelNum;}
set{ _userInfoAccessLevelNum = value;}
}

private bool _userInfoAccessLevelActiveYesNo;
/// <summary>
///UserInfoAccessLevelActiveYesNo
/// </summary>
[Required(ErrorMessage = "This User Info Access Level Active Yes No is required.")]
[DisplayName("User Info Access Level Active Yes No")]

public bool UserInfoAccessLevelActiveYesNo {
get {return _userInfoAccessLevelActiveYesNo;}
set{ _userInfoAccessLevelActiveYesNo = value;}
}


    #endregion

    #region Constants
    
    #endregion

    #region Instance Methods
    public UserInfoAccessLevel():base()
    {
    _userInfoAccessLevelID = 0;
_userInfoAccessLevelName = string.Empty;
_userInfoAccessLevelNum = 0;
_userInfoAccessLevelActiveYesNo = false;

    }
    #endregion

    }
    }
  