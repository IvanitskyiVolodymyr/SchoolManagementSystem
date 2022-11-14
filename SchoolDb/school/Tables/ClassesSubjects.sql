CREATE TABLE [school].[ClassesSubjects] (
    [ClassSubjectId] INT NOT NULL,
    [ClassId]        INT NOT NULL,
    [SubjectId]      INT NOT NULL,
    CONSTRAINT [PK_ClassSubject] PRIMARY KEY CLUSTERED ([ClassSubjectId] ASC),
    CONSTRAINT [FK_ClassSubject_Class] FOREIGN KEY ([ClassId]) REFERENCES [school].[Classes] ([ClassId]),
    CONSTRAINT [FK_ClassSubject_Subject] FOREIGN KEY ([SubjectId]) REFERENCES [school].[Subjects] ([SubjectId])
);


GO
CREATE NONCLUSTERED INDEX [FK_ClassSubject_Class_2]
    ON [school].[ClassesSubjects]([ClassId] ASC);


GO
CREATE NONCLUSTERED INDEX [FK_ClassSubject_Subject_2]
    ON [school].[ClassesSubjects]([SubjectId] ASC);

