
    USE [Log4Exception]
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
    CREATE OR ALTER   PROCEDURE [dbo].[usp_LogErrorMessageProcedure]
    (@MessageId [int],
    @MessageText [varchar](MAX),
    @SeverityLevel [int],
    @State [int],
    @LineNumber [int],
    @ProcedureName [nvarchar](2500),
    @UpdateUserName [nvarchar](100),
    @UpdateFullName [nvarchar](100),
    @Id int OUTPUT
    )
    AS
    BEGIN TRY

    SET NOCOUNT ON;

    SET XACT_ABORT ON;

    BEGIN TRANSACTION;

    IF @MessageId IS NULL
    RETURN;

    -- Return if inside an uncommittable transaction.
    -- Data insertion/modification is not allowed when
    -- a transaction is in an uncommittable state.
    IF XACT_STATE() = -1
    BEGIN
    PRINT 'Cannot log error since the current transaction is in an uncommittable state. '
    + 'Rollback the transaction before executing usp_LogErrorMessage in order to successfully log error information.';
    RETURN;
    END


    INSERT INTO [dbo].[ErrorLog] (MessageId,MessageText,SeverityLevel,[State],LineNumber,ProcedureName,UpdateUserName,UpdateFullName)
    VALUES (@MessageId,@MessageText,@SeverityLevel,@State,@LineNumber,@ProcedureName,@UpdateUserName,@UpdateFullName);

    SET @Id = SCOPE_IDENTITY();

    DECLARE @SERVERNAME as nvarchar(20) = '',
    @Recipients as nvarchar(200) = ''

    IF @@SERVERNAME = @SERVERNAME
    BEGIN

    DECLARE @subject as nvarchar(2550) = ISNULL(@ProcedureName, 'Unknown') + ' - A Exception has Occurred.';

    DECLARE @body as nvarchar(max) = '<!DOCTYPE html>
    <html>
    <head>
    <meta charset="utf-8" />
    <title>' + @subject + '</title>
    </head>
    <body><div><table>' +
    '<tr>' +
    '<td>MessageId: </td><td>' + CAST(ISNULL(@MessageId, 'Unknown') AS nvarchar(50)) + '</td>' +
    '</tr><tr>' +
    '<td>SeverityLevel: </td><td>' + CAST(ISNULL(@SeverityLevel, 'Unknown') AS nvarchar(50)) + '</td>' +
    '</tr><tr>' +
    '<td>State:</td><td>' + CAST(ISNULL(@State, 'Unknown') AS nvarchar(50)) + '</td>' +
    '</tr><tr>' +
    '<td>LineNumber: </td><td>' + CAST(ISNULL(@LineNumber, 'Unknown') AS nvarchar(50)) + '</td>' +
    '</tr><tr>' +
    '<td>UpdateUserName: </td><td>' + ISNULL(@UpdateUserName, 'Unknown') + '</td>' +
    '</tr><tr>' +
    '<td>UpdateFullName: </td><td>' + ISNULL(@UpdateFullName, 'Unknown') + '</td>' +
    '</tr><tr>' +
    '<td>ProcedureName: </td><td>' + ISNULL(@ProcedureName, 'Unknown') + '</td>' +
    '</tr><tr>' +
    '<td style="vertical-align:top">MessageText: </td><td>' + ISNULL(@MessageText, 'Unknown') + '</td>' +
    '</tr></table></div>
    </body>
    </html>';

    EXEC msdb.dbo.sp_send_dbmail
    @profile_name	= 'LogErrorMail'
    ,@recipients		= @Recipients
    ,@subject			= @subject
    ,@body			= @body
    ,@body_format		= 'HTML'

    END

    COMMIT TRANSACTION;

    END TRY

    BEGIN CATCH

    IF (@@TRANCOUNT > 0)

    ROLLBACK TRANSACTION;

    SET @MessageId = ERROR_NUMBER();
    SET @MessageText = ERROR_MESSAGE();
    SET @SeverityLevel  = ERROR_SEVERITY();
    SET @State  = ERROR_STATE();
    SET @LineNumber = ERROR_LINE();
    SET @ProcedureName = ERROR_PROCEDURE();


    INSERT INTO [dbo].[ErrorLog] (MessageId,MessageText,SeverityLevel,[State],LineNumber,ProcedureName,UpdateUserName,UpdateFullName)
    VALUES (@MessageId,@MessageText,@SeverityLevel,@State,@LineNumber,@ProcedureName,@UpdateUserName,@UpdateFullName);

    SET @Id = SCOPE_IDENTITY();

    SELECT @MessageId, @MessageText, @SeverityLevel,@State,@LineNumber,@ProcedureName,@UpdateUserName,@UpdateFullName;

    PRINT 'Error: ' + CONVERT(varchar(50), @MessageId) +
    ', Severity: ' + CONVERT(varchar(5), @SeverityLevel) +
    ', State: ' + CONVERT(varchar(5), @State) +
    ', Procedure: ' + ISNULL(@ProcedureName, '-') +
    ', Line: ' + CONVERT(varchar(5), @LineNumber);
    PRINT 'Message: ' + @MessageText;

    RETURN -1;

    END CATCH

    GO
    -- =============================================
    -- Author:		Earl L. Wilkerson Jr.
    -- Create date: 12/11/2025 10:47:29 PM
    -- Description:	<Description,,>
    -- =============================================

    ALTER   PROCEDURE [dbo].[usp_LogErrorMessageWeb]
    (@UpdateUserName	nvarchar(100),
    @UpdateFullName nvarchar(100),
    @SourceSubject [nvarchar](2500),
    @Source [nvarchar](2500),
    @ErrMsg [varchar](MAX),
    @Id int OUTPUT)
    AS
    BEGIN TRY

    SET NOCOUNT ON;

    SET XACT_ABORT ON;

    BEGIN TRANSACTION;

    -- Return if inside an uncommittable transaction.
    -- Data insertion/modification is not allowed when
    -- a transaction is in an uncommittable state.
    IF XACT_STATE() = -1
    BEGIN
    PRINT 'Cannot log error since the current transaction is in an uncommittable state. '
    + 'Rollback the transaction before executing usp_LogErrorMessage in order to successfully log error information.';
    RETURN;
    END


    INSERT INTO [dbo].[ErrorLog] (MessageId,MessageText,SeverityLevel,[State],LineNumber,ProcedureName,UpdateUserName,UpdateFullName)
    VALUES (0,@ErrMsg,0,0,0,@Source, @UpdateUserName,@UpdateFullName);

    SET @Id = SCOPE_IDENTITY();

    COMMIT TRANSACTION;

    END TRY

    BEGIN CATCH

    IF (@@TRANCOUNT > 0)

    ROLLBACK TRANSACTION;

    DECLARE @MessageId int = ERROR_NUMBER(),
    @MessageText [nvarchar](2047) = ERROR_MESSAGE(),
    @SeverityLevel [int] = ERROR_SEVERITY(),
    @State [int] = ERROR_STATE(),
    @LineNumber [int] = ERROR_LINE() ,
    @ProcedureName [nvarchar](2500) = ERROR_PROCEDURE();


    INSERT INTO [dbo].[ErrorLog] (MessageId,MessageText,SeverityLevel,[State],LineNumber,ProcedureName,UpdateUserName,UpdateFullName)
    VALUES (@MessageId,@MessageText,@SeverityLevel,@State,@LineNumber,@ProcedureName,@UpdateUserName, @UpdateFullName);

    SET @Id = SCOPE_IDENTITY();

    SELECT @MessageId,@MessageText,@SeverityLevel,@State,@LineNumber,@ProcedureName,@UpdateUserName, @UpdateFullName;

    PRINT 'Error: ' + CONVERT(varchar(50), @MessageId) +
    ', Severity: ' + CONVERT(varchar(5), @SeverityLevel) +
    ', State: ' + CONVERT(varchar(5), @State) +
    ', Procedure: ' + ISNULL(@ProcedureName, '-') +
    ', Line: ' + CONVERT(varchar(5), @LineNumber);
    PRINT 'Message: ' + @MessageText;

    RETURN -1;

    END CATCH
    GO

    /*

    Sql Views
    CREATE OR ALTER VIEW [dbo].[View????]
    WITH SCHEMABINDING
    AS

    DECLARE @SERVERNAME as nvarchar(20) = 'EARLWILKERSONJR',
    @Recipients as nvarchar(200) = 'earl.wilkerson.jr@gmail.com'

    IF @@SERVERNAME = @SERVERNAME
    BEGIN

    DECLARE @body as nvarchar(max) = '';

    DECLARE @subject as nvarchar(2550) = ISNULL(@SourceSubject, 'Unknown') + ' - A Exception has Occurred.';

    EXEC msdb.dbo.sp_send_dbmail
    @profile_name	= 'LogErrorMail'
    ,@recipients		= @Recipients
    ,@subject			= @subject
    ,@body			= @body
    ,@body_format		= 'HTML'

    END

    */
  