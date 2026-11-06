
    USE [ULTExampleDb]
    GO

    -- =============================================
    -- Author:		Earl L. Wilkerson Jr.
    -- Create date: 12/11/2025 10:47:29 PM
    -- Description:	<Description,,>
    -- =============================================
    CREATE OR ALTER PROCEDURE [dbo].[usp_AdminInsertLoadUserInfoById]
    @UserInfoID [int] OUTPUT,
    @UserInfoUserIdentityName [nvarchar](50),
    @UserInfoUserName [nvarchar](50),
    @UserInfoFullName [nvarchar](50),
    @UserInfoEmailAddress [nvarchar](50),
    @UserInfoJobTitle [nvarchar](50),
    @UserInfoActiveYesNo [bit],
    @UserInfoAccessLevelID [int],
    @UpdateUserName	[nvarchar](50),
    @UpdateFullName [nvarchar](50),
    @errID  [int]       OUTPUT,
    @errText  [NVARCHAR](2047) OUTPUT

    AS
    BEGIN

    BEGIN TRY

    SET NOCOUNT ON;

    SET XACT_ABORT ON;

    BEGIN TRANSACTION;

    DECLARE @CreateDate datetime = GETDATE();
    INSERT INTO [dbo].[UserInfo] ([UserInfoUserIdentityName], [UserInfoUserName],[UserInfoFullName],[UserInfoEmailAddress],[UserInfoJobTitle],[UserInfoActiveYesNo], [CreateUserName], [CreateFullName], [CreateDate], [UpdateUserName], [UpdateFullName]) VALUES (@UserInfoUserIdentityName, @UserInfoUserName,@UserInfoFullName,@UserInfoEmailAddress,@UserInfoJobTitle,@UserInfoActiveYesNo, @UpdateUserName, @UpdateFullName, @CreateDate, @UpdateUserName, @UpdateFullName);


    SET @UserInfoID = SCOPE_IDENTITY();

    INSERT INTO [dbo].[UserInfoUserInfoAccessLevelXref]
    ([UserInfoID]
    ,[UserInfoAccessLevelID]
    ,[UpdateUserName]
    ,[UpdateFullName])
    VALUES
    (@UserInfoID
    ,@UserInfoAccessLevelID
    ,@UpdateUserName, @UpdateFullName)


    COMMIT TRANSACTION;

    END TRY

    BEGIN CATCH

    IF(@@TRANCOUNT > 0)
    ROLLBACK TRANSACTION;

    DECLARE @LogErrorMessageId [int] = ERROR_NUMBER(),
    @LogErrorMessageText [nvarchar](2047) = ERROR_MESSAGE(),
    @LogErrorSeverityLevel [int] = ERROR_SEVERITY(),
    @LogErrorState [int] = ERROR_STATE(),
    @LogErrorLineNumber [int] = ERROR_LINE(),
    @LogErrorProcedureName [nvarchar](2500) = ERROR_PROCEDURE();

    DECLARE @RC int;

    EXECUTE @RC = [dbo].[usp_LogErrorMessage] @LogErrorMessageId,
    @LogErrorMessageText,
    @LogErrorSeverityLevel,
    @LogErrorState,
    @LogErrorLineNumber,
    @LogErrorProcedureName,
    @UpdateUserName,
    @UpdateFullName;

    SET @errID =  @LogErrorMessageId;
    SET @errText = @LogErrorMessageText;


    END CATCH


    END
    GO

    -- =============================================
    -- Author:		Earl L. Wilkerson Jr.
    -- Create date: 12/11/2025 10:47:29 PM
    -- Description:	<Description,,>
    -- =============================================
    CREATE OR ALTER PROCEDURE [dbo].[usp_AdminUpdateLoadUserInfoById]
    @UserInfoID [int],
    @UserInfoUserIdentityName [nvarchar](50),
    @UserInfoUserName [nvarchar](50),
    @UserInfoFullName [nvarchar](50),
    @UserInfoEmailAddress [nvarchar](50),
    @UserInfoJobTitle [nvarchar](50),
    @UserInfoActiveYesNo [bit],
    @UserInfoAccessLevelID [int],
    @UpdateUserName	[nvarchar](50),
    @UpdateFullName [nvarchar](50),
    @errID  [int]       OUTPUT,
    @errText  [NVARCHAR](2047) OUTPUT

    AS
    BEGIN

    BEGIN TRY

    SET NOCOUNT ON;

    SET XACT_ABORT ON;

    BEGIN TRANSACTION;

    DECLARE @UpdateDate datetime = GETDATE();


    UPDATE [dbo].[UserInfo] SET
    [UserInfoUserIdentityName] = @UserInfoUserIdentityName,
    [UserInfoUserName] = @UserInfoUserName,
    [UserInfoFullName] = @UserInfoFullName,
    [UserInfoEmailAddress] = @UserInfoEmailAddress,
    [UserInfoJobTitle] = @UserInfoJobTitle,
    [UserInfoActiveYesNo] = @UserInfoActiveYesNo,

    [UpdateUserName] = @UpdateUserName,
    [UpdateFullName] = @UpdateFullName,
    [UpdateDate] = @UpdateDate
    WHERE [UserInfoID] = @UserInfoID;

    UPDATE [dbo].[UserInfoUserInfoAccessLevelXref] SET
    [UserInfoAccessLevelID] = @UserInfoAccessLevelID,
    [UpdateUserName] = @UpdateUserName,
    [UpdateFullName] = @UpdateFullName,
    [UpdateDate] = @UpdateDate
    WHERE [UserInfoID] = @UserInfoID;


    COMMIT TRANSACTION;

    END TRY

    BEGIN CATCH

    IF(@@TRANCOUNT > 0)
    ROLLBACK TRANSACTION;

    DECLARE @LogErrorMessageId [int] = ERROR_NUMBER(),
    @LogErrorMessageText [nvarchar](2047) = ERROR_MESSAGE(),
    @LogErrorSeverityLevel [int] = ERROR_SEVERITY(),
    @LogErrorState [int] = ERROR_STATE(),
    @LogErrorLineNumber [int] = ERROR_LINE(),
    @LogErrorProcedureName [nvarchar](2500) = ERROR_PROCEDURE();

    DECLARE @RC int;

    EXECUTE @RC = [dbo].[usp_LogErrorMessage] @LogErrorMessageId,
    @LogErrorMessageText,
    @LogErrorSeverityLevel,
    @LogErrorState,
    @LogErrorLineNumber,
    @LogErrorProcedureName,
    @UpdateUserName,
    @UpdateFullName;

    SET @errID =  @LogErrorMessageId;
    SET @errText = @LogErrorMessageText;


    END CATCH


    END
    GO

    -- =============================================
    -- Author:		Earl L. Wilkerson Jr.
    -- Create date: 12/11/2025 10:47:29 PM
    -- Description:	<Description,,>
    -- =============================================
    CREATE OR ALTER PROCEDURE [dbo].[usp_AdminDeleteLoadUserInfoById]
    @UserInfoID [int],
    @UpdateUserName	[nvarchar](50),
    @UpdateFullName [nvarchar](50),
    @errID  [int]       OUTPUT,
    @errText  [NVARCHAR](2047) OUTPUT

    AS
    BEGIN

    BEGIN TRY

    SET NOCOUNT ON;

    SET XACT_ABORT ON;

    BEGIN TRANSACTION;

    DELETE FROM [dbo].[UserInfoUserInfoAccessLevelXref]
    WHERE [UserInfoID] = @UserInfoID;

    DELETE FROM [dbo].[UserInfo]
    WHERE [UserInfoID] = @UserInfoID;

    COMMIT TRANSACTION;

    END TRY

    BEGIN CATCH

    IF(@@TRANCOUNT > 0)
    ROLLBACK TRANSACTION;

    DECLARE @LogErrorMessageId [int] = ERROR_NUMBER(),
    @LogErrorMessageText [nvarchar](2047) = ERROR_MESSAGE(),
    @LogErrorSeverityLevel [int] = ERROR_SEVERITY(),
    @LogErrorState [int] = ERROR_STATE(),
    @LogErrorLineNumber [int] = ERROR_LINE(),
    @LogErrorProcedureName [nvarchar](2500) = ERROR_PROCEDURE();

    DECLARE @RC int;

    EXECUTE @RC = [dbo].[usp_LogErrorMessage] @LogErrorMessageId,
    @LogErrorMessageText,
    @LogErrorSeverityLevel,
    @LogErrorState,
    @LogErrorLineNumber,
    @LogErrorProcedureName,
    @UpdateUserName,
    @UpdateFullName;

    SET @errID =  @LogErrorMessageId;
    SET @errText = @LogErrorMessageText;


    END CATCH


    END
    GO
  