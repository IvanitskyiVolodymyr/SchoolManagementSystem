CREATE PROCEDURE [dbo].[spGrade_Insert]
	@Value INT,
	@StudentTaskId INT
AS
BEGIN
	INSERT INTO [school].[Grades]([Value], StudentTaskId)
	OUTPUT inserted.GradeId
	VALUES(@Value, @StudentTaskId)
END