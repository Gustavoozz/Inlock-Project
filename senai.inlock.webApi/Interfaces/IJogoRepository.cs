using senai.inlock.webApi.Domains;

namespace senai.inlock.webApi.Interfaces
{
    public interface IJogoRepository
    {
        /// <summary>
        /// Método responsável por cadastrar um novo estúdio.
        /// </summary>
        /// <param name="novoEstudio"></param>
        void Cadastrar(JogoDomain novoJogo);

        /// <summary>
        /// Método responsável por listar os estudio existentes.
        /// </summary>
        /// <returns></returns>
        List<JogoDomain> ListarTodos();
    }
}
