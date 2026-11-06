
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    namespace AspxULTExample.Models
    {
    public partial class ExampleApprove : BaseObject
    {
    #region Properties
    private int _exampleApproveID;
/// <summary>
///ExampleApproveID
/// </summary>
[ScaffoldColumn(false)]
[DisplayName("Example Approve ID")]

public int ExampleApproveID {
get {return _exampleApproveID;}
set{ _exampleApproveID = value;}
}

private int _exampleID;
/// <summary>
///ExampleID
/// </summary>
[Required(ErrorMessage = "This Example ID is required.")]
[DisplayName("Example ID")]
[Range(1, int.MaxValue, ErrorMessage="Example ID cannot be zero.")]
[DisplayFormat(DataFormatString = "{0:d}")]
public int ExampleID {
get {return _exampleID;}
set{ _exampleID = value;}
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


    #endregion

    #region Constants
    
    #endregion

    #region Instance Methods
    public ExampleApprove():base()
    {
    _exampleApproveID = 0;
_exampleID = 0;
_userInfoID = 0;
_userInfoJobTitle = string.Empty;

    }
    #endregion

    }
    }
  