
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

    namespace AspxULTExample.Web.AdminInfos.ExampleApproves
    {
    
    public partial class ExampleApproveDetails : System.Web.UI.Page
    {

    private IExampleApproveBL bl;

    public ExampleApproveDetails()
    {
    bl = new AdminExampleApproveBL(new AdminExampleApproveXmlRepository());
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    SessionRedirect();


    if (!IsPostBack)
    {

    
    string rawExampleApproveID = Request.QueryString["id"];
    int exampleApproveID;
    bool successExampleApproveID = int.TryParse(rawExampleApproveID, out exampleApproveID);
    if (!successExampleApproveID)
    {
    exampleApproveID = 0;
    }
  


    if (exampleApproveID != 0)
    {

    ExampleApprove exampleApprove = bl.GetExampleApproveById(exampleApproveID);
    
    HiddenField_ExampleApproveID.Value = exampleApprove.ExampleApproveID.ToString();
    LabelDisplayForExampleApproveID.Text = exampleApprove.ExampleApproveID.ToString();
  

    LabelDisplayForExampleID.Text = exampleApprove.ExampleID.ToString();
  

    LabelDisplayForUserInfoID.Text = exampleApprove.UserInfoID.ToString();
  

    LabelDisplayForUserInfoJobTitle.Text = exampleApprove.UserInfoJobTitle.ToString();
  


    }
    else
    {
    DisplayAlert("exampleApproveID cannot be zero.");
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
  