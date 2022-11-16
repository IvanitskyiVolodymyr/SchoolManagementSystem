CREATE PROCEDURE [dbo].[spUser_GetByEmail]
	@Email int
AS
BEGIN
	SELECT * FROM school.Users
	WHERE Email = @Email
END
