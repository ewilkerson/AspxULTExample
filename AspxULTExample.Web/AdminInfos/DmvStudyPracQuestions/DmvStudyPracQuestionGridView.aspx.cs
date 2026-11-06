
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

    namespace AspxULTExample.Web.AdminInfos.DmvStudyPracQuestions
    {
    
    public partial class DmvStudyPracQuestionGridView : System.Web.UI.Page
    {

    private IBL<DmvStudyPracQuestion> bl;

    public DmvStudyPracQuestionGridView()
    {
    bl = new AdminDmvStudyPracQuestionBL(new AdminDmvStudyPracQuestionXmlRepository());
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


    var dmvStudyPracQuestions = bl.GetAll();

    ResultGridView.DataSource = dmvStudyPracQuestions;
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

    foreach (LinkButton link in e.Row.Cells[8].Controls.OfType<LinkButton>
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

    int dmvStudyPracQuestionID = ResultGridView.DataKeys[e.RowIndex].Values[0] == null ? 0 : (int)ResultGridView.DataKeys[e.RowIndex].Values[0];


    if(dmvStudyPracQuestionID != 0)
    {

    DmvStudyPracQuestion dmvStudyPracQuestion = bl.GetById(dmvStudyPracQuestionID);


    if (bl.Delete(dmvStudyPracQuestionID, dmvStudyPracQuestion))
    {
    if (dmvStudyPracQuestion.ErrID != 0)
    {
    DisplayAlert(dmvStudyPracQuestion.ErrText);
    }
    }
    else
    {
    DisplayAlert(MsgText(dmvStudyPracQuestion));    }

    }
    else
    {
    DisplayAlert("dmvStudyPracQuestionID cannot be zero.");
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

    int dmvStudyPracQuestionID = ResultGridView.DataKeys[e.RowIndex].Values[0] == null ? 0 : (int)ResultGridView.DataKeys[e.RowIndex].Values[0];

    int dmvStudyPracID;
    bool successDmvStudyPracID = int.TryParse(((TextBox)ResultGridView.Rows[e.RowIndex].FindControl("txtDmvStudyPracID")).Text, out dmvStudyPracID);
    if (!successDmvStudyPracID)
    {
    dmvStudyPracID = 0;
    }
  
string dmvStudyPracQuestionText = ((TextBox)ResultGridView.Rows[e.RowIndex].FindControl("txtDmvStudyPracQuestionText")).Text;
string dmvStudyPracQuestionAnswerText = ((TextBox)ResultGridView.Rows[e.RowIndex].FindControl("txtDmvStudyPracQuestionAnswerText")).Text;
bool dmvStudyPracQuestionPicsYesNo = ((CheckBox)ResultGridView.Rows[e.RowIndex].FindControl("CheckBoxDmvStudyPracQuestionPicsYesNo")).Checked;
bool dmvStudyPracQuestionActiveYesNo = ((CheckBox)ResultGridView.Rows[e.RowIndex].FindControl("CheckBoxDmvStudyPracQuestionActiveYesNo")).Checked;


    DmvStudyPracQuestion dmvStudyPracQuestion = new DmvStudyPracQuestion()
    {
    DmvStudyPracQuestionID = dmvStudyPracQuestionID,
DmvStudyPracID = dmvStudyPracID,
DmvStudyPracQuestionText = dmvStudyPracQuestionText,
DmvStudyPracQuestionAnswerText = dmvStudyPracQuestionAnswerText,
DmvStudyPracQuestionPicsYesNo = dmvStudyPracQuestionPicsYesNo,
DmvStudyPracQuestionActiveYesNo = dmvStudyPracQuestionActiveYesNo
    };

    ValidationContext context = new ValidationContext(dmvStudyPracQuestion, serviceProvider: null, items: null);
    List<ValidationResult> results = new List<ValidationResult>();
    bool isValid = Validator.TryValidateObject(dmvStudyPracQuestion, context, results, false);

    Validate();
    if (Page.IsValid && isValid)
    {

    if (bl.Update(dmvStudyPracQuestion))
    {
    if (dmvStudyPracQuestion.ErrID != 0)
    {
    DisplayAlert(dmvStudyPracQuestion.ErrText);
    }
    }
    else
    {
    DisplayAlert(MsgText(dmvStudyPracQuestion));
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


    protected string MsgText(DmvStudyPracQuestion dmvStudyPracQuestion)
    {

    string msg = string.Empty;

    if (dmvStudyPracQuestion != null)
    {

    Dictionary<string, string>
    isVal = bl.IsValid(dmvStudyPracQuestion);


    foreach (var kvp in isVal)
    msg += "*\t" + kvp.Value + "\n";

    }
    else
    {
    msg = "DmvStudyPracQuestion cannot be null.";
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
  