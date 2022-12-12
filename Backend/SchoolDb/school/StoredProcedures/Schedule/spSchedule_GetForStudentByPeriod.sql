CREATE PROCEDURE [dbo].[spSchedule_GetForStudentByPeriod]
	@StartDateTime DateTime,
	@EndDateTime DateTime,
	@StudentId INT
AS
BEGIN
	SELECT SHDL.*, SJ.Name as SubjectName FROM [school].[Schedules] SHDL
	LEFT JOIN [school].[ClassesSubjects] CS ON SHDL.ClassSubjectId = CS.ClassSubjectId
	LEFT JOIN [school].[Students] S ON S.ClassId = CS.ClassId
	JOIN [school].Subjects SJ ON SJ.SubjectId = CS.SubjectId
	WHERE S.StudentId = @StudentId AND SHDL.StartTime >= @StartDateTime AND SHDL.EndTime <= @EndDateTime
END
