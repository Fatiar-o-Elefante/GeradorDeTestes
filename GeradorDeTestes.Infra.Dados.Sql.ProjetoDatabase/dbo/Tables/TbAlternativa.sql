CREATE TABLE [dbo].[TbAlternativa] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [Letra]      VARCHAR (MAX) NOT NULL,
    [Questao_Id] INT           NOT NULL,
    [Resposta]   VARCHAR (MAX) NOT NULL,
    [Correta]    BIT           NOT NULL,
    CONSTRAINT [PK_TbAlternativa] PRIMARY KEY CLUSTERED ([Id] ASC)
);



