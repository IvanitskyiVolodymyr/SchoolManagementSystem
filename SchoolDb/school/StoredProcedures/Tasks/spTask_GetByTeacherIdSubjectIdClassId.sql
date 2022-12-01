CREATE PROCEDURE [dbo].[spTask_GetByTeacherIdSubjectIdClassId]
	@TeacherId int,
	@SubjectId int,
	@ClassId int,
	@IsDone bit,
	@IsChecked bit
AS
BEGIN
		/*SELECT U.FirstName, U.MiddleName, U.LastName, ST.StudentTaskId, T.TaskType, T.StartDate, T.EndDate, T.Title, T.Description FROM [school].[Tasks] T
		LEFT JOIN [school].[StudentsTasks] ST ON T.TaskId = ST.TaskId
		LEFT JOIN [school].[Students] STUD ON STUD.StudentId = ST.StudentId
		LEFT JOIN [school].[Users] U ON STUD.UserId = U.UserId
		LEFT JOIN [school].[Schedules] SH ON T.ScheduleId = SH.ScheduleId
		LEFT JOIN [school].[ClassesSubjects] CS ON SH.ClassSubjectId = CS.ClassSubjectId
		LEFT JOIN [school].[SubjectsTeachers] SJT ON CS.SubjectId = SJT.SubjectId

		WHERE SJT.TeacherId = @TeacherId AND
				SJT.SubjectId = @SubjectId AND
				CS.ClassId = @ClassId AND
				ST.IsDone = @IsDone AND
				ST.IsChecked = @IsChecked*/
	SELECT U.FirstName, U.MiddleName, U.LastName, ST.StudentTaskId, T.TaskType, T.StartDate, T.EndDate, T.Title, T.Description FROM [school].[Tasks] T
	JOIN [school].[StudentsTasks] ST ON T.TaskId = ST.TaskId AND ST.IsDone = @IsDone AND ST.IsChecked = @IsChecked
	JOIN [school].[Students] STUD ON STUD.StudentId = ST.StudentId
	JOIN [school].[Users] U ON STUD.UserId = U.UserId
	JOIN [school].[Schedules] SH ON T.ScheduleId = SH.ScheduleId
	JOIN [school].[ClassesSubjects] CS ON SH.ClassSubjectId = CS.ClassSubjectId AND CS.ClassId = @ClassId
	JOIN [school].[SubjectsTeachers] SJT ON CS.SubjectId = SJT.SubjectId AND SJT.TeacherId = @TeacherId AND SJT.SubjectId = @SubjectId
END
