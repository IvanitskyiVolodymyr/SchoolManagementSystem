CREATE PROCEDURE [dbo].[spAttendance_Update]
    @ScheduleId INT,
    @StudentId INT,
    @Status INT
AS
BEGIN
    UPDATE [school].[Attendances]
    SET 
    Status = @Status

    WHERE ScheduleId = @ScheduleId AND StudentId = @StudentId
END
