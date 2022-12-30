CREATE PROCEDURE [dbo].[spStudenTaskComment_getByStudentTaskCommentId]
	@StudentTaskCommentId INT
AS
BEGIN
	SELECT STC.*, U.* FROM [school].[StudentTaskComments] STC
	join [school].[Users] U ON STC.UserId = U.UserId
	WHERE STC.StudentTaskCommentId = @StudentTaskCommentId
END
