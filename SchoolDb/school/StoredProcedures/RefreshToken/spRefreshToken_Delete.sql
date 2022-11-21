CREATE PROCEDURE [dbo].[spRefreshToken_Delete]
	@RefreshTokenId INT
AS
BEGIN
	DELETE FROM [school].[RefreshTokens] WHERE RefreshTokenId = @RefreshTokenId
END
