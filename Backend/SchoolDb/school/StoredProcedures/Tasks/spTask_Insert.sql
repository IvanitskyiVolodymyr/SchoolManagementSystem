CREATE PROCEDURE [dbo].[spTask_Insert]
	@ScheduleId INT,
	@TaskType INT,
	@StartDateTime DateTime,
	@EndDateTime DateTime,
	@Description NVARCHAR(1000),
	@Title NVARCHAR(128)
AS
BEGIN
	INSERT INTO [school].[Tasks] (ScheduleId, TaskType, StartDate, EndDate, Description, Title)
	OUTPUT inserted.TaskId
	VALUES(@ScheduleId, @TaskType, @StartDateTime, @EndDateTime, @Description, @Title)
END