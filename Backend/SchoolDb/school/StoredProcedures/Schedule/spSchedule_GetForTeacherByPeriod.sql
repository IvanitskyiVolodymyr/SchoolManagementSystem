CREATE PROCEDURE [dbo].[spSchedule_GetForTeacherByPeriod]
	@StartDateTime DateTime,
	@EndDateTime DateTime,
	@TeacherId INT
AS
BEGIN
	SELECT SHDL.* FROM [school].[Schedules] SHDL
	LEFT JOIN [school].[ClassesSubjects] CS ON SHDL.ClassSubjectId = CS.ClassSubjectId
	LEFT JOIN [school].SubjectsTeachers ST ON CS.SubjectId= ST.SubjectId

	WHERE ST.TeacherId = @TeacherId AND SHDL.StartTime >= @StartDateTime AND SHDL.EndTime <= @EndDateTime
END
