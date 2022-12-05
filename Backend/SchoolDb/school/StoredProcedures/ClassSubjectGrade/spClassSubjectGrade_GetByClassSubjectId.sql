CREATE PROCEDURE [dbo].[spClassSubjectGrade_GetByClassSubjectId]
	@StudentId INT,
	@ClassSubjectId INT
AS
BEGIN
	SELECT * FROM [school].[ClassSubjectGrades]
	WHERE ClassSubjectId = @ClassSubjectId AND StudentId = @StudentId
END
