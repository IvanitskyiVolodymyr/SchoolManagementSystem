CREATE TABLE [school].[Subjects] (
    [SubjectId]   INT            NOT NULL,
    [Name]        NVARCHAR (100) NOT NULL,
    [Description] NVARCHAR (200) NOT NULL,
    CONSTRAINT [PK_Subject] PRIMARY KEY CLUSTERED ([SubjectId] ASC)
);

