
    using System;
    using System.Collections.Generic;
    using AspxULTExample.Models;
    using AspxULTExample.Models.Interface;

    namespace AspxULTExample.BL
    {

    
    public partial class AdminExampleLogBL:IExampleLogBL
    {

    #region AdminExampleLogBL

    private readonly IExampleLogRepository _context;

    public AdminExampleLogBL(IExampleLogRepository context)
    {
    this._context = context;
    }

    public IEnumerable<ExampleLog>
    GetExampleLogs()
    {
    return this._context.GetExampleLogs();
    }

    public ExampleLog GetExampleLogById(int exampleLogID)
    {
    return this._context.GetExampleLogById(exampleLogID);
    }

    public bool InsertExampleLog(ExampleLog exampleLog)
    {

    Dictionary<string, string> isVal = ExampleLogIsValid(exampleLog);
    bool val = isVal.Count == 0;
    if(val)
    {
    this._context.InsertExampleLog(exampleLog);
    }
    return val;
    }

    public bool UpdateExampleLog(ExampleLog exampleLog)
    {
    Dictionary<string, string> isVal = ExampleLogIsValid(exampleLog);
    bool val = isVal.Count == 0;

    if(val)
    {
    this._context.UpdateExampleLog(exampleLog);
    }
    return val;
    }

    public bool DeleteExampleLog(int exampleLogID, ExampleLog exampleLog)
    {

    bool val = exampleLogID != 0;

    if(val)
    {
    this._context.DeleteExampleLog(exampleLogID, exampleLog);
    }
    return val;
    }

    public Dictionary<string,string>ExampleLogIsValid(ExampleLog exampleLog)
    {
    Dictionary<string,string> isVal = new Dictionary<string, string>();

    
    if (exampleLog != null){
    
    if (exampleLog.ExampleLogID == 0)
    {
    isVal.Add("ExampleLogID", "Example Log ID cannot be zero.");
    }
  

    if (exampleLog.ExampleID == 0)
    {
    isVal.Add("ExampleID", "Example ID cannot be zero.");
    }
  

    if (string.IsNullOrWhiteSpace(exampleLog.LogMessage))
    {
    isVal.Add("LogMessage", "Log Message cannot be null or empty or only have white space.");
    }
  

    } else
    {
    isVal.Add("exampleLog", "exampleLog cannot be null.");
    }
  

    return isVal;
    }

    #endregion

    }
  

    }
  