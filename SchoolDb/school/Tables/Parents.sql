CREATE TABLE [school].[Parents] (
    [ParentId] INT NOT NULL,
    [UserId]   INT NOT NULL,
    CONSTRAINT [PK_Parent] PRIMARY KEY CLUSTERED ([ParentId] ASC),
    CONSTRAINT [FK_Parent_User] FOREIGN KEY ([UserId]) REFERENCES [school].[Users] ([UserId])
);


GO
CREATE NONCLUSTERED INDEX [FK_Parent_User_2]
    ON [school].[Parents]([UserId] ASC);

