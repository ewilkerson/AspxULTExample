
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


    public partial class AdminDmvStudyPracQOpt2Repository : IRepository2<DmvStudyPracQOpt>
    {

        #region AdminDmvStudyPracQOpt2Repository

        public IEnumerable<DmvStudyPracQOpt> GetAllById(int dmvStudyPracQuestionID)
        {
            List<DmvStudyPracQOpt> dmvStudyPracQOptLists = new List<DmvStudyPracQOpt>();

            if (dmvStudyPracQuestionID != 0)
            {

                using (var connection = ConnectionDb.LiveConnection())
                {
                    try
                    {
                        DynamicParameters parameters = new DynamicParameters();
                        parameters.Add(name: "@DmvStudyPracQuestionID", dmvStudyPracQuestionID);

                        using (var reader = connection.ExecuteReader(sql: "[dbo].[usp_AdminGetDmvStudyPracQOptsById]"))
                        {

                            while (reader.Read())
                            {
                                DmvStudyPracQOpt dmvStudyPracQOpt = new DmvStudyPracQOpt();
                                if (reader["DmvStudyPracQOptID"] != DBNull.Value)
                                    dmvStudyPracQOpt.DmvStudyPracQOptID =
                                        int.Parse(reader["DmvStudyPracQOptID"].ToString());
                                if (reader["DmvStudyPracQuestionID"] != DBNull.Value)
                                    dmvStudyPracQOpt.DmvStudyPracQuestionID =
                                        int.Parse(reader["DmvStudyPracQuestionID"].ToString());
                                dmvStudyPracQOpt.DmvStudyPracQOptText = reader["DmvStudyPracQOptText"].ToString();
                                if (reader["DmvStudyPracQOptAnswerYesNo"] != DBNull.Value)
                                    dmvStudyPracQOpt.DmvStudyPracQOptAnswerYesNo =
                                        bool.Parse(reader["DmvStudyPracQOptAnswerYesNo"].ToString());
                                if (reader["DmvStudyPracQOptActiveYesNo"] != DBNull.Value)
                                    dmvStudyPracQOpt.DmvStudyPracQOptActiveYesNo =
                                        bool.Parse(reader["DmvStudyPracQOptActiveYesNo"].ToString());

                                dmvStudyPracQOptLists.Add(dmvStudyPracQOpt);
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
            }

            return dmvStudyPracQOptLists;

        }

        #endregion

    }


}
