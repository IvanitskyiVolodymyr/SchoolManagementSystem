CREATE PROCEDURE [dbo].[spClassSubject_Insert]
	@ClassId INT,
	@SubjectId INT
AS
BEGIN
	INSERT INTO [school].[ClassesSubjects](ClassId, SubjectId)
	OUTPUT inserted.ClassSubjectId
	VALUES (@ClassId, @SubjectId)
END
