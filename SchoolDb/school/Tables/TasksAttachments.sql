CREATE TABLE [school].[TasksAttachments] (
    [TaskAttachmentId] INT            NOT NULL,
    [FIleUrl]          NVARCHAR (255) NOT NULL,
    [TaskId]           INT            NOT NULL,
    CONSTRAINT [PK_TaskAttachment] PRIMARY KEY CLUSTERED ([TaskAttachmentId] ASC),
    CONSTRAINT [FK_TaskAttachment_Task] FOREIGN KEY ([TaskId]) REFERENCES [school].[Tasks] ([TaskId])
);


GO
CREATE NONCLUSTERED INDEX [FK_TaskAttachment_Task_2]
    ON [school].[TasksAttachments]([TaskId] ASC);

