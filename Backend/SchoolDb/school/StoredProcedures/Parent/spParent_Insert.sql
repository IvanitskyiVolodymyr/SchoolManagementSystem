CREATE PROCEDURE [dbo].[spParent_Insert]
	@UserId INT
AS
BEGIN
    INSERT INTO [school].[Parents] (UserId)
    OUTPUT inserted.ParentId
    VALUES (@UserId)
END
