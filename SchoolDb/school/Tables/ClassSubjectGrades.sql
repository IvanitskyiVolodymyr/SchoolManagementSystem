CREATE TABLE [school].[ClassSubjectGrades]
(
	[ClassSubjectGradeId] int IDENTITY NOT NULL ,
	[GradeType]           int NOT NULL ,
	[ClassSubjectId]      int NOT NULL ,
	[StudentId]           int NOT NULL ,
	[Grade]               int NOT NULL ,

	CONSTRAINT [PK_ClassSubjectGrade] PRIMARY KEY CLUSTERED ([ClassSubjectGradeId] ASC),
	CONSTRAINT [FK_ClassSubjectGrade_Student] FOREIGN KEY ([StudentId])  REFERENCES [school].[Students]([StudentId]),
	CONSTRAINT [FK_ClassSubjectGrade_ClassSubject] FOREIGN KEY ([ClassSubjectId])  REFERENCES [school].[ClassesSubjects]([ClassSubjectId])
);
GO


CREATE NONCLUSTERED INDEX [FK_ClassSubjectGrade_Student_2] ON [school].[ClassSubjectGrades] 
 (
  [StudentId] ASC
 )

GO

CREATE NONCLUSTERED INDEX [FK_ClassSubjectGrade_ClassSubject_2] ON [school].[ClassSubjectGrades] 
 (
  [ClassSubjectId] ASC
 )

GO
