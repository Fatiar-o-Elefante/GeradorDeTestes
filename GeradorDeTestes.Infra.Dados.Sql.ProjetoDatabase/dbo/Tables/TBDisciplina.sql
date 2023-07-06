CREATE TABLE [dbo].[TbDisciplina] (
    [Id]   INT          IDENTITY (1, 1) NOT NULL,
    [Nome] VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_TbDisciplina] PRIMARY KEY CLUSTERED ([Id] ASC)
);

