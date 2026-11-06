
    using System;
    using System.Collections.Generic;

    namespace AspxULTExample.Models.Interface
    {

    
    public interface IViewExampleBL
    {

    #region IViewExampleBL

    IEnumerable<ViewExample>GetViewExamples(int userInfoID);

    IEnumerable<ExampleApprove> GetViewExampleApprovesById(int exampleID);

    IEnumerable<ExampleLog> GetViewExampleLogsById(int exampleID);

    IEnumerable<UserInfoUserInfoCompanyXref> GetLoadUserInfoUserInfoCompanyXrefsById(int userInfoID);

    ViewExample GetViewExampleById(int exampleID);

    bool InsertViewExample(ViewExample viewExample);

    bool UpdateViewExample(ViewExample viewExample);

    bool SignedUnsignedUpdateViewExample(ViewExample viewExample);

    bool ApproveCompeteRejectRevokeViewExample(ViewExample viewExample, string noteMessage);

    bool DeleteViewExample(int exampleID,ViewExample viewExample);

    Dictionary<string,string> ViewExampleIsValid(ViewExample viewExample);

    #endregion
    }
  

    }
  