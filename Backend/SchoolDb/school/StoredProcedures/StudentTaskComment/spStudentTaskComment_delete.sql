CREATE PROCEDURE [dbo].[spStudentTaskComment_delete]
	@StudentTaskCommentId INT
AS
BEGIN
	DELETE FROM [school].[StudentTaskComments] WHERE StudentTaskCommentId = @StudentTaskCommentId;
END
