CREATE TABLE [school].[Teachers] (
    [TeacherId] INT IDENTITY NOT NULL,
    [UserId]    INT NOT NULL,
    CONSTRAINT [PK_Teacher] PRIMARY KEY CLUSTERED ([TeacherId] ASC),
    CONSTRAINT [FK_Teacher_User] FOREIGN KEY ([UserId]) REFERENCES [school].[Users] ([UserId])
);


GO
CREATE NONCLUSTERED INDEX [FK_Teacher_User_2]
    ON [school].[Teachers]([UserId] ASC);

