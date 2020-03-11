
using Senai.Senatur.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.DataBaseFirst.Interfaces
{
    interface IUsuarioRepository
    {
        /// <summary>
        /// Lista um usuario com os tipos de usuarios
        /// </summary>
        /// <returns>Usuarios com tipos de usuario</returns>
        List<Usuarios> listarComTipos();

        /// <summary>
        /// Valida o usuario
        /// </summary>
        /// <param name="email"></param>
        /// <param name="senha"></param>
        /// <returns>Um usuáraio auteneticado</returns>
        Usuarios BuscarPorEmailSenha(string email, string senha);






    }
}
