
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Linq;
    using System.Security.Policy;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    //  using System.Drawing;
    using System.IO;
    using AspxULTExample.BL;
    using AspxULTExample.Models;
    using AspxULTExample.Models.Interface;
    using AspxULTExample.Repository;

    namespace AspxULTExample.Web.AdminInfos.ExampleLogs
    {
    
    public partial class ExampleLogTelerikRadDetails : System.Web.UI.Page
    {

    private IExampleLogBL bl;

    public ExampleLogTelerikRadDetails()
    {
    bl = new AdminExampleLogBL(new AdminExampleLogXmlRepository());
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    SessionRedirect();


    if (!IsPostBack)
    {
    
    string rawExampleLogID = Request.QueryString["id"];
    int exampleLogID;
    bool successExampleLogID = int.TryParse(rawExampleLogID, out exampleLogID);
    if (!successExampleLogID)
    {
    exampleLogID = 0;
    }
  


    if (exampleLogID != 0)
    {

    ExampleLog exampleLog = bl.GetExampleLogById(exampleLogID);
    
    HiddenField_ExampleLogID.Value = exampleLog.ExampleLogID.ToString();
    LabelDisplayForExampleLogID.Text = exampleLog.ExampleLogID.ToString();
  

    LabelDisplayForExampleID.Text = exampleLog.ExampleID.ToString();
  

    LabelDisplayForLogMessage.Text = exampleLog.LogMessage.ToString();
  

    }
    else
    {
    DisplayAlert("exampleLogID cannot be zero.");
    }

    }
    }

    private string SessionName()
    {
    string sessionName = "AspxULTExample_";
    return sessionName;
    }

    private bool SessionAdminBool()
    {
    bool sessionBool = HttpContext.Current.Session != null && (int)HttpContext.Current.Session[SessionName() + "UserInfoAccessLevelID"] != 0 && (bool)HttpContext.Current.Session[SessionName() + "UserInfoActiveYesNo"];
    bool sessionAdminBool = sessionBool && ((int)HttpContext.Current.Session[SessionName() + "UserInfoAccessLevelID"] == (int)EnumUserInfoAccessLevelID.SuperAccessLevelSr || (int)HttpContext.Current.Session[SessionName() + "UserInfoAccessLevelID"] == (int)EnumUserInfoAccessLevelID.SuperAccessLevelJr);

    return sessionAdminBool;
    }

    private void SessionRedirect()
    {
    if (!SessionAdminBool())
    {
    Response.Redirect("~", false);
    }

    }


    protected void DisplayAlert(string msg)
    {
    if(!string.IsNullOrWhiteSpace(msg)){
    string msgHtml = ((SiteMaster)Master)?.MsgHtml(msg);
    ((SiteMaster)Master)?.DisplayAlert(msgHtml);
    ModelState.AddModelError("", msgHtml);
    }
    }

    }
  
    }
  