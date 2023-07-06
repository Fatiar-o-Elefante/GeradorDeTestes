using GeradorDeTestes.Dominio.ModuloTestes;
using GeradorDeTestes.Infra.Dados.Sql.Compartilhado;

namespace GeradorDeTestes.Infra.Dados.Sql.ModuloTestes
{
    public class RepositorioTesteEmSql : RepositorioEmSqlBase<Teste, MapeadorTeste>, IRepositorioTeste
    {
        protected override string sqlInserir => @"INSERT INTO[DBO].[TBTESTE]
                                                    (
                                                        [TITULO]
                                                       ,[DISCIPLINA_ID]
                                                       ,[MATERIA_ID]
                                                       ,[QUANTIDADEQUESTOES]
                                                       ,[PROVARECUPERACAO]
                                                    )
                                                 VALUES
                                                    (
                                                        @TITULO
                                                       ,@DISCIPLINA_ID
                                                       ,@MATERIA_ID
                                                       ,@QUANTIDADEQUESTOES
                                                       ,@PROVARECUPERACAO
                                                    );
                                                 SELECT SCOPE_IDENTITY();";

        protected override string sqlEditar => @"UPDATE[TBTESTE]
                                               SET
                                                   [TITULO] = @TITULO
                                                   ,[DISCIPLINA_ID] = @DISCIPLINA_ID
                                                   ,[MATERIA_ID] = @MATERIA_ID
                                                   ,[QUANTIDADEQUESTOES] = @QUANTIDADEQUESTOES
                                                   ,[PROVARECUPERACAO] = @PROVARECUPERACAO
                                             WHERE [ID] = @ID;";

        protected override string sqlExcluir => @"DELETE FROM [TBTESTE]
	                                                WHERE 
		                                                [ID] = @ID";

        protected override string sqlSelecionarTodos => @"SELECT 
	                                                        T.[ID]                  TESTE_ID 
                                                           ,T.[TITULO]              TESTE_TITULO
	                                                       ,T.[DISCIPLINA_ID]       TESTE_DISCIPLINA_ID
	                                                       ,T.[MATERIA_ID]          TESTE_MATERIA_ID
                                                           ,T.[QUANTIDADEQUESTOES]  TESTE_QUANTIDADEQUESTOES
                                                           ,T.[PROVARECUPERACAO]    TESTE_PROVARECUPERACAO
                                                           ,M.[ID]                  MATERIA_ID
                                                           ,M.[NOME]                MATERIA_NOME
                                                           ,M.[SERIE]               MATERIA_SERIE
                                                           ,M.[DISCIPLINA_ID]       DISCIPLINA_ID
                                                           ,D.[ID]                  DISCIPLINA_ID
                                                           ,D.[NOME]                DISCIPLINA_NOME

                                                        FROM 
	                                                        [TBTESTE] AS T
                                                        INNER JOIN [TBMATERIA] AS M
                                                                ON T.[MATERIA_ID] = M.ID
                                                        INNER JOIN [TBDISCIPLINA] AS D
                                                                ON M.[DISCIPLINA_ID] = D.ID";

        protected override string sqlSelecionarPorId => @"SELECT 
	                                                        T.[ID]                  TESTE_ID 
                                                           ,T.[TITULO]              TESTE_TITULO
	                                                       ,T.[DISCIPLINA_ID]       TESTE_DISCIPLINA_ID
	                                                       ,T.[MATERIA_ID]          TESTE_MATERIA_ID
                                                           ,T.[QUANTIDADEQUESTOES]  TESTE_QUANTIDADEQUESTOES
                                                           ,T.[PROVARECUPERACAO]    TESTE_PROVARECUPERACAO
                                                           ,M.[ID]                  MATERIA_ID
                                                           ,M.[NOME]                MATERIA_NOME
                                                           ,M.[SERIE]               MATERIA_SERIE
                                                           ,M.[DISCIPLINA_ID]       DISCIPLINA_ID
                                                           ,D.[ID]                  DISCIPLINA_ID
                                                           ,D.[NOME]                DISCIPLINA_NOME
                                                    FROM 
	                                                        [TBTESTE] AS T
                                                        INNER JOIN [TBMATERIA] AS M
                                                                ON T.[MATERIA_ID] = M.ID
                                                        INNER JOIN [TBDISCIPLINA] AS D
                                                                ON M.[DISCIPLINA_ID] = D.ID
                                                    WHERE 
                                                        T.[ID] = @ID";

        public Teste SelecionarPorId(int id)
        {
            Teste teste = base.SelecionarPorId(id);

            return teste;
        }

        public List<Teste> SelecionarTodos()
        {
            List<Teste> testes = base.SelecionarTodos();

            return testes;
        }
    }
}
