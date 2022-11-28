CREATE PROCEDURE [dbo].[spStudentTask_Insert]
	@StudentId INT,
	@TaskId INT
AS
BEGIN
	INSERT INTO [school].[StudentsTasks] (StudentId, TaskId)
	OUTPUT inserted.StudentTaskId
	VALUES(@StudentId,@TaskId)
END
