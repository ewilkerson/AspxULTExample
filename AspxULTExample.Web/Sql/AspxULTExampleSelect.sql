
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
    CREATE OR ALTER PROCEDURE [dbo].[usp_AdminGetDmvStudyPracQOpts]
    AS
    BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    SELECT
    [DmvStudyPracQOptID],
[DmvStudyPracQuestionID],
[DmvStudyPracQOptText],
[DmvStudyPracQOptAnswerYesNo],
[DmvStudyPracQOptAnswerText],
[DmvStudyPracQOptActiveYesNo]
    FROM [dbo].[DmvStudyPracQOpt]
    ORDER BY [DmvStudyPracQOptID] ASC;

    END
    GO

    GO

    -- =============================================
    -- Author:		Earl L. Wilkerson Jr.
    -- Create date: 12/11/2025 10:47:29 PM
    -- Description:	<Description,,>
    -- =============================================
    CREATE OR ALTER PROCEDURE [dbo].[usp_AdminGetDmvStudyPracQOptById]
    @DmvStudyPracQOptID [int]
    AS
    BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    SELECT
    [DmvStudyPracQOptID],
[DmvStudyPracQuestionID],
[DmvStudyPracQOptText],
[DmvStudyPracQOptAnswerYesNo],
[DmvStudyPracQOptAnswerText],
[DmvStudyPracQOptActiveYesNo]
    FROM [dbo].[DmvStudyPracQOpt]
    WHERE [DmvStudyPracQOptID] = @DmvStudyPracQOptID;

    END
    GO

  



    -- =============================================
    -- Author:		Earl L. Wilkerson Jr.
    -- Create date: 12/11/2025 10:47:29 PM
    -- Description:	<Description,,>
    -- =============================================
    CREATE OR ALTER PROCEDURE [dbo].[usp_AdminGetDmvStudyPracQuestions]
    AS
    BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    SELECT
    [DmvStudyPracQuestionID],
[DmvStudyPracID],
[DmvStudyPracQuestionText],
[DmvStudyPracQuestionFileContentYesNo],
[DmvStudyPracQuestionFileContentPath],
[DmvStudyPracQuestionActiveYesNo]
    FROM [dbo].[DmvStudyPracQuestion]
    ORDER BY [DmvStudyPracQuestionID] ASC;

    END
    GO

    GO

    -- =============================================
    -- Author:		Earl L. Wilkerson Jr.
    -- Create date: 12/11/2025 10:47:29 PM
    -- Description:	<Description,,>
    -- =============================================
    CREATE OR ALTER PROCEDURE [dbo].[usp_AdminGetDmvStudyPracQuestionById]
    @DmvStudyPracQuestionID [int]
    AS
    BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    SELECT
    [DmvStudyPracQuestionID],
[DmvStudyPracID],
[DmvStudyPracQuestionText],
[DmvStudyPracQuestionFileContentYesNo],
[DmvStudyPracQuestionFileContentPath],
[DmvStudyPracQuestionActiveYesNo]
    FROM [dbo].[DmvStudyPracQuestion]
    WHERE [DmvStudyPracQuestionID] = @DmvStudyPracQuestionID;

    END
    GO

  



    -- =============================================
    -- Author:		Earl L. Wilkerson Jr.
    -- Create date: 12/11/2025 10:47:29 PM
    -- Description:	<Description,,>
    -- =============================================
    CREATE OR ALTER PROCEDURE [dbo].[usp_AdminGetDmvStudyPracts]
    AS
    BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    SELECT
    [DmvStudyPractID],
[DmvStudyPractNum],
[DmvStudyPractTitle],
[DmvStudyPractActiveYesNo]
    FROM [dbo].[DmvStudyPract]
    ORDER BY [DmvStudyPractID] ASC;

    END
    GO

    GO

    -- =============================================
    -- Author:		Earl L. Wilkerson Jr.
    -- Create date: 12/11/2025 10:47:29 PM
    -- Description:	<Description,,>
    -- =============================================
    CREATE OR ALTER PROCEDURE [dbo].[usp_AdminGetDmvStudyPractById]
    @DmvStudyPractID [int]
    AS
    BEGIN
    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON;

    SELECT
    [DmvStudyPractID],
[DmvStudyPractNum],
[DmvStudyPractTitle],
[DmvStudyPractActiveYesNo]
    FROM [dbo].[DmvStudyPract]
    WHERE [DmvStudyPractID] = @DmvStudyPractID;

    END
    GO

  



  