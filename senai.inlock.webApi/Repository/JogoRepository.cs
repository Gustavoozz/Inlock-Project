using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System.Data.SqlClient;

namespace senai.inlock.webApi.Repository
{
    public class JogoRepository : IJogoRepository
    {
        private string StringConexao = "Data Source = NOTE18-S14; Initial Catalog = inlock_games_tarde; User Id = sa; Pwd = Senai@134";

        /// <summary>
        /// Método responsável por cadastrar novos jogos.
        /// </summary>
        /// <param name="novoJogo"></param>
        public void Cadastrar(JogoDomain novoJogo)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // Declara a query que será executada.
                string queryInsert = $"INSERT INTO Jogo VALUES(@IdEstudio, @Nome, @Descricao, @DataLancamento, @Valor)";

                // Declara o SqlCommand passando a query que será executada e a conexão com o BD.
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@IdEstudio", novoJogo.IdEstudio);

                    cmd.Parameters.AddWithValue("@Nome", novoJogo.Nome);

                    cmd.Parameters.AddWithValue("@Descricao", novoJogo.Descricao);

                    cmd.Parameters.AddWithValue("@DataLancamento", novoJogo.DataLancamento);

                    cmd.Parameters.AddWithValue("@Valor", novoJogo.Valor);

                    // Abre a conexão com o banco de dados.
                    con.Open();

                    // Executa a query.
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Método responsável por listar os jogos cadastrados.
        /// </summary>
        /// <returns></returns>
        public List<JogoDomain> ListarTodos()
        {
            //Cria uma lista de gêneros para armazená-los
            List<JogoDomain> ListaJogos = new();

            //Declara a SqlConnection passando a String de Conexão como parâmetro
            using (SqlConnection con = new(StringConexao))
            {
                //Declara a instrução a ser executada
                string querySelectAll = "SELECT Jogo.IdJogo,Estudio.Nome AS Estudio,Jogo.Nome,Jogo.Descricao,Jogo.DataLancamento,Jogo.Valor FROM Jogo JOIN Estudio ON Jogo.IdEstudio = Estudio.IdEstudio";

                //Abre a conexão com o banco de dados
                con.Open();

                //Declara o SqlDataReader para percorrer (ler) a tabela no banco de dados
                SqlDataReader rdr;

                //Declara o SqlCommand passando a query que será executada e a conexão
                using SqlCommand cmd = new(querySelectAll, con);
                //Executa a query e armazena os dados no rdr
                rdr = cmd.ExecuteReader();

                //Enquanto houver registros para serem lidos no rdr, o laço se repetirá.
                while (rdr.Read())
                {
                    JogoDomain Jogo = new()
                    {
                        //Atribui à propriedade IdFilme os valores das colunas
                        IdJogo = Convert.ToInt32(rdr["IdJogo"]),

                        Nome = rdr["Nome"].ToString(),

                        Descricao = rdr["Descricao"].ToString(),

                        DataLancamento = Convert.ToDateTime(rdr["DataLancamento"]),

                        Valor = Convert.ToByte(rdr["Valor"]),
                        
                        Estudio = new EstudioDomain()
                        {
                            Nome = rdr["Estudio"].ToString()
                        }


                    };


                    ListaJogos.Add(Jogo);
                };
            }

            //Retorna a lista de gêneros
            return ListaJogos;


        }
    }
}
    

