CREATE PROCEDURE [dbo].[spTask_GetUserIdByStudentTaskId]
	@StudentTaskId INT
AS
BEGIN
	SELECT S.UserId FROM [school].[StudentsTasks] ST
	JOIN [school].[Students] S ON ST.StudentId = S.StudentId
	WHERE ST.StudentTaskId = @StudentTaskId
END
