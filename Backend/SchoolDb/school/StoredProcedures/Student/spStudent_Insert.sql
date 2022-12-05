CREATE PROCEDURE [dbo].[spStudent_Insert]
	@UserId INT,
    @ClassId INT NULL,
    @StudentCode INT
AS
BEGIN
    INSERT INTO [school].[Students] (UserId, ClassId, StudentCode)
    OUTPUT inserted.StudentId
    VALUES (@UserId, @ClassId, @StudentCode)
END
