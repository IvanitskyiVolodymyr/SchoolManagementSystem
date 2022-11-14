CREATE TABLE [school].[Schedules] (
    [ScheduleId]                INT IDENTITY NOT NULL,
    [StartTime]                 DATETIME       NOT NULL,
    [ClassSubjectId]            INT            NOT NULL,
    [EndTime]                   DATETIME       NOT NULL,
    [Place]                     NVARCHAR (200) NOT NULL,
    [TeacherMethodicalPlanning] NVARCHAR (255) NOT NULL,
    CONSTRAINT [PK_Schedule] PRIMARY KEY CLUSTERED ([ScheduleId] ASC),
    CONSTRAINT [FK_Schedule_ClassSubject] FOREIGN KEY ([ClassSubjectId]) REFERENCES [school].[ClassesSubjects] ([ClassSubjectId])
);


GO
CREATE NONCLUSTERED INDEX [FK_Shedule_ClassSubject_2]
    ON [school].[Schedules]([ClassSubjectId] ASC);

