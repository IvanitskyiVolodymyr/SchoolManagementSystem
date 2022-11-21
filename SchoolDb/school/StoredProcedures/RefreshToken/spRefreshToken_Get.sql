CREATE PROCEDURE [dbo].[spRefreshToken_Get]
	@Token NVARCHAR(100)
AS
BEGIN
	SELECT * FROM [school].[RefreshTokens]
	WHERE Token = @Token
END
