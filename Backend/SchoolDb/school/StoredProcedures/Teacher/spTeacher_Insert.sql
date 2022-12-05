CREATE PROCEDURE [dbo].[spTeacher_Insert]
	@UserId INT,
	@ClassId INT NULL
AS
BEGIN
	INSERT INTO [school].[Teachers] (UserId, ClassId)
	OUTPUT inserted.TeacherId
    VALUES (@UserId, @ClassId)
END
