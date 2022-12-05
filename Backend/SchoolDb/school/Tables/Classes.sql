CREATE TABLE [school].[Classes] (
    [ClassId] INT IDENTITY NOT NULL,
    [Number]  INT          NOT NULL,
    [Letter]  NVARCHAR (2) NULL,
    [StartOfTheAcademicYear] DATE NOT NULL DEFAULT CAST('2022-09-01' AS DATE),  
    [EndOfTheAcademicYear] DATE NOT NULL DEFAULT CAST('2023-05-31' AS DATE), 
    CONSTRAINT [PK_Class] PRIMARY KEY CLUSTERED ([ClassId] ASC)
);

