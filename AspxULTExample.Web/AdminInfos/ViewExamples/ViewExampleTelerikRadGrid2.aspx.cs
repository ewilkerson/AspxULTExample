
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

    namespace AspxULTExample.Web.AdminInfos.ViewExamples
    {
    
    public partial class ViewExampleTelerikRadGrid2 : System.Web.UI.Page
    {

    private IViewExampleBL bl;

    public ViewExampleTelerikRadGrid2()
    {
    bl = new AdminViewExampleBL(new AdminViewExampleXmlRepository());
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    SessionRedirect();

    if (!IsPostBack)
    {
    BindUserInfo();
    }

    }


    private void BindUserInfo()
    {
    try
    {

    int userInfoID = SessionAdminBool() ? (int)Session[SessionName() + "UserInfoID"] : 0;
    IEnumerable<ViewExample> viewExamples = bl.GetViewExamples(userInfoID);

    ResultGridView.DataSource = viewExamples;
    ResultGridView.DataBind();

    ResultGridView.HeaderRow.TableSection = TableRowSection.TableHeader;
    ResultGridView.UseAccessibleHeader = true;

    if (ResultGridView.Rows.Count > 0)
    {
    ResultGridView.FooterRow.TableSection = TableRowSection.TableFooter;
    }

    }
    catch (Exception exception)
    {
    Log4ExceptionConnDb.Ex(exception);
    DisplayAlert("Unable to save changes. Try again, and if the problem persists see your system administrator.");

    }
    }

    protected void ResultGridView_OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
    if (e.Row.RowType == DataControlRowType.DataRow)
    {

    foreach (LinkButton link in e.Row.Cells[23].Controls.OfType<LinkButton>
    ())
    {
    if (link.CommandName == "Delete")
    {
    link.OnClientClick = "javascript:return DeleteConfirm();";    }
    }
    }
    }

    protected void ResultGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
    try
    {
    SessionRedirect();

    int exampleID = ResultGridView.DataKeys[e.RowIndex].Values[0] == null ? 0 : (int)ResultGridView.DataKeys[e.RowIndex].Values[0];

    int exampleUserInfoStatusID;
    bool successExampleUserInfoStatusID = int.TryParse(ResultGridView.Rows[e.RowIndex].Cells[1].Text, out exampleUserInfoStatusID);
    if (!successExampleUserInfoStatusID)
    {
    exampleUserInfoStatusID = 0;
    }
  

    int exampleUserInfoCompanyID;
    bool successExampleUserInfoCompanyID = int.TryParse(ResultGridView.Rows[e.RowIndex].Cells[2].Text, out exampleUserInfoCompanyID);
    if (!successExampleUserInfoCompanyID)
    {
    exampleUserInfoCompanyID = 0;
    }
  
string title = ResultGridView.Rows[e.RowIndex].Cells[3].Text;

    int release;
    bool successRelease = int.TryParse(ResultGridView.Rows[e.RowIndex].Cells[4].Text, out release);
    if (!successRelease)
    {
    release = 0;
    }
  

    DateTime releaseDateTime;
    bool successReleaseDateTime = DateTime.TryParse(ResultGridView.Rows[e.RowIndex].Cells[5].Text, out releaseDateTime);
    if (!successReleaseDateTime)
    {
    releaseDateTime = DateTime.Now;
    }
  
string genre = ResultGridView.Rows[e.RowIndex].Cells[6].Text;

    decimal price;
    bool successPrice = decimal.TryParse(ResultGridView.Rows[e.RowIndex].Cells[7].Text, out price);
    if (!successPrice)
    {
    price = 0.0M;
    }
  
bool priceYesNo = ((CheckBox)ResultGridView.Rows[e.RowIndex].Cells[8].Controls[0]).Checked;

    DateTime releaseDate;
    bool successReleaseDate = DateTime.TryParse(ResultGridView.Rows[e.RowIndex].Cells[9].Text, out releaseDate);
    if (!successReleaseDate)
    {
    releaseDate = DateTime.Now.Date;
    }
    releaseDate = releaseDate.Date;
  

    TimeSpan releaseTime;
    bool successReleaseTime = TimeSpan.TryParse(ResultGridView.Rows[e.RowIndex].Cells[10].Text, out releaseTime);
    if (!successReleaseTime)
    {
    releaseTime = TimeSpan.Zero;
    }
  
string message = ResultGridView.Rows[e.RowIndex].Cells[11].Text;
string message2 = ResultGridView.Rows[e.RowIndex].Cells[12].Text;
string phoneNumber = ResultGridView.Rows[e.RowIndex].Cells[13].Text;
string emailAddress = ResultGridView.Rows[e.RowIndex].Cells[14].Text;
string creditCard = ResultGridView.Rows[e.RowIndex].Cells[15].Text;
string password = ResultGridView.Rows[e.RowIndex].Cells[16].Text;
string url = ResultGridView.Rows[e.RowIndex].Cells[17].Text;
bool exampleActiveYesNo = ((CheckBox)ResultGridView.Rows[e.RowIndex].Cells[18].Controls[0]).Checked;
string userInfoCompanyName = ResultGridView.Rows[e.RowIndex].Cells[19].Text;
string userInfoStatusName = ResultGridView.Rows[e.RowIndex].Cells[20].Text;


    if(exampleID != 0)
    {

    ViewExample viewExample = bl.GetViewExampleById(exampleID);


    if (bl.DeleteViewExample(exampleID, viewExample))
    {
    if (viewExample.ErrID != 0)
    {
    DisplayAlert(viewExample.ErrText);
    }
    }
    else
    {
    DisplayAlert(MsgText(viewExample));    }

    }
    else
    {
    DisplayAlert("exampleID cannot be zero.");
    }

    BindUserInfo();
    }
    catch (Exception exception)
    {
    Log4ExceptionConnDb.Ex(exception);
    DisplayAlert("Unable to save changes. Try again, and if the problem persists see your system administrator.");

    }
    }

    protected void ResultGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)

    {

    ResultGridView.PageIndex = e.NewPageIndex;

    BindUserInfo();

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


    protected string MsgText(ViewExample viewExample)
    {
    string msg = string.Empty;

    if (viewExample != null)
    {

    Dictionary<string, string>
    isVal = bl.ViewExampleIsValid(viewExample);


    foreach (var kvp in isVal)
    msg += "*\t" + kvp.Value + "\n";

    }
    else
    {
    msg = "ViewExample cannot be null.";
    }

    return msg;
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
  