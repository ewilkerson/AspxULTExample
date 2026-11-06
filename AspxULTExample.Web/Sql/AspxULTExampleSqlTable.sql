
    USE [ULTExampleDb]
    GO

    SET ANSI_NULLS ON
    GO

    SET QUOTED_IDENTIFIER ON
    GO

    
    ALTER TABLE [dbo].[DmvStudyPracQOpt] DROP CONSTRAINT [DF_DmvStudyPracQOpt_UpdateDate]
    GO

    /****** Object:  Table [dbo].[DmvStudyPracQOpt]    Script Date: 12/11/2025 10:47:29 PM ******/
    IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DmvStudyPracQOpt]') AND type in (N'U'))
    DROP TABLE [dbo].[DmvStudyPracQOpt]
    GO

    /****** Object:  Table [dbo].[DmvStudyPracQOpt]    Script Date: 12/11/2025 10:47:29 PM ******/
    SET ANSI_NULLS ON
    GO

    SET QUOTED_IDENTIFIER ON
    GO

    CREATE TABLE [dbo].[DmvStudyPracQOpt](
    [DmvStudyPracQOptID] [int] IDENTITY(1, 1) NOT NULL,
[DmvStudyPracQuestionID] [int] NOT NULL,
[DmvStudyPracQOptText] [varchar](100) NOT NULL,
[DmvStudyPracQOptAnswerYesNo] [bit] NOT NULL,
[DmvStudyPracQOptAnswerText] [varchar](500) NOT NULL,
[DmvStudyPracQOptActiveYesNo] [bit] NOT NULL,

    [CreateUserName] [nvarchar](50) NULL,
    [CreateFullName] [nvarchar](50) NULL,
    [CreateDate] [datetime] NOT NULL,
    [UpdateUserName] [nvarchar](50) NULL,
    [UpdateFullName] [nvarchar](50) NULL,
    [UpdateDate] [datetime] NOT NULL,
    CONSTRAINT [PK_DmvStudyPracQOpt] PRIMARY KEY CLUSTERED
    (
    [DmvStudyPracQOptID] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
    ) ON [PRIMARY]
    GO

    ALTER TABLE [dbo].[DmvStudyPracQOpt] ADD  CONSTRAINT [DF_DmvStudyPracQOpt_UpdateDate]  DEFAULT (getdate()) FOR [UpdateDate]
    GO

  


    ALTER TABLE [dbo].[DmvStudyPracQuestion] DROP CONSTRAINT [DF_DmvStudyPracQuestion_UpdateDate]
    GO

    /****** Object:  Table [dbo].[DmvStudyPracQuestion]    Script Date: 12/11/2025 10:47:29 PM ******/
    IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DmvStudyPracQuestion]') AND type in (N'U'))
    DROP TABLE [dbo].[DmvStudyPracQuestion]
    GO

    /****** Object:  Table [dbo].[DmvStudyPracQuestion]    Script Date: 12/11/2025 10:47:29 PM ******/
    SET ANSI_NULLS ON
    GO

    SET QUOTED_IDENTIFIER ON
    GO

    CREATE TABLE [dbo].[DmvStudyPracQuestion](
    [DmvStudyPracQuestionID] [int] IDENTITY(1, 1) NOT NULL,
[DmvStudyPracID] [int] NOT NULL,
[DmvStudyPracQuestionText] [varchar](500) NOT NULL,
[DmvStudyPracQuestionFileContentYesNo] [bit] NOT NULL,
[DmvStudyPracQuestionFileContentPath] [varchar](256) NULL,
[DmvStudyPracQuestionActiveYesNo] [bit] NOT NULL,

    [CreateUserName] [nvarchar](50) NULL,
    [CreateFullName] [nvarchar](50) NULL,
    [CreateDate] [datetime] NOT NULL,
    [UpdateUserName] [nvarchar](50) NULL,
    [UpdateFullName] [nvarchar](50) NULL,
    [UpdateDate] [datetime] NOT NULL,
    CONSTRAINT [PK_DmvStudyPracQuestion] PRIMARY KEY CLUSTERED
    (
    [DmvStudyPracQuestionID] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
    ) ON [PRIMARY]
    GO

    ALTER TABLE [dbo].[DmvStudyPracQuestion] ADD  CONSTRAINT [DF_DmvStudyPracQuestion_UpdateDate]  DEFAULT (getdate()) FOR [UpdateDate]
    GO

  


    ALTER TABLE [dbo].[DmvStudyPract] DROP CONSTRAINT [DF_DmvStudyPract_UpdateDate]
    GO

    /****** Object:  Table [dbo].[DmvStudyPract]    Script Date: 12/11/2025 10:47:29 PM ******/
    IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DmvStudyPract]') AND type in (N'U'))
    DROP TABLE [dbo].[DmvStudyPract]
    GO

    /****** Object:  Table [dbo].[DmvStudyPract]    Script Date: 12/11/2025 10:47:29 PM ******/
    SET ANSI_NULLS ON
    GO

    SET QUOTED_IDENTIFIER ON
    GO

    CREATE TABLE [dbo].[DmvStudyPract](
    [DmvStudyPractID] [int] IDENTITY(1, 1) NOT NULL,
[DmvStudyPractNum] [int] NOT NULL,
[DmvStudyPractTitle] [varchar](50) NOT NULL,
[DmvStudyPractActiveYesNo] [bit] NOT NULL,

    [CreateUserName] [nvarchar](50) NULL,
    [CreateFullName] [nvarchar](50) NULL,
    [CreateDate] [datetime] NOT NULL,
    [UpdateUserName] [nvarchar](50) NULL,
    [UpdateFullName] [nvarchar](50) NULL,
    [UpdateDate] [datetime] NOT NULL,
    CONSTRAINT [PK_DmvStudyPract] PRIMARY KEY CLUSTERED
    (
    [DmvStudyPractID] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
    ) ON [PRIMARY]
    GO

    ALTER TABLE [dbo].[DmvStudyPract] ADD  CONSTRAINT [DF_DmvStudyPract_UpdateDate]  DEFAULT (getdate()) FOR [UpdateDate]
    GO

  



  