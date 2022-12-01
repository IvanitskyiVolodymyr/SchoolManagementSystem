CREATE PROCEDURE [dbo].[spGrade_GetByClassSubjectIdAndPeriod]
	@StudentId INT,
	@ClassSubjectId INT,
	@From DateTime,
	@To DateTime
AS
BEGIN
	SELECT G.* FROM [school].[Grades] G
	LEFT JOIN [school].[StudentsTasks] ST ON G.StudentTaskId = ST.StudentTaskId
	LEFT JOIN [school].[Tasks] T ON ST.TaskId = T.TaskId
	LEFT JOIN [school].[Schedules] SH ON SH.ClassSubjectId = @ClassSubjectId

	WHERE ST.StudentId = @StudentId AND
	(T.StartDate BETWEEN @From AND @To OR
	T.EndDate BETWEEN @From AND @To)
END
