CREATE TABLE [dbo].[TestResults] (
    [Id]									INT              IDENTITY (1, 1) NOT NULL,
    [AttemtedDate]							DATETIME2 (7)		NULL,
    [PrimaryLanguage]						NVARCHAR (255)		NULL,
    [SecondaryLanguage]						NVARCHAR (255)		NULL,
    [AvailableQuestionsInDictionary]		INT					NULL,
    [QuestionsTaken]						INT					NULL,
    [QuestionsAttempted]					INT					NULL,
    [CorrectAnwers]							INT					NULL,
	[UserId]								INT					NOT NULL,
    CONSTRAINT [PK_TestResults] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TestResults_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id]) ON DELETE CASCADE
);