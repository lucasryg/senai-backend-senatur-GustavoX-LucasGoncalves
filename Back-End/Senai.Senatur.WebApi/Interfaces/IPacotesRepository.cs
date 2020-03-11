using Senai.Senatur.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.DataBaseFirst.Interfaces
{
    interface IPacotesRepository
    {
        /// <summary>
        /// Lista a lista de pacotes
        /// </summary>
        /// <returns>lista de pacotes</returns>
        List<Pacotes> Listar();

        /// <summary>
        /// Busca um pacote pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>o pacote buscado</returns>
        Pacotes BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo pacote
        /// </summary>
        /// <param name="pacotes"></param>
        void Cadastrar(Pacotes pacotes);

        /// <summary>
        /// Atualiza um pacote
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pacoteAtualizado"></param>
        void Atualizar(int id, Pacotes pacoteAtualizado);

        /// <summary>
        /// Lista apenas os pacotes ativos
        /// </summary>
        /// <returns></returns>
        List<Pacotes> PacotesAtivos();

        /// <summary>
        /// Lista apenas os pacotes inativos
        /// </summary>
        /// <returns></returns>
        List<Pacotes> PacotesInativos();

        /// <summary>
        /// Lista os pacotes por cidade 
        /// </summary>
        /// <returns></returns>
        Pacotes Cidades(string cidade);

        /// <summary>
        /// Lista os pacotes por preço
        /// </summary>
        /// <returns></returns>
        List<Pacotes> PorPreco(int preco);
    }
}
