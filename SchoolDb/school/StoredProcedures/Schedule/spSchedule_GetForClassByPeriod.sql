CREATE PROCEDURE [dbo].[spSchedule_GetForClassByPeriod]
	@StartDateTime DateTime,
	@EndDateTime DateTime,
	@ClassId INT
AS
BEGIN
	SELECT SHDL.* FROM [school].[Schedules] SHDL
	LEFT JOIN [school].[ClassesSubjects] CS ON SHDL.ClassSubjectId = CS.ClassSubjectId
	LEFT JOIN [school].[Classes] C ON CS.ClassId = C.ClassId
	WHERE C.ClassId = @ClassId AND SHDL.StartTime >= @StartDateTime AND SHDL.EndTime <= @EndDateTime
END
