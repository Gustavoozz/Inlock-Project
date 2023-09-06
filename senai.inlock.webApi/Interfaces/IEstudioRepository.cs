using senai.inlock.webApi.Domains;

namespace senai.inlock.webApi.Interfaces
{
    public interface IEstudioRepository
    {
        /// <summary>
        /// Método responsável por cadastrar um novo estúdio.
        /// </summary>
        /// <param name="novoEstudio"></param>
        void Cadastrar(EstudioDomain novoEstudio);

        /// <summary>
        /// Método responsável por listar os estudio existentes.
        /// </summary>
        /// <returns></returns>
        List<EstudioDomain> ListarTodos();
    }
}
