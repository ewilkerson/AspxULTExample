
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    namespace AspxULTExample.Models
    {
    public partial class DmvStudyPract : BaseObject
    {
    #region Properties
    private int _dmvStudyPractID;
/// <summary>
///DmvStudyPractID
/// </summary>
[ScaffoldColumn(false)]
[DisplayName("Dmv Study Pract ID")]

public int DmvStudyPractID {
get {return _dmvStudyPractID;}
set{ _dmvStudyPractID = value;}
}

private int _dmvStudyPractNum;
/// <summary>
///DmvStudyPractNum
/// </summary>
[Required(ErrorMessage = "This Dmv Study Pract Num is required.")]
[DisplayName("Dmv Study Pract Num")]
[Range(1, int.MaxValue, ErrorMessage="Dmv Study Pract Num cannot be zero.")]
[DisplayFormat(DataFormatString = "{0:d}")]
public int DmvStudyPractNum {
get {return _dmvStudyPractNum;}
set{ _dmvStudyPractNum = value;}
}

private string _dmvStudyPractTitle;
/// <summary>
///DmvStudyPractTitle
/// </summary>
[Required(ErrorMessage = "This Dmv Study Pract Title is required.")]
[DisplayName("Dmv Study Pract Title")]
[DataType(DataType.Text)]
[StringLength(50, MinimumLength = 1, ErrorMessage="Dmv Study Pract Title cannot be null or empty or only have white space or 50 characters maximum.")]
public string DmvStudyPractTitle {
get {return _dmvStudyPractTitle;}
set{ _dmvStudyPractTitle = value;}
}

private bool _dmvStudyPractActiveYesNo;
/// <summary>
///DmvStudyPractActiveYesNo
/// </summary>
[Required(ErrorMessage = "This Dmv Study Pract Active Yes No is required.")]
[DisplayName("Dmv Study Pract Active Yes No")]

public bool DmvStudyPractActiveYesNo {
get {return _dmvStudyPractActiveYesNo;}
set{ _dmvStudyPractActiveYesNo = value;}
}


    #endregion

    #region Constants
    
    #endregion

    #region Instance Methods
    public DmvStudyPract():base()
    {
    _dmvStudyPractID = 0;
_dmvStudyPractNum = 0;
_dmvStudyPractTitle = string.Empty;
_dmvStudyPractActiveYesNo = false;

    }
    #endregion

    }
    }
  