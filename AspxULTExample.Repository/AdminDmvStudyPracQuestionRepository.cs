
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


    public partial class AdminDmvStudyPracQuestionRepository : IRepository<DmvStudyPracQuestion>
    {

        #region AdminDmvStudyPracQuestionRepository

        public IEnumerable<DmvStudyPracQuestion> GetAll()
        {
            List<DmvStudyPracQuestion> dmvStudyPracQuestionLists = new List<DmvStudyPracQuestion>();

            using (var connection = ConnectionDb.LiveConnection())
            {
                try
                {
                    using (var reader = connection.ExecuteReader(sql: "[dbo].[usp_AdminGetDmvStudyPracQuestions]"))
                    {

                        while (reader.Read())
                        {
                            DmvStudyPracQuestion dmvStudyPracQuestion = new DmvStudyPracQuestion();
                            if (reader["DmvStudyPracQuestionID"] != DBNull.Value)
                                dmvStudyPracQuestion.DmvStudyPracQuestionID = int.Parse(reader["DmvStudyPracQuestionID"].ToString());
                            if (reader["DmvStudyPracID"] != DBNull.Value)
                                dmvStudyPracQuestion.DmvStudyPracID = int.Parse(reader["DmvStudyPracID"].ToString());
                            dmvStudyPracQuestion.DmvStudyPracQuestionText = reader["DmvStudyPracQuestionText"].ToString();
                            dmvStudyPracQuestion.DmvStudyPracQuestionAnswerText = reader["DmvStudyPracQuestionAnswerText"].ToString();
                            if (reader["DmvStudyPracQuestionPicsYesNo"] != DBNull.Value)
                                dmvStudyPracQuestion.DmvStudyPracQuestionPicsYesNo = bool.Parse(reader["DmvStudyPracQuestionPicsYesNo"].ToString());
                            if (reader["DmvStudyPracQuestionActiveYesNo"] != DBNull.Value)
                                dmvStudyPracQuestion.DmvStudyPracQuestionActiveYesNo = bool.Parse(reader["DmvStudyPracQuestionActiveYesNo"].ToString());

                            dmvStudyPracQuestionLists.Add(dmvStudyPracQuestion);
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

            return dmvStudyPracQuestionLists;

        }

        public DmvStudyPracQuestion GetById(int dmvStudyPracQuestionID)
        {

            DmvStudyPracQuestion dmvStudyPracQuestion = new DmvStudyPracQuestion();

            using (var connection = ConnectionDb.LiveConnection())
            {
                try
                {

                    if (dmvStudyPracQuestionID != 0)
                    {

                        DynamicParameters parameters = new DynamicParameters();
                        parameters.Add(name: "@DmvStudyPracQuestionID", dmvStudyPracQuestionID);


                        using (var reader = connection.ExecuteReader(sql: "[dbo].[usp_AdminGetDmvStudyPracQuestionById]", param: parameters, transaction: null, commandTimeout: null, CommandType.StoredProcedure))
                        {
                            if (reader.Read())
                            {
                                if (reader["DmvStudyPracQuestionID"] != DBNull.Value)
                                    dmvStudyPracQuestion.DmvStudyPracQuestionID = int.Parse(reader["DmvStudyPracQuestionID"].ToString());
                                if (reader["DmvStudyPracID"] != DBNull.Value)
                                    dmvStudyPracQuestion.DmvStudyPracID = int.Parse(reader["DmvStudyPracID"].ToString());
                                dmvStudyPracQuestion.DmvStudyPracQuestionText = reader["DmvStudyPracQuestionText"].ToString();
                                dmvStudyPracQuestion.DmvStudyPracQuestionAnswerText = reader["DmvStudyPracQuestionAnswerText"].ToString();
                                if (reader["DmvStudyPracQuestionPicsYesNo"] != DBNull.Value)
                                    dmvStudyPracQuestion.DmvStudyPracQuestionPicsYesNo = bool.Parse(reader["DmvStudyPracQuestionPicsYesNo"].ToString());
                                if (reader["DmvStudyPracQuestionActiveYesNo"] != DBNull.Value)
                                    dmvStudyPracQuestion.DmvStudyPracQuestionActiveYesNo = bool.Parse(reader["DmvStudyPracQuestionActiveYesNo"].ToString());

                            }
                        }
                    }
                    else
                    {
                        dmvStudyPracQuestion.ErrID = 1;
                        dmvStudyPracQuestion.ErrText = "dmvStudyPracQuestionID cannot be zero.";
                    }

                }
                catch (Exception exception)
                {
                    Errors(dmvStudyPracQuestion);
                    Log4ExceptionConnDb.Ex(exception);
                }
                finally
                {
                    ConnectionDb.CloseConnection(connection);
                }
            }

            return dmvStudyPracQuestion;

        }

        public DmvStudyPracQuestion Insert(DmvStudyPracQuestion dmvStudyPracQuestion)
        {

            using (var connection = ConnectionDb.LiveConnection())
            {
                try
                {

                    if (dmvStudyPracQuestion != null)
                    {
                        if (dmvStudyPracQuestion.DmvStudyPracQuestionID != 0)
                        {

                            DynamicParameters parameters = new DynamicParameters();
                            parameters.Add(name: "@DmvStudyPracQuestionID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                            parameters.Add(name: "@DmvStudyPracID", dmvStudyPracQuestion.DmvStudyPracID);
                            parameters.Add(name: "@DmvStudyPracQuestionText", dmvStudyPracQuestion.DmvStudyPracQuestionText);
                            parameters.Add(name: "@DmvStudyPracQuestionAnswerText", dmvStudyPracQuestion.DmvStudyPracQuestionAnswerText);
                            parameters.Add(name: "@DmvStudyPracQuestionPicsYesNo", dmvStudyPracQuestion.DmvStudyPracQuestionPicsYesNo);
                            parameters.Add(name: "@DmvStudyPracQuestionActiveYesNo", dmvStudyPracQuestion.DmvStudyPracQuestionActiveYesNo);

                            parameters.Add(name: "@UpdateUserName", dmvStudyPracQuestion.UpdateUserName);
                            parameters.Add(name: "@UpdateFullName", dmvStudyPracQuestion.UpdateFullName);
                            parameters.Add(name: "@errID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                            parameters.Add(name: "@errText", dbType: DbType.String, direction: ParameterDirection.Output, size: 2047);

                            connection.Execute(sql: "[dbo].[usp_AdminInsertDmvStudyPracQuestionById]", param: parameters, commandType: CommandType.StoredProcedure);

                            if (parameters.Get<int?>(name: "@errID") != null)
                            {
                                int errID = parameters.Get<int>(name: "@errID");
                                string errText = parameters.Get<string>(name: "@errText");
                                dmvStudyPracQuestion.ErrID = errID;
                                dmvStudyPracQuestion.ErrText = errText;

                            }
                            else
                            {
                                int dmvStudyPracQuestionID = parameters.Get<int>("@DmvStudyPracQuestionID");
                                dmvStudyPracQuestion.DmvStudyPracQuestionID = dmvStudyPracQuestionID;
                            }

                        }
                        else
                        {
                            dmvStudyPracQuestion.ErrID = 1;
                            dmvStudyPracQuestion.ErrText = "DmvStudyPracQuestionID cannot be zero.";
                        }

                    }
                    else
                    {
                        dmvStudyPracQuestion = new DmvStudyPracQuestion()
                        {
                            ErrID = 1,
                            ErrText = "DmvStudyPracQuestion cannot be null."
                        };
                    }

                }
                catch (Exception exception)
                {
                    Errors(dmvStudyPracQuestion);
                    Log4ExceptionConnDb.Ex(exception);
                }
                finally
                {
                    ConnectionDb.CloseConnection(connection);
                }
            }
            return dmvStudyPracQuestion;
        }

        public DmvStudyPracQuestion Update(DmvStudyPracQuestion dmvStudyPracQuestion)
        {

            using (var connection = ConnectionDb.LiveConnection())
            {
                try
                {

                    if (dmvStudyPracQuestion != null)
                    {

                        if (dmvStudyPracQuestion.DmvStudyPracQuestionID != 0)
                        {

                            DynamicParameters parameters = new DynamicParameters();
                            parameters.Add(name: "@DmvStudyPracQuestionID", dmvStudyPracQuestion.DmvStudyPracQuestionID);
                            parameters.Add(name: "@DmvStudyPracID", dmvStudyPracQuestion.DmvStudyPracID);
                            parameters.Add(name: "@DmvStudyPracQuestionText", dmvStudyPracQuestion.DmvStudyPracQuestionText);
                            parameters.Add(name: "@DmvStudyPracQuestionAnswerText", dmvStudyPracQuestion.DmvStudyPracQuestionAnswerText);
                            parameters.Add(name: "@DmvStudyPracQuestionPicsYesNo", dmvStudyPracQuestion.DmvStudyPracQuestionPicsYesNo);
                            parameters.Add(name: "@DmvStudyPracQuestionActiveYesNo", dmvStudyPracQuestion.DmvStudyPracQuestionActiveYesNo);

                            parameters.Add(name: "@UpdateUserName", dmvStudyPracQuestion.UpdateUserName);
                            parameters.Add(name: "@UpdateFullName", dmvStudyPracQuestion.UpdateFullName);
                            parameters.Add(name: "@errID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                            parameters.Add(name: "@errText", dbType: DbType.String, direction: ParameterDirection.Output, size: 2047);

                            connection.Execute(sql: "[dbo].[usp_AdminUpdateDmvStudyPracQuestionById]", param: parameters, commandType: CommandType.StoredProcedure);

                            if (parameters.Get<int?>(name: "@errID") != null)
                            {
                                int errID = parameters.Get<int>(name: "@errID");
                                string errText = parameters.Get<string>(name: "@errText");
                                dmvStudyPracQuestion.ErrID = errID;
                                dmvStudyPracQuestion.ErrText = errText;

                            }

                        }
                        else
                        {
                            dmvStudyPracQuestion.ErrID = 1;
                            dmvStudyPracQuestion.ErrText = "DmvStudyPracQuestionID cannot be zero.";
                        }

                    }
                    else
                    {
                        dmvStudyPracQuestion = new DmvStudyPracQuestion()
                        {
                            ErrID = 1,
                            ErrText = "DmvStudyPracQuestion cannot be null."
                        };
                    }

                }
                catch (Exception exception)
                {
                    Errors(dmvStudyPracQuestion);
                    Log4ExceptionConnDb.Ex(exception);
                }
                finally
                {
                    ConnectionDb.CloseConnection(connection);
                }
            }

            return dmvStudyPracQuestion;
        }

        public DmvStudyPracQuestion Delete(int dmvStudyPracQuestionID, DmvStudyPracQuestion dmvStudyPracQuestion)
        {

            using (var connection = ConnectionDb.LiveConnection())
            {
                try
                {

                    if (dmvStudyPracQuestion != null)
                    {

                        if (dmvStudyPracQuestionID != 0)
                        {

                            DynamicParameters parameters = new DynamicParameters();
                            parameters.Add(name: "@DmvStudyPracQuestionID", dmvStudyPracQuestionID);

                            parameters.Add(name: "@UpdateUserName", dmvStudyPracQuestion.UpdateUserName);
                            parameters.Add(name: "@UpdateFullName", dmvStudyPracQuestion.UpdateFullName);
                            parameters.Add(name: "@errID", dbType: DbType.Int32, direction: ParameterDirection.Output);
                            parameters.Add(name: "@errText", dbType: DbType.String, direction: ParameterDirection.Output, size: 2047);

                            connection.Execute(sql: "[dbo].[usp_AdminDeleteDmvStudyPracQuestionById]", param: parameters, commandType: CommandType.StoredProcedure);

                            if (parameters.Get<int?>(name: "@errID") != null)
                            {
                                int errID = parameters.Get<int>(name: "@errID");
                                string errText = parameters.Get<string>(name: "@errText");
                                dmvStudyPracQuestion.ErrID = errID;
                                dmvStudyPracQuestion.ErrText = errText;
                            }
                            else
                            {
                                dmvStudyPracQuestion.DeleteTrueFalse = true;
                            }

                        }
                        else
                        {
                            dmvStudyPracQuestion.ErrID = 1;
                            dmvStudyPracQuestion.ErrText = "dmvStudyPracQuestionID cannot be zero.";
                        }
                    }
                    else
                    {
                        dmvStudyPracQuestion = new DmvStudyPracQuestion()
                        {
                            ErrID = 1,
                            ErrText = "DmvStudyPracQuestion cannot be null."
                        };
                    }

                }
                catch (Exception exception)
                {
                    Errors(dmvStudyPracQuestion);
                    Log4ExceptionConnDb.Ex(exception);
                }
                finally
                {
                    ConnectionDb.CloseConnection(connection);
                }
            }

            return dmvStudyPracQuestion;
        }

        private void Errors(DmvStudyPracQuestion dmvStudyPracQuestion)
        {
            if (dmvStudyPracQuestion != null)
            {

                dmvStudyPracQuestion.ErrID = 1;
                dmvStudyPracQuestion.ErrText = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
            }
            else
            {
                dmvStudyPracQuestion = new DmvStudyPracQuestion()
                {
                    ErrID = 1,
                    ErrText = "DmvStudyPracQuestion cannot be null."
                };
            }
        }

        #endregion

    }


}
