CREATE PROCEDURE [dbo].[spStudentTask_Update]
	@StudentId INT,
	@TaskId INT,
	@IsDone BIT,
	@IsChecked BIT,
	@IsNeededToBeRedone BIT,
	@AttachmentsLinks NVARCHAR(MAX)
AS
BEGIN
	UPDATE [school].[StudentsTasks]
	SET
	IsDone = @IsDone,
	IsChecked = @IsChecked,
	IsNeededToBeRedone = @IsNeededToBeRedone,
	AttachmentsLinks = @AttachmentsLinks

	WHERE TaskId = @TaskId AND StudentId = @StudentId
END
