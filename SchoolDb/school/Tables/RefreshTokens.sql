CREATE TABLE [school].[RefreshTokens] (
    [RehreshTokenId] INT IDENTITY NOT NULL,
    [Token]          NVARCHAR (60) NOT NULL,
    [UserId]         INT           NOT NULL,
    [Expires]        DATETIME      NOT NULL,
    CONSTRAINT [PK_RefreshToken] PRIMARY KEY CLUSTERED ([RehreshTokenId] ASC),
    CONSTRAINT [FK_RefreshToken_User] FOREIGN KEY ([UserId]) REFERENCES [school].[Users] ([UserId])
);


GO
CREATE NONCLUSTERED INDEX [FK_RefreshToken_User_2]
    ON [school].[RefreshTokens]([UserId] ASC);

