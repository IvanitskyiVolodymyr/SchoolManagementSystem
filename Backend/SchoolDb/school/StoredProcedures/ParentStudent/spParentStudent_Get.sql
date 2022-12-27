CREATE PROCEDURE [dbo].[spParentStudent_Get]
	@ParentId INT
AS
BEGIN
	SELECT SP.*, U.UserId as StudentUserId FROM [school].[StudentsParents] SP
	JOIN [school].[Students] S ON SP.StudentId = S.StudentId
	JOIN [school].[Users] U ON U.UserId = S.UserId
	WHERE SP.ParentId = @ParentId
END