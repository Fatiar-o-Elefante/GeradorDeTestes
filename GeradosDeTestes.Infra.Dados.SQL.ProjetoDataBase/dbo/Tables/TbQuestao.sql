CREATE TABLE [dbo].[TbQuestao] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [Materia_Id] INT           NOT NULL,
    [Enunciado]  VARCHAR (100) NOT NULL,
    CONSTRAINT [PK_TbQuestao] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TbQuestao_TbMateria] FOREIGN KEY ([Materia_Id]) REFERENCES [dbo].[TbMateria] ([Id])
);

