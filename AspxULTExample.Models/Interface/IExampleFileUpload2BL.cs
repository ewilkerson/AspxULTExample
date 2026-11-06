
using System;
using System.Collections.Generic;

namespace AspxULTExample.Models.Interface
{


    public interface IExampleFileUpload2BL
    {

        #region IExampleFileUpload2BL

        IEnumerable<ExampleFileUpload2> GetExampleFileUpload2s();

        ExampleFileUpload2 GetExampleFileUpload2ById(int exampleFileUpload2ID);

        bool InsertExampleFileUpload2(ExampleFileUpload2 exampleFileUpload2);

        bool UpdateExampleFileUpload2(ExampleFileUpload2 exampleFileUpload2);

        bool DeleteExampleFileUpload2(int exampleFileUpload2ID, ExampleFileUpload2 exampleFileUpload2);

        Dictionary<string, string> ExampleFileUpload2IsValid(ExampleFileUpload2 exampleFileUpload2);

        #endregion
    }


}
