CREATE PROCEDURE [dbo].[spTasks_GetByStudentTaskId]
	@StudentTaskId INT
AS
BEGIN
	SELECT T.*, ST.StudentTaskId, ST.IsChecked, ST.IsDone, ST.IsNeededToBeRedone, ST.AttachmentsLinks, S.Name AS SubjectTitle  FROM [school].[Tasks] T
	JOIN [school].[StudentsTasks] ST ON T.TaskId = ST.TaskId
	JOIN [school].[Schedules] SCH ON SCH.ScheduleId = T.ScheduleId
	JOIN [school].[ClassesSubjects] CS ON CS.ClassSubjectId = SCH.ClassSubjectId
	JOIN [school].[Subjects] S ON CS.SubjectId = S.SubjectId
	WHERE ST.StudentTaskId = @StudentTaskId
END
