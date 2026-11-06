
    USE [ULTExampleDb]
    GO

    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO

    -- =============================================
    -- Author:		Earl L. Wilkerson Jr.
    -- Create date: 12/11/2025 10:47:29 PM
    -- Description:	<Description,,>
    -- =============================================

    CREATE OR ALTER  PROCEDURE [dbo].[usp_LogErrorMessage]
    (@MessageId [int],
    @MessageText [nvarchar](2047),
    @SeverityLevel [int],
    @State [int],
    @LineNumber [int],
    @ProcedureName [nvarchar](2500),
    @UpdateUserName [nvarchar](100),
    @UpdateFullName [nvarchar](100)
    )
    AS
    BEGIN

    DECLARE @RC int, @Id int

    SET @ProcedureName = 'ULTExampleDb Application => ' + @ProcedureName;

    EXECUTE @RC = [Log4Exception].[dbo].[usp_LogErrorMessageProcedure] @MessageId,
    @MessageText,
    @SeverityLevel,
    @State,
    @LineNumber,
    @ProcedureName,
    @UpdateUserName,
    @UpdateFullName,
    @Id OUTPUT;

    END
    GO


    
    -- =============================================
    -- Author:		Earl L. Wilkerson Jr.
    -- Create date: 12/11/2025 10:47:29 PM
    -- Description:	<Description,,>
    -- =============================================
    CREATE OR ALTER PROCEDURE [dbo].[usp_AdminInsertDmvStudyPracQOptById]
    @DmvStudyPracQOptID [int] OUTPUT,
@DmvStudyPracQuestionID [int],
@DmvStudyPracQOptText [varchar](100),
@DmvStudyPracQOptAnswerYesNo [bit],
@DmvStudyPracQOptAnswerText [varchar](500),
@DmvStudyPracQOptActiveYesNo [bit],

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

    INSERT INTO [dbo].[DmvStudyPracQOpt] ([DmvStudyPracQuestionID],[DmvStudyPracQOptText],[DmvStudyPracQOptAnswerYesNo],[DmvStudyPracQOptAnswerText],[DmvStudyPracQOptActiveYesNo], [CreateUserName], [CreateFullName], [CreateDate], [UpdateUserName], [UpdateFullName]) VALUES (@DmvStudyPracQuestionID,@DmvStudyPracQOptText,@DmvStudyPracQOptAnswerYesNo,@DmvStudyPracQOptAnswerText,@DmvStudyPracQOptActiveYesNo, @UpdateUserName, @UpdateFullName, @CreateDate, @UpdateUserName, @UpdateFullName);

    
SET @DmvStudyPracQOptID = SCOPE_IDENTITY();

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
    CREATE OR ALTER PROCEDURE [dbo].[usp_AdminUpdateDmvStudyPracQOptById]
    @DmvStudyPracQOptID [int],
@DmvStudyPracQuestionID [int],
@DmvStudyPracQOptText [varchar](100),
@DmvStudyPracQOptAnswerYesNo [bit],
@DmvStudyPracQOptAnswerText [varchar](500),
@DmvStudyPracQOptActiveYesNo [bit],

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

    UPDATE [dbo].[DmvStudyPracQOpt] SET
    [DmvStudyPracQuestionID] = @DmvStudyPracQuestionID,
[DmvStudyPracQOptText] = @DmvStudyPracQOptText,
[DmvStudyPracQOptAnswerYesNo] = @DmvStudyPracQOptAnswerYesNo,
[DmvStudyPracQOptAnswerText] = @DmvStudyPracQOptAnswerText,
[DmvStudyPracQOptActiveYesNo] = @DmvStudyPracQOptActiveYesNo,

    [UpdateUserName] = @UpdateUserName,
    [UpdateFullName] = @UpdateFullName,
    [UpdateDate] = @UpdateDate
    WHERE [DmvStudyPracQOptID] = @DmvStudyPracQOptID;

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
    CREATE OR ALTER PROCEDURE [dbo].[usp_AdminDeleteDmvStudyPracQOptById]
    @DmvStudyPracQOptID [int],
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

    DELETE FROM [dbo].[DmvStudyPracQOpt]
    WHERE [DmvStudyPracQOptID] = @DmvStudyPracQOptID;

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
    CREATE OR ALTER PROCEDURE [dbo].[usp_AdminInsertDmvStudyPracQuestionById]
    @DmvStudyPracQuestionID [int] OUTPUT,
@DmvStudyPracID [int],
@DmvStudyPracQuestionText [varchar](500),
@DmvStudyPracQuestionFileContentYesNo [bit],
@DmvStudyPracQuestionFileContentPath [varchar](256),
@DmvStudyPracQuestionActiveYesNo [bit],

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

    INSERT INTO [dbo].[DmvStudyPracQuestion] ([DmvStudyPracID],[DmvStudyPracQuestionText],[DmvStudyPracQuestionFileContentYesNo],[DmvStudyPracQuestionFileContentPath],[DmvStudyPracQuestionActiveYesNo], [CreateUserName], [CreateFullName], [CreateDate], [UpdateUserName], [UpdateFullName]) VALUES (@DmvStudyPracID,@DmvStudyPracQuestionText,@DmvStudyPracQuestionFileContentYesNo,@DmvStudyPracQuestionFileContentPath,@DmvStudyPracQuestionActiveYesNo, @UpdateUserName, @UpdateFullName, @CreateDate, @UpdateUserName, @UpdateFullName);

    
SET @DmvStudyPracQuestionID = SCOPE_IDENTITY();

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
    CREATE OR ALTER PROCEDURE [dbo].[usp_AdminUpdateDmvStudyPracQuestionById]
    @DmvStudyPracQuestionID [int],
@DmvStudyPracID [int],
@DmvStudyPracQuestionText [varchar](500),
@DmvStudyPracQuestionFileContentYesNo [bit],
@DmvStudyPracQuestionFileContentPath [varchar](256),
@DmvStudyPracQuestionActiveYesNo [bit],

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

    UPDATE [dbo].[DmvStudyPracQuestion] SET
    [DmvStudyPracID] = @DmvStudyPracID,
[DmvStudyPracQuestionText] = @DmvStudyPracQuestionText,
[DmvStudyPracQuestionFileContentYesNo] = @DmvStudyPracQuestionFileContentYesNo,
[DmvStudyPracQuestionFileContentPath] = @DmvStudyPracQuestionFileContentPath,
[DmvStudyPracQuestionActiveYesNo] = @DmvStudyPracQuestionActiveYesNo,

    [UpdateUserName] = @UpdateUserName,
    [UpdateFullName] = @UpdateFullName,
    [UpdateDate] = @UpdateDate
    WHERE [DmvStudyPracQuestionID] = @DmvStudyPracQuestionID;

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
    CREATE OR ALTER PROCEDURE [dbo].[usp_AdminDeleteDmvStudyPracQuestionById]
    @DmvStudyPracQuestionID [int],
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

    DELETE FROM [dbo].[DmvStudyPracQuestion]
    WHERE [DmvStudyPracQuestionID] = @DmvStudyPracQuestionID;

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
    CREATE OR ALTER PROCEDURE [dbo].[usp_AdminInsertDmvStudyPractById]
    @DmvStudyPractID [int] OUTPUT,
@DmvStudyPractNum [int],
@DmvStudyPractTitle [varchar](50),
@DmvStudyPractActiveYesNo [bit],

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

    INSERT INTO [dbo].[DmvStudyPract] ([DmvStudyPractNum],[DmvStudyPractTitle],[DmvStudyPractActiveYesNo], [CreateUserName], [CreateFullName], [CreateDate], [UpdateUserName], [UpdateFullName]) VALUES (@DmvStudyPractNum,@DmvStudyPractTitle,@DmvStudyPractActiveYesNo, @UpdateUserName, @UpdateFullName, @CreateDate, @UpdateUserName, @UpdateFullName);

    
SET @DmvStudyPractID = SCOPE_IDENTITY();

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
    CREATE OR ALTER PROCEDURE [dbo].[usp_AdminUpdateDmvStudyPractById]
    @DmvStudyPractID [int],
@DmvStudyPractNum [int],
@DmvStudyPractTitle [varchar](50),
@DmvStudyPractActiveYesNo [bit],

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

    UPDATE [dbo].[DmvStudyPract] SET
    [DmvStudyPractNum] = @DmvStudyPractNum,
[DmvStudyPractTitle] = @DmvStudyPractTitle,
[DmvStudyPractActiveYesNo] = @DmvStudyPractActiveYesNo,

    [UpdateUserName] = @UpdateUserName,
    [UpdateFullName] = @UpdateFullName,
    [UpdateDate] = @UpdateDate
    WHERE [DmvStudyPractID] = @DmvStudyPractID;

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
    CREATE OR ALTER PROCEDURE [dbo].[usp_AdminDeleteDmvStudyPractById]
    @DmvStudyPractID [int],
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

    DELETE FROM [dbo].[DmvStudyPract]
    WHERE [DmvStudyPractID] = @DmvStudyPractID;

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
    CREATE OR ALTER PROCEDURE [dbo].[usp_GetLoadUserInfoUserInfoCompanyXrefsById]
    @UserInfoID [int]
    AS
    BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    SELECT
    UUC.[UserInfoID],
    UUC.[UserInfoCompanyID],
    UC.[UserInfoCompanyName]
    FROM [dbo].[UserInfoUserInfoCompanyXref] UUC
    JOIN [dbo].[UserInfoCompany] UC ON UUC.UserInfoCompanyID = UC.UserInfoCompanyID
    WHERE  UUC.[UserInfoID] = @UserInfoID AND
    UUC.[UserInfoUserInfoCompanyXrefActiveYesNo] = 1
    ORDER BY [UserInfoCompanyName] ASC;

    END

    Go


  