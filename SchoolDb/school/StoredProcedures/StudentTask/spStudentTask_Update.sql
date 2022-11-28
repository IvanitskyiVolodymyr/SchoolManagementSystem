CREATE PROCEDURE [dbo].[spStudentTask_Update]
	@StudentId INT,
	@TaskId INT,
	@IsDone BIT,
	@IsChecked BIT,
	@IsNeededToBeRedone BIT
AS
BEGIN
	UPDATE [school].[StudentsTasks]
	SET
	IsDone = @IsDone,
	IsChecked = @IsChecked,
	IsNeededToBeRedone = @IsNeededToBeRedone

	WHERE TaskId = @TaskId AND StudentId = @StudentId
END
