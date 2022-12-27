CREATE PROCEDURE [dbo].[spRole_GetByUserId]
	@UserId INT
AS
BEGIN
	SELECT R.RoleId FROM [school].Roles R
	JOIN [school].[Users] U ON U.RoleId = R.RoleId
	WHERE U.UserId = @UserId
END
