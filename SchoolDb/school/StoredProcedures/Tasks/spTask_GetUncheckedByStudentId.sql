CREATE PROCEDURE [dbo].[spTask_GetUncheckedByStudentId]
	@StudentId INT
AS
BEGIN
	SELECT T.*, ST.StudentTaskId, ST.IsChecked, ST.IsDone, ST.IsNeededToBeRedone FROM [school].[Tasks] T
	LEFT JOIN [school].[StudentsTasks] ST ON T.TaskId = ST.TaskId
	WHERE ST.StudentId = @StudentId AND ST.IsChecked = 0
END
