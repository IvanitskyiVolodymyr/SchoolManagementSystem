CREATE PROCEDURE [dbo].[spUser_GetAllByScheduleId]
	@ScheduleId INT
AS
BEGIN
	SELECT S.* FROM [school].[Students] S
	LEFT JOIN [school].[ClassesSubjects] CS ON S.ClassId = CS.ClassId
	LEFT JOIN [school].[Schedules] SH ON CS.ClassSubjectId = SH.ClassSubjectId

	WHERE SH.ScheduleId = @ScheduleId
END
