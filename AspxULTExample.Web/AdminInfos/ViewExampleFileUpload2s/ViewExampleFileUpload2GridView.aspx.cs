
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

namespace AspxULTExample.Web.AdminInfos.ViewExampleFileUpload2s
{

    public partial class ViewExampleFileUpload2GridView : System.Web.UI.Page
    {

        private IViewExampleFileUpload2BL bl;
        private string folderUploads = "~/AspxULTExample_Uploads/";

        public ViewExampleFileUpload2GridView()
        {
            bl = new AdminViewExampleFileUpload2BL(new AdminViewExampleFileUpload2XmlRepository());

            folderUploads = Server.MapPath(folderUploads);
            if (!Directory.Exists(folderUploads))
            {
                Directory.CreateDirectory(folderUploads);
            }

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

                IEnumerable<ViewExampleFileUpload2> viewExampleFileUpload2s = bl.GetViewExampleFileUpload2s();

                ResultGridView.DataSource = viewExampleFileUpload2s;
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


                foreach (LinkButton link in e.Row.Cells[6].Controls.OfType<LinkButton>
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


        protected void UploadButton_Click(object sender, EventArgs e)
        {
            try
            {
                SessionRedirect();

                if (Page.IsValid && FileUpload1.HasFile)
                {

                    string fileName = Path.GetFileName(FileUpload1.FileName);
                    string fileExt = Path.GetExtension(fileName).ToUpper();

                    //52,428,800 bytes (approximately 50 MB) to be uploaded.
                    // int fileSizeMax = 52428800;

                    //10485760 bytes (approximately 10 MB) to be uploaded.
                    int fileSizeMax = 10485760;

                    if (fileExt == ".PDF" ||
                    fileExt == ".JPG" ||
                    fileExt == ".JPEG" ||
                    fileExt == ".BMP" ||
                    fileExt == ".DOC" ||
                    fileExt == ".DOCX" ||
                    fileExt == ".TXT" ||
                    fileExt == ".CVS" ||
                    fileExt == ".GIF" ||
                    fileExt == ".TIFF" ||
                    fileExt == ".XML" ||
                    fileExt == ".XLS" ||
                    fileExt == ".XLSX" ||
                    fileExt == ".PNG")
                    {
                        int fileSize = FileUpload1.PostedFile.ContentLength;

                        // Allow only files less than fileSizeMax (52,428,800 bytes)
                        if (fileSize < fileSizeMax)
                        {

                            string fileContentType = FileUpload1.PostedFile.ContentType;
                            decimal fileContentLengthKbMb = (decimal)(fileSize / 1024f); // - kg, (files.ContentLength / 1024f) / 1024f - mg
                            string fileContentPath = folderUploads + fileName;

                            ViewExampleFileUpload2 viewExampleFileUpload2 = new ViewExampleFileUpload2()
                            {
                                ExampleFileUpload2ID = 1,
                                FileName = fileName,
                                FileContentType = fileContentType,
                                FileContentLength = fileSize,
                                FileContentLengthKbMb = fileContentLengthKbMb,
                                FileContentPath = fileContentPath
                            };


                            if (File.Exists(viewExampleFileUpload2.FileContentPath))
                            {
                                DisplayAlert(viewExampleFileUpload2.FileName + " already exists on the server!");
                            }
                            else if (bl.InsertViewExampleFileUpload2(viewExampleFileUpload2))
                            {
                                if (viewExampleFileUpload2.ErrID == 0)
                                {
                                    FileUpload1.PostedFile.SaveAs(viewExampleFileUpload2.FileContentPath);
                                    Response.Redirect("../ViewExampleFileUpload2s/ViewExampleFileUpload2GridView.aspx", false);
                                }
                                else
                                {
                                    DisplayAlert(viewExampleFileUpload2.ErrText);
                                }
                            }
                            else
                            {
                                DisplayAlert(MsgText(viewExampleFileUpload2));

                            }
                        }
                        else
                        {
                            DisplayAlert("Your file was not uploaded because it exceeds the 10 MB size limit.");
                        }
                    }
                    else
                    {
                        DisplayAlert("Invalid file format.");
                    }
                }

            }
            catch (DataException exception)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                DisplayAlert("Unable to save changes. Try again, and if the problem persists see your system administrator.");
                Log4ExceptionConnDb.Ex(exception);
            }
        }


        protected void DownloadData(object sender, EventArgs e)
        {
            if ((sender as LinkButton).CommandArgument == null)
            {
                DisplayAlert("ExampleFileUpload2ID cannot be zero.");
            }
            else
            {
                int id = int.Parse((sender as LinkButton).CommandArgument);
                ViewExampleFileUpload2 viewExampleFileUpload2 = bl.GetViewExampleFileUpload2ById(id);

                if (!string.IsNullOrWhiteSpace(viewExampleFileUpload2.FileContentPath) && File.Exists(viewExampleFileUpload2.FileContentPath))
                {
                    Response.ContentType = viewExampleFileUpload2.FileContentType;
                    Response.AppendHeader("Content-Disposition", "attachment; filename=" + viewExampleFileUpload2.FileName);
                    Response.WriteFile(viewExampleFileUpload2.FileContentPath);
                    Response.End();
                }
                else
                {
                    DisplayAlert("FileContentPath is null.");
                }
                BindUserInfo();
            }
        }


        protected void ResultGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                SessionRedirect();

                int exampleFileUpload2ID = ResultGridView.DataKeys[e.RowIndex].Values[0] == null ? 0 : (int)ResultGridView.DataKeys[e.RowIndex].Values[0];


                if (exampleFileUpload2ID != 0)
                {

                    ViewExampleFileUpload2 viewExampleFileUpload2 = bl.GetViewExampleFileUpload2ById(exampleFileUpload2ID);

                    if (!string.IsNullOrWhiteSpace(viewExampleFileUpload2.FileContentPath))
                    {

                        if (bl.DeleteViewExampleFileUpload2(viewExampleFileUpload2.ExampleFileUpload2ID, viewExampleFileUpload2))
                        {
                            if (viewExampleFileUpload2.ErrID != 0)
                            {
                                DisplayAlert(viewExampleFileUpload2.ErrText);
                            }
                            else if (!string.IsNullOrWhiteSpace(viewExampleFileUpload2.FileContentPath) && File.Exists(viewExampleFileUpload2.FileContentPath))
                            {
                                File.Delete(viewExampleFileUpload2.FileContentPath);
                            }
                        }
                        else
                        {
                            DisplayAlert(MsgText(viewExampleFileUpload2));

                        }


                    }
                    else
                    {
                        DisplayAlert("exampleFileUpload2ID cannot be zero.");
                    }

                    BindUserInfo();
                }
                else
                {
                    DisplayAlert("FileContentPath is null.");
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

        protected string MsgText(ViewExampleFileUpload2 viewExampleFileUpload2)
        {
            string msg = string.Empty;

            if (viewExampleFileUpload2 != null)
            {

                Dictionary<string, string>
                isVal = bl.ViewExampleFileUpload2IsValid(viewExampleFileUpload2);


                foreach (var kvp in isVal)
                    msg += "*\t" + kvp.Value + "\n";

            }
            else
            {
                msg = "ViewExampleFileUpload2 cannot be null.";
            }

            return msg;
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
