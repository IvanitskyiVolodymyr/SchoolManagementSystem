CREATE TABLE [school].[StudentsParents] (
    [StudentParentId] INT IDENTITY NOT NULL,
    [StudentId]       INT NOT NULL,
    [ParentId]        INT NOT NULL,
    CONSTRAINT [PK_3] PRIMARY KEY CLUSTERED ([StudentParentId] ASC),
    CONSTRAINT [FK_StudentParent_Parent] FOREIGN KEY ([ParentId]) REFERENCES [school].[Parents] ([ParentId]),
    CONSTRAINT [FK_StudentParent_Student] FOREIGN KEY ([StudentId]) REFERENCES [school].[Students] ([StudentId])
);


GO
CREATE NONCLUSTERED INDEX [FK_StudentParent_Parent_2]
    ON [school].[StudentsParents]([ParentId] ASC);


GO
CREATE NONCLUSTERED INDEX [FK_StudentParent_Student_2]
    ON [school].[StudentsParents]([StudentId] ASC);

