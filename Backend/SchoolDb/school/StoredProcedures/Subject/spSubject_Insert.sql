CREATE PROCEDURE [dbo].[spSubject_Insert]
	@Name NVARCHAR (100),
    @Description NVARCHAR (200)
AS
BEGIN
	INSERT INTO [school].[Subjects] (Name, Description)
	OUTPUT inserted.SubjectId
	VALUES (@Name, @Description)
END
