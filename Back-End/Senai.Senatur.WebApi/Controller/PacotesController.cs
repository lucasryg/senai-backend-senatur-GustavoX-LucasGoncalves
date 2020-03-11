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

    public class PacotesController : ControllerBase
    {
        private IPacotesRepository _pacotesRepository;

        public PacotesController()
        {
            _pacotesRepository = new PacotesRepository();
        }

        /// <summary>
        /// Lista os pacotes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_pacotesRepository.Listar());
        }

        /// <summary>
        /// Seleciona um pacote por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(_pacotesRepository.BuscarPorId(id));
        }

        /// <summary>
        /// Criar um novo pacote 
        /// </summary>
        /// <param name="novoPacote"></param>
        /// <returns></returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Pacotes novoPacote)
        {
            _pacotesRepository.Cadastrar(novoPacote);

            return StatusCode(201);
        }

        /// <summary>
        /// Atualiza um pacote já existente
        /// </summary>
        /// <param name="id"></param>
        /// <param name="atualizarPacotes"></param>
        /// <returns></returns>
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, Pacotes atualizarPacotes)
        {
            _pacotesRepository.Atualizar(id, atualizarPacotes);

            return StatusCode(204);
        }

        [HttpPost("{cidades}")]
        public IActionResult GetByCidades(string cidade)
        {
            return Ok(_pacotesRepository.Cidades(cidade));
        }


    }
}
