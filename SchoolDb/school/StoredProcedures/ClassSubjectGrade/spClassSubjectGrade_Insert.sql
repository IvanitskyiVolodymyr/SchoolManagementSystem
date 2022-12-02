CREATE PROCEDURE [dbo].[spClassSubjectGrade_Insert]
	@GradeType INT,
	@ClassSubjectId INT,
	@StudentId INT,
	@Grade INT
AS
BEGIN
	INSERT INTO [school].[ClassSubjectGrades](GradeType, ClassSubjectId, StudentId, Grade)
	OUTPUT inserted.ClassSubjectGradeId
	VALUES(@GradeType, @ClassSubjectId, @StudentId, @Grade)
END