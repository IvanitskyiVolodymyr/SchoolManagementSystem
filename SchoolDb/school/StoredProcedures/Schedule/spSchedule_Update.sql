CREATE PROCEDURE [dbo].[spSchedule_Update]
    @ScheduleId INT,
	@StartTime DATETIME,
    @ClassSubjectId INT,
    @EndTime DATETIME,
    @Place NVARCHAR (200)
AS
BEGIN
    UPDATE [school].[Schedules]
    SET
    StartTime = @StartTime,
    ClassSubjectId = @ClassSubjectId,
    EndTime = @EndTime,
    Place = @Place
    WHERE ScheduleId = @ScheduleId
END
