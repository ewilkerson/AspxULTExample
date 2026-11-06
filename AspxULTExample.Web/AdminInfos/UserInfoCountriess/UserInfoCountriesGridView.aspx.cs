
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

    namespace AspxULTExample.Web.AdminInfos.UserInfoCountriess
    {
    
    public partial class UserInfoCountriesGridView : System.Web.UI.Page
    {

    private IUserInfoCountriesBL bl;

    public UserInfoCountriesGridView()
    {
    bl = new AdminUserInfoCountriesBL(new AdminUserInfoCountriesXmlRepository());
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


    var userInfoCountriess = bl.GetUserInfoCountriess();

    ResultGridView.DataSource = userInfoCountriess;
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

    foreach (LinkButton link in e.Row.Cells[5].Controls.OfType<LinkButton>
    ())
    {
    if (link.CommandName == "Delete")
    {
    link.OnClientClick = "javascript:return DeleteConfirm();";
    }
    }
    }
    }

    protected void ResultGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    ResultGridView.PageIndex = e.NewPageIndex;

    BindUserInfo();

    }


    protected void ResultGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
    try
    {
    SessionRedirect();

    int userInfoCountriesID = ResultGridView.DataKeys[e.RowIndex].Values[0] == null ? 0 : (int)ResultGridView.DataKeys[e.RowIndex].Values[0];


    if(userInfoCountriesID != 0)
    {

    UserInfoCountries userInfoCountries = bl.GetUserInfoCountriesById(userInfoCountriesID);


    if (bl.DeleteUserInfoCountries(userInfoCountriesID, userInfoCountries))
    {
    if (userInfoCountries.ErrID != 0)
    {
    DisplayAlert(userInfoCountries.ErrText);
    }
    }
    else
    {
    DisplayAlert(MsgText(userInfoCountries));    }

    }
    else
    {
    DisplayAlert("userInfoCountriesID cannot be zero.");
    }

    BindUserInfo();
    }
    catch (Exception exception)
    {
    Log4ExceptionConnDb.Ex(exception);
    DisplayAlert("Unable to save changes. Try again, and if the problem persists see your system administrator.");

    }
    }

    protected void ResultGridView_RowEditing(object sender, GridViewEditEventArgs e)
    {

    ResultGridView.EditIndex = e.NewEditIndex;

    BindUserInfo();

    }

    protected void ResultGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
    try
    {
    SessionRedirect();

    int userInfoCountriesID = ResultGridView.DataKeys[e.RowIndex].Values[0] == null ? 0 : (int)ResultGridView.DataKeys[e.RowIndex].Values[0];
string userInfoCountriesName = ((TextBox)ResultGridView.Rows[e.RowIndex].FindControl("txtUserInfoCountriesName")).Text;
bool userInfoCountriesActiveYesNo = ((CheckBox)ResultGridView.Rows[e.RowIndex].FindControl("CheckBoxUserInfoCountriesActiveYesNo")).Checked;


    UserInfoCountries userInfoCountries = new UserInfoCountries()
    {
    UserInfoCountriesID = userInfoCountriesID,
UserInfoCountriesName = userInfoCountriesName,
UserInfoCountriesActiveYesNo = userInfoCountriesActiveYesNo
    };

    ValidationContext context = new ValidationContext(userInfoCountries, serviceProvider: null, items: null);
    List<ValidationResult> results = new List<ValidationResult>();
    bool isValid = Validator.TryValidateObject(userInfoCountries, context, results, false);

    Validate();
    if (Page.IsValid && isValid)
    {

    if (bl.UpdateUserInfoCountries(userInfoCountries))
    {
    if (userInfoCountries.ErrID != 0)
    {
    DisplayAlert(userInfoCountries.ErrText);
    }
    }
    else
    {
    DisplayAlert(MsgText(userInfoCountries));
    }

    ResultGridView.EditIndex = -1;
    BindUserInfo();
    }

    }
    catch (Exception exception)
    {
    DisplayAlert("Unable to save changes. Try again, and if the problem persists see your system administrator.");
    Log4ExceptionConnDb.Ex(exception);

    }

    }

    protected void ResultGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {

    ResultGridView.EditIndex = -1;

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


    protected string MsgText(UserInfoCountries userInfoCountries)
    {

    string msg = string.Empty;

    if (userInfoCountries != null)
    {

    Dictionary<string, string>
    isVal = bl.UserInfoCountriesIsValid(userInfoCountries);


    foreach (var kvp in isVal)
    msg += "*\t" + kvp.Value + "\n";

    }
    else
    {
    msg = "UserInfoCountries cannot be null.";
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
  