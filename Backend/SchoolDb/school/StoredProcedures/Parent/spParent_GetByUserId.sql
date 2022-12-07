CREATE PROCEDURE [dbo].[spParent_GetByUserId]
	@UserId INT
AS
BEGIN
	SELECT P.* FROM [school].[Parents] P
	JOIN [school].[Users] U ON P.UserId = U.UserId
	WHERE U.UserId = @UserId
END