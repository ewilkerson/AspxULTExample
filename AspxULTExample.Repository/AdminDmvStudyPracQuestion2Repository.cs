
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


    public partial class AdminDmvStudyPracQuestion2Repository : IRepository3<DmvStudyPracQuestion>
    {

        #region AdminDmvStudyPracQuestion2Repository

        public IEnumerable<DmvStudyPracQuestion> GetAll_Ten()
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

                    List<DmvStudyPracQuestion> dmvStudyPracQuestionTenLists = dmvStudyPracQuestionLists.Where(x => x.DmvStudyPracID == 1).ToList();

                    int intCount = 10;
                    RandomObject randomize = new RandomObject();
                    List<DmvStudyPracQuestion> dmvStudyPracQuestionsRandomizeList =
                        randomize.Randomize<DmvStudyPracQuestion>(dmvStudyPracQuestionTenLists).GetRange(0, intCount);

                    dmvStudyPracQuestionLists = dmvStudyPracQuestionsRandomizeList;

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

        public IEnumerable<DmvStudyPracQuestion> GetAll_Thirty()
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

                    int intCount = 10; //30
                    RandomObject randomize = new RandomObject();
                    List<DmvStudyPracQuestion> dmvStudyPracQuestionsRandomizeList =
                        randomize.Randomize<DmvStudyPracQuestion>(dmvStudyPracQuestionLists).GetRange(0, intCount);

                    dmvStudyPracQuestionLists = dmvStudyPracQuestionsRandomizeList;

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

        #endregion

    }


}
