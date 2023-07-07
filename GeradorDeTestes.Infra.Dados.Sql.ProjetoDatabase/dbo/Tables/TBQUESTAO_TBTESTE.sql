CREATE TABLE [dbo].[TBQUESTAO_TBTESTE] (
    [Questao_Id] INT NOT NULL,
    [Teste_Id]   INT NOT NULL,
    CONSTRAINT [FK_TBQUESTAO_TBTESTE_TbQuestao] FOREIGN KEY ([Questao_Id]) REFERENCES [dbo].[TbQuestao] ([Id]),
    CONSTRAINT [FK_TBQUESTAO_TBTESTE_TbTeste] FOREIGN KEY ([Teste_Id]) REFERENCES [dbo].[TbTeste] ([Id])
);

