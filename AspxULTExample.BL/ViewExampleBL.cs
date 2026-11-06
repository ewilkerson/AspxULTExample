
    using System;
    using System.Collections.Generic;
    using AspxULTExample.Models;
    using AspxULTExample.Models.Interface;

    namespace AspxULTExample.BL
    {

    
    public partial class ViewExampleBL:IViewExampleBL
    {

    #region ViewExampleBL

    private readonly IViewExampleRepository _context;

    public ViewExampleBL(IViewExampleRepository context)
    {
    this._context = context;
    }

    public IEnumerable<ViewExample>
    GetViewExamples(int userInfoID)
    {
    return this._context.GetViewExamples(userInfoID);
    }

    public IEnumerable<ExampleApprove> GetViewExampleApprovesById(int exampleID)
    {
    return this._context.GetViewExampleApprovesById(exampleID);
    }

    public  IEnumerable<ExampleLog> GetViewExampleLogsById(int exampleID)
    {
    return this._context.GetViewExampleLogsById(exampleID);
    }

    public IEnumerable<UserInfoUserInfoCompanyXref> GetLoadUserInfoUserInfoCompanyXrefsById(int userInfoID)
    {
    return this._context.GetLoadUserInfoUserInfoCompanyXrefsById(userInfoID);
    }

    public ViewExample GetViewExampleById(int exampleID)
    {
    return this._context.GetViewExampleById(exampleID);
    }

    public bool InsertViewExample(ViewExample viewExample)
    {

    bool val = true;
    if(val)
    {
    this._context.InsertViewExample(viewExample);
    }
    return val;
    }

    public bool UpdateViewExample(ViewExample viewExample)
    {

    bool val = true;
    if(val)
    {
    this._context.UpdateViewExample(viewExample);
    }
    return val;
    }

    public  bool SignedUnsignedUpdateViewExample(ViewExample viewExample)
    {
    Dictionary<string, string> isVal = ViewExampleIsValid(viewExample);
    bool val = isVal.Count == 0;

    if(val)
    {
    this._context.SignedUnsignedUpdateViewExample(viewExample);
    }
    return val;
    }

    public  bool ApproveCompeteRejectRevokeViewExample(ViewExample viewExample, string noteMessage)
    {
    Dictionary<string, string> isVal = ViewExampleIsValid(viewExample);
    bool val = isVal.Count == 0;

    if(val)
    {
    this._context.ApproveCompeteRejectRevokeViewExample(viewExample, noteMessage);
    }
    return val;
    }


    public bool DeleteViewExample(int exampleID, ViewExample viewExample)
    {
    bool val = exampleID != 0;

    if(val)
    {
    this._context.DeleteViewExample(exampleID, viewExample);
    }
    return val;
    }

    public Dictionary<string,string>ViewExampleIsValid(ViewExample viewExample)
    {
    Dictionary<string,string> isVal = new Dictionary<string, string>();

    
    if (viewExample != null){
    
    if (viewExample.ExampleID == 0)
    {
    isVal.Add("ExampleID", "Example ID cannot be zero.");
    }
  

    if (viewExample.ExampleUserInfoStatusID == 0)
    {
    isVal.Add("ExampleUserInfoStatusID", "Example User Info Status ID cannot be zero.");
    }
  

    if (viewExample.ExampleUserInfoCompanyID == 0)
    {
    isVal.Add("ExampleUserInfoCompanyID", "Example User Info Company ID cannot be zero.");
    }
  

    if (string.IsNullOrWhiteSpace(viewExample.Title))
    {
    isVal.Add("Title", "Title cannot be null or empty or only have white space.");
    }
  

    if (viewExample.Release == 0)
    {
    isVal.Add("Release", "Release cannot be zero.");
    }
  


    if (string.IsNullOrWhiteSpace(viewExample.Genre))
    {
    isVal.Add("Genre", "Genre cannot be null or empty or only have white space.");
    }
  

    if (viewExample.Price == 0)
    {
    isVal.Add("Price", "Price cannot be zero.");
    }
  




    if (string.IsNullOrWhiteSpace(viewExample.Message))
    {
    isVal.Add("Message", "Message cannot be null or empty or only have white space.");
    }
  

    if (string.IsNullOrWhiteSpace(viewExample.Message2))
    {
    isVal.Add("Message2", "Message2 cannot be null or empty or only have white space.");
    }
  

    if (string.IsNullOrWhiteSpace(viewExample.PhoneNumber))
    {
    isVal.Add("PhoneNumber", "Phone Number cannot be null or empty or only have white space.");
    }
  

    if (string.IsNullOrWhiteSpace(viewExample.EmailAddress))
    {
    isVal.Add("EmailAddress", "Email Address cannot be null or empty or only have white space.");
    }
  

    if (string.IsNullOrWhiteSpace(viewExample.CreditCard))
    {
    isVal.Add("CreditCard", "Credit Card cannot be null or empty or only have white space.");
    }
  

    if (string.IsNullOrWhiteSpace(viewExample.Password))
    {
    isVal.Add("Password", "Password cannot be null or empty or only have white space.");
    }
  

    if (string.IsNullOrWhiteSpace(viewExample.Url))
    {
    isVal.Add("Url", "Url cannot be null or empty or only have white space.");
    }
  


    } else
    {
    isVal.Add("viewExample", "viewExample cannot be null.");
    }
  

    return isVal;
    }

    #endregion

    }
  

    }
  