CREATE TABLE [dbo].[TBDisciplina] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Nome] VARCHAR (300) NOT NULL,
    CONSTRAINT [PK_TBDisciplina] PRIMARY KEY CLUSTERED ([Id] ASC)
);

