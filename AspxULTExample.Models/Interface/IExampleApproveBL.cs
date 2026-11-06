
    using System;
    using System.Collections.Generic;

    namespace AspxULTExample.Models.Interface
    {

    
    public interface IExampleApproveBL
    {

    #region IExampleApproveBL

    IEnumerable<ExampleApprove>GetExampleApproves();

    ExampleApprove GetExampleApproveById(int exampleApproveID);

    bool InsertExampleApprove(ExampleApprove exampleApprove);

    bool UpdateExampleApprove(ExampleApprove exampleApprove);

    bool DeleteExampleApprove(int exampleApproveID,ExampleApprove exampleApprove);

    Dictionary<string,string> ExampleApproveIsValid(ExampleApprove exampleApprove);

    #endregion
    }
  

    }
  