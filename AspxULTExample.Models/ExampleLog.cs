
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    namespace AspxULTExample.Models
    {
    public partial class ExampleLog : BaseObject
    {
    #region Properties
    private int _exampleLogID;
/// <summary>
///ExampleLogID
/// </summary>
[ScaffoldColumn(false)]
[DisplayName("Example Log ID")]

public int ExampleLogID {
get {return _exampleLogID;}
set{ _exampleLogID = value;}
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

private string _logMessage;
/// <summary>
///LogMessage
/// </summary>
[Required(ErrorMessage = "This Log Message is required.")]
[DisplayName("Log Message")]
[DataType(DataType.MultilineText)]
[StringLength(2000, MinimumLength = 1, ErrorMessage="Log Message cannot be null or empty or only have white space or 2000 characters maximum.")]
public string LogMessage {
get {return _logMessage;}
set{ _logMessage = value;}
}


    #endregion

    #region Constants
    
    #endregion

    #region Instance Methods
    public ExampleLog():base()
    {
    _exampleLogID = 0;
_exampleID = 0;
_logMessage = string.Empty;

    }
    #endregion

    }
    }
  