﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.Senatur.WebApi.DataBaseFirst.Interfaces;
using Senai.Senatur.WebApi.DataBaseFirst.Repository;
using Senai.Senatur.WebApi.DataBaseFirst.ViewModel;
using Senai.Senatur.WebApi.Domains;

namespace Senai.Senatur.WebApi.Controller
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]
    public class LoginController : ControllerBase
    {

        private IUsuarioRepository _usuarioRepository;

        /// <summary>
        /// Instancia este objeto para que haja a referência aos métodos no repositório
        /// </summary>
        public LoginController()
        {
            _usuarioRepository = new UsuariosRepository();
        }

        /// <summary>
        /// Logar um usuario
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost]  
        public IActionResult Post(LoginViewModel login)
        {

            Usuarios usuarioBuscado = _usuarioRepository.BuscarPorEmailSenha(login.Email, login.Senha);

           
            if (usuarioBuscado == null)
            {
                
                return NotFound("E-mail ou senha inválidos");
            }

          
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoUsuario.ToString())
            };

            
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Senatur-chave-autenticacao"));
            
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

           
            var token = new JwtSecurityToken(
                issuer: "Senatur.WebApi",                
                audience: "Senatur.WebApi",              
                claims: claims,                         
                expires: DateTime.Now.AddMinutes(30),    
                signingCredentials: creds                
            );

            
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
    }
}
