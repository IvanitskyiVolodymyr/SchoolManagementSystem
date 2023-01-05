CREATE PROCEDURE [dbo].[spSchedule_GetForTeacherByPeriod]
	@StartDateTime DateTime,
	@EndDateTime DateTime,
	@TeacherId INT
AS
BEGIN
	SELECT SHDL.*, SJ.Name as SubjectName, C.Number as ClassNumber, C.Letter as ClassLetter FROM [school].[Schedules] SHDL
	JOIN [school].[ClassesSubjects] CS ON SHDL.ClassSubjectId = CS.ClassSubjectId
	JOIN [school].SubjectsTeachers ST ON CS.SubjectId= ST.SubjectId
	JOIN [school].[Subjects] SJ ON CS.SubjectId = SJ.SubjectId
	JOIN [school].[Classes] C ON CS.ClassId = C.ClassId

	WHERE ST.TeacherId = @TeacherId AND SHDL.StartTime >= @StartDateTime AND SHDL.EndTime <= @EndDateTime
END
