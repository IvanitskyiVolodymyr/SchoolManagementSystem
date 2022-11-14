CREATE TABLE [school].[Tasks] (
    [TaskId]             INT      NOT NULL,
    [ScheduleId]         INT      NOT NULL,
    [StudentId]          INT      NOT NULL,
    [TaskType]           INT      NOT NULL,
    [IsDone]             BIT      NOT NULL,
    [IsChecked]          BIT      NOT NULL,
    [IsNeededToBeRedone] BIT      NOT NULL,
    [StartDate]          DATETIME NOT NULL,
    [EndDate]            DATETIME NOT NULL,
    CONSTRAINT [PK_Task] PRIMARY KEY CLUSTERED ([TaskId] ASC),
    CONSTRAINT [FK_Task_Schedule] FOREIGN KEY ([ScheduleId]) REFERENCES [school].[Schedules] ([ScheduleId]),
    CONSTRAINT [FK_Task_Student] FOREIGN KEY ([StudentId]) REFERENCES [school].[Students] ([StudentId])
);


GO
CREATE NONCLUSTERED INDEX [FK_Task_Student_2]
    ON [school].[Tasks]([StudentId] ASC);


GO
CREATE NONCLUSTERED INDEX [FK_Task_Schedule_2]
    ON [school].[Tasks]([ScheduleId] ASC);

