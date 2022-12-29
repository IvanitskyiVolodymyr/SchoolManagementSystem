CREATE PROCEDURE [dbo].[spStudentTaskComment_Update]
	@StudentTaskCommentId INT,
	@Comment NVARCHAR(MAX)
AS
BEGIN
	UPDATE [school].[StudentTaskComments]
	SET
	Comment = @Comment,
	UpdatedAt = GETDATE()

	WHERE StudentTaskCommentId = @StudentTaskCommentId
END
