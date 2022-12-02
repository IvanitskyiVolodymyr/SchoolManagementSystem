CREATE PROCEDURE [dbo].[spClassSubjectGrade_Update]
	@GradeType INT,
	@ClassSubjectId INT,
	@StudentId INT,
	@Grade INT
AS
BEGIN
	UPDATE [school].[ClassSubjectGrades]
	SET Grade = @Grade
	WHERE GradeType = @GradeType AND StudentId = @StudentId AND @ClassSubjectId = @ClassSubjectId
END
