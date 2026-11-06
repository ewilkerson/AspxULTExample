
    using System;
    using System.Collections.Generic;

    namespace AspxULTExample.Models.Interface
    {

    
    public interface IExampleLogRepository
    {

    #region IExampleLogRepository

    IEnumerable<ExampleLog>GetExampleLogs();

    ExampleLog GetExampleLogById(int exampleLogID);

    ExampleLog InsertExampleLog(ExampleLog exampleLog);

    ExampleLog UpdateExampleLog(ExampleLog exampleLog);

    ExampleLog DeleteExampleLog(int exampleLogID,ExampleLog exampleLog);

    #endregion
    }
  

    }
  