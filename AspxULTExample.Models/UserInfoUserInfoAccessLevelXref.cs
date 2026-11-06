
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    namespace AspxULTExample.Models
    {
    public partial class UserInfoUserInfoAccessLevelXref : BaseObject
    {
    #region Properties
    private int _userInfoUserInfoAccessLevelXrefID;
/// <summary>
///UserInfoUserInfoAccessLevelXrefID
/// </summary>
[ScaffoldColumn(false)]
[DisplayName("User Info User Info Access Level Xref ID")]

public int UserInfoUserInfoAccessLevelXrefID {
get {return _userInfoUserInfoAccessLevelXrefID;}
set{ _userInfoUserInfoAccessLevelXrefID = value;}
}

private int _userInfoID;
/// <summary>
///UserInfoID
/// </summary>
[Required(ErrorMessage = "This User Info ID is required.")]
[DisplayName("User Info ID")]
[Range(1, int.MaxValue, ErrorMessage="User Info ID cannot be zero.")]
[DisplayFormat(DataFormatString = "{0:d}")]
public int UserInfoID {
get {return _userInfoID;}
set{ _userInfoID = value;}
}

private int _userInfoAccessLevelID;
/// <summary>
///UserInfoAccessLevelID
/// </summary>
[Required(ErrorMessage = "This User Info Access Level ID is required.")]
[DisplayName("User Info Access Level ID")]
[Range(1, int.MaxValue, ErrorMessage="User Info Access Level ID cannot be zero.")]
[DisplayFormat(DataFormatString = "{0:d}")]
public int UserInfoAccessLevelID {
get {return _userInfoAccessLevelID;}
set{ _userInfoAccessLevelID = value;}
}

private bool _userInfoUserInfoAccessLevelXrefActiveYesNo;
/// <summary>
///UserInfoUserInfoAccessLevelXrefActiveYesNo
/// </summary>
[Required(ErrorMessage = "This User Info User Info Access Level Xref Active Yes No is required.")]
[DisplayName("User Info User Info Access Level Xref Active Yes No")]

public bool UserInfoUserInfoAccessLevelXrefActiveYesNo {
get {return _userInfoUserInfoAccessLevelXrefActiveYesNo;}
set{ _userInfoUserInfoAccessLevelXrefActiveYesNo = value;}
}


    #endregion

    #region Constants
    
    #endregion

    #region Instance Methods
    public UserInfoUserInfoAccessLevelXref():base()
    {
    _userInfoUserInfoAccessLevelXrefID = 0;
_userInfoID = 0;
_userInfoAccessLevelID = 0;
_userInfoUserInfoAccessLevelXrefActiveYesNo = false;

    }
    #endregion

    }
    }
  