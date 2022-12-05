CREATE PROCEDURE [dbo].[spClass_Insert]
	@Number INT,
	@Letter NVARCHAR(2),
	@StartOfTheAcademicYear DATE,
	@EndOfTheAcademicYear DATE
AS
BEGIN
	INSERT INTO [school].[Classes] (Number, Letter, StartOfTheAcademicYear, EndOfTheAcademicYear)
	OUTPUT inserted.ClassId
	VALUES (@Number, @Letter, @StartOfTheAcademicYear, @EndOfTheAcademicYear)
END
