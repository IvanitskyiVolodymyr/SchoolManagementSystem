CREATE PROCEDURE [dbo].[spStudentTaskAttachment_GetByStudentTaskId]
	@StudentTaskId INT
AS
BEGIN
	SELECT * FROM [school].StudentTaskAttachment STA
	WHERE STA.StudentTaskId = @StudentTaskId
END
