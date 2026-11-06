
using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using System.IO;
using System.Web;
using System.Xml.Serialization;
using System.Linq;
using AspxULTExample.Models;
using AspxULTExample.Models.Interface;

namespace AspxULTExample.Repository
{


    public partial class AdminViewExampleFileUpload2Repository : IViewExampleFileUpload2Repository
    {

        #region AdminViewExampleFileUpload2Repository

        public IEnumerable<ViewExampleFileUpload2> GetViewExampleFileUpload2s()
        {
            List<ViewExampleFileUpload2> viewExampleFileUpload2Lists = new List<ViewExampleFileUpload2>();

            using (var connection = ConnectionDb.LiveConnection())
            {
                try
                {
                    using (var reader = connection.ExecuteReader(sql: "[dbo].[usp_AdminGetViewExampleFileUpload2s]"))
                    {

                        while (reader.Read())
                        {
                            ViewExampleFileUpload2 viewExampleFileUpload2 = new ViewExampleFileUpload2();
                            if (reader["ExampleFileUpload2ID"] != DBNull.Value)
                                viewExampleFileUpload2.ExampleFileUpload2ID = int.Parse(reader["ExampleFileUpload2ID"].ToString());
                            viewExampleFileUpload2.FileName = reader["FileName"].ToString();
                            viewExampleFileUpload2.FileContentType = reader["FileContentType"].ToString();
                            if (reader["FileContentLength"] != DBNull.Value)
                                viewExampleFileUpload2.FileContentLength = long.Parse(reader["FileContentLength"].ToString());
                            if (reader["FileContentLengthKbMb"] != DBNull.Value)
                                viewExampleFileUpload2.FileContentLengthKbMb = decimal.Parse(reader["FileContentLengthKbMb"].ToString());
                            viewExampleFileUpload2.FileContentPath = reader["FileContentPath"].ToString();

                            viewExampleFileUpload2Lists.Add(viewExampleFileUpload2);
                        }
                    }
                }
                catch (Exception exception)
                {
                    Log4ExceptionConnDb.Ex(exception);
                }
                finally
                {
                    ConnectionDb.CloseConnection(connection);
                }
            }

            return viewExampleFileUpload2Lists;

        }

        public ViewExampleFileUpload2 GetViewExampleFileUpload2ById(int exampleFileUpload2ID)
        {

            ViewExampleFileUpload2 viewExampleFileUpload2 = new ViewExampleFileUpload2();

            using (var connection = ConnectionDb.LiveConnection())
            {
                try
                {

                    if (exampleFileUpload2ID != 0)
                    {

                        DynamicParameters parameters = new DynamicParameters();
                        parameters.Add(name: "@ExampleFileUpload2ID", exampleFileUpload2ID);


                        using (var reader = connection.ExecuteReader(sql: "[dbo].[usp_AdminGetViewExampleFileUpload2ById]", param: parameters, transaction: null, commandTimeout: null, CommandType.StoredProcedure))
                        {
                            if (reader.Read())
                            {
                                if (reader["ExampleFileUpload2ID"] != DBNull.Value)
                                    viewExampleFileUpload2.ExampleFileUpload2ID = int.Parse(reader["ExampleFileUpload2ID"].ToString());
                                viewExampleFileUpload2.FileName = reader["FileName"].ToString();
                                viewExampleFileUpload2.FileContentType = reader["FileContentType"].ToString();
                                if (reader["FileContentLength"] != DBNull.Value)
                                    viewExampleFileUpload2.FileContentLength = long.Parse(reader["FileContentLength"].ToString());
                                if (reader["FileContentLengthKbMb"] != DBNull.Value)
                                    viewExampleFileUpload2.FileContentLengthKbMb = decimal.Parse(reader["FileContentLengthKbMb"].ToString());
                                viewExampleFileUpload2.FileContentPath = reader["FileContentPath"].ToString();

                            }
                        }
                    }
                    else
                    {
                        viewExampleFileUpload2.ErrID = 1;
                        viewExampleFileUpload2.ErrText = "exampleFileUpload2ID cannot be zero.";
                    }

                }
                catch (Exception exception)
                {
                    Errors(viewExampleFileUpload2);
                    Log4ExceptionConnDb.Ex(exception);
                }
                finally
                {
                    ConnectionDb.CloseConnection(connection);
                }
            }

            return viewExampleFileUpload2;

        }

        public ViewExampleFileUpload2 InsertViewExampleFileUpload2(ViewExampleFileUpload2 viewExampleFileUpload2)
        {

            using (var connection = ConnectionDb.LiveConnection())
            {
                try
                {

                    if (viewExampleFileUpload2 != null)
                    {
                        if (viewExampleFileUpload2.ExampleFileUpload2ID != 0)
                        {

                            DynamicParameters parameters = new DynamicParameters();
                            parameters.Add(name: "@ExampleFileUpload2ID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                            parameters.Add(name: "@FileName", viewExampleFileUpload2.FileName);
                            parameters.Add(name: "@FileContentType", viewExampleFileUpload2.FileContentType);
                            parameters.Add(name: "@FileContentLength", viewExampleFileUpload2.FileContentLength);
                            parameters.Add(name: "@FileContentLengthKbMb", viewExampleFileUpload2.FileContentLengthKbMb);
                            parameters.Add(name: "@FileContentPath", viewExampleFileUpload2.FileContentPath);

                            parameters.Add(name: "@UpdateUserName", viewExampleFileUpload2.UpdateUserName);
                            parameters.Add(name: "@UpdateFullName", viewExampleFileUpload2.UpdateFullName);
                            parameters.Add(name: "@errID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                            parameters.Add(name: "@errText", dbType: DbType.String, direction: ParameterDirection.Output, size: 2047);

                            connection.Execute(sql: "[dbo].[usp_AdminInsertViewExampleFileUpload2ById]", param: parameters, commandType: CommandType.StoredProcedure);

                            if (parameters.Get<int?>(name: "@errID") != null)
                            {
                                int errID = parameters.Get<int>(name: "@errID");
                                string errText = parameters.Get<string>(name: "@errText");
                                viewExampleFileUpload2.ErrID = errID;
                                viewExampleFileUpload2.ErrText = errText;

                            }
                            else
                            {
                                int exampleFileUpload2ID = parameters.Get<int>("@ExampleFileUpload2ID");
                                viewExampleFileUpload2.ExampleFileUpload2ID = exampleFileUpload2ID;
                            }

                        }
                        else
                        {
                            viewExampleFileUpload2.ErrID = 1;
                            viewExampleFileUpload2.ErrText = "ExampleFileUpload2ID cannot be zero.";
                        }

                    }
                    else
                    {
                        viewExampleFileUpload2 = new ViewExampleFileUpload2()
                        {
                            ErrID = 1,
                            ErrText = "ViewExampleFileUpload2 cannot be null."
                        };
                    }

                }
                catch (Exception exception)
                {
                    Errors(viewExampleFileUpload2);
                    Log4ExceptionConnDb.Ex(exception);
                }
                finally
                {
                    ConnectionDb.CloseConnection(connection);
                }
            }
            return viewExampleFileUpload2;
        }

        public ViewExampleFileUpload2 UpdateViewExampleFileUpload2(ViewExampleFileUpload2 viewExampleFileUpload2)
        {

            using (var connection = ConnectionDb.LiveConnection())
            {
                try
                {

                    if (viewExampleFileUpload2 != null)
                    {

                        if (viewExampleFileUpload2.ExampleFileUpload2ID != 0)
                        {

                            DynamicParameters parameters = new DynamicParameters();
                            parameters.Add(name: "@ExampleFileUpload2ID", viewExampleFileUpload2.ExampleFileUpload2ID);
                            parameters.Add(name: "@FileName", viewExampleFileUpload2.FileName);
                            parameters.Add(name: "@FileContentType", viewExampleFileUpload2.FileContentType);
                            parameters.Add(name: "@FileContentLength", viewExampleFileUpload2.FileContentLength);
                            parameters.Add(name: "@FileContentLengthKbMb", viewExampleFileUpload2.FileContentLengthKbMb);
                            parameters.Add(name: "@FileContentPath", viewExampleFileUpload2.FileContentPath);

                            parameters.Add(name: "@UpdateUserName", viewExampleFileUpload2.UpdateUserName);
                            parameters.Add(name: "@UpdateFullName", viewExampleFileUpload2.UpdateFullName);
                            parameters.Add(name: "@errID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                            parameters.Add(name: "@errText", dbType: DbType.String, direction: ParameterDirection.Output, size: 2047);

                            connection.Execute(sql: "[dbo].[usp_AdminUpdateViewExampleFileUpload2ById]", param: parameters, commandType: CommandType.StoredProcedure);

                            if (parameters.Get<int?>(name: "@errID") != null)
                            {
                                int errID = parameters.Get<int>(name: "@errID");
                                string errText = parameters.Get<string>(name: "@errText");
                                viewExampleFileUpload2.ErrID = errID;
                                viewExampleFileUpload2.ErrText = errText;

                            }

                        }
                        else
                        {
                            viewExampleFileUpload2.ErrID = 1;
                            viewExampleFileUpload2.ErrText = "ExampleFileUpload2ID cannot be zero.";
                        }

                    }
                    else
                    {
                        viewExampleFileUpload2 = new ViewExampleFileUpload2()
                        {
                            ErrID = 1,
                            ErrText = "ViewExampleFileUpload2 cannot be null."
                        };
                    }

                }
                catch (Exception exception)
                {
                    Errors(viewExampleFileUpload2);
                    Log4ExceptionConnDb.Ex(exception);
                }
                finally
                {
                    ConnectionDb.CloseConnection(connection);
                }
            }

            return viewExampleFileUpload2;
        }

        public ViewExampleFileUpload2 DeleteViewExampleFileUpload2(int exampleFileUpload2ID, ViewExampleFileUpload2 viewExampleFileUpload2)
        {

            using (var connection = ConnectionDb.LiveConnection())
            {
                try
                {

                    if (viewExampleFileUpload2 != null)
                    {

                        if (exampleFileUpload2ID != 0)
                        {

                            DynamicParameters parameters = new DynamicParameters();
                            parameters.Add(name: "@ExampleFileUpload2ID", exampleFileUpload2ID);

                            parameters.Add(name: "@UpdateUserName", viewExampleFileUpload2.UpdateUserName);
                            parameters.Add(name: "@UpdateFullName", viewExampleFileUpload2.UpdateFullName);
                            parameters.Add(name: "@errID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                            parameters.Add(name: "@errText", dbType: DbType.String, direction: ParameterDirection.Output, size: 2047);

                            connection.Execute(sql: "[dbo].[usp_AdminDeleteViewExampleFileUpload2ById]", param: parameters, commandType: CommandType.StoredProcedure);

                            if (parameters.Get<int?>(name: "@errID") != null)
                            {
                                int errID = parameters.Get<int>(name: "@errID");
                                string errText = parameters.Get<string>(name: "@errText");
                                viewExampleFileUpload2.ErrID = errID;
                                viewExampleFileUpload2.ErrText = errText;
                            }
                            else
                            {
                                viewExampleFileUpload2.DeleteTrueFalse = true;
                            }

                        }
                        else
                        {
                            viewExampleFileUpload2.ErrID = 1;
                            viewExampleFileUpload2.ErrText = "exampleFileUpload2ID cannot be zero.";
                        }
                    }
                    else
                    {
                        viewExampleFileUpload2 = new ViewExampleFileUpload2()
                        {
                            ErrID = 1,
                            ErrText = "ViewExampleFileUpload2 cannot be null."
                        };
                    }

                }
                catch (Exception exception)
                {
                    Errors(viewExampleFileUpload2);
                    Log4ExceptionConnDb.Ex(exception);
                }
                finally
                {
                    ConnectionDb.CloseConnection(connection);
                }
            }

            return viewExampleFileUpload2;
        }

        private void Errors(ViewExampleFileUpload2 viewExampleFileUpload2)
        {
            viewExampleFileUpload2.ErrID = 1;
            viewExampleFileUpload2.ErrText = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
        }
        #endregion

    }


}
