CREATE TABLE [dbo].[TbMateria] (
    [Id]            INT          IDENTITY (1, 1) NOT NULL,
    [Nome]          VARCHAR (50) NOT NULL,
    [Disciplina_Id] INT          NOT NULL,
    [Serie]         INT          NOT NULL,
    CONSTRAINT [PK_TbMateria] PRIMARY KEY CLUSTERED ([Id] ASC)
);

