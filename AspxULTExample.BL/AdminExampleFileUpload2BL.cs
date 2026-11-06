
    using System;
    using System.Collections.Generic;
    using AspxULTExample.Models;
    using AspxULTExample.Models.Interface;

    namespace AspxULTExample.BL
    {

    
    public partial class AdminExampleFileUpload2BL:IExampleFileUpload2BL
    {

    #region AdminExampleFileUpload2BL

    private readonly IExampleFileUpload2Repository _context;

    public AdminExampleFileUpload2BL(IExampleFileUpload2Repository context)
    {
    this._context = context;
    }

    public IEnumerable<ExampleFileUpload2>
    GetExampleFileUpload2s()
    {
    return this._context.GetExampleFileUpload2s();
    }

    public ExampleFileUpload2 GetExampleFileUpload2ById(int exampleFileUpload2ID)
    {
    return this._context.GetExampleFileUpload2ById(exampleFileUpload2ID);
    }

    public bool InsertExampleFileUpload2(ExampleFileUpload2 exampleFileUpload2)
    {

    Dictionary<string, string> isVal = ExampleFileUpload2IsValid(exampleFileUpload2);
    bool val = isVal.Count == 0;
    if(val)
    {
    this._context.InsertExampleFileUpload2(exampleFileUpload2);
    }
    return val;
    }

    public bool UpdateExampleFileUpload2(ExampleFileUpload2 exampleFileUpload2)
    {
    Dictionary<string, string> isVal = ExampleFileUpload2IsValid(exampleFileUpload2);
    bool val = isVal.Count == 0;

    if(val)
    {
    this._context.UpdateExampleFileUpload2(exampleFileUpload2);
    }
    return val;
    }

    public bool DeleteExampleFileUpload2(int exampleFileUpload2ID, ExampleFileUpload2 exampleFileUpload2)
    {

    bool val = exampleFileUpload2ID != 0;

    if(val)
    {
    this._context.DeleteExampleFileUpload2(exampleFileUpload2ID, exampleFileUpload2);
    }
    return val;
    }

    public Dictionary<string,string>ExampleFileUpload2IsValid(ExampleFileUpload2 exampleFileUpload2)
    {
    Dictionary<string,string> isVal = new Dictionary<string, string>();

    
    if (exampleFileUpload2 != null){
    
    if (exampleFileUpload2.ExampleFileUpload2ID == 0)
    {
    isVal.Add("ExampleFileUpload2ID", "Example File Upload2 ID cannot be zero.");
    }
  

    if (string.IsNullOrWhiteSpace(exampleFileUpload2.FileName))
    {
    isVal.Add("FileName", "File Name cannot be null or empty or only have white space.");
    }
  

    if (string.IsNullOrWhiteSpace(exampleFileUpload2.FileContentType))
    {
    isVal.Add("FileContentType", "File Content Type cannot be null or empty or only have white space.");
    }
  

    if (exampleFileUpload2.FileContentLength == 0)
    {
    isVal.Add("FileContentLength", "File Content Length cannot be zero.");
    }
  

    if (exampleFileUpload2.FileContentLengthKbMb == 0)
    {
    isVal.Add("FileContentLengthKbMb", "File Content Length Kb Mb cannot be zero.");
    }
  

    if (string.IsNullOrWhiteSpace(exampleFileUpload2.FileContentPath))
    {
    isVal.Add("FileContentPath", "File Content Path cannot be null or empty or only have white space.");
    }
  

    } else
    {
    isVal.Add("exampleFileUpload2", "exampleFileUpload2 cannot be null.");
    }
  

    return isVal;
    }

    #endregion

    }
  

    }
  