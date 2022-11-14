CREATE TABLE [school].[CommentsAttachments] (
    [CommentAttachementId] INT            NOT NULL,
    [FileUrl]              NVARCHAR (255) NOT NULL,
    [TaskCommentId]        INT            NOT NULL,
    CONSTRAINT [PK_CommentAttachment] PRIMARY KEY CLUSTERED ([CommentAttachementId] ASC),
    CONSTRAINT [FK_CommentAttachment_TaskComment] FOREIGN KEY ([TaskCommentId]) REFERENCES [school].[TasksComments] ([TaskCommentId])
);


GO
CREATE NONCLUSTERED INDEX [FK_2]
    ON [school].[CommentsAttachments]([TaskCommentId] ASC);

