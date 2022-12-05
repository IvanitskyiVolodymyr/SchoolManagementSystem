CREATE PROCEDURE [dbo].[spTask_GetCheckedByStudentId]
	@StudentId INT,
	@From DateTime,
	@To DateTime
AS
BEGIN
	SELECT T.*, ST.StudentTaskId, ST.IsChecked, ST.IsDone, ST.IsNeededToBeRedone FROM [school].[Tasks] T
	LEFT JOIN [school].[StudentsTasks] ST ON T.TaskId = ST.TaskId
	WHERE ST.StudentId = @StudentId AND ST.IsChecked = 1 AND
	(T.StartDate BETWEEN @From AND @To OR
	T.EndDate BETWEEN @From AND @To)

	--ST.StudentId = @StudentId AND (T.StartDate >= @StartDateTime OR T.EndDate <= @EndDateTime)
END
