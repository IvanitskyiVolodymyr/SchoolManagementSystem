CREATE TABLE [school].[Users] (
    [UserId]       INT     IDENTITY       NOT NULL,
    [FirstName]    NVARCHAR (20)  NOT NULL,
    [RoleId]       INT            NULL,
    [MiddleName]   NVARCHAR (20)  NOT NULL,
    [LastName]     NVARCHAR (20)  NOT NULL,
    [Gender]       NVARCHAR (1)   NOT NULL,
    [PhoneNumber]  NVARCHAR (20)  NOT NULL,
    [Email]        NVARCHAR (50)  NOT NULL,
    [Address]      NVARCHAR (100) NOT NULL,
    [PasswordSalt] NVARCHAR (100) NOT NULL,
    [BirthDate]    DATE           NOT NULL,
    [JoinDate]     DATE           NOT NULL, 
    [AvatarUrl]    NVARCHAR (255) NULL,
    [PasswordHash] NVARCHAR(100) NOT NULL DEFAULT '', 
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([UserId] ASC),
    CONSTRAINT [FK_User_Role] FOREIGN KEY ([RoleId]) REFERENCES [school].[Roles] ([RoleId]),
    CONSTRAINT [UC_UserEmail] UNIQUE ([Email])
);


GO
CREATE NONCLUSTERED INDEX [FK_User_Role_2]
    ON [school].[Users]([RoleId] ASC);

GO

CREATE NONCLUSTERED INDEX [UC_User_Email]
    ON [school].[Users]([Email] ASC);

