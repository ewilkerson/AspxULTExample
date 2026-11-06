
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    namespace AspxULTExample.Models
    {
    public partial class ViewExampleFileUpload2 : BaseObject
    {
    #region Properties
    private int _exampleFileUpload2ID;
/// <summary>
///ExampleFileUpload2ID
/// </summary>
[ScaffoldColumn(false)]
[DisplayName("Example File Upload2 ID")]

public int ExampleFileUpload2ID {
get {return _exampleFileUpload2ID;}
set{ _exampleFileUpload2ID = value;}
}

private string _fileName;
/// <summary>
///FileName
/// </summary>
[Required(ErrorMessage = "This File Name is required.")]
[DisplayName("File Name")]
[DataType(DataType.MultilineText)]
[StringLength(256, MinimumLength = 1, ErrorMessage="File Name cannot be null or empty or only have white space or 256 characters maximum.")]
public string FileName {
get {return _fileName;}
set{ _fileName = value;}
}

private string _fileContentType;
/// <summary>
///FileContentType
/// </summary>
[Required(ErrorMessage = "This File Content Type is required.")]
[DisplayName("File Content Type")]
[DataType(DataType.MultilineText)]
[StringLength(256, MinimumLength = 1, ErrorMessage="File Content Type cannot be null or empty or only have white space or 256 characters maximum.")]
public string FileContentType {
get {return _fileContentType;}
set{ _fileContentType = value;}
}

private long _fileContentLength;
/// <summary>
///FileContentLength
/// </summary>
[Required(ErrorMessage = "This File Content Length is required.")]
[DisplayName("File Content Length")]
[Range(1, int.MaxValue, ErrorMessage="File Content Length cannot be zero.")]
[DisplayFormat(DataFormatString = "{0:d}")]
public long FileContentLength {
get {return _fileContentLength;}
set{ _fileContentLength = value;}
}

private decimal _fileContentLengthKbMb;
/// <summary>
///FileContentLengthKbMb
/// </summary>
[Required(ErrorMessage = "This File Content Length Kb Mb is required.")]
[DisplayName("File Content Length Kb Mb")]
[Range(.01, double.MaxValue, ErrorMessage="File Content Length Kb Mb cannot be zero.")]
[DisplayFormat(DataFormatString = "{0:f}")]
public decimal FileContentLengthKbMb {
get {return _fileContentLengthKbMb;}
set{ _fileContentLengthKbMb = value;}
}

private string _fileContentPath;
/// <summary>
///FileContentPath
/// </summary>
[Required(ErrorMessage = "This File Content Path is required.")]
[DisplayName("File Content Path")]
[DataType(DataType.MultilineText)]
[StringLength(256, MinimumLength = 1, ErrorMessage="File Content Path cannot be null or empty or only have white space or 256 characters maximum.")]
public string FileContentPath {
get {return _fileContentPath;}
set{ _fileContentPath = value;}
}


    #endregion

    #region Constants
    
    #endregion

    #region Instance Methods
    public ViewExampleFileUpload2():base()
    {
    _exampleFileUpload2ID = 0;
_fileName = string.Empty;
_fileContentType = string.Empty;
_fileContentLength = 0;
_fileContentLengthKbMb = 0.0M;
_fileContentPath = string.Empty;

    }
    #endregion

    }
    }
  