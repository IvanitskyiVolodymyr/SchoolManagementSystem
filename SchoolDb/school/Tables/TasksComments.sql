CREATE TABLE [school].[TasksComments] (
    [TaskCommentId] INT            NOT NULL,
    [TaskId]        INT            NOT NULL,
    [Comment]       NVARCHAR (255) NOT NULL,
    CONSTRAINT [PK_TaskComment] PRIMARY KEY CLUSTERED ([TaskCommentId] ASC),
    CONSTRAINT [FK_TaskComment_Task] FOREIGN KEY ([TaskId]) REFERENCES [school].[Tasks] ([TaskId])
);


GO
CREATE NONCLUSTERED INDEX [FK_TaskComment_Task_2]
    ON [school].[TasksComments]([TaskId] ASC);

