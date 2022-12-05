CREATE PROCEDURE [dbo].[spSchedule_Insert]
	@StartTime DATETIME,
    @ClassSubjectId INT,
    @EndTime DATETIME,
    @Place NVARCHAR (200)
AS
BEGIN
    INSERT INTO [school].[Schedules] (StartTime, ClassSubjectId, EndTime, Place) 
    OUTPUT inserted.ScheduleId
    VALUES (@StartTime, @ClassSubjectId, @EndTime, @Place)
END
