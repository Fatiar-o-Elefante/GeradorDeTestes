using GeradorDeTestes.Dominio.ModuloQuestoes;
using GeradorDeTestes.Dominio.ModuloTestes;
using GeradorDeTestes.Infra.Dados.Sql.Compartilhado;
using GeradorDeTestes.Infra.Dados.Sql.ModuloQuestoes;
using Microsoft.Data.SqlClient;

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


        private const string sqlAdicionarQuestao =
            @"INSERT INTO [TBQUESTAO_TBTESTE]
                (
                    [Questao_Id]
                   ,[Teste_Id])
            VALUES
                (
                    @Questao_Id
                   ,@Teste_Id
                )";

        //private const string sqlCarregarQuestoes =
        //    @"SELECT 
        //        Q.ID            QUESTAO_ID, 
        //        Q.MATERIA_ID    QUESTAO_MATERIA_ID, 
        //        Q.ENUNCIADO     QUESTAO_ENUNCIADO,
        //        Q.RESPOSTA      QUESTAO_RESPOSTA,
                
        //        M.ID             MATERIA_ID,
        //        M.NOME           MATERIA_NOME,
        //        M.DISCIPLINA_ID  DISCIPLINA_ID,
        //        M.SERIE          MATERIA_SERIE,

        //        D.ID             DISCIPLINA_ID,
        //        D.NOME           DISCIPLINA_NOME
        //    FROM 
        //        [TBQUESTOES] Q

        //        INNER JOIN TBMATERIA M

        //            ON Q.MATERIA_ID = M.ID

        //        INNER JOIN TBDISCIPLINA D

        //            ON M.DISCIPLINA_ID = D.ID
        //    WHERE 

        //        Q.MATERIA_ID = @MATERIA_ID AND M.DISCIPLINA_ID = @DISCIPLINA_ID";

        private const string sqlRemoverQuestoes =
            @"DELETE FROM TBQUESTAO_TBTESTE
                WHERE TESTE_ID = @TESTE_ID AND QUESTAO_ID = @QUESTAO_ID";

        private const string sqlCarregasQuestoesTeste = @"SELECT 
                Q.ID                QUESTAO_ID, 
                Q.MATERIA_ID        QUESTAO_MATERIA_ID, 
                Q.ENUNCIADO         QUESTAO_ENUNCIADO,
                Q.RESPOSTA          QUESTAO_RESPOSTA,

                TBT.TESTE_ID        TESTE_ID,
                
                M.ID                MATERIA_ID,
                M.NOME              MATERIA_NOME,
                M.DISCIPLINA_ID     DISCIPLINA_ID,
                M.SERIE             MATERIA_SERIE,

                D.ID             DISCIPLINA_ID,
                D.NOME           DISCIPLINA_NOME
                
            FROM 
                [TBQUESTAO] Q

                INNER JOIN TBQUESTAO_TBTESTE TBT
                    ON Q.ID = TBT.QUESTAO_ID

                INNER JOIN TBMATERIA M
                    ON Q.MATERIA_ID = M.ID
    
                INNER JOIN TBDISCIPLINA D
                    ON M.DISCIPLINA_ID = D.ID

            WHERE 

                TBT.TESTE_ID = @TESTE_ID";


        public void Inserir(Teste novoRegistro, List<Questao> questoesAdicionadas)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            SqlCommand comandoInserir = conexaoComBanco.CreateCommand();
            comandoInserir.CommandText = sqlInserir;

            MapeadorTeste mapeador = new MapeadorTeste();

            mapeador.ConfigurarParametros(comandoInserir, novoRegistro);

            object id = comandoInserir.ExecuteScalar();

            novoRegistro.id = Convert.ToInt32(id);

            conexaoComBanco.Close();

            foreach (Questao questao in questoesAdicionadas)
            {
                AdicionarQuestao(questao, novoRegistro);
            }
        }

        public void Excluir(Teste registroSelecionado)
        {
            foreach (Questao QuestaoParaRemover in registroSelecionado.ListQuestoes)
            {
                RemoverQuestao(QuestaoParaRemover, registroSelecionado);
            }

            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            SqlCommand comandoExcluir = conexaoComBanco.CreateCommand();
            comandoExcluir.CommandText = sqlExcluir;

            comandoExcluir.Parameters.AddWithValue("ID", registroSelecionado.id);

            comandoExcluir.ExecuteNonQuery();

            conexaoComBanco.Close();
        }

        private void AdicionarQuestao(Questao questao, Teste teste)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            SqlCommand comandoInserir = conexaoComBanco.CreateCommand();
            comandoInserir.CommandText = sqlAdicionarQuestao;

            comandoInserir.Parameters.AddWithValue("QUESTAO_ID", questao.id);
            comandoInserir.Parameters.AddWithValue("TESTE_ID", teste.id);

            comandoInserir.ExecuteNonQuery();

            conexaoComBanco.Close();
        }

        public void CarregarQuestoes(Teste teste)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            SqlCommand comandoSelecionarItens = conexaoComBanco.CreateCommand();
            comandoSelecionarItens.CommandText = sqlCarregasQuestoesTeste;

            comandoSelecionarItens.Parameters.AddWithValue("TESTE_ID", teste.id);
            comandoSelecionarItens.Parameters.AddWithValue("MATERIA_ID", teste.Materia.id);
            comandoSelecionarItens.Parameters.AddWithValue("DISCIPLINA_ID", teste.Disciplina.id);

            SqlDataReader leitorQuestao = comandoSelecionarItens.ExecuteReader();

            while (leitorQuestao.Read())
            {
                MapeadorQuestao mapeador = new MapeadorQuestao();

                Questao questao = mapeador.ConverterRegistro(leitorQuestao);

                teste.AdicionarQuestao(questao);
            }

            conexaoComBanco.Close();
        }

        private void RemoverQuestao(Questao questao, Teste teste)
        {
            SqlConnection conexaoComBanco = new SqlConnection(enderecoBanco);
            conexaoComBanco.Open();

            SqlCommand comandoInserir = conexaoComBanco.CreateCommand();
            comandoInserir.CommandText = sqlRemoverQuestoes;

            comandoInserir.Parameters.AddWithValue("TESTE_ID", teste.id);
            comandoInserir.Parameters.AddWithValue("QUESTAO_ID", questao.id);

            comandoInserir.ExecuteNonQuery();

            conexaoComBanco.Close();
        }

        public Teste SelecionarPorId(int id)
        {
            Teste teste = base.SelecionarPorId(id);

            if (teste != null)
                CarregarQuestoes(teste);

            return teste;
        }

        public List<Teste> SelecionarTodos()
        {
            List<Teste> testes = base.SelecionarTodos();

            return testes;
        }
    }
}
