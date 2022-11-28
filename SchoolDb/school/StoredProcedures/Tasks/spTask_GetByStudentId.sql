CREATE PROCEDURE [dbo].[spTask_GetByStudentId]
	@StudentId INT,
	@StartDateTime DateTime,
	@EndDateTime DateTime
AS
BEGIN
	SELECT T.*, ST.IsChecked, ST.IsDone, ST.IsNeededToBeRedone FROM [school].[Tasks] T
	LEFT JOIN [school].[StudentsTasks] ST ON T.TaskId = ST.TaskId
	WHERE ST.StudentId = @StudentId AND T.StartDate >= @StartDateTime AND T.EndDate <= @EndDateTime
END