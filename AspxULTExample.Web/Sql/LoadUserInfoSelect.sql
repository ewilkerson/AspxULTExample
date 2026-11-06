
    USE [ULTExampleDb]
    GO

    -- =============================================
    -- Author:		Earl L. Wilkerson Jr.
    -- Create date: 12/11/2025 10:47:29 PM
    -- Description:	<Description,,>
    -- =============================================
    CREATE OR ALTER PROCEDURE [dbo].[usp_GetLoadUserInfoByString]
    @UserInfoUserIdentityName nvarchar(100)
    AS
    BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    SELECT U.[UserInfoID]
    ,U.[UserInfoUserIdentityName]
    ,U.[UserInfoUserName]
    ,U.[UserInfoFullName]
    ,U.[UserInfoEmailAddress]
    ,U.[UserInfoJobTitle]
    ,U.[UserInfoActiveYesNo]
    ,UAL.[UserInfoAccessLevelID]
    ,UAL.UserInfoAccessLevelName
    FROM [dbo].[UserInfoUserInfoAccessLevelXref] AS UUALX
    JOIN [dbo].[UserInfo]						 AS U     ON U.[UserInfoID] = UUALX.[UserInfoID]
    JOIN [dbo].[UserInfoAccessLevel]			 AS UAL   ON UAL.[UserInfoAccessLevelID] = UUALX.[UserInfoAccessLevelID]
    WHERE U.[UserInfoUserIdentityName] = @UserInfoUserIdentityName AND U.[UserInfoActiveYesNo] = 1;

    END;
    Go

    -- =============================================
    -- Author:		Earl L. Wilkerson Jr.
    -- Create date: 12/11/2025 10:47:29 PM
    -- Description:	<Description,,>
    -- =============================================
    CREATE OR ALTER PROCEDURE [dbo].[usp_AdminGetLoadUserInfos]
    AS
    BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    SELECT U.[UserInfoID]
    ,U.[UserInfoUserIdentityName]
    ,U.[UserInfoUserName]
    ,U.[UserInfoFullName]
    ,U.[UserInfoEmailAddress]
    ,U.[UserInfoJobTitle]
    ,U.[UserInfoActiveYesNo]
    ,UAL.[UserInfoAccessLevelID]
    ,UAL.UserInfoAccessLevelName
    FROM [dbo].[UserInfoUserInfoAccessLevelXref] AS UUALX
    JOIN [dbo].[UserInfo]						 AS U     ON U.[UserInfoID] = UUALX.[UserInfoID]
    JOIN [dbo].[UserInfoAccessLevel]			 AS UAL   ON UAL.[UserInfoAccessLevelID] = UUALX.[UserInfoAccessLevelID];

    END
    GO

    GO

    -- =============================================
    -- Author:		Earl L. Wilkerson Jr.
    -- Create date: 12/11/2025 10:47:29 PM
    -- Description:	<Description,,>
    -- =============================================
    CREATE OR ALTER PROCEDURE [dbo].[usp_AdminGetLoadUserInfoById]
    @UserInfoID [int]
    AS
    BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    SELECT U.[UserInfoID]
    ,U.[UserInfoUserIdentityName]
    ,U.[UserInfoUserName]
    ,U.[UserInfoFullName]
    ,U.[UserInfoEmailAddress]
    ,U.[UserInfoJobTitle]
    ,U.[UserInfoActiveYesNo]
    ,UAL.[UserInfoAccessLevelID]
    ,UAL.UserInfoAccessLevelName
    FROM [dbo].[UserInfoUserInfoAccessLevelXref] AS UUALX
    JOIN [dbo].[UserInfo]						 AS U     ON U.[UserInfoID] = UUALX.[UserInfoID]
    JOIN [dbo].[UserInfoAccessLevel]			 AS UAL   ON UAL.[UserInfoAccessLevelID] = UUALX.[UserInfoAccessLevelID]
    WHERE U.[UserInfoID] = @UserInfoID;

    END
    GO

    -- =============================================
    -- Author:		Earl L. Wilkerson Jr.
    -- Create date: 12/11/2025 10:47:29 PM
    -- Description:	<Description,,>
    -- =============================================
    CREATE OR ALTER   PROCEDURE [dbo].[usp_GetLoadUserInfoUserInfoCompanyXrefsById]
    @UserInfoID [int]
    AS
    BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    SELECT
    UUC.UserInfoID,
    UUC.UserInfoCompanyID,
    UC.UserInfoCompanyName
    FROM [dbo].[UserInfoUserInfoCompanyXref] UUC
    JOIN [dbo].[UserInfoCompany] UC ON UUC.UserInfoCompanyID = UC.UserInfoCompanyID
    WHERE  UUC.[UserInfoID] = @UserInfoID AND
    UUC.[UserInfoUserInfoCompanyXrefActiveYesNo] = 1
    ORDER BY UserInfoCompanyName ASC;

    END

    GO

    -- =============================================
    -- Author:		Earl L. Wilkerson Jr.
    -- Create date: 12/11/2025 10:47:29 PM
    -- Description:	<Description,,>
    -- =============================================
    CREATE OR ALTER PROCEDURE [dbo].[usp_GetLoadUserInfoEmailAddressByCompanyID]
    @CompanyID int
    AS
    BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    --
    --   SELECT U.[UserInfoID]
    --   ,U.[UserInfoUserName]
    --   ,U.[UserInfoFullName]
    --,U.[UserInfoActiveYesNo]
    --,U.[UserInfoEmailAddress]
    --,UAL.[UserInfoAccessLevelID]
    --   ,UAL.UserInfoAccessLevelName
    --,UC.UserInfoCompanyName
    --,UC.UserInfoCompanyID
    --   FROM [dbo].[UserInfoUserInfoCompanyXref]		 AS UUC
    --JOIN [dbo].[UserInfoCompany]                 AS UC    ON UUC.[UserInfoCompanyID] = UC.[UserInfoCompanyID]
    --JOIN [dbo].[UserInfoUserInfoAccessLevelXref] AS UUALX ON UUC.[UserInfoID] = UUALX.[UserInfoID]
    --JOIN [dbo].[UserInfo]						 AS U     ON U.[UserInfoID] = [dbo].[usp_GetUserInfoAccessLevels]UUALX.[UserInfoID]
    --   JOIN [dbo].[UserInfoAccessLevel]			 AS UAL   ON UAL.[UserInfoAccessLevelID] = UUALX.[UserInfoAccessLevelID]


    SET NOCOUNT ON;

    SELECT UUC.[UserInfoCompanyID]
    ,U.[UserInfoFullName]
    ,U.[UserInfoEmailAddress]
    ,UUALX.[UserInfoAccessLevelID]
    FROM [dbo].[UserInfoUserInfoCompanyXref]		 AS UUC
    JOIN [dbo].[UserInfo]						 AS U     ON U.[UserInfoID] = UUC.[UserInfoID]
    JOIN [dbo].[UserInfoUserInfoAccessLevelXref] AS UUALX ON  UUALX.[UserInfoID] = U.[UserInfoID]
    WHERE UUC.[UserInfoCompanyID] = @CompanyID AND
    UUC.[UserInfoUserInfoCompanyXrefActiveYesNo] = 1 AND
    UUC.[UserInfoUserInfoCompanyXrefEmailAddressActiveYesNo] = 1 AND
    U.UserInfoActiveYesNo = 1;

    END;

    GO
  