CREATE PROCEDURE [dbo].[spGrade_GetByStudentTaskId]
	@StudentTaskId INT
AS
BEGIN
	SELECT * FROM [school].[Grades]
	WHERE StudentTaskId = @StudentTaskId
END