CREATE PROCEDURE [dbo].[spGrade_GetAllWithSubjects]
	@StudentId INT
AS
BEGIN

	/*SELECT SJC.SubjectId, SJC.Name, SJC.ClassSubjectId, G.*, ST.StudentId FROM 
		(SELECT SJ.SubjectId, Sj.Name, CS.ClassSubjectId FROM [school].[ClassesSubjects] CS 
		INNER JOIN [school].[Students] S ON CS.ClassId = S.ClassId
		INNER JOIN [school].[Subjects] SJ ON CS.SubjectId = SJ.SubjectId
		WHERE S.StudentId = @StudentId) AS SJC
	LEFT JOIN [school].[Schedules] SH ON SJC.ClassSubjectId = SH.ClassSubjectId
	LEFT JOIN [school].[Tasks] T ON SH.ScheduleId = T.ScheduleId
	LEFT JOIN [school].[StudentsTasks] ST ON ST.TaskId = T.TaskId AND ST.StudentId = @StudentId
	LEFT JOIN [school].[Grades] G ON G.StudentTaskId = ST.StudentTaskId*/

	SELECT SJC.ClassSubjectId, SJC.Name as SubjectName, G.*  FROM[school].[Grades] G 
	INNER JOIN [school].[StudentsTasks] ST ON G.StudentTaskId = ST.StudentTaskId 
	INNER JOIN [school].[Tasks] T ON ST.TaskId = T.TaskId AND ST.StudentId = @StudentId
	INNER JOIN [school].[Schedules] SH ON SH.ScheduleId = T.ScheduleId
	RIGHT JOIN (SELECT SJ.Name, CS.ClassSubjectId FROM [school].[ClassesSubjects] CS 
				INNER JOIN [school].[Students] S ON CS.ClassId = S.ClassId
				INNER JOIN [school].[Subjects] SJ ON CS.SubjectId = SJ.SubjectId
				WHERE S.StudentId = @StudentId) 
				AS SJC ON SJC.ClassSubjectId = SH.ClassSubjectId

END
