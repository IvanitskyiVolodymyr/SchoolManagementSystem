CREATE PROCEDURE [dbo].[spSchedule_UpdateAttendanceCheck]
	@ScheduleId INT,
	@IsAttendanceChecked BIT
AS
BEGIN
	UPDATE [school].[Schedules]
	SET IsAttendanceChecked = @IsAttendanceChecked
	WHERE ScheduleId = @ScheduleId
END