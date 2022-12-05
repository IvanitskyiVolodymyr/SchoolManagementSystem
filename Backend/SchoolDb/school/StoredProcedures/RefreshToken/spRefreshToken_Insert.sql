CREATE PROCEDURE [dbo].[spRefreshToken_Insert]
    @RefreshTokenId INT,
	@Token NVARCHAR (100),
    @UserId INT,
    @Expires DATETIME
AS
BEGIN
INSERT INTO [school].[RefreshTokens]
    (Token,
    UserId,
    Expires)
    VALUES(
    @Token,
    @UserId,
    @Expires);
END
