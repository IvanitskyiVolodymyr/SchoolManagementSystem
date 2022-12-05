CREATE PROCEDURE [dbo].[spClassSubjectGrade_GetByClassId]
	@StudentId INT,
	@ClassId INT
AS
BEGIN
	SELECT CSG.* FROM [school].[ClassSubjectGrades] CSG
	JOIN [school].[Students] S ON S.StudentId = CSG.StudentId

	WHERE S.StudentId = @StudentId AND S.ClassId = @ClassId
END
