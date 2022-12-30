CREATE PROCEDURE [dbo].[spStudentTaskComment_GetByStudentTaskId]
	@StudentTaskId INT
AS
BEGIN
	SELECT STC.*, U.* FROM [school].[StudentTaskComments] STC
	join [school].[Users] U ON STC.UserId = U.UserId
	WHERE STC.StudentTaskId = @StudentTaskId
END