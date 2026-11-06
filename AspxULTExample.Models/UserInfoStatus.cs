
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    namespace AspxULTExample.Models
    {
    public partial class UserInfoStatus : BaseObject
    {
    #region Properties
    private int _userInfoStatusID;
/// <summary>
///UserInfoStatusID
/// </summary>
[ScaffoldColumn(false)]
[DisplayName("User Info Status ID")]

public int UserInfoStatusID {
get {return _userInfoStatusID;}
set{ _userInfoStatusID = value;}
}

private string _userInfoStatusName;
/// <summary>
///UserInfoStatusName
/// </summary>
[Required(ErrorMessage = "This User Info Status Name is required.")]
[DisplayName("User Info Status Name")]
[DataType(DataType.Text)]
[StringLength(50, MinimumLength = 1, ErrorMessage="User Info Status Name cannot be null or empty or only have white space or 50 characters maximum.")]
public string UserInfoStatusName {
get {return _userInfoStatusName;}
set{ _userInfoStatusName = value;}
}

private bool _userInfoStatusActiveYesNo;
/// <summary>
///UserInfoStatusActiveYesNo
/// </summary>
[Required(ErrorMessage = "This User Info Status Active Yes No is required.")]
[DisplayName("User Info Status Active Yes No")]

public bool UserInfoStatusActiveYesNo {
get {return _userInfoStatusActiveYesNo;}
set{ _userInfoStatusActiveYesNo = value;}
}


    #endregion

    #region Constants
    
    #endregion

    #region Instance Methods
    public UserInfoStatus():base()
    {
    _userInfoStatusID = 0;
_userInfoStatusName = string.Empty;
_userInfoStatusActiveYesNo = false;

    }
    #endregion

    }
    }
  