CREATE PROCEDURE [dbo].[spAttendance_GetForClassSubjectByPeriod]
	@ClassSubjectId INT,
	@StartDateTime DateTime,
	@EndDateTime DateTime
AS
BEGIN
	SELECT A.* FROM [school].[Attendances] A
	JOIN [school].[Schedules] S ON A.ScheduleId = S.ScheduleId
	JOIN [school].[ClassesSubjects] CS ON S.ClassSubjectId = CS.ClassSubjectId
	WHERE S.StartTime >= @StartDateTime AND S.EndTime <= @EndDateTime AND CS.ClassSubjectId = @ClassSubjectId
END