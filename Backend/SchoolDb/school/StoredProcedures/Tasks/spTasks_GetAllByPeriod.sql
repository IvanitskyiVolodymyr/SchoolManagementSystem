CREATE PROCEDURE [dbo].[spTasks_GetAllByPeriod]
	@StudentId INT,
	@From DateTime,
	@To DateTime
AS
BEGIN
	SELECT T.*, ST.StudentTaskId, ST.IsChecked, ST.IsDone, ST.IsNeededToBeRedone, S.Name AS SubjectTitle  FROM [school].[Tasks] T
	JOIN [school].[StudentsTasks] ST ON T.TaskId = ST.TaskId
	JOIN [school].[Schedules] SCH ON SCH.ScheduleId = T.ScheduleId
	JOIN [school].[ClassesSubjects] CS ON CS.ClassSubjectId = SCH.ClassSubjectId
	JOIN [school].[Subjects] S ON CS.SubjectId = S.SubjectId
	WHERE ST.StudentId = @StudentId AND
	--(T.StartDate BETWEEN @From AND @To OR
	--T.EndDate BETWEEN @From AND @To)
	T.EndDate BETWEEN @From AND @To
END
