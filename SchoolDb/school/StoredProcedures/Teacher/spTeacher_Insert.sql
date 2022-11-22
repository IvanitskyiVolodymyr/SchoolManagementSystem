CREATE PROCEDURE [dbo].[spTeacher_Insert]
	@UserId INT
AS
BEGIN
	INSERT INTO [school].[Teachers] (UserId)
	OUTPUT inserted.TeacherId
    VALUES (@UserId)
END
