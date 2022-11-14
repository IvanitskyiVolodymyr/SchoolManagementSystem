CREATE TABLE [school].[Attendances] (
    [AttendanceId] INT NOT NULL,
    [ScheduleId]   INT NOT NULL,
    [StudentId]    INT NOT NULL,
    [Status]       BIT NOT NULL,
    CONSTRAINT [PK_Attendance] PRIMARY KEY CLUSTERED ([AttendanceId] ASC),
    CONSTRAINT [FK_Attendance_Schedule] FOREIGN KEY ([ScheduleId]) REFERENCES [school].[Schedules] ([ScheduleId]),
    CONSTRAINT [FK_Attendance_Student] FOREIGN KEY ([StudentId]) REFERENCES [school].[Students] ([StudentId])
);


GO
CREATE NONCLUSTERED INDEX [FK_Attendance_Student_2]
    ON [school].[Attendances]([StudentId] ASC);


GO
CREATE NONCLUSTERED INDEX [FK_Attendance_Schedule_2]
    ON [school].[Attendances]([ScheduleId] ASC);

