CREATE PROCEDURE [dbo].[spStudentTaskComment_Create]
	@Comment NVARCHAR(MAX),
	@UserId INT,
	@StudentTaskId INT
AS
BEGIN
	INSERT INTO [school].[StudentTaskComments](Comment, UserId, StudentTaskId, CreatedAt)
	OUTPUT inserted.StudentTaskCommentId
	VALUES(@Comment, @UserId, @StudentTaskId, GETDATE())
END
