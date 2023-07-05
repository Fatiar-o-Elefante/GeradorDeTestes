CREATE TABLE [dbo].[TbTeste] (
    [Id]                 INT          IDENTITY (1, 1) NOT NULL,
    [Titulo]             VARCHAR (50) NOT NULL,
    [Disciplina_Id]      INT          NOT NULL,
    [Materia_Id]         INT          NOT NULL,
    [QuantidadeQuestoes] INT          NOT NULL,
    CONSTRAINT [PK_TbTeste] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TbTeste_TbDisciplina] FOREIGN KEY ([Disciplina_Id]) REFERENCES [dbo].[TbDisciplina] ([Id]),
    CONSTRAINT [FK_TbTeste_TbMateria] FOREIGN KEY ([Materia_Id]) REFERENCES [dbo].[TbMateria] ([Id])
);

