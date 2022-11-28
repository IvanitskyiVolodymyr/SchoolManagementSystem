CREATE PROCEDURE [dbo].[spTask_Update]
	@TaskId INT,
	@TaskType INT,
	@StartDateTime DateTime,
	@EndDateTime DateTime,
	@Description NVARCHAR(1000),
	@Title NVARCHAR(128)
AS
BEGIN
	UPDATE [school].[Tasks]
	SET
	TaskType = @TaskType,
	StartDate = @StartDateTime,
	EndDate = @EndDateTime,
	[Description] = @Description,
	Title = @Title

	WHERE TaskId = @TaskId
END
