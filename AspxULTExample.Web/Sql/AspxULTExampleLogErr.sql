
    USE [Log4Exception]
    GO
    SET ANSI_NULLS ON
    GO
    SET QUOTED_IDENTIFIER ON
    GO

    ALTER TABLE [dbo].[ErrorLog] DROP CONSTRAINT [DF_ErrorLog_CreateDate]
    GO

    /****** Object:  Table [dbo].[ErrorLog]    Script Date: 12/11/2025 10:47:29 PM ******/
    IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ErrorLog]') AND type in (N'U'))
    DROP TABLE [dbo].[ErrorLog]
    GO

    /****** Object:  Table [dbo].[ErrorLog]    Script Date: 12/11/2025 10:47:29 PM ******/
    SET ANSI_NULLS ON
    GO

    SET QUOTED_IDENTIFIER ON
    GO

    CREATE TABLE [dbo].[ErrorLog](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [MessageId] [int] NOT NULL,
    [MessageText] [varchar](max) NULL,
    [SeverityLevel] [int] NOT NULL,
    [State] [int] NOT NULL,
    [LineNumber] [int] NOT NULL,
    [ProcedureName] [nvarchar](2500) NULL,
    [CreateDate] [datetime] NOT NULL,
    [UpdateUserName] [nvarchar](100) NULL,
    [UpdateFullName] [nvarchar](100) NULL,
    CONSTRAINT [PK_ErrorLogId] PRIMARY KEY CLUSTERED
    (
    [Id] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
    ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
    GO

    ALTER TABLE [dbo].[ErrorLog] ADD  CONSTRAINT [DF_ErrorLog_CreateDate]  DEFAULT (getdate()) FOR [CreateDate]
    GO

    /*
    DELETE FROM [dbo].[ErrorLog]
    GO
    DBCC CHECKIDENT ('[dbo].[ErrorLog]', RESEED, 1);
    GO
    */
    /*

    Sql Views
    CREATE OR ALTER VIEW [dbo].[View????]
    WITH SCHEMABINDING
    AS

    DECLARE @SERVERNAME as nvarchar(20) = '',
    @Recipients as nvarchar(200) = ''

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
  