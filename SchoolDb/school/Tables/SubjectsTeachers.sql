CREATE TABLE [school].[SubjectsTeachers] (
    [SubjectTeacherId] INT IDENTITY NOT NULL,
    [SubjectId]        INT NOT NULL,
    [TeacherId]        INT NOT NULL,
    CONSTRAINT [PK_SubjectTeacher] PRIMARY KEY CLUSTERED ([SubjectTeacherId] ASC),
    CONSTRAINT [FK_SubjectTeacher_Subject] FOREIGN KEY ([SubjectId]) REFERENCES [school].[Subjects] ([SubjectId]),
    CONSTRAINT [FK_SubjectTeacher_Teacher] FOREIGN KEY ([TeacherId]) REFERENCES [school].[Teachers] ([TeacherId])
);


GO
CREATE NONCLUSTERED INDEX [FK_SubjectTeacher_Subject_2]
    ON [school].[SubjectsTeachers]([SubjectId] ASC);


GO
CREATE NONCLUSTERED INDEX [FK_SubjectTeacher_Teacher_2]
    ON [school].[SubjectsTeachers]([TeacherId] ASC);

