CREATE TABLE [school].[Grades] (
    [GradeId] INT IDENTITY NOT NULL,
    [Grade]   INT NOT NULL,
    [TaskId]  INT NOT NULL,
    CONSTRAINT [PK_Grade] PRIMARY KEY CLUSTERED ([GradeId] ASC),
    CONSTRAINT [FK_Grade_Task] FOREIGN KEY ([TaskId]) REFERENCES [school].[Tasks] ([TaskId])
);


GO
CREATE NONCLUSTERED INDEX [FK_Grade_Task_2]
    ON [school].[Grades]([TaskId] ASC);

