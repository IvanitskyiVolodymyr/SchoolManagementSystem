CREATE PROCEDURE [dbo].[spAttendance_Insert]
	@ScheduleId INT,
	@StudentId INT,
	@Status INT
AS
BEGIN
	INSERT INTO [school].[Attendances] (ScheduleId, StudentId, Status)
	OUTPUT inserted.AttendanceId
	VALUES(@ScheduleId, @StudentId, @Status)
END