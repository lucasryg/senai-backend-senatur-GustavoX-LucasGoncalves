using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Senai.Senatur.WebApi.DataBaseFirst.Interfaces;
using Senai.Senatur.WebApi.DataBaseFirst.Repository;
using Senai.Senatur.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Senatur.WebApi.Controller
{
        [Produces("application/json")]

        // Define que a rota de uma requisição será no formato domínio/api/NomeController
        [Route("api/[controller]")]

        // Define que é um controlador de API
        [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository;

        public UsuariosController()
        {
            _usuarioRepository = new UsuariosRepository();
        }

        /// <summary>
        /// Uma lista com todos os usuários mostrando o título do tipo de usuário
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_usuarioRepository.listarComTipos());         
        }

        
    }
}
