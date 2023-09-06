using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System.Data.SqlClient;

namespace senai.inlock.webApi.Repository
{
    public class JogoRepository : IJogoRepository
    {
        private string StringConexao = "Data Source = NOTE18-S14; Initial Catalog = Filmes_Tarde; User Id = sa; Pwd = Senai@134";
        public void Cadastrar(JogoDomain novoJogo)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                // Declara a query que será executada.
                string queryInsert = $"SELECT Jogo.Nome AS Jogo,Estudio.Nome AS Estudio From Jogo INNER JOIN Estudio ON Jogo.IdEstudio = Estudio.IdEstudio;";

                // Declara o SqlCommand passando a query que será executada e a conexão com o BD.
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@IdJogo", novoJogo.IdJogo);
                    cmd.Parameters.AddWithValue("@Nome", novoJogo.Nome);

                    // Abre a conexão com o banco de dados.
                    con.Open();

                    // Executa a query.
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<JogoDomain> ListarTodos()
        {
            //Cria uma lista de gêneros para armazená-los
            List<JogoDomain> ListaJogos = new();

            //Declara a SqlConnection passando a String de Conexão como parâmetro
            using (SqlConnection con = new(StringConexao))
            {
                //Declara a instrução a ser executada
                string querySelectAll = "SELECT Estudio.Nome AS Estudio,Jogo.Nome AS Jogo FROM Estudio LEFT JOIN Jogo ON Estudio.IdEstudio = Jogo.IdEstudio;";

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

                    };


                    ListaJogos.Add(Jogo);
                };
            }

            //Retorna a lista de gêneros
            return ListaJogos;


        }
    }
}
    

