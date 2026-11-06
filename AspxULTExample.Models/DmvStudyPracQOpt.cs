
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    namespace AspxULTExample.Models
    {
    public partial class DmvStudyPracQOpt : BaseObject
    {
    #region Properties
    private int _dmvStudyPracQOptID;
/// <summary>
///DmvStudyPracQOptID
/// </summary>
[ScaffoldColumn(false)]
[DisplayName("Dmv Study Prac Q Opt ID")]

public int DmvStudyPracQOptID {
get {return _dmvStudyPracQOptID;}
set{ _dmvStudyPracQOptID = value;}
}

private int _dmvStudyPracQuestionID;
/// <summary>
///DmvStudyPracQuestionID
/// </summary>
[Required(ErrorMessage = "This Dmv Study Prac Question ID is required.")]
[DisplayName("Dmv Study Prac Question ID")]
[Range(1, int.MaxValue, ErrorMessage="Dmv Study Prac Question ID cannot be zero.")]
[DisplayFormat(DataFormatString = "{0:d}")]
public int DmvStudyPracQuestionID {
get {return _dmvStudyPracQuestionID;}
set{ _dmvStudyPracQuestionID = value;}
}

private string _dmvStudyPracQOptText;
/// <summary>
///DmvStudyPracQOptText
/// </summary>
[Required(ErrorMessage = "This Dmv Study Prac Q Opt Text is required.")]
[DisplayName("Dmv Study Prac Q Opt Text")]
[DataType(DataType.MultilineText)]
[StringLength(100, MinimumLength = 1, ErrorMessage="Dmv Study Prac Q Opt Text cannot be null or empty or only have white space or 100 characters maximum.")]
public string DmvStudyPracQOptText {
get {return _dmvStudyPracQOptText;}
set{ _dmvStudyPracQOptText = value;}
}

private bool _dmvStudyPracQOptAnswerYesNo;
/// <summary>
///DmvStudyPracQOptAnswerYesNo
/// </summary>
[Required(ErrorMessage = "This Dmv Study Prac Q Opt Answer Yes No is required.")]
[DisplayName("Dmv Study Prac Q Opt Answer Yes No")]

public bool DmvStudyPracQOptAnswerYesNo {
get {return _dmvStudyPracQOptAnswerYesNo;}
set{ _dmvStudyPracQOptAnswerYesNo = value;}
}

private bool _dmvStudyPracQOptActiveYesNo;
/// <summary>
///DmvStudyPracQOptActiveYesNo
/// </summary>
[Required(ErrorMessage = "This Dmv Study Prac Q Opt Active Yes No is required.")]
[DisplayName("Dmv Study Prac Q Opt Active Yes No")]

public bool DmvStudyPracQOptActiveYesNo {
get {return _dmvStudyPracQOptActiveYesNo;}
set{ _dmvStudyPracQOptActiveYesNo = value;}
}


    #endregion

    #region Constants
    
    #endregion

    #region Instance Methods
    public DmvStudyPracQOpt():base()
    {
    _dmvStudyPracQOptID = 0;
_dmvStudyPracQuestionID = 0;
_dmvStudyPracQOptText = string.Empty;
_dmvStudyPracQOptAnswerYesNo = false;
_dmvStudyPracQOptActiveYesNo = false;

    }
    #endregion

    }
    }
  