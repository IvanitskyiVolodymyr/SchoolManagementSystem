CREATE TABLE [school].[Users] (
    [UserId]       INT            NOT NULL,
    [FirstName]    NVARCHAR (20)  NOT NULL,
    [RoleId]       INT            NOT NULL,
    [MiddleName]   NVARCHAR (20)  NOT NULL,
    [LastName]     NVARCHAR (20)  NOT NULL,
    [Gender]       NVARCHAR (1)   NOT NULL,
    [PhoneNumber]  NVARCHAR (20)  NOT NULL,
    [Email]        NVARCHAR (20)  NOT NULL,
    [Address]      NVARCHAR (100) NOT NULL,
    [PasswordSalt] NVARCHAR (100) NOT NULL,
    [BirthDate]    DATE           NOT NULL,
    [JoinDate]     DATE           NOT NULL,
    [AvatarUrl]    NVARCHAR (255) NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([UserId] ASC),
    CONSTRAINT [FK_User_Role] FOREIGN KEY ([RoleId]) REFERENCES [school].[Roles] ([RoleId])
);


GO
CREATE NONCLUSTERED INDEX [FK_User_Role_2]
    ON [school].[Users]([RoleId] ASC);

