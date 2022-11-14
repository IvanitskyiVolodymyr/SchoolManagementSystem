CREATE PROCEDURE [dbo].[spUser_GetById]
	@UserId int
AS
BEGIN
	SELECT * FROM school.Users
	WHERE UserId = @UserId
END
