CREATE TABLE [dbo].[TBMateria] (
    [Id]            INT           IDENTITY (1, 1) NOT NULL,
    [Nome]          VARCHAR (300) NOT NULL,
    [Disciplina_Id] INT           NOT NULL,
    [Serie]         INT           NOT NULL,
    CONSTRAINT [PK_TBMateria] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TBMateria_TBDisciplina] FOREIGN KEY ([Disciplina_Id]) REFERENCES [dbo].[TBDisciplina] ([Id])
);

