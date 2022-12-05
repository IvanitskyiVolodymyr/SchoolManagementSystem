CREATE PROCEDURE [dbo].[spSchedule_CheckIsPeriodForClassSubjectFree]
	@StartDateTime DateTime,
	@EndDateTime DateTime,
	@ClassSubjectId INT
AS
BEGIN
	SELECT CASE WHEN EXISTS 
	(
		SELECT * FROM [school].[Schedules] S
		LEFT JOIN [school].[ClassesSubjects] CS ON CS.ClassSubjectId = S.ClassSubjectId
		WHERE 
		--If some schedule has already exists at this period then - false
		((S.StartTime BETWEEN @StartDateTime AND @EndDateTime) OR (S.EndTime BETWEEN @StartDateTime AND @EndDateTime))
		AND
		CS.ClassId = (SELECT ClassId FROM [school].[ClassesSubjects] WHERE ClassSubjectId = @ClassSubjectId) 
	)
	THEN 0
	ELSE 1
	END
END