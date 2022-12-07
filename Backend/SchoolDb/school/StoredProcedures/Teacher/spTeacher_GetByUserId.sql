CREATE PROCEDURE [dbo].[spTeacher_GetByUserId]
	@UserId INT
AS
BEGIN
	SELECT T.* FROM [school].[Teachers] T
	JOIN [school].[Users] U ON T.UserId = U.UserId
	WHERE U.UserId = @UserId
END
