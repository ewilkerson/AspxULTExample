
    using System;
    using System.Collections.Generic;

    namespace AspxULTExample.Models.Interface
    {

    
    public interface IExampleLogBL
    {

    #region IExampleLogBL

    IEnumerable<ExampleLog>GetExampleLogs();

    ExampleLog GetExampleLogById(int exampleLogID);

    bool InsertExampleLog(ExampleLog exampleLog);

    bool UpdateExampleLog(ExampleLog exampleLog);

    bool DeleteExampleLog(int exampleLogID,ExampleLog exampleLog);

    Dictionary<string,string> ExampleLogIsValid(ExampleLog exampleLog);

    #endregion
    }
  

    }
  