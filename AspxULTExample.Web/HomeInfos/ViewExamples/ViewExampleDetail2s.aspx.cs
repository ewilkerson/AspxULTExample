
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
    // using System.Drawing;
    using System.IO;
    using AspxULTExample.BL;
    using AspxULTExample.Models;
    using AspxULTExample.Models.Interface;
    using AspxULTExample.Repository;

    namespace AspxULTExample.Web.HomeInfos.ViewExamples
    {
    
    public partial class ViewExampleDetail2s : System.Web.UI.Page
    {

    private IViewExampleBL bl;

    public ViewExampleDetail2s()
    {
    bl = new ViewExampleBL(new ViewExampleXmlRepository());
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

    ViewExample viewExample = bl.GetViewExampleById(exampleID);
    
    HiddenField_ExampleID.Value = viewExample.ExampleID.ToString();
    LabelDisplayForExampleID.Text = viewExample.ExampleID.ToString();
  

    LabelDisplayForExampleUserInfoStatusID.Text = viewExample.ExampleUserInfoStatusID.ToString();
  

    LabelDisplayForExampleUserInfoCompanyID.Text = viewExample.ExampleUserInfoCompanyID.ToString();
  

    LabelDisplayForTitle.Text = viewExample.Title.ToString();
  

    LabelDisplayForRelease.Text = viewExample.Release.ToString();
  

    LabelDisplayForReleaseDateTime.Text = viewExample.ReleaseDateTime.ToString();
  

    LabelDisplayForGenre.Text = viewExample.Genre.ToString();
  

    LabelDisplayForPrice.Text = viewExample.Price.ToString();
  

    LabelDisplayForPriceYesNo.Text = viewExample.PriceYesNo.ToString();
  

    LabelDisplayForReleaseDate.Text = viewExample.ReleaseDate.ToString();
  

    LabelDisplayForReleaseTime.Text = viewExample.ReleaseTime.ToString();
  

    LabelDisplayForMessage.Text = viewExample.Message.ToString();
  

    LabelDisplayForMessage2.Text = viewExample.Message2.ToString();
  

    LabelDisplayForPhoneNumber.Text = viewExample.PhoneNumber.ToString();
  

    LabelDisplayForEmailAddress.Text = viewExample.EmailAddress.ToString();
  

    LabelDisplayForCreditCard.Text = viewExample.CreditCard.ToString();
  

    LabelDisplayForPassword.Text = viewExample.Password.ToString();
  

    LabelDisplayForUrl.Text = viewExample.Url.ToString();
  

    LabelDisplayForExampleActiveYesNo.Text = viewExample.ExampleActiveYesNo.ToString();
  

    LabelDisplayForUserInfoCompanyName.Text = viewExample.UserInfoCompanyName.ToString();
  

    LabelDisplayForUserInfoStatusName.Text = viewExample.UserInfoStatusName.ToString();
  


    BindUserInfo(exampleID);
    }
    else
    {
    DisplayAlert("exampleID cannot be zero.");
    }

    }
    }

    private void BindUserInfo(int id)
    {
    try
    {
    if(id != 0)
    {

    IEnumerable<ExampleApprove> viewExampleApproves = bl.GetViewExampleApprovesById(id);

    ResultGridViewApproves.DataSource = viewExampleApproves;
    ResultGridViewApproves.DataBind();

    ResultGridViewApproves.HeaderRow.TableSection = TableRowSection.TableHeader;
    ResultGridViewApproves.UseAccessibleHeader = true;

    if (ResultGridViewApproves.Rows.Count > 0)
    {
    ResultGridViewApproves.FooterRow.TableSection = TableRowSection.TableFooter;
    }

    IEnumerable<ExampleLog> viewExampleLogs = bl.GetViewExampleLogsById(id);

    ResultGridViewLogs.DataSource = viewExampleLogs;
    ResultGridViewLogs.DataBind();

    ResultGridViewLogs.HeaderRow.TableSection = TableRowSection.TableHeader;
    ResultGridViewLogs.UseAccessibleHeader = true;

    if (ResultGridViewLogs.Rows.Count > 0)
    {
    ResultGridViewLogs.FooterRow.TableSection = TableRowSection.TableFooter;
    }
    }
    else
    {
    DisplayAlert("id cannot be zero.");
    }


    }
    catch (Exception exception)
    {
    Log4ExceptionConnDb.Ex(exception);
    DisplayAlert("Unable to save changes. Try again, and if the problem persists see your system administrator.");

    }
    }

    private string SessionName()
    {
    string sessionName = "AspxULTExample_";
    return sessionName;
    }

    private bool SessionBool()
    {
    bool sessionBool = HttpContext.Current.Session != null && (int)HttpContext.Current.Session[SessionName() + "UserInfoAccessLevelID"] != 0 && (bool)HttpContext.Current.Session[SessionName() + "UserInfoActiveYesNo"];
    return sessionBool;
    }

    private void SessionRedirect()
    {
    if (!SessionBool())
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
  