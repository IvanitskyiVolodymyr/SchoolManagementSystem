CREATE TABLE [school].[Grades] (
    [GradeId] INT IDENTITY NOT NULL,
    [Value]   INT NOT NULL,
    [StudentTaskId]  INT NOT NULL,
    CONSTRAINT [PK_Grade] PRIMARY KEY CLUSTERED ([GradeId] ASC),
    CONSTRAINT [FK_Grade_Task] FOREIGN KEY ([StudentTaskId]) REFERENCES [school].[StudentsTasks] ([StudentTaskId])
);


GO
CREATE NONCLUSTERED INDEX [FK_Grade_Task_2]
    ON [school].[Grades]([StudentTaskId] ASC);

