
    USE [ULTExampleDb]
    GO

    ALTER TABLE [dbo].[UserInfo] DROP CONSTRAINT [DF_UserInfo_UpdateDate]
    GO

    /****** Object:  Table [dbo].[UserInfo]    Script Date: 12/11/2025 10:47:29 PM PM ******/
    IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserInfo]') AND type in (N'U'))
    DROP TABLE [dbo].[UserInfo]
    GO

    /****** Object:  Table [dbo].[UserInfo]    Script Date: 12/11/2025 10:47:29 PM ******/
    SET ANSI_NULLS ON
    GO

    SET QUOTED_IDENTIFIER ON
    GO

    CREATE TABLE [dbo].[UserInfo](
    [UserInfoID] [int] IDENTITY(1,1) NOT NULL,
    [UserInfoUserIdentityName] [nvarchar](50) NOT NULL,
    [UserInfoUserName] [nvarchar](50) NOT NULL,
    [UserInfoFullName] [nvarchar](50) NOT NULL,
    [UserInfoEmailAddress] [nvarchar](50) NOT NULL,
    [UserInfoJobTitle] [nvarchar](50) NOT NULL,
    [UserInfoActiveYesNo] [bit] NOT NULL,
    [CreateUserName] [nvarchar](50) NULL,
    [CreateFullName] [nvarchar](50) NULL,
    [CreateDate] [datetime] NOT NULL,
    [UpdateUserName] [nvarchar](50) NULL,
    [UpdateFullName] [nvarchar](50) NULL,
    [UpdateDate] [datetime] NOT NULL,
    CONSTRAINT [PK_UserInfo] PRIMARY KEY CLUSTERED
    (
    [UserInfoID] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
    ) ON [PRIMARY]
    GO

    ALTER TABLE [dbo].[UserInfo] ADD  CONSTRAINT [DF_UserInfo_UpdateDate]  DEFAULT (getdate()) FOR [UpdateDate]
    GO


    ALTER TABLE [dbo].[LoadUserInfo] DROP CONSTRAINT [DF_LoadUserInfo_UpdateDate]
    GO

    /****** Object:  Table [dbo].[LoadUserInfo]    Script Date: 12/11/2025 10:47:29 PM ******/
    IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[LoadUserInfo]') AND type in (N'U'))
    DROP TABLE [dbo].[LoadUserInfo]
    GO

    /****** Object:  Table [dbo].[LoadUserInfo]    Script Date: 12/11/2025 10:47:29 PM ******/
    SET ANSI_NULLS ON
    GO

    SET QUOTED_IDENTIFIER ON
    GO

    CREATE TABLE [dbo].[LoadUserInfo](
    [UserInfoID] [int] IDENTITY(1,1) NOT NULL,
    [UserInfoUserIdentityName] [nvarchar](50) NOT NULL,
    [UserInfoUserName] [nvarchar](50) NOT NULL,
    [UserInfoFullName] [nvarchar](50) NOT NULL,
    [UserInfoEmailAddress] [nvarchar](50) NOT NULL,
    [UserInfoJobTitle] [nvarchar](50) NOT NULL,
    [UserInfoActiveYesNo] [bit] NOT NULL,
    [UserInfoAccessLevelID] [int] NOT NULL,
    [CreateUserName] [nvarchar](50) NULL,
    [CreateFullName] [nvarchar](50) NULL,
    [CreateDate] [datetime] NOT NULL,
    [UpdateUserName] [nvarchar](50) NULL,
    [UpdateFullName] [nvarchar](50) NULL,
    [UpdateDate] [datetime] NOT NULL,
    CONSTRAINT [PK_LoadUserInfo] PRIMARY KEY CLUSTERED
    (
    [UserInfoID] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
    ) ON [PRIMARY]
    GO

    ALTER TABLE [dbo].[LoadUserInfo] ADD  CONSTRAINT [DF_LoadUserInfo_UpdateDate]  DEFAULT (getdate()) FOR [UpdateDate]
    GO


    ALTER TABLE [dbo].[UserInfoAccessLevel] DROP CONSTRAINT [DF_UserInfoAccessLevel_UpdateDate]
    GO

    /****** Object:  Table [dbo].[UserInfoAccessLevel]    Script Date: 12/11/2025 10:47:29 PM ******/
    IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserInfoAccessLevel]') AND type in (N'U'))
    DROP TABLE [dbo].[UserInfoAccessLevel]
    GO

    /****** Object:  Table [dbo].[UserInfoAccessLevel]    Script Date: 12/11/2025 10:47:29 PM ******/
    SET ANSI_NULLS ON
    GO

    SET QUOTED_IDENTIFIER ON
    GO

    CREATE TABLE [dbo].[UserInfoAccessLevel](
    [UserInfoAccessLevelID] [int]  NOT NULL,
    [UserInfoAccessLevelName] [nvarchar](50) NOT NULL,
    [UserInfoAccessLevelNum] [int] NOT NULL,
    [UserInfoAccessLevelActiveYesNo] [bit] NOT NULL,
    [CreateUserName] [nvarchar](50) NULL,
    [CreateFullName] [nvarchar](50) NULL,
    [CreateDate] [datetime] NOT NULL,
    [UpdateUserName] [nvarchar](50) NULL,
    [UpdateFullName] [nvarchar](50) NULL,
    [UpdateDate] [datetime] NOT NULL,
    CONSTRAINT [PK_UserInfoAccessLevel] PRIMARY KEY CLUSTERED
    (
    [UserInfoAccessLevelID] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
    ) ON [PRIMARY]
    GO

    ALTER TABLE [dbo].[UserInfoAccessLevel] ADD  CONSTRAINT [DF_UserInfoAccessLevel_UpdateDate]  DEFAULT (getdate()) FOR [UpdateDate]
    GO


    ALTER TABLE [dbo].[UserInfoUserInfoAccessLevelXref] DROP CONSTRAINT [DF_UserInfoUserInfoAccessLevelXref_UpdateDate]
    GO

    /****** Object:  Table [dbo].[UserInfoUserInfoAccessLevelXref]    Script Date: 12/11/2025 10:47:29 PM ******/
    IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserInfoUserInfoAccessLevelXref]') AND type in (N'U'))
    DROP TABLE [dbo].[UserInfoUserInfoAccessLevelXref]
    GO

    /****** Object:  Table [dbo].[UserInfoUserInfoAccessLevelXref]    Script Date: 12/11/2025 10:47:29 PM ******/
    SET ANSI_NULLS ON
    GO

    SET QUOTED_IDENTIFIER ON
    GO

    CREATE TABLE [dbo].[UserInfoUserInfoAccessLevelXref](
    [UserInfoUserInfoAccessLevelXrefID] [int] IDENTITY(1,1) NOT NULL,
    [UserInfoID] [int] NOT NULL,
    [UserInfoAccessLevelID] [int] NOT NULL,
    [UserInfoUserInfoAccessLevelXrefActiveYesNo] [bit] NOT NULL,
    [CreateUserName] [nvarchar](50) NULL,
    [CreateFullName] [nvarchar](50) NULL,
    [CreateDate] [datetime] NOT NULL,
    [UpdateUserName] [nvarchar](50) NULL,
    [UpdateFullName] [nvarchar](50) NULL,
    [UpdateDate] [datetime] NOT NULL,
    CONSTRAINT [PK_UserInfoUserInfoAccessLevelXref] PRIMARY KEY CLUSTERED
    (
    [UserInfoUserInfoAccessLevelXrefID] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
    ) ON [PRIMARY]
    GO


    ALTER TABLE [dbo].[UserInfoUserInfoAccessLevelXref] ADD  CONSTRAINT [DF_UserInfoUserInfoAccessLevelXref_UpdateDate]  DEFAULT (getdate()) FOR [UpdateDate]
    GO


    ALTER TABLE [dbo].[UserInfoCountries] DROP CONSTRAINT [DF_UserInfoCountries_UpdateDate]
    GO

    /****** Object:  Table [dbo].[UserInfoCountries]    Script Date: 12/11/2025 10:47:29 PM ******/
    IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserInfoCountries]') AND type in (N'U'))
    DROP TABLE [dbo].[UserInfoCountries]
    GO

    /****** Object:  Table [dbo].[UserInfoCountries]    Script Date: 12/11/2025 10:47:29 PM ******/
    SET ANSI_NULLS ON
    GO

    SET QUOTED_IDENTIFIER ON
    GO

    CREATE TABLE [dbo].[UserInfoCountries](
    [UserInfoCountriesID] [int] NOT NULL,
    [UserInfoCountriesName] [nvarchar](50) NOT NULL,
    [UserInfoCountriesActiveYesNo] [bit] NOT NULL,
    [CreateUserName] [nvarchar](50) NULL,
    [CreateFullName] [nvarchar](50) NULL,
    [CreateDate] [datetime] NOT NULL,
    [UpdateUserName] [nvarchar](50) NULL,
    [UpdateFullName] [nvarchar](50) NULL,
    [UpdateDate] [datetime] NOT NULL,
    CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED
    (
    [UserInfoCountriesID] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
    ) ON [PRIMARY]
    GO


    ALTER TABLE [dbo].[UserInfoCountries] ADD  CONSTRAINT [DF_UserInfoCountries_UpdateDate]  DEFAULT (getdate()) FOR [UpdateDate]
    GO

    ALTER TABLE [dbo].[UserInfoCompany] DROP CONSTRAINT [DF_UserInfoCompany_UpdateDate]
    GO

    /****** Object:  Table [dbo].[UserInfoCompany]    Script Date: 12/11/2025 10:47:29 PM ******/
    IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserInfoCompany]') AND type in (N'U'))
    DROP TABLE [dbo].[UserInfoCompany]
    GO

    /****** Object:  Table [dbo].[UserInfoCompany]    Script Date: 12/11/2025 10:47:29 PM ******/
    SET ANSI_NULLS ON
    GO

    SET QUOTED_IDENTIFIER ON
    GO

    CREATE TABLE [dbo].[UserInfoCompany](
    [UserInfoCompanyID] [int] NOT NULL,
    [UserInfoCompanyName] [nvarchar](200) NOT NULL,
    [UserInfoCompanyAddress1] [nvarchar](60) NOT NULL,
    [UserInfoCompanyAddress2] [nvarchar](60) NOT NULL,
    [UserInfoCompanyCityStateZip]	[nvarchar](60) NOT NULL,
    [UserInfoCompanyTelephone]	[nvarchar](50) NOT NULL,
    [UserInfoCompanyEmailAddress]	[nvarchar](50) NOT NULL,
    [UserInfoCountriesID] [int] NULL,
    [UserInfoCompanyActiveYesNo] [bit] NOT NULL,
    [CreateUserName] [nvarchar](50) NULL,
    [CreateFullName] [nvarchar](50) NULL,
    [CreateDate] [datetime] NOT NULL,
    [UpdateUserName] [nvarchar](50) NULL,
    [UpdateFullName] [nvarchar](50) NULL,
    [UpdateDate] [datetime] NOT NULL,
    CONSTRAINT [PK_Company] PRIMARY KEY CLUSTERED
    (
    [UserInfoCompanyID] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
    ) ON [PRIMARY]
    GO

    ALTER TABLE [dbo].[UserInfoCompany] ADD  CONSTRAINT [DF_UserInfoCompany_UpdateDate]  DEFAULT (getdate()) FOR [UpdateDate]
    GO


    ALTER TABLE [dbo].[UserInfoUserInfoCompanyXref] DROP CONSTRAINT [DF_UserInfoUserInfoCompanyXref_UpdateDate]
    GO

    /****** Object:  Table [dbo].[UserInfoUserInfoCompanyXref]    Script Date: 12/11/2025 10:47:29 PM ******/
    IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserInfoUserInfoCompanyXref]') AND type in (N'U'))
    DROP TABLE [dbo].[UserInfoUserInfoCompanyXref]
    GO

    /****** Object:  Table [dbo].[UserInfoUserInfoCompanyXref]    Script Date: 12/11/2025 10:47:29 PM ******/
    SET ANSI_NULLS ON
    GO

    SET QUOTED_IDENTIFIER ON
    GO

    CREATE TABLE [dbo].[UserInfoUserInfoCompanyXref](
    [UserInfoUserInfoCompanyXrefID] [int] IDENTITY(1,1) NOT NULL,
    [UserInfoID] [int] NOT NULL,
    [UserInfoCompanyID] [int] NOT NULL,
    [UserInfoUserInfoCompanyXrefEmailAddressActiveYesNo] [bit] NOT NULL,
    [UserInfoUserInfoCompanyXrefActiveYesNo] [bit] NOT NULL,
    [CreateUserName] [nvarchar](50) NULL,
    [CreateFullName] [nvarchar](50) NULL,
    [CreateDate] [datetime] NOT NULL,
    [UpdateUserName] [nvarchar](50) NULL,
    [UpdateFullName] [nvarchar](50) NULL,
    [UpdateDate] [datetime] NOT NULL,
    CONSTRAINT [PK_UserInfoCompanyXref] PRIMARY KEY CLUSTERED
    (
    [UserInfoUserInfoCompanyXrefID] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
    ) ON [PRIMARY]
    GO


    ALTER TABLE [dbo].[UserInfoUserInfoCompanyXref] ADD CONSTRAINT [DF_UserInfoUserInfoCompanyXref_UpdateDate]  DEFAULT (getdate()) FOR [UpdateDate]
    GO

    ALTER TABLE [dbo].[UserInfoStatus] DROP CONSTRAINT [DF_UserInfoStatus_UpdateDate]
    GO

    /****** Object:  Table [dbo].[UserInfoStatus]    Script Date: 12/11/2025 10:47:29 PM ******/
    IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserInfoStatus]') AND type in (N'U'))
    DROP TABLE [dbo].[UserInfoStatus]
    GO

    /****** Object:  Table [dbo].[UserInfoStatus]    Script Date: 12/11/2025 10:47:29 PM ******/
    SET ANSI_NULLS ON
    GO

    SET QUOTED_IDENTIFIER ON
    GO

    CREATE TABLE [dbo].[UserInfoStatus](
    [UserInfoStatusID] [int] NOT NULL,
    [UserInfoStatusName] [nvarchar](50) NOT NULL,
    [UserInfoStatusActiveYesNo] [bit] NOT NULL,
    [CreateUserName] [nvarchar](50) NULL,
    [CreateFullName] [nvarchar](50) NULL,
    [CreateDate] [datetime] NOT NULL,
    [UpdateUserName] [nvarchar](50) NULL,
    [UpdateFullName] [nvarchar](50) NULL,
    [UpdateDate] [datetime] NOT NULL,
    CONSTRAINT [PK_UserInfoStatus] PRIMARY KEY CLUSTERED
    (
    [UserInfoStatusID] ASC
    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
    ) ON [PRIMARY]
    GO

    ALTER TABLE [dbo].[UserInfoStatus] ADD  CONSTRAINT [DF_UserInfoStatus_UpdateDate]  DEFAULT (getdate()) FOR [UpdateDate]
    GO

  