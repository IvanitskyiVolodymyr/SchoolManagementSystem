CREATE TABLE [school].[StudentTaskComments]
(
	[StudentTaskCommentId] INT NOT NULL IDENTITY, 
    [Comment] NVARCHAR(MAX) NOT NULL, 
    [UserId] INT NOT NULL, 
    [StudentTaskId] INT NOT NULL,
    [CreatedAt] DATETIME NOT NULL, 
    [UpdatedAt] DATETIME NULL, 
    [CommentParentId] INT NULL, 

    CONSTRAINT [PK_StudentTaskComment] PRIMARY KEY CLUSTERED ([StudentTaskCommentId] ASC),
    CONSTRAINT [FK_StudentTaskComment_StudentTask] FOREIGN KEY ([StudentTaskId])  REFERENCES [school].[StudentsTasks]([StudentTaskId]),
    CONSTRAINT [FK_StudentTaskComment_User] FOREIGN KEY ([UserId])  REFERENCES [school].[Users]([UserId])

)
GO

CREATE NONCLUSTERED INDEX [IX_StudentTaskComment_StudentTask] ON [school].[StudentTaskComments] 
 (
  [StudentTaskId] ASC
 )

GO

CREATE NONCLUSTERED INDEX [IX_StudentTaskComment_User] ON [school].[StudentTaskComments] 
 (
  [UserId] ASC
 )

