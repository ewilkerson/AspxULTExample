
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

    
    public partial class AdminDmvStudyPractRepository : IRepository<DmvStudyPract>
    {

    #region AdminDmvStudyPractRepository

    public IEnumerable<DmvStudyPract> GetAll()
    {
    List <DmvStudyPract> dmvStudyPractLists = new List<DmvStudyPract>();

    using (var connection = ConnectionDb.LiveConnection())
    {
    try
    {
    using (var reader = connection.ExecuteReader(sql: "[dbo].[usp_AdminGetDmvStudyPracts]"))
    {

    while (reader.Read())
    {
    DmvStudyPract dmvStudyPract = new DmvStudyPract();
    			if(reader["DmvStudyPractID"] != DBNull.Value)
				dmvStudyPract.DmvStudyPractID = int.Parse(reader["DmvStudyPractID"].ToString());
			if(reader["DmvStudyPractNum"] != DBNull.Value)
				dmvStudyPract.DmvStudyPractNum = int.Parse(reader["DmvStudyPractNum"].ToString());
			dmvStudyPract.DmvStudyPractTitle = reader["DmvStudyPractTitle"].ToString();
			if(reader["DmvStudyPractActiveYesNo"] != DBNull.Value)
				dmvStudyPract.DmvStudyPractActiveYesNo = bool.Parse(reader["DmvStudyPractActiveYesNo"].ToString());

    dmvStudyPractLists.Add(dmvStudyPract);
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

    return dmvStudyPractLists;

    }

    public DmvStudyPract GetById(int dmvStudyPractID)
    {

    DmvStudyPract dmvStudyPract = new DmvStudyPract();

    using (var connection = ConnectionDb.LiveConnection())
    {
    try
    {

    if (dmvStudyPractID != 0)
    {

    DynamicParameters parameters = new DynamicParameters();
    parameters.Add(name:"@DmvStudyPractID", dmvStudyPractID);


    using (var reader = connection.ExecuteReader(sql: "[dbo].[usp_AdminGetDmvStudyPractById]", param: parameters, transaction: null, commandTimeout: null, CommandType.StoredProcedure))
    {
    if (reader.Read())
    {
    			if(reader["DmvStudyPractID"] != DBNull.Value)
				dmvStudyPract.DmvStudyPractID = int.Parse(reader["DmvStudyPractID"].ToString());
			if(reader["DmvStudyPractNum"] != DBNull.Value)
				dmvStudyPract.DmvStudyPractNum = int.Parse(reader["DmvStudyPractNum"].ToString());
			dmvStudyPract.DmvStudyPractTitle = reader["DmvStudyPractTitle"].ToString();
			if(reader["DmvStudyPractActiveYesNo"] != DBNull.Value)
				dmvStudyPract.DmvStudyPractActiveYesNo = bool.Parse(reader["DmvStudyPractActiveYesNo"].ToString());

    }
    }
    }
    else
    {
    dmvStudyPract.ErrID = 1;
    dmvStudyPract.ErrText = "dmvStudyPractID cannot be zero.";
    }

    }
    catch (Exception exception)
    {
    Errors(dmvStudyPract);
    Log4ExceptionConnDb.Ex(exception);
    }
    finally
    {
    ConnectionDb.CloseConnection(connection);
    }
    }

    return dmvStudyPract;

    }

    public DmvStudyPract Insert(DmvStudyPract dmvStudyPract)
    {

    using (var connection = ConnectionDb.LiveConnection())
    {
    try
    {

    if(dmvStudyPract != null)
    {
    if(dmvStudyPract.DmvStudyPractID != 0)
    {

    DynamicParameters parameters = new DynamicParameters();
    parameters.Add(name:"@DmvStudyPractID", dbType: DbType.Int32, direction: ParameterDirection.Output);
parameters.Add(name:"@DmvStudyPractNum", dmvStudyPract.DmvStudyPractNum);
parameters.Add(name:"@DmvStudyPractTitle", dmvStudyPract.DmvStudyPractTitle);
parameters.Add(name:"@DmvStudyPractActiveYesNo", dmvStudyPract.DmvStudyPractActiveYesNo);

    parameters.Add(name: "@UpdateUserName", dmvStudyPract.UpdateUserName);
    parameters.Add(name: "@UpdateFullName",dmvStudyPract.UpdateFullName);
    parameters.Add(name: "@errID", dbType: DbType.Int32, direction: ParameterDirection.Output);
    parameters.Add(name: "@errText", dbType: DbType.String, direction: ParameterDirection.Output, size:2047);

    connection.Execute(sql: "[dbo].[usp_AdminInsertDmvStudyPractById]", param: parameters, commandType: CommandType.StoredProcedure);

    if (parameters.Get<int?>(name: "@errID") != null)
    {
    int errID = parameters.Get<int>(name: "@errID");
    string errText = parameters.Get<string>(name: "@errText");
    dmvStudyPract.ErrID = errID;
    dmvStudyPract.ErrText = errText;

    }
    else
    {
    			int dmvStudyPractID = parameters.Get<int>("@DmvStudyPractID");
dmvStudyPract.DmvStudyPractID = dmvStudyPractID;
    }

    }
    else
    {
    dmvStudyPract.ErrID = 1;
    dmvStudyPract.ErrText = "DmvStudyPractID cannot be zero.";
    }

    }
    else
    {
    dmvStudyPract = new DmvStudyPract(){
    ErrID = 1,
    ErrText = "DmvStudyPract cannot be null."
    };
    }

    }
    catch (Exception exception)
    {
    Errors(dmvStudyPract);
    Log4ExceptionConnDb.Ex(exception);
    }
    finally
    {
    ConnectionDb.CloseConnection(connection);
    }
    }
    return dmvStudyPract;
    }

    public DmvStudyPract Update(DmvStudyPract dmvStudyPract)
    {

    using (var connection = ConnectionDb.LiveConnection())
    {
    try
    {

    if(dmvStudyPract != null)
    {

    if(dmvStudyPract.DmvStudyPractID != 0)
    {

    DynamicParameters parameters = new DynamicParameters();
    parameters.Add(name:"@DmvStudyPractID", dmvStudyPract.DmvStudyPractID);
parameters.Add(name:"@DmvStudyPractNum", dmvStudyPract.DmvStudyPractNum);
parameters.Add(name:"@DmvStudyPractTitle", dmvStudyPract.DmvStudyPractTitle);
parameters.Add(name:"@DmvStudyPractActiveYesNo", dmvStudyPract.DmvStudyPractActiveYesNo);

    parameters.Add(name: "@UpdateUserName", dmvStudyPract.UpdateUserName);
    parameters.Add(name: "@UpdateFullName",dmvStudyPract.UpdateFullName);
    parameters.Add(name: "@errID", dbType: DbType.Int32, direction: ParameterDirection.Output);
    parameters.Add(name: "@errText", dbType: DbType.String, direction: ParameterDirection.Output, size:2047);

    connection.Execute(sql: "[dbo].[usp_AdminUpdateDmvStudyPractById]", param: parameters, commandType: CommandType.StoredProcedure);

    if (parameters.Get<int?>(name: "@errID") != null)
    {
    int errID = parameters.Get<int>(name: "@errID");
    string errText = parameters.Get<string>(name: "@errText");
    dmvStudyPract.ErrID = errID;
    dmvStudyPract.ErrText = errText;

    }

    }
    else
    {
    dmvStudyPract.ErrID = 1;
    dmvStudyPract.ErrText = "DmvStudyPractID cannot be zero.";
    }

    }
    else
    {
    dmvStudyPract = new DmvStudyPract(){
    ErrID = 1,
    ErrText = "DmvStudyPract cannot be null."
    };
    }

    }
    catch (Exception exception)
    {
    Errors(dmvStudyPract);
    Log4ExceptionConnDb.Ex(exception);
    }
    finally
    {
    ConnectionDb.CloseConnection(connection);
    }
    }

    return dmvStudyPract;
    }

    public DmvStudyPract Delete(int dmvStudyPractID,DmvStudyPract dmvStudyPract)
    {

    using (var connection = ConnectionDb.LiveConnection())
    {
    try
    {

    if(dmvStudyPract != null)
    {

    if(dmvStudyPractID != 0)
    {

    DynamicParameters parameters = new DynamicParameters();
    parameters.Add(name:"@DmvStudyPractID", dmvStudyPractID);

    parameters.Add(name: "@UpdateUserName", dmvStudyPract.UpdateUserName);
    parameters.Add(name: "@UpdateFullName",dmvStudyPract.UpdateFullName);
    parameters.Add(name: "@errID", dbType: DbType.Int32, direction: ParameterDirection.Output);
    parameters.Add(name: "@errText", dbType: DbType.String, direction: ParameterDirection.Output, size:2047);

    connection.Execute(sql: "[dbo].[usp_AdminDeleteDmvStudyPractById]", param: parameters, commandType: CommandType.StoredProcedure);

    if (parameters.Get<int?>(name: "@errID") != null)
    {
    int errID = parameters.Get<int>(name: "@errID");
    string errText = parameters.Get<string>(name: "@errText");
    dmvStudyPract.ErrID = errID;
    dmvStudyPract.ErrText = errText;
    }
    else
    {
    dmvStudyPract.DeleteTrueFalse = true;
    }

    }
    else
    {
    dmvStudyPract.ErrID = 1;
    dmvStudyPract.ErrText = "dmvStudyPractID cannot be zero.";
    }
    }
    else
    {
    dmvStudyPract = new DmvStudyPract(){
    ErrID = 1,
    ErrText = "DmvStudyPract cannot be null."
    };
    }

    }
    catch (Exception exception)
    {
    Errors(dmvStudyPract);
    Log4ExceptionConnDb.Ex(exception);
    }
    finally
    {
    ConnectionDb.CloseConnection(connection);
    }
    }

    return dmvStudyPract;
    }

    private void Errors(DmvStudyPract dmvStudyPract)
    {
    if(dmvStudyPract != null)
    {

    dmvStudyPract.ErrID = 1;
    dmvStudyPract.ErrText = "Unable to save changes. Try again, and if the problem persists see your system administrator.";
    }
    else
    {
    dmvStudyPract = new DmvStudyPract(){
    ErrID = 1,
    ErrText = "DmvStudyPract cannot be null."
    };
    }
    }

    #endregion

    }
  

    }
  