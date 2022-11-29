CREATE PROCEDURE [dbo].[spStudentTask_GetById]
	@StudentTaskId INT
AS
BEGIN
	SELECT * FROM [school].[StudentsTasks]
	WHERE StudentTaskId = @StudentTaskId
END