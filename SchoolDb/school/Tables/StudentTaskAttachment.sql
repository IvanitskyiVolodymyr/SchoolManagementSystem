CREATE TABLE [school].[StudentTaskAttachment]
(
	[StudentTaskAttachmentId] INT IDENTITY NOT NULL, 
    [FileUrl] NVARCHAR(256) NOT NULL, 
    [StudentTaskId] INT NOT NULL

    CONSTRAINT [PK_StudentTaskAttachment] PRIMARY KEY CLUSTERED ([StudentTaskAttachmentId] ASC),
    CONSTRAINT [FK_StudentTaskAttachment_StudentTask] FOREIGN KEY ([StudentTaskId]) REFERENCES [school].[StudentsTasks]([StudentTaskId])
)
GO

CREATE NONCLUSTERED INDEX [FK_StudentTaskAttachment_StudentTask_2] ON [school].[StudentTaskAttachment] 
 (
  [StudentTaskId] ASC
 )
