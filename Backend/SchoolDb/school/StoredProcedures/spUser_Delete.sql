CREATE PROCEDURE [dbo].[spUser_Delete]
	@UserId int
AS
BEGIN
	DELETE 
	FROM school.Users
	WHERE UserId = @UserId
END
