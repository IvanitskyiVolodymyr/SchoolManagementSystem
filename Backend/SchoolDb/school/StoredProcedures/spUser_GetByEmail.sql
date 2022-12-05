CREATE PROCEDURE [dbo].[spUser_GetByEmail]
	@Email NVARCHAR(50)
AS
BEGIN
	SELECT * FROM school.Users
	WHERE Email = @Email
END
