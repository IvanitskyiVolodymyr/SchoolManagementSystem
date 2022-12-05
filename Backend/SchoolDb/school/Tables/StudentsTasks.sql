CREATE TABLE [school].[StudentsTasks]
(
	[StudentTaskId] INT NOT NULL IDENTITY, 
    [StudentId] INT NOT NULL, 
    [TaskId] INT NOT NULL,
    [IsDone]             BIT      NOT NULL DEFAULT 0,
    [IsChecked]          BIT      NOT NULL DEFAULT 0,
    [IsNeededToBeRedone] BIT      NOT NULL DEFAULT 0,
    CONSTRAINT [PK_StudentTask] PRIMARY KEY CLUSTERED ([StudentTaskId] ASC),
    CONSTRAINT [FK_StudentTask_Student] FOREIGN KEY ([StudentId]) REFERENCES [school].[Students] ([StudentId]),
    CONSTRAINT [FK_StudentTask_Task] FOREIGN KEY ([TaskId]) REFERENCES [school].[Tasks]([TaskId]),
)

GO
CREATE NONCLUSTERED INDEX [FK_StudentTask_Student_2]
    ON [school].[Students]([StudentId] ASC);

GO
CREATE NONCLUSTERED INDEX [FK_StudentTask_Task_2]
    ON [school].[Tasks]([TaskId] ASC);
