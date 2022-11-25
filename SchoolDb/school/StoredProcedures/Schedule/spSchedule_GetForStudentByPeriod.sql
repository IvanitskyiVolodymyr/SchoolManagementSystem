CREATE PROCEDURE [dbo].[spSchedule_GetForStudentByPeriod]
	@StartDateTime DateTime,
	@EndDateTime DateTime,
	@StudentId INT
AS
BEGIN
	SELECT SHDL.* FROM [school].[Schedules] SHDL
	LEFT JOIN [school].[ClassesSubjects] CS ON SHDL.ClassSubjectId = CS.ClassSubjectId
	LEFT JOIN [school].[Students] S ON S.ClassId = CS.ClassId
	WHERE S.StudentId = @StudentId AND SHDL.StartTime >= @StartDateTime AND SHDL.EndTime <= @EndDateTime
END
