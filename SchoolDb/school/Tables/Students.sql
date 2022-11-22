CREATE TABLE [school].[Students] (
    [StudentId]   INT IDENTITY NOT NULL,
    [UserId]      INT NOT NULL,
    [ClassId]     INT NULL,
    [StudentCode] INT NULL,
    CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED ([StudentId] ASC),
    CONSTRAINT [FK_Student_Class] FOREIGN KEY ([ClassId]) REFERENCES [school].[Classes] ([ClassId]),
    CONSTRAINT [FK_Student_User] FOREIGN KEY ([UserId]) REFERENCES [school].[Users] ([UserId])
);


GO
CREATE NONCLUSTERED INDEX [FK_Student_User_2]
    ON [school].[Students]([UserId] ASC);


GO
CREATE NONCLUSTERED INDEX [FK_Student_Class_2]
    ON [school].[Students]([ClassId] ASC);

