
    using System;
    using System.Collections.Generic;
    using AspxULTExample.Models;
    using AspxULTExample.Models.Interface;

    namespace AspxULTExample.BL
    {

    
    public partial class AdminExampleApproveBL:IExampleApproveBL
    {

    #region AdminExampleApproveBL

    private readonly IExampleApproveRepository _context;

    public AdminExampleApproveBL(IExampleApproveRepository context)
    {
    this._context = context;
    }

    public IEnumerable<ExampleApprove>
    GetExampleApproves()
    {
    return this._context.GetExampleApproves();
    }

    public ExampleApprove GetExampleApproveById(int exampleApproveID)
    {
    return this._context.GetExampleApproveById(exampleApproveID);
    }

    public bool InsertExampleApprove(ExampleApprove exampleApprove)
    {

    Dictionary<string, string> isVal = ExampleApproveIsValid(exampleApprove);
    bool val = isVal.Count == 0;
    if(val)
    {
    this._context.InsertExampleApprove(exampleApprove);
    }
    return val;
    }

    public bool UpdateExampleApprove(ExampleApprove exampleApprove)
    {
    Dictionary<string, string> isVal = ExampleApproveIsValid(exampleApprove);
    bool val = isVal.Count == 0;

    if(val)
    {
    this._context.UpdateExampleApprove(exampleApprove);
    }
    return val;
    }

    public bool DeleteExampleApprove(int exampleApproveID, ExampleApprove exampleApprove)
    {

    bool val = exampleApproveID != 0;

    if(val)
    {
    this._context.DeleteExampleApprove(exampleApproveID, exampleApprove);
    }
    return val;
    }

    public Dictionary<string,string>ExampleApproveIsValid(ExampleApprove exampleApprove)
    {
    Dictionary<string,string> isVal = new Dictionary<string, string>();

    
    if (exampleApprove != null){
    
    if (exampleApprove.ExampleApproveID == 0)
    {
    isVal.Add("ExampleApproveID", "Example Approve ID cannot be zero.");
    }
  

    if (exampleApprove.ExampleID == 0)
    {
    isVal.Add("ExampleID", "Example ID cannot be zero.");
    }
  

    if (exampleApprove.UserInfoID == 0)
    {
    isVal.Add("UserInfoID", "User Info ID cannot be zero.");
    }
  

    if (string.IsNullOrWhiteSpace(exampleApprove.UserInfoJobTitle))
    {
    isVal.Add("UserInfoJobTitle", "User Info Job Title cannot be null or empty or only have white space.");
    }
  

    } else
    {
    isVal.Add("exampleApprove", "exampleApprove cannot be null.");
    }
  

    return isVal;
    }

    #endregion

    }
  

    }
  