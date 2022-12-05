CREATE PROCEDURE [dbo].[spGrade_Update]
	@Value INT,
	@StudentTaskId INT
AS
BEGIN
	UPDATE [school].[Grades]
	SET [Value] = @Value
	WHERE StudentTaskId = @StudentTaskId
END
