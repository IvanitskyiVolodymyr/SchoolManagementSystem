CREATE PROCEDURE [dbo].[spTask_GetAllByPeriodAndType]
	@StudentId INT,
	@From DateTime,
	@To DateTime,
	@TaskType INT
AS
BEGIN
	SELECT T.*, ST.StudentTaskId, ST.IsChecked, ST.IsDone, ST.IsNeededToBeRedone FROM [school].[Tasks] T
	LEFT JOIN [school].[StudentsTasks] ST ON T.TaskId = ST.TaskId
	WHERE ST.StudentId = @StudentId AND T.TaskType = @TaskType AND
	(T.StartDate BETWEEN @From AND @To OR
	T.EndDate BETWEEN @From AND @To)
END
