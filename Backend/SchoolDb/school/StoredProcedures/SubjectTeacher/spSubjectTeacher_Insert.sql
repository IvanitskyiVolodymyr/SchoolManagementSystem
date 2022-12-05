CREATE PROCEDURE [dbo].[spSubjectTeacher_Insert]
	@SubjectId INT,
	@TeacherId INT
AS
BEGIN
	INSERT INTO [school].[SubjectsTeachers](SubjectId, TeacherId)
	OUTPUT inserted.SubjectTeacherId
	VALUES (@SubjectId, @TeacherId)
END
