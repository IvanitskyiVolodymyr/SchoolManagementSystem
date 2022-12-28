CREATE PROCEDURE [dbo].[spUser_GetClassIdByStudentId]
	@StudentId INT
AS
BEGIN
	SELECT C.ClassId FROM [school].[Students] S 
	JOIN [school].[Classes] C ON C.ClassId = S.ClassId
	WHERE S.StudentId= @StudentId
END

