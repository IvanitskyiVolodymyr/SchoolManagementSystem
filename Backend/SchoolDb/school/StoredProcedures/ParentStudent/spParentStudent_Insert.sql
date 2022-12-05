CREATE PROCEDURE [dbo].[spParentStudent_Insert]
	@ParentId INT,
	@StudentId INT
AS
BEGIN
	INSERT INTO [school].[StudentsParents](ParentId, StudentId)
	OUTPUT inserted.StudentParentId
	VALUES (@ParentId, @StudentId)
END
