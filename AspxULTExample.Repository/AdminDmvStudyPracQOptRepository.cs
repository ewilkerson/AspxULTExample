
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

    
    public partial class AdminDmvStudyPracQOptRepository : IRepository<DmvStudyPracQOpt>
    {

    #region AdminDmvStudyPracQOptRepository

    public IEnumerable<DmvStudyPracQOpt> GetAll()
    {
    List <DmvStudyPracQOpt> dmvStudyPracQOptLists = new List<DmvStudyPracQOpt>();

    using (var connection = ConnectionDb.LiveConnection())
    {
    try
    {
    using (var reader = connection.ExecuteReader(sql: "[dbo].[usp_AdminGetDmvStudyPracQOpts]"))
    {

    while (reader.Read())
    {
    DmvStudyPracQOpt dmvStudyPracQOpt = new DmvStudyPracQOpt();
    			if(reader["DmvStudyPracQOptID"] != DBNull.Value)
				dmvStudyPracQOpt.DmvStudyPracQOptID = int.Parse(reader["DmvStudyPracQOptID"].ToString());
			if(reader["DmvStudyPracQuestionID"] != DBNull.Value)
				dmvStudyPracQOpt.DmvStudyPracQuestionID = int.Parse(reader["DmvStudyPracQuestionID"].ToString());
			dmvStudyPracQOpt.DmvStudyPracQOptText = reader["DmvStudyPracQOptText"].ToString();
			if(reader["DmvStudyPracQOptAnswerYesNo"] != DBNull.Value)
				dmvStudyPracQOpt.DmvStudyPracQOptAnswerYesNo = bool.Parse(reader["DmvStudyPracQOptAnswerYesNo"].ToString());
			if(reader["DmvStudyPracQOptActiveYesNo"] != DBNull.Value)
				dmvStudyPracQOpt.DmvStudyPracQOptActiveYesNo = bool.Parse(reader["DmvStudyPracQOptActiveYesNo"].ToString());

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

    return dmvStudyPracQOptLists;

    }

    public DmvStudyPracQOpt GetById(int dmvStudyPracQOptID)
    {

    DmvStudyPracQOpt dmvStudyPracQOpt = new DmvStudyPracQOpt();

    using (var connection = ConnectionDb.LiveConnection())
    {
    try
    {

    if (dmvStudyPracQOptID != 0)
    {

    DynamicParameters parameters = new DynamicParameters();
    parameters.Add(name:"@DmvStudyPracQOptID", dmvStudyPracQOptID);


    using (var reader = connection.ExecuteReader(sql: "[dbo].[usp_AdminGetDmvStudyPracQOptById]", param: parameters, transaction: null, commandTimeout: null, CommandType.StoredProcedure))
    {
    if (reader.Read())
    {
    			if(reader["DmvStudyPracQOptID"] != DBNull.Value)
				dmvStudyPracQOpt.DmvStudyPracQOptID = int.Parse(reader["DmvStudyPracQOptID"].ToString());
			if(reader["DmvStudyPracQuestionID"] != DBNull.Value)
				dmvStudyPracQOpt.DmvStudyPracQuestionID = int.Parse(reader["DmvStudyPracQuestionID"].ToString());
			dmvStudyPracQOpt.DmvStudyPracQOptText = reader["DmvStudyPracQOptText"].ToString();
			if(reader["DmvStudyPracQOptAnswerYesNo"] != DBNull.Value)
				dmvStudyPracQOpt.DmvStudyPracQOptAnswerYesNo = bool.Parse(reader["DmvStudyPracQOptAnswerYesNo"].ToString());
			if(reader["DmvStudyPracQOptActiveYesNo"] != DBNull.Value)
				dmvStudyPracQOpt.DmvStudyPracQOptActiveYesNo = bool.Parse(reader["DmvStudyPracQOptActiveYesNo"].ToString());

    }
    }
    }
    else
    {
    dmvStudyPracQOpt.ErrID = 1;
    dmvStudyPracQOpt.ErrText = "dmvStudyPracQOptID cannot be zero.";
    }

    }
    catch (Exception exception)
    {
    Errors(dmvStudyPracQOpt);
    Log4ExceptionConnDb.Ex(exception);
    }
    finally
    {
    ConnectionDb.CloseConnection(connection);
    }
    }

    return dmvStudyPracQOpt;

    }

    public DmvStudyPracQOpt Insert(DmvStudyPracQOpt dmvStudyPracQOpt)
    {

    using (var connection = ConnectionDb.LiveConnection())
    {
    try
    {

    if(dmvStudyPracQOpt != null)
    {
    if(dmvStudyPracQOpt.DmvStudyPracQOptID != 0)
    {

    DynamicParameters parameters = new DynamicParameters();
    parameters.Add(name:"@DmvStudyPracQOptID", dbType: DbType.Int32, direction: ParameterDirection.Output);
parameters.Add(name:"@DmvStudyPracQuestionID", dmvStudyPracQOpt.DmvStudyPracQuestionID);
parameters.Add(name:"@DmvStudyPracQOptText", dmvStudyPracQOpt.DmvStudyPracQOptText);
parameters.Add(name:"@DmvStudyPracQOptAnswerYesNo", dmvStudyPracQOpt.DmvStudyPracQOptAnswerYesNo);
parameters.Add(name:"@DmvStudyPracQOptActiveYesNo", dmvStudyPracQOpt.DmvStudyPracQOptActiveYesNo);

    parameters.Add(name: "@UpdateUserName", dmvStudyPracQOpt.UpdateUserName);
    parameters.Add(name: "@UpdateFullName",dmvStudyPracQOpt.UpdateFullName);
    parameters.Add(name: "@errID", dbType: DbType.Int32, direction: ParameterDirection.Output);
    parameters.Add(name: "@errText", dbType: DbType.String, direction: ParameterDirection.Output, size:2047);

    connection.Execute(sql: "[dbo].[usp_AdminInsertDmvStudyPracQOptById]", param: parameters, commandType: CommandType.StoredProcedure);

    if (parameters.Get<int?>(name: "@errID") != null)
    {
    int errID = parameters.Get<int>(name: "@errID");
    string errText = parameters.Get<string>(name: "@errText");
    dmvStudyPracQOpt.ErrID = errID;
    dmvStudyPracQOpt.ErrText = errText;

    }
    else
    {
    			int dmvStudyPracQOptID = parameters.Get<int>("@DmvStudyPracQOptID");
dmvStudyPracQOpt.DmvStudyPracQOptID = dmvStudyPracQOptID;
    }

    }
    else
    {
    dmvStudyPracQOpt.ErrID = 1;
    dmvStudyPracQOpt.ErrText = "DmvStudyPracQOptID cannot be zero.";
    }

    }
    else
    {
    dmvStudyPracQOpt = new DmvStudyPracQOpt(){
    ErrID = 1,
    ErrText = "DmvStudyPracQOpt cannot be null."
    };
    }

    }
    catch (Exception exception)
    {
    Errors(dmvStudyPracQOpt);
    Log4ExceptionConnDb.Ex(exception);
    }
    finally
    {
    ConnectionDb.CloseConnection(connection);
    }
    }
    return dmvStudyPracQOpt;
    }

    public DmvStudyPracQOpt Update(DmvStudyPracQOpt dmvStudyPracQOpt)
    {

    using (var connection = ConnectionDb.LiveConnection())
    {
    try
    {

    if(dmvStudyPracQOpt != null)
    {

    if(dmvStudyPracQOpt.DmvStudyPracQOptID != 0)
    {

    DynamicParameters parameters = new DynamicParameters();
    parameters.Add(name:"@DmvStudyPracQOptID", dmvStudyPracQOpt.DmvStudyPracQOptID);
parameters.Add(name:"@DmvStudyPracQuestionID", dmvStudyPracQOpt.DmvStudyPracQuestionID);
parameters.Add(name:"@DmvStudyPracQOptText", dmvStudyPracQOpt.DmvStudyPracQOptText);
parameters.Add(name:"@DmvStudyPracQOptAnswerYesNo", dmvStudyPracQOpt.DmvStudyPracQOptAnswerYesNo);
parameters.Add(name:"@DmvStudyPracQOptActiveYesNo", dmvStudyPracQOpt.DmvStudyPracQOptActiveYesNo);

    parameters.Add(name: "@UpdateUserName", dmvStudyPracQOpt.UpdateUserName);
    parameters.Add(name: "@UpdateFullName",dmvStudyPracQOpt.UpdateFullName);
    parameters.Add(name: "@errID", dbType: DbType.Int32, direction: ParameterDirection.Output);
    parameters.Add(name: "@errText", dbType: DbType.String, direction: ParameterDirection.Output, size:2047);

    connection.Execute(sql: "[dbo].[usp_AdminUpdateDmvStudyPracQOptById]", param: parameters, commandType: CommandType.StoredProcedure);

    if (parameters.Get<int?>(name: "@errID") != null)
    {
    int errID = parameters.Get<int>(name: "@errID");
    string errText = parameters.Get<string>(name: "@errText");
    dmvStudyPracQOpt.ErrID = errID;
    dmvStudyPracQOpt.ErrText = errText;

    }

    }
    else
    {
    dmvStudyPracQOpt.ErrID = 1;
    dmvStudyPracQOpt.ErrText = "DmvStudyPracQOptID cannot be zero.";
    }

    }
    else
    {
    dmvStudyPracQOpt = new DmvStudyPracQOpt(){
    ErrID = 1,
    ErrText = "DmvStudyPracQOpt cannot be null."
    };
    }

    }
    catch (Exception exception)
    {
    Errors(dmvStudyPracQOpt);
    Log4ExceptionConnDb.Ex(exception);
    }
    finally
    {
    ConnectionDb.CloseConnection(connection);
    }
    }

    return dmvStudyPracQOpt;
    }

    public DmvStudyPracQOpt Delete(int dmvStudyPracQOptID,DmvStudyPracQOpt dmvStudyPracQOpt)
    {

    using (var connection = ConnectionDb.LiveConnection())
    {
    try
    {

    if(dmvStudyPracQOpt != null)
    {

    if(dmvStudyPracQOptID != 0)
    {

    DynamicParameters parameters = new DynamicParameters();
    parameters.Add(name:"@DmvStudyPracQOptID", dmvStudyPracQOptID);

    parameters.Add(name: "@UpdateUserName", dmvStudyPracQOpt.UpdateUserName);
    parameters.Add(name: "@UpdateFullName",dmvStudyPracQOpt.UpdateFullName);
    parameters.Add(name: "@errID", dbType: DbType.Int32, direction: ParameterDirection.Output);
    parameters.Add(name: "@errText", dbType: DbType.String, direction: ParameterDirection.Output, size:2047);

    connection.Execute(sql: "[dbo].[usp_AdminDeleteDmvStudyPracQOptById]", param: parameters, commandType: CommandType.StoredProcedure);

    if (parameters.Get<int?>(name: "@errID") != null)
    {
    int errID = parameters.Get<int>(name: "@errID");
    string errText = parameters.Get<string>(name: "@errText");
    dmvStudyPracQOpt.ErrID = errID;
    dmvStudyPracQOpt.ErrText = errText;
    }
    else
    {
    dmvStudyPracQOpt.DeleteTrueFalse = true;
    }

    }
    else
    {
    dmvStudyPracQOpt.ErrID = 1;
    dmvStudyPracQOpt.ErrText = "dmvStudyPracQOptID cannot be zero.";
    }
    }
    else
    {
    dmvStudyPracQOpt = new DmvStudyPracQOpt(){
    ErrID = 1,
    ErrText = "DmvStudyPracQOpt cannot be null."
    };
    }

    }
    catch (Exception exception)
    {
    Errors(dmvStudyPracQOpt);
    Log4ExceptionConnDb.Ex(exception);
    }
    finally
    {
    ConnectionDb.CloseConnection(connection);
    }
    }

    return dmvStudyPracQOpt;
    }

    private void Errors(DmvStudyPracQOpt dmvStudyPracQOpt)
    {
    if(dmvStudyPracQOpt != null)
    {

    dmvStudyPracQOpt.ErrID = 1;
    dmvStudyPracQOpt.ErrText = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
    }
    else
    {
    dmvStudyPracQOpt = new DmvStudyPracQOpt(){
    ErrID = 1,
    ErrText = "DmvStudyPracQOpt cannot be null."
    };
    }
    }

    #endregion

    }
  

    }
  