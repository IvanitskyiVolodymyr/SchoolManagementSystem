CREATE TABLE [school].[Teachers] (
    [TeacherId] INT IDENTITY NOT NULL,
    [UserId]    INT NOT NULL,
    [ClassId] INT NULL,
    CONSTRAINT [PK_Teacher] PRIMARY KEY CLUSTERED ([TeacherId] ASC),
    CONSTRAINT [FK_Teacher_User] FOREIGN KEY ([UserId]) REFERENCES [school].[Users] ([UserId]),
    CONSTRAINT [FK_Teacher_Class] FOREIGN KEY ([ClassId]) REFERENCES [school].[Classes]([ClassId])
);


GO
CREATE NONCLUSTERED INDEX [FK_Teacher_User_2]
    ON [school].[Teachers]([UserId] ASC);

GO
CREATE NONCLUSTERED INDEX [FK_Teacher_Class_2]
    ON [school].[Teachers]([ClassId] ASC);

