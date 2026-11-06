
using System;
using System.Collections.Generic;

namespace AspxULTExample.Models.Interface
{


    public interface IViewExampleFileUpload2BL
    {

        #region IViewExampleFileUpload2BL

        IEnumerable<ViewExampleFileUpload2> GetViewExampleFileUpload2s();

        ViewExampleFileUpload2 GetViewExampleFileUpload2ById(int exampleFileUpload2ID);

        bool InsertViewExampleFileUpload2(ViewExampleFileUpload2 viewExampleFileUpload2);

        bool UpdateViewExampleFileUpload2(ViewExampleFileUpload2 viewExampleFileUpload2);

        bool DeleteViewExampleFileUpload2(int exampleFileUpload2ID, ViewExampleFileUpload2 viewExampleFileUpload2);

        Dictionary<string, string> ViewExampleFileUpload2IsValid(ViewExampleFileUpload2 viewExampleFileUpload2);

        #endregion
    }


}
