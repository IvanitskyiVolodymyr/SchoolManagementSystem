CREATE PROCEDURE [dbo].[spStudentTaskComment_Create]
	@Comment NVARCHAR(MAX),
	@UserId INT,
	@StudentTaskId INT,
	@CommentParentId INT
AS
BEGIN
	INSERT INTO [school].[StudentTaskComments](Comment, UserId, StudentTaskId, CreatedAt, CommentParentId)
	OUTPUT inserted.StudentTaskCommentId
	VALUES(@Comment, @UserId, @StudentTaskId, GETDATE(), @CommentParentId)
END
