CREATE PROCEDURE [dbo].[spStudent_GetByUserId]
	@UserId INT
AS
BEGIN
	SELECT S.* FROM [school].[Students] S
	JOIN [school].[Users] U ON S.UserId = U.UserId
	WHERE U.UserId = @UserId
END