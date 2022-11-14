CREATE TABLE [school].[Classes] (
    [ClassId] INT IDENTITY NOT NULL,
    [Number]  INT          NOT NULL,
    [Letter]  NVARCHAR (2) NULL,
    CONSTRAINT [PK_Class] PRIMARY KEY CLUSTERED ([ClassId] ASC)
);

