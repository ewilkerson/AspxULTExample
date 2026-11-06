
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    namespace AspxULTExample.Models
    {
    public partial class UserInfoCountries : BaseObject
    {
    #region Properties
    private int _userInfoCountriesID;
/// <summary>
///UserInfoCountriesID
/// </summary>
[ScaffoldColumn(false)]
[DisplayName("User Info Countries ID")]

public int UserInfoCountriesID {
get {return _userInfoCountriesID;}
set{ _userInfoCountriesID = value;}
}

private string _userInfoCountriesName;
/// <summary>
///UserInfoCountriesName
/// </summary>
[Required(ErrorMessage = "This User Info Countries Name is required.")]
[DisplayName("User Info Countries Name")]
[DataType(DataType.Text)]
[StringLength(50, MinimumLength = 1, ErrorMessage="User Info Countries Name cannot be null or empty or only have white space or 50 characters maximum.")]
public string UserInfoCountriesName {
get {return _userInfoCountriesName;}
set{ _userInfoCountriesName = value;}
}

private bool _userInfoCountriesActiveYesNo;
/// <summary>
///UserInfoCountriesActiveYesNo
/// </summary>
[Required(ErrorMessage = "This User Info Countries Active Yes No is required.")]
[DisplayName("User Info Countries Active Yes No")]

public bool UserInfoCountriesActiveYesNo {
get {return _userInfoCountriesActiveYesNo;}
set{ _userInfoCountriesActiveYesNo = value;}
}


    #endregion

    #region Constants
    
    #endregion

    #region Instance Methods
    public UserInfoCountries():base()
    {
    _userInfoCountriesID = 0;
_userInfoCountriesName = string.Empty;
_userInfoCountriesActiveYesNo = false;

    }
    #endregion

    }
    }
  