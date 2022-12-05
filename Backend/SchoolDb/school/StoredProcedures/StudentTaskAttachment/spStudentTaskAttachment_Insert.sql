CREATE PROCEDURE [dbo].[spStudentTaskAttachment_Insert]
	@StudentTaskId INT,
	@FileUrl NVARCHAR(256)
AS
BEGIN
	INSERT INTO [school].[StudentTaskAttachment](StudentTaskId, FileUrl)
	OUTPUT inserted.StudentTaskAttachmentId
	VALUES(@StudentTaskId, @FileUrl)
END
