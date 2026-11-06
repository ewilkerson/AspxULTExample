
    using System;
    using System.Collections.Generic;
    using AspxULTExample.Models;
    using AspxULTExample.Models.Interface;

    namespace AspxULTExample.BL
    {

    
    public partial class ViewExampleFileUpload2BL:IViewExampleFileUpload2BL
    {

    #region ViewExampleFileUpload2BL

    private readonly IViewExampleFileUpload2Repository _context;

    public ViewExampleFileUpload2BL(IViewExampleFileUpload2Repository context)
    {
    this._context = context;
    }

    public IEnumerable<ViewExampleFileUpload2>
    GetViewExampleFileUpload2s()
    {
    return this._context.GetViewExampleFileUpload2s();
    }

    public ViewExampleFileUpload2 GetViewExampleFileUpload2ById(int exampleFileUpload2ID)
    {
    return this._context.GetViewExampleFileUpload2ById(exampleFileUpload2ID);
    }

    public bool InsertViewExampleFileUpload2(ViewExampleFileUpload2 viewExampleFileUpload2)
    {

    Dictionary<string, string> isVal = ViewExampleFileUpload2IsValid(viewExampleFileUpload2);
    bool val = isVal.Count == 0;
    if(val)
    {
    this._context.InsertViewExampleFileUpload2(viewExampleFileUpload2);
    }
    return val;
    }

    public bool UpdateViewExampleFileUpload2(ViewExampleFileUpload2 viewExampleFileUpload2)
    {
    Dictionary<string, string> isVal = ViewExampleFileUpload2IsValid(viewExampleFileUpload2);
    bool val = isVal.Count == 0;

    if(val)
    {
    this._context.UpdateViewExampleFileUpload2(viewExampleFileUpload2);
    }
    return val;
    }

    public bool DeleteViewExampleFileUpload2(int exampleFileUpload2ID, ViewExampleFileUpload2 viewExampleFileUpload2)
    {

    bool val = exampleFileUpload2ID != 0;

    if(val)
    {
    this._context.DeleteViewExampleFileUpload2(exampleFileUpload2ID, viewExampleFileUpload2);
    }
    return val;
    }

    public Dictionary<string,string>ViewExampleFileUpload2IsValid(ViewExampleFileUpload2 viewExampleFileUpload2)
    {
    Dictionary<string,string> isVal = new Dictionary<string, string>();

    
    if (viewExampleFileUpload2 != null){
    
    if (viewExampleFileUpload2.ExampleFileUpload2ID == 0)
    {
    isVal.Add("ExampleFileUpload2ID", "Example File Upload2 ID cannot be zero.");
    }
  

    if (string.IsNullOrWhiteSpace(viewExampleFileUpload2.FileName))
    {
    isVal.Add("FileName", "File Name cannot be null or empty or only have white space.");
    }
  

    if (string.IsNullOrWhiteSpace(viewExampleFileUpload2.FileContentType))
    {
    isVal.Add("FileContentType", "File Content Type cannot be null or empty or only have white space.");
    }
  

    if (viewExampleFileUpload2.FileContentLength == 0)
    {
    isVal.Add("FileContentLength", "File Content Length cannot be zero.");
    }
  

    if (viewExampleFileUpload2.FileContentLengthKbMb == 0)
    {
    isVal.Add("FileContentLengthKbMb", "File Content Length Kb Mb cannot be zero.");
    }
  

    if (string.IsNullOrWhiteSpace(viewExampleFileUpload2.FileContentPath))
    {
    isVal.Add("FileContentPath", "File Content Path cannot be null or empty or only have white space.");
    }
  

    } else
    {
    isVal.Add("viewExampleFileUpload2", "viewExampleFileUpload2 cannot be null.");
    }
  

    return isVal;
    }

    #endregion

    }
  

    }
  