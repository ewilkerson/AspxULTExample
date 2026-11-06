
    using System;
    using System.Collections.Generic;

    namespace AspxULTExample.Models.Interface
    {

    
    public interface IExampleApproveRepository
    {

    #region IExampleApproveRepository

    IEnumerable<ExampleApprove>GetExampleApproves();

    ExampleApprove GetExampleApproveById(int exampleApproveID);

    ExampleApprove InsertExampleApprove(ExampleApprove exampleApprove);

    ExampleApprove UpdateExampleApprove(ExampleApprove exampleApprove);

    ExampleApprove DeleteExampleApprove(int exampleApproveID,ExampleApprove exampleApprove);

    #endregion
    }
  

    }
  