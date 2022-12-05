CREATE PROCEDURE [dbo].[spSubject_GetAllByStudentId]
	@StudentId INT
AS
BEGIN
	SELECT S.SubjectId, S.Name, CS.ClassSubjectId FROM [school].[Subjects] S
	JOIN [school].[ClassesSubjects] CS ON S.SubjectId = CS.SubjectId
	JOIN [school].[Students] ST ON St.ClassId = CS.ClassId

	WHERE ST.StudentId = @StudentId
END
