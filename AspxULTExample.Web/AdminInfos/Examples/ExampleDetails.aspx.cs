
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

    namespace AspxULTExample.Web.AdminInfos.Examples
    {
    
    public partial class ExampleDetails : System.Web.UI.Page
    {

    private IExampleBL bl;

    public ExampleDetails()
    {
    bl = new AdminExampleBL(new AdminExampleXmlRepository());
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    SessionRedirect();


    if (!IsPostBack)
    {

    
    string rawExampleID = Request.QueryString["id"];
    int exampleID;
    bool successExampleID = int.TryParse(rawExampleID, out exampleID);
    if (!successExampleID)
    {
    exampleID = 0;
    }
  


    if (exampleID != 0)
    {

    Example example = bl.GetExampleById(exampleID);
    
    HiddenField_ExampleID.Value = example.ExampleID.ToString();
    LabelDisplayForExampleID.Text = example.ExampleID.ToString();
  

    LabelDisplayForExampleUserInfoStatusID.Text = example.ExampleUserInfoStatusID.ToString();
  

    LabelDisplayForExampleUserInfoCompanyID.Text = example.ExampleUserInfoCompanyID.ToString();
  

    LabelDisplayForTitle.Text = example.Title.ToString();
  

    LabelDisplayForRelease.Text = example.Release.ToString();
  

    LabelDisplayForReleaseDateTime.Text = example.ReleaseDateTime.ToString();
  

    LabelDisplayForGenre.Text = example.Genre.ToString();
  

    LabelDisplayForPrice.Text = example.Price.ToString();
  

    LabelDisplayForPriceYesNo.Text = example.PriceYesNo.ToString();
  

    LabelDisplayForReleaseDate.Text = example.ReleaseDate.ToString();
  

    LabelDisplayForReleaseTime.Text = example.ReleaseTime.ToString();
  

    LabelDisplayForMessage.Text = example.Message.ToString();
  

    LabelDisplayForMessage2.Text = example.Message2.ToString();
  

    LabelDisplayForPhoneNumber.Text = example.PhoneNumber.ToString();
  

    LabelDisplayForEmailAddress.Text = example.EmailAddress.ToString();
  

    LabelDisplayForCreditCard.Text = example.CreditCard.ToString();
  

    LabelDisplayForPassword.Text = example.Password.ToString();
  

    LabelDisplayForUrl.Text = example.Url.ToString();
  

    LabelDisplayForExampleActiveYesNo.Text = example.ExampleActiveYesNo.ToString();
  


    }
    else
    {
    DisplayAlert("exampleID cannot be zero.");
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
  