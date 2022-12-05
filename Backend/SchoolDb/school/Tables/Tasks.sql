CREATE TABLE [school].[Tasks] (
    [TaskId]             INT IDENTITY NOT NULL,
    [ScheduleId]         INT      NOT NULL,
    [TaskType]           INT      NOT NULL,
    [StartDate]          DATETIME NOT NULL,
    [EndDate]            DATETIME NOT NULL,
    [Description] NVARCHAR(1024) NULL, 
    [Title] NVARCHAR(128) NULL, 
    CONSTRAINT [PK_Task] PRIMARY KEY CLUSTERED ([TaskId] ASC),
    CONSTRAINT [FK_Task_Schedule] FOREIGN KEY ([ScheduleId]) REFERENCES [school].[Schedules] ([ScheduleId])
);


GO
CREATE NONCLUSTERED INDEX [FK_Task_Schedule_2]
    ON [school].[Tasks]([ScheduleId] ASC);

