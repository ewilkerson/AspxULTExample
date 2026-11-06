
using AspxULTExample.BL;
using AspxULTExample.Models;
using AspxULTExample.Models.Interface;
using AspxULTExample.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;

//  using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static Telerik.Web.UI.OrgChartStyles;

namespace AspxULTExample.Web.AdminInfos.DmvStudyPracQuestions
{

    public partial class DmvStudyPracQuestionRepeaterQOptTen : System.Web.UI.Page
    {

        private IBL3<DmvStudyPracQuestion> bl;
        private IBL2<DmvStudyPracQOpt> blOpt;
        protected bool qNAResultsYesNo = false;

        public DmvStudyPracQuestionRepeaterQOptTen()
        {
            bl = new AdminDmvStudyPracQuestion2BL(new AdminDmvStudyPracQuestionXml2Repository());
            blOpt = new AdminDmvStudyPracQOpt2BL(new AdminDmvStudyPracQOptXml2Repository());
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
                var dmvStudyPracQuestionsList = bl.GetAll_Ten();

                rptQNA.DataSource = dmvStudyPracQuestionsList;
                rptQNA.DataBind();

            }
            catch (Exception exception)
            {
                Log4ExceptionConnDb.Ex(exception);
                DisplayAlert("Unable to save changes. Try again, and if the problem persists see your system administrator.");

            }
        }

        protected void OnItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    string rawDmvStudyPracQuestionID = (e.Item.FindControl("hdnQuestionId") as HiddenField).Value;
                    int dmvStudyPracQuestionID;
                    bool successDmvStudyPracQuestionID = int.TryParse(rawDmvStudyPracQuestionID, out dmvStudyPracQuestionID);
                    if (!successDmvStudyPracQuestionID)
                    {
                        dmvStudyPracQuestionID = 0;
                    }

                    var dmvStudyPracQOptList = blOpt.GetAllById(dmvStudyPracQuestionID).ToList();

                    RadioButtonList rblOptions = e.Item.FindControl("rblOptions") as RadioButtonList;
                    rblOptions.DataSource = dmvStudyPracQOptList;
                    rblOptions.DataTextField = "DmvStudyPracQOptText";
                    rblOptions.DataValueField = "DmvStudyPracQOptAnswerYesNo";
                    rblOptions.DataBind();
                }
            }
            catch (Exception exception)
            {
                Log4ExceptionConnDb.Ex(exception);
                DisplayAlert("Unable to save changes. Try again, and if the problem persists see your system administrator.");

            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            SessionRedirect();

            Page.Validate();

            if (Page.IsValid)
            {
                qNAResultsYesNo = true;

                const double passScoreRate = 1;

                int correctAnswersCount = 0;
                int question = 0;


                // Iterate through the Repeater items to get the selected values
                foreach (RepeaterItem item in rptQNA.Items)
                {
                    if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                    {
                        HiddenField hdnQuestionId = (HiddenField)item.FindControl("hdnQuestionId");
                        RadioButtonList rblOptions = (RadioButtonList)item.FindControl("rblOptions");
                        Label labelSelectedText = (Label)item.FindControl("LabelSelectedText");

                        if (hdnQuestionId != null && rblOptions != null && rblOptions.SelectedItem != null)
                        {
                            string selectedText = rblOptions.SelectedItem.ToString();
                            string selectedValue = rblOptions.SelectedValue;
                            bool selectScoreTrue = rblOptions.SelectedValue == "True";
                            string msgSelectedText;

                            if (selectScoreTrue)
                            {
                                correctAnswersCount++;
                                msgSelectedText = "<i class=\"bi bi-check-lg\"></i>\u00a0" + rblOptions.SelectedItem;
                            }
                            else
                            {
                                msgSelectedText = "<b><i class=\"bi bi-x-lg\"></i>\u00a0" + rblOptions.SelectedItem + "</b>";
                            }

                            labelSelectedText.Text = msgSelectedText;

                            // You can now process or save this data (e.g., insert into a database)
                            System.Diagnostics.Debug.WriteLine($"ID: {hdnQuestionId.Value}, Text: {selectedText}, Score: {selectedValue}");

                        }
                        question++;
                    }
                }

                double passRate = (double)correctAnswersCount / question;

                string msgScoreRate = "Score: {0:P0}. ";
                string msg = String.Empty;

                if (passRate >= passScoreRate)
                {
                    msg = string.Format(msgScoreRate + "You passed the study guide exam!", passRate);
                }
                else
                {
                    msg = string.Format(msgScoreRate + "You failed. Please study more and try again.", passRate);
                }

                LabelResults.Text = msg;
                DisplayAlert(msg);
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
            if (!string.IsNullOrWhiteSpace(msg))
            {
                string msgHtml = ((SiteMaster)Master)?.MsgHtml(msg);
                ((SiteMaster)Master)?.DisplayAlert(msgHtml);
                ModelState.AddModelError("", msgHtml);
            }
        }

    }

}
