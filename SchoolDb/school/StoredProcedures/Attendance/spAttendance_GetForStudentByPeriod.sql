CREATE PROCEDURE [dbo].[spAttendance_GetForStudentByPeriod]
	@StudentId INT,
	@StartDateTime DateTime,
	@EndDateTime DateTime
AS
BEGIN
	SELECT A.* FROM [school].[Attendances] A
	LEFT JOIN [school].[Schedules] S ON A.ScheduleId = S.ScheduleId
	WHERE S.StartTime >= @StartDateTime AND S.EndTime <= @EndDateTime AND A.StudentId = @StudentId
END